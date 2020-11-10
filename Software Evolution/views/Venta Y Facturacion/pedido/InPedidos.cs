using Software_Evolution.managers.general;
using Software_Evolution.managers.ventas_y_facturacion;
using Software_Evolution.modalviews.ventasfacturacion;
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

namespace Software_Evolution.views.Venta_Y_Facturacion.pedido
{
    public partial class InPedidos : BaseForm
    {
        private readonly PedidosManager manager = new PedidosManager();
        ClientesManager clientesManager = new ClientesManager();
        ProductosManager productosManager = new ProductosManager();
        DataRow clienteData;
        readonly DataRow preferencias = AppData.Instance.Preferencias;
        private bool impuestoincluido,sinexistencia;
        double maximodescuento1, maximodescuento2;
        string documento = "", tipodoc = "",cotizacion="";
        int nodoc = 0;

        public InPedidos()
        {
            InitializeComponent();
            InitData();
            cmb_almacen.Valor = 1;
            impuestoincluido = preferencias.Field<bool>("f_itbis_incluido");
            maximodescuento1 = Convert.ToDouble(preferencias.Field<decimal>("f_maximo_descuento1"));
            maximodescuento2 = Convert.ToDouble(preferencias.Field<decimal>("f_maximo_descuento2"));
            sinexistencia = preferencias.Field<bool>("f_sin_existencia");
            lblusuario.Text = AppData.Instance.Currentuser.Nombre;
            Creando = true;
        }

        public InPedidos(string documento) : this()
        {
            Creando = false;
            var header = manager.GetPedidoHeader(documento);
            var detalle = manager.GetPedidoDetalle(documento);
            if (header is null)
            {
                Mensaje("No se encontro la cotizacion solicitada!");
                return;
            }
            this.documento = header.Field<string>("f_documento");
            tipodoc = header.Field<string>("f_tipodoc");
            nodoc = header.Field<int>("f_nodoc");
            txtclienteid.Valor = header.Field<int>("f_cliente");
            txtclienteid_Validated(null, null);
            txtnombrecliente.Text = header.Field<string>("f_nombre_cliente");
            vendedorPickerPanel1.Valor = header.Field<int>("f_vendedor");
            cmb_moneda.Valor = header.Field<int>("f_moneda");
            evProyectoCmb1.Valor = header.Field<int>("f_proyecto");
            cmb_almacen.Valor = header.Field<int>("f_vendedor");            
            btn_contado.Checked = header.Field<bool>("f_tipo_pedido");
            txtnota.Text = header.Field<string>("f_observacion");
            evDateTimePicker1.Value = header.Field<DateTime>("f_fecha");
            txtpdesc1.Valor = Convert.ToDouble(header.Field<decimal>("f_p_descuento1"));
            txtpdesc2.Valor = Convert.ToDouble(header.Field<decimal>("f_p_descuento2"));
            txtpflete.Valor = Convert.ToDouble(header.Field<decimal>("f_p_flete"));
            dsdetalle.Clear();
            foreach (DataRow det in detalle.Rows)
            {
                var newrow = dsdetalle.Tables[0].NewRow();
                newrow.SetField("items", dsdetalle.Tables[0].Rows.Count + 1);
                newrow.SetField("referencia", det.Field<string>("f_referencia"));
                newrow.SetField("marca", productosManager.GetMarcaProducto(det.Field<string>("f_referencia")));
                newrow.SetField("descripcion", det.Field<string>("f_descripcion"));
                newrow.SetField("cantidad", det.Field<decimal>("f_cantidad"));
                newrow.SetField("almacen", det.Field<int>("f_almacen"));
                newrow.SetField("refped", det.Field<string>("f_referencia") + det.Field<int>("f_almacen").ToString());
                newrow.SetField("precio", det.Field<decimal>("f_precio"));
                newrow.SetField("impuesto", det.Field<decimal>("f_itbs"));
                newrow.SetField("pimpuesto", det.Field<decimal>("f_impuesto") / 100);
                newrow.SetField("cuenta", "");
                newrow.SetField("categoriaid", det.Field<int>("f_idcategoria"));
                newrow.SetField("precio2", det.Field<decimal>("f_precio"));
                newrow.SetField("costo", det.Field<decimal>("f_ultimocosto"));
                newrow.SetField("desc3", det.Field<decimal>("f_descuento"));
                newrow.SetField("tieneimpuesto", det.Field<bool>("f_tieneitbs"));
                newrow.SetField("categoria", productosManager.GetCategoriaProducto(det.Field<string>("f_referencia")));
                newrow.SetField("existencia", det.Field<decimal>("f_existencia"));
                newrow.SetField("unidad", Convert.ToDouble((det.Field<decimal>("f_maxdescuento") / 100)) * newrow.Field<double>("precio"));
                newrow.SetField("fechavenc", det.IsNull("f_fecha_vencimiento") ? DateTime.Now : det.Field<DateTime>("f_fecha_vencimiento"));
                newrow.SetField("mensaje", det.Field<string>("f_mensaje"));
                newrow.SetField("items", dsdetalle.Tables[0].Rows.Count + 1);                
                newrow.SetField("reservada", det.Field<decimal>("f_reservada"));
                newrow.SetField("backorder", det.Field<decimal>("f_back_orde"));                
                newrow.SetField("precio1", det.Field<decimal>("f_precio"));
                newrow.SetField("precio2", det.Field<decimal>("f_precio2"));
                newrow.SetField("precio3", det.Field<decimal>("f_precio3"));
                newrow.SetField("precio4", det.Field<decimal>("f_precio4"));
                newrow.SetField("precio5", det.Field<decimal>("f_precio5"));
                newrow.SetField("precio6", det.Field<decimal>("f_precio6"));               
                dsdetalle.Tables[0].Rows.Add(newrow);
                dsdetalle.AcceptChanges();
            }
            Calcular();

        }

        private void InitData()
        {
            cmb_almacen.LoadData();
            evProyectoCmb1.LoadData();
            cmb_moneda.LoadData();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var clienteid = clientesManager.SelectClienteFromGialog(this, "");
            if (clienteid > 0)
            {
                txtclienteid.Valor = clienteid;
                txtclienteid_Validated(null, null);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetProducto("");
        }

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

            var producto = productosManager.GetProducto(referencia);
            int precioventa = clienteData.Field<int>("f_precio_venta");
            var impuestoincluido = preferencias.Field<bool>("f_itbis_incluido");
            double reservada, backorder;
            if (producto is null)
            {
                Mensaje("No se encontro este producto!");
                return;
            }
            var impuesto = producto.Field<decimal>("f_impuesto");

            //*------------valido la existencia en el inventario para la cantidad reservada y backorder-----------------*//
            if(!sinexistencia && producto.Field<bool>("f_controlinventario"))
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
                newrow.SetField("reservada", reservada);
                newrow.SetField("backorder", backorder);
                newrow.SetField("almacen", Convert.ToInt32(cmb_almacen.Valor));
                newrow.SetField("refped", referencia + cmb_almacen.Valor.ToString());
                newrow.SetField("precio", txtprecio.Valor);
                newrow.SetField("precio1", producto.Field<decimal>("f_precio"));
                newrow.SetField("precio2", producto.Field<decimal>("f_precio2"));
                newrow.SetField("precio3", producto.Field<decimal>("f_precio3"));
                newrow.SetField("precio4", producto.Field<decimal>("f_precio4"));
                newrow.SetField("precio5", producto.Field<decimal>("f_precio5"));
                newrow.SetField("precio6", producto.Field<decimal>("f_precio6"));
                newrow.SetField("impuesto", producto.Field<decimal>("f_impuesto"));
                newrow.SetField("pimpuesto", producto.Field<decimal>("f_impuesto") / 100);
                newrow.SetField("cuenta", "");
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
            txtprecio.Limpiar();
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

        private void txtclienteid_Validated(object sender, EventArgs e)
        {
            if (txtclienteid.Valor > 0)
            {
                var cliente = clientesManager.GetCliente(txtclienteid.Valor);
                if (cliente != null)
                {
                    if (cliente.Field<bool>("f_activo") == false)
                    {
                        Mensaje("La cuenta de este cliente esta inactivo");
                        return;
                    }
                    clienteData = cliente;
                    txtnombrecliente.Text = cliente.Field<string>("f_nombre");
                    txtbalance.Valor = Convert.ToDouble(cliente.Field<decimal>("f_balance"));
                    txtcredito.Valor = Convert.ToDouble(cliente.Field<decimal>("f_limite_credito") -cliente.Field<decimal>("f_balance"));
                    cmb_moneda.Valor = cliente.Field<int>("f_tipo_moneda");
                    switch (cliente.Field<int>("f_termino"))
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
                }
                else
                {
                    Mensaje("Cliente no existe o esta inactivo");
                    return;
                }
            }
        }

        private void txtpdesc1_Validated(object sender, EventArgs e)
        {
            if (txtpdesc1.Valor > 0)
            {
                if (txtpdesc1.Valor > maximodescuento1)
                    txtpdesc1.Valor = maximodescuento1;
                Calcular();
            }
        }

        private void txtpdesc2_Validated(object sender, EventArgs e)
        {
            if (txtpdesc2.Valor > 0)
            {
                if (txtpdesc2.Valor > maximodescuento2)
                    txtpdesc2.Valor = maximodescuento2;
                Calcular();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CambiarPrecio();
        }

        private void CambiarPrecio()
        {
            if (ValidarGrid(gridView2))
            {
                if (!AppData.Instance.Currentuser.CambiarPrecio)
                {
                    UsuariosManager usuariosManager = new UsuariosManager();
                    if (usuariosManager.ValidarPermiso(this, "f_cambiar_precio=true", "Cambio de Precio Produto") == 2)
                    {
                        Mensaje("Este usuario no tiene permiso para cambiar precios!");
                        return;
                    }
                }
                var row = dsdetalle.Tables[0].Rows[gridView2.GetSelectedRows()[0]];
                var precio = productosManager.GetCambiarPrecioProducto(this, row.Field<string>("referencia"));
                if (precio > 0)
                {
                    if (!preferencias.Field<bool>("f_facturar_costo") && precio < row.Field<double>("costo"))
                    {
                        Mensaje("No Puede Facturar Por Debajo del Costo");
                        return;
                    }

                    row.BeginEdit();
                    row.SetField("precio", precio);
                    row.SetField("precio2", precio);
                    row.EndEdit();
                    dsdetalle.AcceptChanges();
                    Calcular();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DescuentoItems();
        }

        private void DescuentoItems()
        {
            if (ValidarGrid(gridView2))
            {
                UsuariosManager usuariosManager = new UsuariosManager();
                if (!AppData.Instance.Currentuser.AplicarDescuentoItems)
                {
                    if (usuariosManager.ValidarPermiso(this, "f_d_producto=true", "Aplicar Descuento a Productos") == 2)
                    {
                        Mensaje("Este usuario no tiene permiso para aplicar descuentos items!");
                        return;
                    }
                }
                var row = dsdetalle.Tables[0].Rows[gridView2.GetSelectedRows()[0]];
                NumericInputDialog dialog = new NumericInputDialog("Descuento Items", "Digite el Porcentaje Descuento(%):", row.Field<double>("pdesc3"));
                var result = dialog.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    var cantidad = dialog.Result;
                    if (cantidad > 0)
                    {
                        row.BeginEdit();
                        row.SetField("pdesc3", cantidad);
                        row.EndEdit();
                        dsdetalle.AcceptChanges();
                        Calcular();
                    }
                }
                dialog.Dispose();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CambiarCantidad();
        }

        private void CambiarCantidad()
        {
            if (ValidarGrid(gridView2))
            {
                var row = dsdetalle.Tables[0].Rows[gridView2.GetSelectedRows()[0]];
                NumericInputDialog dialog = new NumericInputDialog("Cambiar cantidad", "Digite la cantidad que desea agregar", row.Field<double>("cantidad"));
                var result = dialog.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    var cantidad = dialog.Result;
                    if (cantidad > 0)
                    {
                        row.BeginEdit();
                        row.SetField("cantidad", cantidad);
                        row.EndEdit();
                        dsdetalle.AcceptChanges();
                        Calcular();
                    }
                }
                dialog.Dispose();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BuscarProducto();    
        }

        private void BuscarProducto()
        {
            GetProducto("");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BorrarLinea();
        }

        private void BorrarLinea()
        {
            if (ValidarGrid(gridView2))
            {
                dsdetalle.Tables[0].Rows.Remove(dsdetalle.Tables[0].Rows[gridView2.GetSelectedRows()[0]]);
                dsdetalle.AcceptChanges();
                gridView2.RefreshData();
                Calcular();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void gridView2_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (ValidarGrid(gridView2))
            {
                //*-----------Page precio------------------*//
                var fila = dsdetalle.Tables[0].Rows[gridView2.GetSelectedRows()[0]];
                evTextBox1.Text = fila.Field<string>("referencia");
                evTextBox2.Text = fila.Field<string>("descripcion");
                txtprev.Valor = fila.Field<double>("precio");
                txtpre1.Valor = fila.Field<double>("precio1");
                txtpre2.Valor = fila.Field<double>("precio2");
                txtpre3.Valor = fila.Field<double>("precio3");
                txtpre4.Valor = fila.Field<double>("precio4");
                txtpre5.Valor = fila.Field<double>("precio5");
                txtpre6.Valor = fila.Field<double>("precio6");
                txtexist.Valor = fila.Field<double>("existencia");
                //*---------------FIN----------------------*//

                //*----------Page exietencia ---------------*//
                var existenciasalmacen = productosManager.GetExistenciaAlmacenProducto(fila.Field<string>("referencia"));
                gridControl1.DataSource = existenciasalmacen;
                Refresh();
                //*----------FIn------------------------*//

                //*-------------- productos --------------*//
                txtdesc.Text = fila.Field<string>("descripcion");
                txtcat.Text = fila.Field<string>("categoria");
                txtprec.Valor = fila.Field<double>("precio");
                txtexistgeneral.Valor= fila.Field<double>("existencia");
                txtpdesc.Valor= fila.Field<double>("pdesc3");
                txtdescuento.Valor= fila.Field<double>("desc3");
                txtbackorder.Valor= fila.Field<double>("backorder");
                txtpendiente.Valor= fila.Field<double>("reservada");
                //*----------------FIn---------------------------*//
            }
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                CambiarCantidad();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var doccoti = manager.CargarCotizacion(this,txtclienteid.Valor);
            if (doccoti != string.Empty)
            {
                cotizacion = doccoti;
                CotizacionManager cotizacionManager = new CotizacionManager();
                var header = cotizacionManager.GetCotizacionHeader(cotizacion);
                var detalle = cotizacionManager.GetCotizacionDetalle(cotizacion);
                if (header is null)
                {
                    Mensaje("No se encontro la cotizacion solicitada!");
                    return;
                }                
                txtclienteid.Valor = header.Field<int>("f_cliente");
                txtclienteid_Validated(null, null);
                txtnombrecliente.Text = header.Field<string>("f_nombre_cliente");
                vendedorPickerPanel1.Valor = header.Field<int>("f_vendedor");
                cmb_moneda.Valor = header.Field<int>("f_moneda");
                evProyectoCmb1.Valor = header.Field<int>("f_proyecto");
                cmb_almacen.Valor = header.Field<int>("f_vendedor");
                btn_contado.Checked = header.Field<bool>("f_condicion");             
                evDateTimePicker1.Value = header.Field<DateTime>("f_fecha");
                txtpdesc1.Valor = Convert.ToDouble(header.Field<decimal>("f_p_descuento1"));
                txtpdesc2.Valor = Convert.ToDouble(header.Field<decimal>("f_p_descuento2"));
                txtpflete.Valor = Convert.ToDouble(header.Field<decimal>("f_p_flete"));
                dsdetalle.Clear();
                foreach (DataRow det in detalle.Rows)
                {
                    var newrow = dsdetalle.Tables[0].NewRow();
                    newrow.SetField("items", dsdetalle.Tables[0].Rows.Count + 1);
                    newrow.SetField("referencia", det.Field<string>("f_referencia"));
                    newrow.SetField("marca", productosManager.GetMarcaProducto(det.Field<string>("f_referencia")));
                    newrow.SetField("descripcion", det.Field<string>("f_descripcion"));
                    newrow.SetField("cantidad", det.Field<decimal>("f_cantidad"));
                    newrow.SetField("almacen", det.Field<int>("f_almacen"));
                    newrow.SetField("refped", det.Field<string>("f_referencia") + det.Field<int>("f_almacen").ToString());
                    newrow.SetField("precio", det.Field<decimal>("f_precio"));
                    newrow.SetField("impuesto", det.Field<decimal>("f_itbs"));
                    newrow.SetField("pimpuesto", det.Field<decimal>("f_impuesto") / 100);
                    newrow.SetField("cuenta", "");
                    newrow.SetField("categoriaid", det.Field<int>("f_idcategoria"));
                    newrow.SetField("precio2", det.Field<decimal>("f_precio"));
                    newrow.SetField("costo", det.Field<decimal>("f_ultimocosto"));
                    newrow.SetField("desc3", det.Field<decimal>("f_descuento"));
                    newrow.SetField("tieneimpuesto", det.Field<bool>("f_tieneitbs"));
                    newrow.SetField("categoria", productosManager.GetCategoriaProducto(det.Field<string>("f_referencia")));
                    newrow.SetField("existencia", det.Field<decimal>("f_existencia"));
                    newrow.SetField("unidad", Convert.ToDouble((det.Field<decimal>("f_maxdescuento") / 100)) * newrow.Field<double>("precio"));
                    newrow.SetField("fechavenc", det.IsNull("f_fecha_vencimiento") ? DateTime.Now : det.Field<DateTime>("f_fecha_vencimiento"));
                    newrow.SetField("mensaje", det.Field<string>("f_mensaje"));
                    newrow.SetField("items", dsdetalle.Tables[0].Rows.Count + 1);
                    newrow.SetField("reservada", det.Field<decimal>("f_cantidad"));
                    newrow.SetField("backorder", 0);                   
                    dsdetalle.Tables[0].Rows.Add(newrow);
                    dsdetalle.AcceptChanges();
                }
                Calcular();
            }

        }

        private void InPedidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.F2:
                    {
                        BuscarProducto();
                        break;
                    }
                case (char)Keys.F3:
                    {
                        CambiarCantidad();
                        break;
                    }
                case (char)Keys.F5:
                    {
                        DescuentoItems();
                        break;
                    }
                case (char)Keys.F10:
                    {
                        CambiarPrecio();
                        break;
                    }
                case (char)Keys.F6:
                    {
                        BorrarLinea();
                        break;
                    }
                case (char)Keys.F11:
                    {
                        Salvar();
                        break;
                    }
                case (char)Keys.Escape:
                    {
                        Salir();
                        break;
                    }
            }
        }

        private void Salvar()
        {
            int autorizacionid;
            if (txtnombrecliente.IsEmpty())
            {
                txtnombrecliente.Text = "Cliente Contado";
            }
            if (evProyectoCmb1.IsEmpty())
            {
                Mensaje("Debe seleccionar el proyecto!");
                evProyectoCmb1.Focus();
                return;
            }
            if (dsdetalle.Tables[0].Rows.Count == 0)
            {
                Mensaje("No existen Productos para este Pedido...!!");
                return;
            }

            if (txtcredito.Valor < txttotalneto.Valor)
            {
                //*----------Valido que tenga autorizacion-----------------*//
                var autorizacion=clientesManager.GetAutorizacionCLiente(txtclienteid.Valor);
                if (autorizacion != null)
                {
                    if((Convert.ToDouble(autorizacion.Field<decimal>("f_monto")) + 0.5) < txttotalneto.Valor) 
                    {
                        Mensaje("El monto del Pedido Excede el credito aprovado que es de..." + Ntos(autorizacion.Field<decimal>("f_monto")));
                        return;
                    }
                    autorizacionid = autorizacion.Field<int>("f_id");
                }
                else
                {
                    if (!ConfirmarMensaje($"El Monto del Pedido Excede el Limite de Credito..; su Balance Disponible es...{Ntos(txtcredito.Valor)}  Desea Continuar.. "))
                    {
                        return;
                    }
                }

            }


            if (!ConfirmarMensaje("Desea salvar el pedido?"))
            {
                return;
            }

            Dictionary<string, object> datos = new Dictionary<string, object>();
            datos["f_documento"] = documento;
            datos["f_nodoc"] = nodoc;
            datos["f_tipodoc"] = tipodoc;
            datos["f_devuelta"] = 0.00;
            datos["f_decuento"] = txtdesc1.Valor;
            datos["f_envio"] = txtflete.Valor;
            datos["f_monto"] = txttotalneto.Valor;
            datos["f_itbis"] = txtitbis.Valor;
            datos["f_fecha"] = evDateTimePicker1.Value;
            datos["f_hora"] = CurrentTime;
            datos["f_hechopor"] = AppData.Instance.Currentuser.Codigousuario;
            datos["f_costo"] = Convert.ToDouble(dsdetalle.Tables[0].Compute("SUM(costo)", ""));
            datos["f_mostrar_itbis"] = true;
            datos["f_anulado"] = false;
            datos["f_cerrado"] = false;
            datos["f_cliente"] = txtclienteid.Valor;
            datos["f_depto"] = 0;
            datos["f_vendedor"] = vendedorPickerPanel1.Valor;
            datos["f_codigo_fidelidad"] = 0;
            datos["f_ncf"] = "";
            datos["f_tipo_ncf"] = 0;
            datos["f_nombre_cliente"] = txtnombrecliente.Text;
            datos["f_factura"] = "";
            datos["f_cancelada"] = false;
            datos["f_tipo_papel"] = 0;
            datos["f_monto_excento"] = txtmontoexento.Valor;
            datos["f_base_imponible"] = txtbaseimponible.Valor;
            datos["f_observacion"] = txtnota.Text;
            datos["f_id_transporte"] = 0;
            datos["f_descuento2"] = txtdes2.Valor;
            datos["f_p_descuento1"] = txtpdesc1.Valor;
            datos["f_p_descuento2"] = txtpdesc2.Valor;
            datos["f_p_flete"] = txtpflete.Valor;
            datos["f_descuento_items"] = txtdescuentoitem.Valor;
            datos["f_estado"] = false;
            datos["f_estado_pedido"] = 1;
            datos["f_mesa"] = 1;
            datos["f_fecha_factura"] = CurrentDate;
            datos["f_fecha_empaque"] = CurrentDate;
            datos["f_fecha_despacho"] = CurrentDate;
            datos["f_fecha_recepcion"] = CurrentDate;            
            datos["f_moneda"] = cmb_moneda.Valor;
            datos["f_monto_bruto"] = txttotalbruto.Valor;
            datos["f_tipo_pedido"] = btn_contado.Checked;
            datos["f_enviado"] = false;
            datos["f_abierto"] = false;
            datos["f_fecha_entrega"] = txtfechaentrega.Valor;
            datos["f_proyecto"] = evProyectoCmb1.Valor;
            datos["f_fideicomiso"] = false;
            try
            {
                var doc = manager.SalvarPedido(Creando, datos, dsdetalle.Tables[0],cotizacion);
                if(ConfirmarMensaje("Desea imprimir el pedido?"))
                {
                    manager.PrintPedido(this, doc);
                }
                Limpiar();
            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        private void GetProducto(string referencia)
        {
            if (referencia == string.Empty)
            {
                var producto = productosManager.SelectProductoFromDialog(this, "");
                if (producto != null)
                {
                    txtreferencia.Text = producto.Field<string>("f_referencia");
                    txtrefsup.Text = producto.Field<string>("f_referencia_suplidor");
                    txtdescripcion.Text = producto.Field<string>("f_descripcion");
                    txtprecio.Valor = Convert.ToDouble(producto.Field<decimal>("f_precio2"));
                    txtcantidad.Focus();
                }
            }
            else
            {
                var producto = productosManager.GetProducto(referencia);
                if (producto != null)
                {
                    txtreferencia.Text = producto.Field<string>("f_referencia");
                    txtrefsup.Text = producto.Field<string>("f_referencia_suplidor");
                    txtdescripcion.Text = producto.Field<string>("f_descripcion");
                    txtprecio.Valor = Convert.ToDouble(producto.Field<decimal>("f_precio2"));
                    txtcantidad.Focus();
                }
                else
                {
                    var producto2 = productosManager.SelectProductoFromDialog(this, referencia);
                    if (producto2 != null)
                    {
                        txtreferencia.Text = producto2.Field<string>("f_referencia");
                        txtrefsup.Text = producto2.Field<string>("f_referencia_suplidor");
                        txtdescripcion.Text = producto2.Field<string>("f_descripcion");
                        txtprecio.Valor = Convert.ToDouble(producto2.Field<decimal>("f_precio2"));
                        txtcantidad.Focus();
                    }
                }
            }
        }

        protected override void Limpiar()
        {
            base.Limpiar();
            dsdetalle.Clear();
            documento = "";
            tipodoc = "";
            nodoc = 0;
            btn_contado.Checked = true;
        }
    }
}
