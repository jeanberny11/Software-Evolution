using Software_Evolution.managers.general;
using Software_Evolution.managers.ventas_y_facturacion;
using Software_Evolution.utils.clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Evolution.views.Venta_Y_Facturacion.facturacion
{
    public partial class InFacturacion : BaseForm
    {
        private readonly FacturasManager manager = new FacturasManager();
        ClientesManager clientesManager = new ClientesManager();
        ProductosManager productosManager = new ProductosManager();
        DataRow clienteData;
        readonly DataRow preferencias = AppData.Instance.Preferencias;
        private bool impuestoincluido, sinexistencia,clienteexento,bloqueocredito,bloqueoentrega;
        double maximodescuento1, maximodescuento2;
        string documento = "", tipodoc = "", cotizacion = "",tipodoccliente="",cuentacliente="";

        private void txtreferencia_Validated(object sender, EventArgs e)
        {
            if (txtreferencia.Text != string.Empty)
            {
                GetProducto(txtreferencia.Text);
            }
        }

        private void txtrefsup_Validated(object sender, EventArgs e)
        {
            if (txtrefsup.Text != string.Empty)
            {
                GetProducto(txtrefsup.Text);
            }
        }

        private void txtcantidad_Validated(object sender, EventArgs e)
        {
            if (txtcantidad.Valor > 0)
            {
                if (txtreferencia.Text == string.Empty)
                {
                    Mensaje("No hay producto seleccionado");
                    txtreferencia.Focus();
                    return;
                }
                try
                {
                    AddItem(txtreferencia.Text, txtcantidad.Valor);
                }
                catch (Exception ex)
                {
                    Mensaje(ex.Message);
                    txtcantidad.Focus();
                }

            }
        }

        private void AddItem(string referencia, double cantidad)
        {
            var producto = productosManager.GetProducto(referencia,Convert.ToInt32(cmb_almacen.Valor));
            int precioventa = clienteData.Field<int>("f_precio_venta");
            var impuestoincluido = preferencias.Field<bool>("f_itbis_incluido");
            double reservada, backorder;
            if (producto is null)
            {
                Mensaje("No se encontro este producto!");
                return;
            }

            if (producto.Field<decimal>("f_cigars_qty") == 0)
            {
                Mensaje("Error de configuracion de los cigarros");
                return;
            }

            if (producto.Field<decimal>("f_factor_gross") == 0)
            {
                Mensaje("Error de configuracion de los cigarros");
                return;
            }


            var impuesto = producto.Field<decimal>("f_impuesto");

            //*------------valido la existencia en el inventario para la cantidad reservada y backorder-----------------*//
            if (!sinexistencia && producto.Field<bool>("f_controlinventario"))
            {
                if (cantidad >= Convert.ToDouble(producto.Field<decimal>("f_existencia")))
                {
                    reservada = Convert.ToDouble(producto.Field<decimal>("f_existencia"));
                    backorder = cantidad - Convert.ToDouble(producto.Field<decimal>("f_existencia"));
                }
                else
                {
                    reservada = cantidad;
                    backorder = 0;
                }
            }
            else
            {
                reservada = cantidad;
                backorder = 0;
            }
            //*---------------FIN-----------------------------*//

            //*--------valido las ventas decimales---------*//
            if (producto.Field<bool>("f_ventasdecimales"))
            {
                if (Frac(cantidad) > 0)
                {
                    var ventas_decimales = productosManager.GetVentasDecimales(Frac(cantidad));
                    if (ventas_decimales == null)
                    {
                        Mensaje($"Este Producto no Acepta ventas en decimales como {Frac(cantidad)}");
                        return;
                    }
                }
            }
            else if (Frac(cantidad) > 0)
            {
                Mensaje("Este Producto no Acepta ventas decimales ");
                return;
            }
            //*-----------------end------------------------*//

            // fila si ya existe el registro//
            var row = dsdetalle.Tables[0].Rows.Find(referencia + cmb_almacen.Valor.ToString());

            if (precioventa == 0)
                _ = 1;

            // Verificando si la fila existe para actializarlo//
            if (row != null)
            {
                row.BeginEdit();
                row.SetField("cantidad", row.Field<double>("cantidad") + cantidad);
                row.SetField("reservada", reservada);
                row.SetField("backorder", backorder);
                if (txtclienteid.Valor == 0)
                {
                    row.SetField("precio", producto.Field<decimal>("f_precio"));
                }
                else
                {
                    switch (precioventa)
                    {
                        case 1:
                            {
                                row.SetField("precio", producto.Field<decimal>("f_precio"));
                                break;
                            }
                        case 2:
                            {
                                row.SetField("precio", producto.Field<decimal>("f_precio2"));
                                break;
                            }
                        case 3:
                            {
                                row.SetField("precio", producto.Field<decimal>("f_precio3"));
                                break;
                            }
                        case 4:
                            {
                                row.SetField("precio", producto.Field<decimal>("f_precio4"));
                                break;
                            }
                        case 5:
                            {
                                row.SetField("precio", producto.Field<decimal>("f_precio5"));
                                break;
                            }
                        case 6:
                            {
                                row.SetField("precio", producto.Field<decimal>("f_precio6"));
                                break;
                            }
                        default:
                            {
                                row.SetField("precio", producto.Field<decimal>("f_precio"));
                                break;
                            }
                    }
                }
                if (impuesto > 0)
                {
                    row.SetField("precio", Math.Round(row.Field<double>("precio"), 2));
                }
                //------------valido el precio de oferta------------//
                if (producto.Field<bool>("f_oferta") && (producto.Field<DateTime>("f_fecha_oferta") >= CurrentDate))
                {
                    row.SetField("precio", producto.Field<decimal>("f_precio6"));
                }
                //--------------------------------------------------//                
                row.SetField("montobruto", row.Field<double>("precio") * row.Field<double>("cantidad"));
                row.EndEdit();
                dsdetalle.Tables[0].AcceptChanges();
            }
            //--------Si la fila no wxiste lo creo
            else
            {
                var newrow = dsdetalle.Tables[0].NewRow();
                newrow.SetField("items", dsdetalle.Tables[0].Rows.Count + 1);
                newrow.SetField("referencia", referencia);
                newrow.SetField("marca", productosManager.GetMarcaProducto(referencia));
                newrow.SetField("descripcion", producto.Field<string>("f_descripcion"));
                newrow.SetField("cantidad", cantidad);
                newrow.SetField("almacen", Convert.ToInt32(cmb_almacen.Valor));
                newrow.SetField("refped", referencia + cmb_almacen.Valor.ToString());
                newrow.SetField("cuenta", producto.Field<string>("f_cuenta_venta"));
                newrow.SetField("cuentacosto", producto.Field<string>("f_cuenta_compra"));
                newrow.SetField("cuentainventario", producto.Field<string>("f_cuenta_inventario"));
                newrow.SetField("cuentaimpuesto", producto.Field<string>("f_cuenta_impuesto"));
                newrow.SetField("controlinventario", producto.Field<bool>("f_controlinventario"));
                newrow.SetField("refsup", producto.Field<string>("f_referencia_suplidor"));
                newrow.SetField("cigars", cantidad*Convert.ToDouble(producto.Field<decimal>("f_cigars_qty")));
                newrow.SetField("gross", cantidad * Convert.ToDouble(producto.Field<decimal>("f_gross_weigth") / producto.Field<decimal>("f_factor_gross")));
                newrow.SetField("netweigth", Convert.ToDouble((producto.Field<decimal>("f_net_weigth")/ producto.Field<decimal>("f_factor_gross"))* producto.Field<decimal>("f_cigars_qty")));
                newrow.SetField("grossweigth", Convert.ToDouble(producto.Field<decimal>("f_gross_weigth") / producto.Field<decimal>("f_factor_gross")));
                newrow.SetField("tllcigars", newrow.Field<double>("cigars"));
                newrow.SetField("tllnetweigth", newrow.Field<double>("netweigth"));
                newrow.SetField("tllgrossweigth", newrow.Field<double>("grossweigth"));
                if (producto.Field<bool>("f_tieneitbs"))
                {
                    newrow.SetField("impuesto", producto.Field<decimal>("f_impuesto"));
                    newrow.SetField("pimpuesto", Convert.ToDouble(producto.Field<decimal>("f_impuesto")) / 100);
                }else
                {
                    newrow.SetField("impuesto", 0);
                    newrow.SetField("pimpuesto", 0);
                }
                newrow.SetField("precio", producto.Field<decimal>("f_precio"));              
                newrow.SetField("precio2", producto.Field<decimal>("f_precio"));                               
                newrow.SetField("categoriaid", producto.Field<int>("f_idcategoria"));

                //------------valido el precio de oferta------------//
                if (producto.Field<bool>("f_oferta") && (producto.Field<DateTime>("f_fecha_oferta") >= CurrentDate))
                {
                    newrow.SetField("precio", producto.Field<double>("f_precio6"));
                }
                //--------------------------------------------------//                
                newrow.SetField("costo", producto.Field<decimal>("f_ultimocosto"));
                newrow.SetField("tieneimpuesto", producto.Field<bool>("f_tieneitbs"));
                newrow.SetField("categoria", productosManager.GetCategoriaProducto(referencia));
                newrow.SetField("existencia", producto.Field<decimal>("f_existencia"));
                newrow.SetField("unidad", Convert.ToDouble((producto.Field<decimal>("f_maxdescuento") / 100)) * newrow.Field<double>("precio"));
                newrow.SetField("fechavenc", producto.IsNull("f_fecha_vencimiento") ? DateTime.Now : producto.Field<DateTime>("f_fecha_vencimiento"));
                newrow.SetField("mensaje", producto.Field<string>("f_mensaje"));
                dsdetalle.Tables[0].Rows.Add(newrow);
                dsdetalle.AcceptChanges();
            }
            Calcular();
            txtreferencia.Limpiar();
            txtrefsup.Limpiar();
            txtdescripcion.Limpiar();
            txtcantidad.Limpiar();
            txtreferencia.Focus();
        }

        private void Calcular()
        {
            double montobruto = 0, montoexento = 0, baseimponible = 0, itbis = 0, descuento1 = 0, descuento2 = 0, descuento3 = 0;
            foreach (DataRow row in dsdetalle.Tables[0].Rows)
            {
                //------------------asignando los totales de cada fila---------------//
                row.BeginEdit();
                if (row.Field<double>("impuesto") > 0 && row.Field<bool>("tieneimpuesto") && impuestoincluido)
                {
                    row.SetField("montobruto", (row.Field<double>("cantidad") * row.Field<double>("precio")) / (1 + row.Field<double>("pimpuesto")));

                }
                else
                {
                    row.SetField("montobruto", row.Field<double>("cantidad") * row.Field<double>("precio"));
                }
                double montores = row.Field<double>("montobruto");
                row.SetField("desc1", montores * (txtpdesc1.Valor / 100));
                montores -= row.Field<double>("desc1");
                row.SetField("desc2", montores * (txtpdesc2.Valor / 100));
                montores -= row.Field<double>("desc2");
                row.SetField("desc3", montores * (row.Field<double>("pdesc3") / 100));
                montores -= row.Field<double>("desc3");
                row.SetField("flete", montores * (txtpflete.Valor / 100));

                //-----blankeo la base imponible y el monto exento para asignarlo de nuevo por si lo parametros cambiaron--//
                row.SetField("baseimponible", 0);
                row.SetField("montoexento", 0);
                //-----------------------

                //------calculo la base imponible, montoexento y el itbis-------//
                if (row.Field<bool>("tieneimpuesto"))
                {
                    if (impuestoincluido)
                    {
                        row.SetField("baseimponible", montores / (1 + row.Field<double>("pimpuesto")));
                        row.SetField("impuesto", montores - row.Field<double>("baseimponible"));
                    }
                    else
                    {
                        row.SetField("baseimponible", montores);
                        row.SetField("impuesto", row.Field<double>("baseimponible") * row.Field<double>("pimpuesto"));
                    }
                }
                else
                {
                    row.SetField("montoexento", montores);
                }
                row.SetField("total", row.Field<double>("baseimponible") + row.Field<double>("montoexento") + row.Field<double>("impuesto"));
                row.EndEdit();

                montobruto += row.Field<double>("montobruto");
                baseimponible += row.Field<double>("baseimponible");
                montoexento += row.Field<double>("montoexento");
                itbis += row.Field<double>("impuesto");
                descuento1 += row.Field<double>("desc1");
                descuento2 += row.Field<double>("desc2");
                descuento3 += row.Field<double>("desc3");
            }
            dsdetalle.AcceptChanges();
            txttotalbruto.Valor = montobruto;
            txtmontoexento.Valor = montoexento;
            txtbaseimponible.Valor = baseimponible;
            txtitbis.Valor = itbis;
            txtdesc1.Valor = descuento1;
            txtdes2.Valor = descuento2;
            txtdescuentoitem.Valor = descuento3;
            txttotalneto.Valor = baseimponible + montoexento + itbis;
            Refresh();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetProducto("");
        }

        private void txtclienteid_Validated(object sender, EventArgs e)
        {
            if (txtclienteid.Valor > 0)
            {
                GetCliente(txtclienteid.Valor);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetCliente(0);
        }

        int nodoc = 0,diascredito=0;
        public InFacturacion()
        {
            InitializeComponent();
        }

        private void GetCliente(int clienteid)
        {
            if (clienteid == 0)
            {
                clienteid = clientesManager.SelectClienteFromGialog(this, "");
            }
            if (clienteid > 0)
            {
                clienteData = clientesManager.GetCliente(txtclienteid.Valor);
                if (clienteData != null)
                {
                    if (!clienteData.Field<bool>("f_activo"))
                    {
                        Mensaje("La cuenta de este cliente esta inactivo");
                        return;
                    }
                    txtnombrecliente.Text = clienteData.Field<string>("f_nombre")+" "+ clienteData.Field<string>("f_apellido");
                    tipodoccliente = clienteData.Field<string>("f_tipo_documento");
                    txtdireccion.Text = clienteData.Field<string>("f_direccion_envio");
                    txttelefono.Text = clienteData.Field<string>("f_telefono");
                    txtfax.Text = clienteData.Field<string>("f_celular");
                    diascredito = clienteData.Field<int>("f_dias_credito");
                    cmb_tiponcf.Valor = clienteData.Field<int>("f_tipo_comprobante");
                    txtcredito.Valor = Convert.ToDouble(clienteData.Field<decimal>("f_limite_credito")- clienteData.Field<decimal>("f_balance"));
                    cuentacliente = clienteData.Field<string>("f_cuenta_contable");
                    cmb_moneda.Valor = clienteData.Field<int>("f_tipo_moneda");
                    if (clienteData.Field<int>("f_vendedor") > 0)
                        vendedorPickerPanel1.Valor = clienteData.Field<int>("f_vendedor");
                    clienteexento= clienteData.Field<bool>("f_exento_impuestos");
                    GetConsignatario(clienteData.Field<int>("f_id"));
                    bloqueocredito = clienteData.Field<bool>("f_bloqueo_credito");
                    bloqueoentrega = clienteData.Field<bool>("f_facturar_contra_entrega");
                    cmb_almacen.Valor = clienteData.Field<int>("f_almacen");
                    GetFlete(clienteData.Field<int>("f_id_transporte"));
                    
                    switch (clienteData.Field<int>("f_termino"))
                    {
                        case 0:
                            {
                                btn_contado.Checked = true;
                                btn_contado.Enabled = false;
                                btn_credito.Enabled = false;
                                break;
                            }
                        case 1:
                            {
                                btn_credito.Checked = true;
                                btn_contado.Enabled = true;
                                btn_credito.Enabled = true;
                                break;
                            }
                        case 2:
                            {
                                btn_credito.Checked = true;
                                btn_contado.Enabled = true;
                                btn_credito.Enabled = true;
                                break;
                            }
                        default:
                            {
                                btn_contado.Checked = true;
                                btn_contado.Enabled = false;
                                btn_credito.Enabled = false;
                                break;
                            }

                    }
                    if (clienteData.Field<decimal>("f_precio_internacional") > 0)
                    {
                        btn_contado.Checked = true;
                    }
                }
                else
                {
                    Mensaje("Cliente no existe o esta inactivo");
                    return;
                }
            }
        }

        private void GetFlete(int v)
        {
            throw new NotImplementedException();
        }

        private void GetConsignatario(int id)
        {
            if (id == 0)
            {
                id = clientesManager.SelectClienteFromGialog(this, "");
            }
            if (id > 0)
            {
                var consignatario = clientesManager.GetCliente(id);
                if (consignatario != null)
                {
                    txtidconsignatario.Valor = consignatario.Field<int>("f_id");
                    txtnombreconsignatario.Text = consignatario.Field<string>("f_nombre") + " " + consignatario.Field<string>("f_apellido");
                }
                else
                {
                    Mensaje("No se encontro el consignatario especificado");
                    return;
                }
            }
        }

        private void GetProducto(string referencia)
        {
            DataRow producto;
            if (referencia == string.Empty)
            {
                producto = productosManager.SelectProductoFromDialog(this, "");
            }
            else
            {
                producto = productosManager.GetProducto(referencia);
                if(producto is  null)
                {
                    producto = productosManager.SelectProductoFromDialog(this, referencia);                    
                }
            }

            if (producto != null)
            {
                if (producto.Field<bool>("f_controlinventario"))
                {
                    if(!preferencias.Field<bool>("f_sin_existencia") && producto.Field<decimal>("f_existencia")<=0 && !producto.Field<bool>("f_facturar_negativo"))
                    {
                        Mensaje("Este producto no tiene existencia!");
                        txtreferencia.Limpiar();
                        txtrefsup.Limpiar();
                        txtreferencia.Focus();
                        return;
                    }
                }
                if (producto.Field<int>("f_estado_producto") == 2)
                {
                    Mensaje("Este producto esta inactivo...!");
                    txtreferencia.Limpiar();
                    txtrefsup.Limpiar();
                    txtreferencia.Focus();
                    return;
                }
                if (producto.Field<int>("f_estado_producto") == 4)
                {
                    Mensaje("Este producto no esta disponible para la venta...!");
                    txtreferencia.Limpiar();
                    txtrefsup.Limpiar();
                    txtreferencia.Focus();
                    return;
                }

                var listaprecio = clientesManager.GetListaPrecioProdCliente(txtclienteid.Valor, referencia);
                if (listaprecio.Rows.Count > 0)
                {
                    txtoreferencia.Text = referencia;
                    txtodescripcion.Text = listaprecio.Rows[0].Field<string>("f_descripcion");
                    txtoprecio1.Valor = Convert.ToDouble(listaprecio.Rows[0].Field<decimal>("f_precio"));
                    txtoprecio2.Valor = Convert.ToDouble(listaprecio.Rows[0].Field<decimal>("f_precio"));
                    txtoexistencia.Valor = Convert.ToDouble(listaprecio.Rows[0].Field<decimal>("f_existencia"));
                }
                else
                {
                    txtoreferencia.Text = referencia;
                    txtodescripcion.Text = producto.Field<string>("f_descripcion");
                    txtoprecio1.Valor = Convert.ToDouble(producto.Field<decimal>("f_precio"));
                    txtoprecio2.Valor = Convert.ToDouble(producto.Field<decimal>("f_precio"));
                    txtoexistencia.Valor = Convert.ToDouble(producto.Field<decimal>("f_existencia"));
                }

                txtreferencia.Text = producto.Field<string>("f_referencia");
                txtrefsup.Text = producto.Field<string>("f_referencia_suplidor");
                txtdescripcion.Text = producto.Field<string>("f_descripcion");
                txtcantidad.Valor = 1;
                txtprecio.Focus();
            }
        }
    }
}
