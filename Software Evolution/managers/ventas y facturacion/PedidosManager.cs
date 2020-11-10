using Software_Evolution.data;
using Software_Evolution.managers.reportes;
using Software_Evolution.modalviews;
using Software_Evolution.modalviews.ventasfacturacion;
using Software_Evolution.utils.clases;
using Software_Evolution.views.Venta_Y_Facturacion.pedido;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Evolution.managers.ventas_y_facturacion
{
    class PedidosManager
    {
        private readonly QueryManager manager = QueryManager.Instance;

        public DataTable GetPedidosfecha(string fecha1,string fecha2)
        {
            var sql = $"select *,get_nombre_usuario(f_hechopor)as usuario,get_nombre_cliente(f_cliente)as cliente,get_nombre_usuario(f_hechopor)as usuario," +
                $"get_nombre_vendedor(f_vendedor)as vendedor,get_estado_pedido(f_estado_pedido) as estado from t_factura_pedido" +
                $" where f_fecha between '{fecha1}' and '{fecha2}' order by f_fecha,f_documento";
            return manager.Query(sql);
        }

        public DataTable GetPedidosDepurarfecha(string fecha1, string fecha2)
        {
            var sql = $"select *,get_nombre_usuario(f_hechopor)as usuario,get_nombre_cliente(f_cliente)as cliente,get_estado_pedido(f_estado_pedido) as estado " +
                $" from t_factura_pedido" +
                $" where f_fecha between '{fecha1}' and '{fecha2}' and get_cantidad_productos_pedido(f_documento)>0  and f_estado_pedido<=2 and f_cancelada=false and f_factura='' order by f_fecha,f_documento";
            return manager.Query(sql);
        }

        public void UpdateEstadoPedido(int estado,string documento)
        {
            manager.Execute($"update t_factura_pedido set f_estado_pedido={estado} where f_documento='{documento}'");
        }

        internal string SalvarPedido(bool creando, Dictionary<string, object> datos, DataTable detalles,string cotizacion)
        {
            try
            {
                manager.BeginWork();
                if (creando)
                {
                    var tipodoc = manager.GetTipoDoc(81);
                    var secuencia = manager.GetSecuencia(tipodoc);
                    var documento = manager.ToWholeNum(tipodoc, secuencia);
                    datos["f_documento"] = documento;
                    datos["f_nodoc"] = secuencia;
                    datos["f_tipodoc"] = tipodoc;
                }
                else
                {
                    manager.Execute($"delete from t_factura_pedido where f_documento='{datos["f_documento"]}'");
                    manager.Execute($"delete from t_detalle_factura_pedido where f_documento='{datos["f_documento"]}'");
                }
                manager.CreateRecord("t_factura_pedido", datos);
                if (cotizacion != string.Empty)
                {
                    manager.Execute($"update t_factura_cotizacion set f_estado=true,f_pedido='{datos["f_documento"]}' where f_documento='{cotizacion}'");
                }
                foreach (DataRow row in detalles.Rows)
                {
                    var detalle = new Dictionary<string, object>()
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
                        ["f_id_area"] = 0,
                        ["f_cantidad_pedido"] = row.Field<double>("cantidad"),
                        ["f_almacen"] = row.Field<int>("almacen"),
                        ["f_cantidad_asignada"] = 0,
                        ["f_sin_existencia"] = false,
                        ["f_depuracion"] = false,
                        ["f_reservada"] = row.Field<double>("reservada"),
                        ["f_back_orde"] = row.Field<double>("backorder"),
                        ["f_precio2"] = row.Field<double>("precio2"),
                        ["f_nota"] = row.Field<string>("nota"),
                        ["f_proyecto"] = datos["f_proyecto"],
                    };
                    manager.CreateRecord("t_detalle_factura_pedido", detalle);
                    if (cotizacion != string.Empty)
                    {
                        manager.Execute($"update t_detalle_factura_cotizacion set f_cantidad_pedido=f_cantidad_pedido-{row.Field<double>("cantidad")} where f_referencia='{row.Field<string>("referencia")}' and f_documento='{cotizacion}'");
                    }
                }
                manager.CommitWork();
                return datos["f_documento"].ToString();
            }
            catch (Exception ex)
            {
                manager.RollBack();
                throw ex;
            }
        }

        internal void PrintPedido(BaseForm parent, string documento)
        {
            FormatoImpresionGeneralManager reportemanager = new FormatoImpresionGeneralManager();
            var reportdata = manager.QueryProcedure("p_print_pedidos_cliente_general", $"'{documento}'");
            var parameters = new Dictionary<string, string>()
            {
                ["rif"] = "RNC",
                ["IVA"] = "Itbis"
            };
            reportemanager.PrintReport(parent, reportemanager.Get_tipo_papel_general("f_formato_pedido"), reportdata, parameters);
        }

        public DataRow GetPedidoHeader(string documento)
        {
            var res = manager.Query($"select * from t_factura_pedido where f_documento='{documento}'");
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
                $"p.f_precio5,p.f_precio6 from t_detalle_factura_pedido d,t_productos_sucursal p where d.f_referencia=p.f_referencia and  d.f_documento='{documento}'");
        }

        public string CargarCotizacion(BaseForm parent,int clienteid)
        {
            string result = "";
            GetCotizacionAbierta dialog = new GetCotizacionAbierta(clienteid);
            var dialolresult = dialog.ShowDialog(parent);
            if (dialolresult == System.Windows.Forms.DialogResult.OK)
            {
                result = dialog.Result;
            }
            dialog.Dispose();

            return result;
        }

        public void BorrarPedido(string documento)
        {
            manager.BeginWork();
            try
            {
                var detalles = manager.Query($"select * from  t_detalle_factura_pedido where f_documento='{documento}'");
                foreach (DataRow det in detalles.Rows)
                {
                    var prodalmacen2 = manager.Query($"SELECT  * FROM t_almacen_productos WHERE f_referencia='{det.Field<string>("f_referencia")}' AND f_almacen=2 FOR UPDATE");
                    if (prodalmacen2.Rows.Count > 0)
                        manager.Execute($"UPDATE t_almacen_productos SET f_existencia=f_existencia-{det.Field<decimal>("f_reservada")} WHERE f_referencia='{det.Field<string>("f_referencia")}' AND f_almacen=2");
                    manager.Execute($"UPDATE t_almacen_productos SET f_existencia=f_existencia-{det.Field<decimal>("f_reservada")} WHERE f_referencia='{det.Field<string>("f_referencia")}' AND f_almacen={det.Field<int>("f_almacen")}");
                }
                manager.Execute($"delete from t_factura_pedido where f_documento='{documento}'");
                manager.Execute($"delete from t_detalle_factura_pedido where f_documento='{documento}'");
                manager.CommitWork();
            }catch(Exception ex)
            {
                manager.RollBack();
                throw ex;
            }
        }
    }
}
