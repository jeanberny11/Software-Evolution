using Software_Evolution.data;
using Software_Evolution.managers.reportes;
using Software_Evolution.utils.clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Evolution.managers.ventas_y_facturacion
{
    class FacturasManager
    {
        private readonly QueryManager manager = QueryManager.Instance;


        public bool ValidarCierreModular(string fecha,int tipo)
        {
            var result = manager.Query($"select f_activo from t_periodo_contable where f_tipo = {tipo} and f_fecha_fin>='{fecha}' and f_fecha_inicio<='{fecha}'");
            if (result.Rows.Count > 0)
            {
                return result.Rows[0].Field<bool>("f_activo");
            }
            return false;
        }

        public DataRow GetTipoFactura(int id)
        {
            var result = manager.Query($"select * from t_tipos_factura where f_id={id}");
            if (result.Rows.Count > 0)
            {
                return result.Rows[0];
            }
            return null;
        }

        public string SalvarFactura(bool creando, Dictionary<string, object> datos, DataTable detalle, DataTable detallecontable,string doccli,string pedido)
        {
            manager.BeginWork();
            try
            {
                //-----------Si se esta creando la factura genero los documentos y el ncf-------------//
                if (creando)
                {
                    string ano = Convert.ToDateTime(datos["f_fecha"]).Year.ToString();
                    var tipo = $"{doccli}{ano}-";
                    var secuencia = manager.GetSecuencia(tipo);
                    var documento = manager.ToWholeNum(tipo, secuencia);
                    datos["f_documento"] = documento;
                    datos["f_nodoc"] = secuencia;
                    datos["f_tipodoc"] = tipo;
                    datos["f_ncf"] = manager.GetSecuenciaNcf(Convert.ToInt32(datos["f_tipo_ncf"]), Convert.ToDateTime(datos["f_fecha"]));
                }
                else
                {
                    //----------Si se esta modificando delimino los registros anteriores--------------//
                    manager.Execute($"delete from t_factura where f_documento='{datos["f_documento"]}'");
                    manager.Execute($"delete from t_detalle_factura where f_documento='{datos["f_documento"]}'");
                    manager.Execute($"delete from t_detalle_contable where f_wholenum='{datos["f_documento"]}'");
                    manager.Execute($"delete from t_detalle_salida where f_documento='{datos["f_documento"]}'");
                }
                //----------Savlo los datos de la factura--------//
                manager.CreateRecord("t_factura", datos);

                //------Actualizo el pedido en caso que haya--------//
                if (pedido != string.Empty)
                {
                    manager.Execute($"update t_factura_pedido set f_estado=true,f_factura='{datos["f_documento"]}',f_estado_pedido=8 where f_documento='{pedido}'");
                }

                //-----------Salvo el detalle de la factura----------------//
                int orden = 1;
                foreach(DataRow row in detalle.Rows)
                {
                    var det = new Dictionary<string, object>()
                    {
                        ["f_documento"] = datos["f_documento"],
                        ["f_nodoc"] = datos["f_nodoc"],
                        ["f_tipodoc"] = datos["f_tipodoc"],
                        ["f_referencia"] = row.Field<string>("referencia"),
                        ["f_descuento"] = row.Field<double>("desc1"),
                        ["f_precio"] = row.Field<double>("precio"),
                        ["f_cantidad"] = row.Field<double>("cantidad"),
                        ["f_fecha"] = datos["f_fecha"],
                        ["f_categoria"] = row.Field<int>("categoriaid"),
                        ["f_itbs"] = row.Field<double>("impuesto"),
                        ["f_devuelta"] = 0,
                        ["f_costo"] = row.Field<double>("costo"),
                        ["f_iddep"] = 0,
                        ["f_almacen"] = row.Field<int>("almacen"),
                        ["f_pedido"] = datos["f_pedido"],
                        ["f_descuento2"] = row.Field<double>("desc2"),
                        ["f_descuento3"] = row.Field<double>("desc3"),
                        ["f_flete"] = row.Field<double>("flete"),
                        ["f_precio_real"] = row.Field<double>("precio"),
                        ["f_desc_general"]=0,
                        ["f_total"] = row.Field<double>("total"),
                        ["f_orden"]=orden,
                        ["f_proyecto"]=datos["f_proyecto"]
                    };
                    manager.CreateRecord("t_detalle_factura", det);
                    if (pedido != string.Empty)
                    {
                        manager.Execute($"update t_detalle_factura_pedido set f_cantidad_pedido=f_cantidad_pedido-{row.Field<double>("cantidad")} where f_referencia='{row.Field<string>("referencia")}' and f_documento='{datos["f_documento"]}'");
                    }
                    orden++;
                }

                //----------Salvo el detalle contable--------------------//
                foreach(DataRow row in detallecontable.Rows)
                {
                    var det = new Dictionary<string, object>() 
                    { 
                        ["f_tipo_doc"]=datos["f_tipodoc"],
                        ["f_no_doc"]=datos["f_nodoc"],
                        ["f_fecha"]=datos["f_fecha"],
                        ["f_monto_db"]=row.Field<double>("debito"),
                        ["f_monto_cre"]= row.Field<double>("credito"),
                        ["f_descripcion"]=row.Field<string>("nombre"),
                        ["f_cuenta"] = row.Field<string>("cuenta"),
                        ["f_wholenum"] = datos["f_documento"],
                        ["f_centro"] = row.Field<int>("centrocosto"),
                        ["f_proyecto"]= datos["f_proyecto"],
                        ["f_hechopor"]= datos["f_hechopor"],
                        ["f_moneda"] = datos["f_moneda"],
                    };
                    manager.CreateRecord("t_detalle_contable", det);
                }

                //------------------------FIN Guardado---------------------//
                manager.CommitWork();
                return datos["f_documento"].ToString();
            }catch(Exception ex)
            {
                manager.RollBack();
                throw ex;
            }
        }
        internal void PrintFactura(BaseForm parent, string documento)
        {
            FormatoImpresionGeneralManager reportemanager = new FormatoImpresionGeneralManager();
            var reportdata = manager.QueryProcedure("p_print_factura_cliente_general", $"'{documento}'");
            var parameters = new Dictionary<string, string>()
            {
                ["rif"] = "RNC",
                ["IVA"] = "Itbis"
            };
            reportemanager.PrintReport(parent, reportemanager.Get_tipo_papel_general("f_formato_factura"), reportdata, parameters);
        }

        public DataRow GetFacturaHeader(string documento)
        {
            var res = manager.Query($"select * from t_factura where f_documento='{documento}'");
            if (res.Rows.Count > 0)
            {
                return res.Rows[0];
            }
            return null;
        }

        public DataTable GetPedidoDetalle(string documento)
        {
            return manager.Query($"select d.*,p.f_descripcion,p.f_impuesto,p.f_idcategoria,p.f_ultimocosto,p.f_tieneitbs,p.f_existencia," +
                $"p.f_maxdescuento,p.f_fecha_vencimiento,p.f_mensaje,p.f_precio2,p.f_precio3,p.f_precio4," +
                $"p.f_precio5,p.f_precio6 from t_detalle_factura d,t_productos_sucursal p where d.f_referencia=p.f_referencia and  d.f_documento='{documento}'");
        }
    }
}
