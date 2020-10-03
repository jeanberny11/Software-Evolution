using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Evolution.repositorios
{
    public class SecuenciaRepository:Repository
    {
        public DataSet GetSecuenciasLive()
        {
            return manager.QueryLive("select * from t_secuencias ");
        }

        public int SaveSecuencias(DataSet data)
        {
            return manager.SaveFromDataset("t_secuencias", data);
        }

        public DataTable GetSecuencias()
        {
            return manager.Query("select * from t_secuencias order by f_tipo_documento");
        }

        public int CreateOrUpdateSecuencia(DataRow row)
        {
            try
            {
                var result = manager.Query($"select * from t_secuencias where f_tipo_documento='{row.Field<string>("f_tipo_documento")}'");
                if (result.Rows.Count > 0)
                {
                    return manager.Execute($"update t_secuencias set f_tipo_documento='{row.Field<string>("f_tipo_documento")}',f_secuencia={row.Field<int>("f_secuencia")}," +
                        $"f_descripcion='{row.Field<string>("f_descripcion")}',f_secuencia_manual={row.Field<bool>("f_secuencia_manual")} where f_tipo_documento='{row.Field<string>("f_tipo_documento")}'");
                }
                else
                {
                    return manager.Execute($"insert into t_secuencias (f_tipo_documento,f_secuencia,f_descripcion,f_secuencia_manual) values " +
                        $"('{row.Field<string>("f_tipo_documento")}',{row.Field<int>("f_secuencia")},'{row.Field<string>("f_descripcion")}',{row.Field<bool>("f_secuencia_manual")})");
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
