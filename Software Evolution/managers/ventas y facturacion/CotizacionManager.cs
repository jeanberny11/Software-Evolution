using Software_Evolution.data;
using Software_Evolution.managers.reportes;
using Software_Evolution.utils.clases;
using Software_Evolution.views.mantenimientos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Evolution.managers.ventas_y_facturacion
{
    class CotizacionManager
    {
        QueryManager manager = QueryManager.Instance;

        public DataTable GetCotizacionesFecha(string fecha1,string fecha2)
        {
            var sql = $"select f.*,get_nombre_usuario(f.f_hechopor)as usuario,f_nombre_cliente as cliente," +
                $" get_nombre_vendedor(f.f_vendedor)as vendedor,c.f_email " +
                $" from t_factura_cotizacion f,t_clientes c where f.f_cliente=c.f_id and f.f_fecha between '{fecha1}' and '{fecha2}' order by f.f_fecha";
            return manager.Query(sql);
        }      

        public string SalvarCotizacion(bool creando,Dictionary<string,object> datos,DataTable detalles)
        {
            try
            {
                manager.BeginWork();
                if (creando)
                {
                    var tipodoc = manager.GetTipoDoc(222);
                    var secuencia = manager.GetSecuencia(tipodoc);
                    var documento = manager.ToWholeNum(tipodoc, secuencia);
                    datos["f_documento"] = documento;
                    datos["f_nodoc"] = secuencia;
                    datos["f_tipodoc"] = tipodoc;
                }
                else
                {
                    manager.Execute($"delete from t_factura_cotizacion where f_documento='{datos["f_documento"]}'");
                    manager.Execute($"delete from t_detalle_factura_cotizacion where f_documento='{datos["f_documento"]}'");
                }
                manager.CreateRecord("t_factura_cotizacion", datos);
                foreach(DataRow row in detalles.Rows)
                {
                    var detalle = new Dictionary<string, object>() 
                    {
                        ["f_documento"]=datos["f_documento"],
                        ["f_nodoc"] = datos["f_nodoc"],
                        ["f_tipodoc"] = datos["f_tipodoc"],
                        ["f_referencia"]=row.Field<string>("referencia"),
                        ["f_descuento"]= row.Field<double>("desc1"),
                        ["f_precio"] = row.Field<double>("precio"),
                        ["f_cantidad"] = row.Field<double>("cantidad"),
                        ["f_fecha"] = datos["f_fecha"],
                        ["f_descuento"] = row.Field<double>("desc1"),
                        ["f_categoria"] = row.Field<int>("categoriaid"),
                        ["f_itbs"] = row.Field<double>("impuesto"),
                        ["f_devuelta"] = 0,
                        ["f_costo"] = row.Field<double>("costo"),
                        ["f_iddep"] = 0,
                        ["f_id_area"] = 0,
                        ["f_cantidad_pedido"] = row.Field<double>("cantidad"),
                        ["f_almacen"] = row.Field<int>("almacen"),
                        ["f_proyecto"] = datos["f_proyecto"],
                    };
                    manager.CreateRecord("t_detalle_factura_cotizacion", detalle);
                }
                manager.CommitWork();
                return datos["f_documento"].ToString();
            }
            catch(Exception ex)
            {
                manager.RollBack();
                throw ex;
            }
        }

        public void PrintCotizacion(BaseForm parent,string documento)
        {
            FormatoImpresionGeneralManager reportemanager = new FormatoImpresionGeneralManager();
            var reportdata = manager.QueryProcedure("p_print_cotizaciones_cliente_general", $"'{documento}'");
            var parameters = new Dictionary<string, string>()
            {
                ["rif"]="RNC",
                ["IVA"]="Itbis"
            };
            reportemanager.PrintReport(parent, reportemanager.Get_tipo_papel_general("f_formato_cotizacion"), reportdata, parameters);
        }

        public DataRow GetCotizacionHeader(string documento)
        {
            var res = manager.Query($"select * from t_factura_cotizacion where f_documento='{documento}'");
            if (res.Rows.Count > 0)
            {
                return res.Rows[0];
            }
            return null;
        }

        public DataTable GetCotizacionDetalle(string documento)
        {
            return manager.Query($"select d.*,p.f_descripcion,p.f_impuesto,p.f_idcategoria,p.f_ultimocosto,p.f_tieneitbs,p.f_existencia,p.f_maxdescuento,p.f_fecha_vencimiento,p.f_mensaje from t_detalle_factura_cotizacion d,t_productos_sucursal p where d.f_referencia=p.f_referencia and  d.f_documento='{documento}'");
        }

        public void EnviarCotizacionCorreo(BaseForm parrent, string documento,string email)
        {
            FormatoImpresionGeneralManager reportemanager = new FormatoImpresionGeneralManager();
            var reportdata = manager.QueryProcedure("p_print_cotizaciones_cliente_general", $"'{documento}'");
            var parameters = new Dictionary<string, string>()
            {
                ["rif"] = "RNC",
                ["IVA"] = "Itbis"
            };
            var reporte = reportemanager.GetReporte(reportemanager.Get_tipo_papel_general("f_formato_cotizacion"), reportdata, parameters);           
            InEnviarCorreo inEnviarCorreo = new InEnviarCorreo(email, "Cotizacion Cliente", "prueba", reporte);
            inEnviarCorreo.ShowDialog(parrent);
        }
    }
}
