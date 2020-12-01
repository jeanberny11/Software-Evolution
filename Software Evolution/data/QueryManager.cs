using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Evolution.data
{
    public sealed class QueryManager
    {
        private readonly static QueryManager _instance = new QueryManager();
        NpgsqlConnection connection ;
        NpgsqlTransaction tran;
        private bool work;
        private bool isOpen;       

        private QueryManager()
        {

        }

        public static QueryManager Instance
        {
            get
            {
                return _instance;
            }
        }

        public void Open()
        {
            try
            {
                if(!work && !isOpen)
                {
                    connection = ConexionManager.Instance.GetConnection(AppData.Instance.Currentuser.Username, AppData.Instance.Currentuser.Password);
                    connection.Open();
                    isOpen = true;
                }
            }catch(NpgsqlException ex)
            {
                throw ex;
            }
        }

        public void Close()
        {
            try
            {
                if(!work && connection!=null && isOpen)
                {
                    connection.Close();
                    isOpen = false;
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
        }

        public void BeginWork()
        {
            if(work)
            {
                throw new Exception("Ya existe transaccion iniciada");
            }
            try
            {
                Open();
                work = true;
                tran = connection.BeginTransaction();
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
        }

        public void RollBack()
        {
            if (!work)
            {
                throw new Exception("No hay una transaccion iniciada");
            }
            try
            {
                work = false;
                tran.Rollback();
                Close();
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
        }

        public void CommitWork()
        {
            if (!work)
            {
                throw new Exception("No hay una transaccion iniciada");
            }
            try
            {
                work = false;
                tran.Commit();
                Close();
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
        }

        public DataTable Query(String sql)
        {
            try
            {
                Open();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, connection);
                NpgsqlCommandBuilder comando = new NpgsqlCommandBuilder(da);
                var tabla = new DataTable();
                da.Fill(tabla);
                Close();                
                return tabla;
            }catch(NpgsqlException ex)
            {
                throw ex;
            }
        }

        public DataSet QueryLive(string sql)
        {
            try
            {
                Open();
                var dataadapter = new NpgsqlDataAdapter(sql, connection);
                var result = new DataSet();
                dataadapter.FillSchema(result, SchemaType.Source);
                dataadapter.Fill(result);
                Close();
                return result;
            }catch(NpgsqlException ex)
            {
                throw ex;
            }
        }

        public int SaveFromDataset(string tablename,DataSet dataSet)
        {
            try
            {
                Open();
                var dataadapter = new NpgsqlDataAdapter($"select * from {tablename}", connection);
                var cmb = new NpgsqlCommandBuilder(dataadapter);
                var result = dataadapter.Update(dataSet);
                dataadapter.Dispose();
                cmb.Dispose();
                Close();
                return result;
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
        }

        public int Execute(String sql)
        {
            try
            {
                Open();
                var cmd = new NpgsqlCommand(sql,connection);
                var result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                Close();
                return result;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public DataTable QueryProcedure(String procedurename,String param)
        {
            var cursorname = procedurename.Substring(1);
            var p = param ?? "";
            var parameters = $"'{cursorname}'" + ((!p.Equals("")) ? $",{param}" : "");
            try
            {
                BeginWork();
                NpgsqlCommand cmd = new NpgsqlCommand($"select {procedurename}({parameters})",connection);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.CommandText= $"fetch all in \"{cursorname}\"";
                cmd.CommandType = CommandType.Text;
                var dr = cmd.ExecuteReader();
                DataTable result = new DataTable();
                result.Load(dr);
                CommitWork();
                return result;
            }
            catch (NpgsqlException ex)
            {
                RollBack();
                throw ex;
            }
        }

        public int GetSecuencia(string tipodoc)
        {
            try
            {
                var sql = $"select get_secuencia('{tipodoc}')";
                var res = Query(sql);
                var secuencia = res.Rows[0].Field<int>("get_secuencia");
                return secuencia;
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
        }

        public string GetSecuenciaNcf(int tipo,DateTime fecha)
        {
            var res = Query($"select * from t_ncf where f_codigo={tipo} for update");
            var secuencia = res.Rows[0].Field<int>("f_secuencia") + 1;
            var res2 = Query($"select f_fecha_vencimiento from t_solicitud_ncf where f_tipo_ncf={tipo} and {secuencia}>=f_secuencia_inicial and {secuencia}<=f_secuencia_final");
            if(res2.Rows.Count==0 && res.Rows[0].Field<int>("f_codigo") != 1)
            {
                throw new Exception("Se a Agotado la Disponibilidad de Este Tipo de Comprobante...");
            }
            if(res2.Rows[0].Field<DateTime>("f_fecha_vencimiento")<fecha && res.Rows[0].Field<int>("f_codigo") != 1)
            {
                throw new Exception("Este NCF Está Vencido...");
            }
            var ncf = ToWholeNumNcf(res.Rows[0].Field<string>("f_tipo"), secuencia);
            Execute($"update t_ncf set f_secuencia=f_secuencia+1,f_secuencia_solicitada=f_secuencia_solicitada-1 where f_codigo={tipo}");
            return ncf;
        }

        public string ToWholeNumNcf(string tipo,int secuencia)
        {
            var res = Query($"select towholenum_2('{tipo}',{secuencia}) as whole");
            return res.Rows[0].Field<string>("whole");
        }

        public string GetTipoDoc(int tipo)
        {
            try
            {
                var sql = $"select f_tipodoc from t_tiposdocumentos where f_indiceordenador ={tipo}";
                var res = Query(sql);
                var tipodoc = res.Rows[0].Field<string>("f_tipodoc");
                return tipodoc;
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
        }

        public string ToWholeNum(string tipodoc,int secuencia)
        {
            var pad = 12 - tipodoc.Length;
            var sec = secuencia.ToString().PadLeft(pad, '0');
            return tipodoc + sec;
        }

        public int CreateRecord(String tabla,Dictionary<String,object> record)
        {
            String columns = "";
            String values = "";
            foreach (KeyValuePair<string, object> entry in record)
            {
                columns += $",{entry.Key}";
                if(entry.Value is string)
                {
                    values += $",'{entry.Value}'";
                }
                else if (entry.Value is int)
                {
                    values += $",{Convert.ToInt32(entry.Value)}";
                }
                else if (entry.Value is double)
                {
                    values += $",{Convert.ToDouble(entry.Value)}";
                }
                else if (entry.Value is bool)
                {
                    values += $",{entry.Value}";
                }
                else if (entry.Value is DateTime val)
                {
                    values += $",'{val.ToString("yyyyMMdd")}'";
                }
                else
                {
                    values += $",'{entry.Value}'";
                }
            }

            try
            {
                var sql = $"insert into {tabla} ({columns.Substring(1)}) values ({values.Substring(1)})";
                Console.WriteLine(sql);
                Open();
                var cmd = new NpgsqlCommand(sql, connection);
                var result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                Close();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateRecord(string tabla, Dictionary<String, object> record,string whereclause)
        {
            try
            {
                Open();
                var adapter = new NpgsqlDataAdapter($"Select * From {tabla} {whereclause}", connection);
                var dataset = new DataSet("dataset" + tabla);
                adapter.FillSchema(dataset, SchemaType.Source, tabla);
                adapter.Fill(dataset, tabla);
                var datatable = dataset.Tables[tabla];
                var row = datatable.Rows.Count > 0 ? datatable.Rows[0] : datatable.NewRow();
                row.BeginEdit();
                foreach (KeyValuePair<string, object> entry in record)
                {
                    row[entry.Key] = entry.Value;
                }
                row.EndEdit();                
                var command = new NpgsqlCommandBuilder(adapter);
                int result = adapter.Update(dataset, tabla);
                Close();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public void SaveRecord(String tabla, Dictionary<String, object> record)
        {
            try
            {
                Open();
                var adapter = new NpgsqlDataAdapter($"Select * From {tabla} limit 0", connection);
                var dataset = new DataSet("dataset" + tabla);
                adapter.FillSchema(dataset, SchemaType.Source, tabla);
                adapter.Fill(dataset, tabla);
                var datatable = dataset.Tables[tabla];
                var row = datatable.NewRow();
                foreach (KeyValuePair<string, object> entry in record)
                {
                    row[entry.Key] = entry.Value;
                }
                datatable.Rows.Add(row);
                var command = new NpgsqlCommandBuilder(adapter);
                adapter.Update(dataset, tabla);
                Close();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public void SaveRecord(String tabla, DataRow data)
        {
            try
            {
                Open();
                var adapter = new NpgsqlDataAdapter($"Select * From {tabla} limit 0", connection);
                var dataset = new DataSet("dataset" + tabla);
                adapter.FillSchema(dataset, SchemaType.Source, tabla);
                adapter.Fill(dataset, tabla);
                var datatable = dataset.Tables[tabla];
                var row = datatable.NewRow();
                foreach (DataColumn column in row.Table.Columns)
                {
                    row[column.ColumnName] = data[column.ColumnName];
                }
                datatable.Rows.Add(row);
                var command = new NpgsqlCommandBuilder(adapter);
                adapter.Update(dataset, tabla);
                Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DateTime CurrentDate()
        {
            var res = Query("select current_date as date");
            return res.Rows[0].Field<DateTime>("date");
        }
        public string CurrentTime()
        {
            var res = Query("select to_char(current_timestamp, 'HH24:MI:SS') as time");
            return res.Rows[0].Field<string>("time");
        }
    }
}
