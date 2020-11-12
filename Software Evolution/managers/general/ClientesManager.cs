using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Software_Evolution.data;
using Software_Evolution.repositorios;
using Software_Evolution.utils.clases;
using Software_Evolution.modalviews;
using Software_Evolution.views.mantenimientos;
using Software_Evolution.modalviews.ventasfacturacion;

namespace Software_Evolution.managers.general
{
    class ClientesManager
    {
        private readonly QueryManager manager = QueryManager.Instance;

        public DataRow GetCliente(int clienteid)
        {
            var res = manager.Query($"select * from t_clientes where f_id={clienteid}");
            if (res.Rows.Count > 0) {
                return res.Rows[0];
            }
            return null;
        }

        public DataTable GetAllClientes()
        {
            var sql = "select get_ciudad(f_ciudad)as ciudad,get_pais(f_pais)as pais,f_direccion,get_estado(f_estado)as estado," +
                "get_nombre_vendedor(f_vendedor)AS vendedor,get_clasificacion_cliente(f_clasificacion)as status,f_id,f_telefono," +
                "f_nombre,f_balance,f_cedula,f_rif,f_email,f_dias_credito from t_clientes order by f_id";
            return manager.Query(sql);
        }

        public DataRow SelectProvinciasFromDialog(BaseForm parent)
        {
            DataRow result=null;
            Qry_provincia_municipio provincias = new Qry_provincia_municipio();
            var dialolresult = provincias.ShowDialog(parent);
            if (dialolresult == System.Windows.Forms.DialogResult.OK)
            {
                result = provincias.Result;
            }
            provincias.Dispose();

            return result;
        }

        public DataTable GetDescuentoXProntoPago(int usuarioid)
        {
            var sql = (usuarioid > 0) ? $"select f_dia_inicio,f_dia_fin,f_descuento1,f_descuento2 from t_desc_x_pago_cliente where f_cliente={usuarioid}" : "select f_dia_inicio,f_dia_fin,f_descuento1,f_descuento2 from t_desc_x_pago_cliente limit 0";
            return manager.Query(sql);
        }

        public DataTable GetListaPreciosCliente(int clienteid)
        {
            var sql = (clienteid > 0) ? $"select * from t_lista_precios where f_cliente={clienteid}" : "select * from t_lista_precios limit 0";
            return manager.Query(sql);
        }

        public DataRow ValidarCedula(string cedula)
        {
            var sql = $"select f_rif,f_id,f_nombre from t_clientes where f_rif='{cedula}'";
            var res = manager.Query(sql);
            if (res.Rows.Count > 0)
            {
                return res.Rows[0];
            }
            return null;
        }

        public void CreateCliente(bool creando,Dictionary<string,object> datos,DataTable tdescutno,DataTable tlistaprecios)
        {
            manager.BeginWork();
            try
            {
                
                if (creando)
                {
                    datos["f_id"] = manager.GetSecuencia(manager.GetTipoDoc(1));
                    datos["f_fecha"] = manager.CurrentDate();
                    manager.CreateRecord("t_clientes", datos);
                }
                else
                {
                    datos["f_modificado_por"] = AppData.Instance.Currentuser.Codigousuario;
                    datos["f_ultima_modificacion"] = manager.CurrentDate();
                    manager.UpdateRecord("t_clientes", datos, $"where f_id={datos["f_id"]}");
                }
                if (tdescutno != null)
                {
                    manager.Execute($"delete from t_desc_x_pago_cliente where f_cliente={datos["f_id"]}");
                    foreach (DataRow row in tdescutno.Rows)
                    {
                        manager.CreateRecord("t_desc_x_pago_cliente", new Dictionary<string, object>()
                        {
                            ["f_cliente"] = datos["f_id"],
                            ["f_dia_inicio"] = row.Field<int>("f_dia_inicio"),
                            ["f_dia_fin"] = row.Field<int>("f_dia_fin"),
                            ["f_descuento1"] = row.Field<decimal>("f_descuento1"),
                            ["f_descuento2"] = row.Field<decimal>("f_descuento2")
                        });
                    }
                }
                if (tlistaprecios != null)
                {
                    manager.Execute($"delete from t_lista_precios where f_cliente={datos["f_id"]}");
                    foreach (DataRow row in tlistaprecios.Rows)
                    {
                        manager.CreateRecord("t_lista_precios", new Dictionary<string, object>()
                        {
                            ["f_cliente"] = datos["f_id"],
                            ["f_referencia"] = row.Field<string>("f_referencia"),
                            ["f_descripcion"] = row.Field<string>("f_descripcion"),
                            ["f_precio"] = row.Field<decimal>("f_precio")
                        });
                    }
                }
                manager.CommitWork();
            }catch(Exception ex)
            {
                manager.RollBack();
                throw ex;
            }
        }

        public void PrintEstadoCuentaCliente(BaseForm parent,int clienteid,DateTime date)
        {
            var reportesmanager = new reportes.FormatoImpresionReportesManager();
            var parametros = $"{clienteid},'{date:yyyy/MM/dd}'";
            var data = manager.QueryProcedure("p_estado_cuenta_cliente", parametros);
            reportesmanager.PrintReport(parent, 2045, data, new Dictionary<string, string>() {
                ["fecha1"] =date.ToString("dd-MM-yyyy")
            });            
        }

        public void EnviarEstadoCorreo(BaseForm parrent, int clienteid,DateTime date)
        {
            var reportesmanager = new reportes.FormatoImpresionReportesManager();            
            var parametros = $"{clienteid},'{date:yyyy/MM/dd}'";
            var data = manager.QueryProcedure("p_estado_cuenta_cliente", parametros);
            var reporte = reportesmanager.GetReporte(2045,data, new Dictionary<string, string>()
            {
                ["fecha1"] = $"{date:yyyy/MM/dd}"
            });            
            InEnviarCorreo inEnviarCorreo = new InEnviarCorreo("ing.berny11@gmail.com", "", "prueba", reporte);
            inEnviarCorreo.ShowDialog(parrent);

        }

        public int SelectClienteFromGialog(BaseForm parent,string textfilter)
        {
            int result = 0;
            Qry_Get_Clientes dialog = new Qry_Get_Clientes(textfilter);
            var dialolresult = dialog.ShowDialog(parent);
            if (dialolresult == System.Windows.Forms.DialogResult.OK)
            {
                result = dialog.Result;
            }
            dialog.Dispose();
            return result;
        }

        public DataRow GetAutorizacionCLiente(int clienteid)
        {
            var sql = $"select * from t_autorizaciones_venta where f_estado=true and f_rechazada=false and f_aplicada=false and f_cliente={clienteid}";
            var result = manager.Query(sql);
            if (result.Rows.Count > 0)
            {
                return result.Rows[0];
            }
            return null;
        }

        public DataTable GetListaPrecioProdCliente(int clienteid,string referencia)
        {
            return manager.Query($"select * from t_lista_precios where f_cliente={clienteid}  and f_referencia='{referencia}'");
        }
    }
}
