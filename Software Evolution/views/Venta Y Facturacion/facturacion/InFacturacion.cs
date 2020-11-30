using Software_Evolution.managers.contabilidad;
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

namespace Software_Evolution.views.Venta_Y_Facturacion.facturacion
{
    public partial class InFacturacion : BaseForm
    {
        private readonly FacturasManager manager = new FacturasManager();
        ClientesManager clientesManager = new ClientesManager();
        ProductosManager productosManager = new ProductosManager();
        AutorizacionManager autorizacionManager = new AutorizacionManager();
        CuentasContablesManager cuentasContablesmanager = new CuentasContablesManager();
        PagosManager pagosManager = new PagosManager();
        DataRow clienteData;
        readonly DataRow preferencias = AppData.Instance.Preferencias;
        private bool impuestoincluido, sinexistencia,clienteexento,bloqueocredito,bloqueoentrega;
        private double maximodescuento1, maximodescuento2;
        private string documento = "", tipodoc = "", cotizacion = "",tipodoccliente="",cuentacliente="",DocumentoCliente,ncf,documentopedido;
        private int nodoc = 0, diascredito = 0;
        public InFacturacion()
        {
            InitializeComponent();
            cmb_tipofacturas.LoadData();
            cmb_tipoventa.LoadData();
            cmb_tiponcf.LoadData();
            cmb_moneda.LoadData();
            cmb_proyecto.LoadData();
            cmb_almacen.LoadData();
            Creando = true;
        }
        protected override void Limpiar()
        {
            base.Limpiar();
            dsdetalle.Clear();
            clienteData=null;
            impuestoincluido = false; sinexistencia = false; clienteexento = false; bloqueocredito = false; bloqueoentrega = false;
            maximodescuento1 = 0; maximodescuento2 = 0;
            documento = ""; tipodoc = ""; cotizacion = ""; tipodoccliente = ""; cuentacliente = ""; DocumentoCliente = ""; ncf = ""; documentopedido="";
            nodoc = 0; diascredito = 0;
            btn_contado.Checked = true;
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
                switch (precioventa)
                {
                    case 1:
                        {
                            newrow.SetField("precio", producto.Field<decimal>("f_precio"));
                            break;
                        }
                    case 2:
                        {
                            newrow.SetField("precio", producto.Field<decimal>("f_precio2"));
                            break;
                        }
                    case 3:
                        {
                            newrow.SetField("precio", producto.Field<decimal>("f_precio3"));
                            break;
                        }
                    case 4:
                        {
                            newrow.SetField("precio", producto.Field<decimal>("f_precio4"));
                            break;
                        }
                    case 5:
                        {
                            newrow.SetField("precio", producto.Field<decimal>("f_precio5"));
                            break;
                        }
                    case 6:
                        {
                            newrow.SetField("precio", producto.Field<decimal>("f_precio6"));
                            break;
                        }
                    default:
                        {
                            newrow.SetField("precio", producto.Field<decimal>("f_precio"));
                            break;
                        }
                }
                

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

        private void Salvar()
        {
            double efectivo = 0, devuelta = 0, montocheque = 0,montotarjetadeb=0,montotarjetacre=0,montotrans=0,montovale=0;
            int chequeno = 0, bancocheque = 0, claveconfcheque = 0,tarjetadebno=0,tarjetacreno=0,tipotarjetadeb=0,tipotarjetacre=0,noauttarjdeb=0,
                noauttarkcre=0,bancotarjdeb=0,bancotarkcre=0,doctrans=0,bancotrans=0,docvale=0,institutionvale=0;
            DateTime fechacheque=DateTime.Now,fechacobrocheque = DateTime.Now, fechatrans = DateTime.Now;
            if (cmb_proyecto.IsEmpty())
            {
                Mensaje("Debe seleccionar el proyecto!");
                cmb_proyecto.Focus();
                return;
            }
            if (cmb_almacen.IsEmpty())
            {
                Mensaje("Elija el Almacén...");
                cmb_almacen.Focus();
                return;
            }
            if (manager.ValidarCierreModular(Dtos(txtfecha.Value), 2))
            {
                Mensaje("Este periodo contable está cerrado...");
                return;
            }

            if (dsdetalle.Tables[0].Rows.Count == 0)
            {
                Mensaje("No existen Productos para esta Factura...!!");
                return;
            }
            if (txtclienteid.IsEmpty())
            {
                Mensaje("Elija un Cliente Para esta Factura...!!");
                txtclienteid.Focus();
                return;
            }

            if (cmb_tipoventa.IsEmpty())
            {
                Mensaje("Elija el Tipo de Venta...");
                cmb_tipoventa.Focus();
                return;
            }
            //-------------Valido la distribucion del pago---------------------//
            if (pagosManager.GetFacturaCaja() && !btn_credito.Checked)
            {
                var distribucion = pagosManager.GetDistribucionPago(this,txttotalneto.Valor);
                if (distribucion is null)
                    return;
                efectivo = Convert.ToDouble(distribucion[InPago.EFECTIVOKEY]);
                devuelta = Convert.ToDouble(distribucion[InPago.DEVUELTAKEY]);
                montocheque = Convert.ToDouble(distribucion[InPago.MONTOCHEQUEKEY]);
                chequeno = Convert.ToInt32(distribucion[InPago.NUMEROCHEQUEKEY]);
                bancocheque = Convert.ToInt32(distribucion[InPago.BANCOCHEQUEKEY]);
                claveconfcheque= Convert.ToInt32(distribucion[InPago.CLAVECONFCHEQUEKEY]);
                fechacheque = Convert.ToDateTime(distribucion[InPago.FECHARECCHEQUEKEY]);
                fechacobrocheque = Convert.ToDateTime(distribucion[InPago.FECHACOBROCHEQUEKEY]);
                tarjetadebno = Convert.ToInt32(distribucion[InPago.BANCOCHEQUEKEY]);
                tipotarjetadeb = Convert.ToInt32(distribucion[InPago.TIPOTARJETADEBKEY]);
                montotarjetadeb = Convert.ToDouble(distribucion[InPago.MONTOTARJETADEBKEY]);
                noauttarjdeb= Convert.ToInt32(distribucion[InPago.AUTTARJETADEBKEY]);
                bancotarjdeb= Convert.ToInt32(distribucion[InPago.BANCOTARJETADEBKEY]);
                tarjetacreno= Convert.ToInt32(distribucion[InPago.NOTARJETACREKEY]);
                tipotarjetacre= Convert.ToInt32(distribucion[InPago.TIPOTARJETADEBKEY]);
                montotarjetacre = Convert.ToDouble(distribucion[InPago.MONTOTARJETACREKEY]);
                noauttarkcre= Convert.ToInt32(distribucion[InPago.AUTTARJETACREKEY]);
                bancotarkcre= Convert.ToInt32(distribucion[InPago.BANCOTARJETACREKEY]);
                montotrans = Convert.ToDouble(distribucion[InPago.MONTOTRANSKEY]);
                doctrans= Convert.ToInt32(distribucion[InPago.DOCTRANSKEY]);
                bancotrans= Convert.ToInt32(distribucion[InPago.BANCOTRANSKEY]);
                fechatrans = Convert.ToDateTime(distribucion[InPago.FECHATRANSKEY]);
                montovale = Convert.ToDouble(distribucion[InPago.MONTOVALEKEY]);
                docvale= Convert.ToInt32(distribucion[InPago.DOCVALEKEY]);
                institutionvale= Convert.ToInt32(distribucion[InPago.INSTVALEKEY]);
            }
            //------------FIn distribucion----------------------------------------//
            //---------Genero la codificacion de nuevo-------//            
            Codificar();

            //------------Capturo los datos------------------------------//
            Dictionary<string, object> datos = new Dictionary<string, object>()
            {
                ["f_documento"] = documento,
                ["f_nodoc"] = nodoc,
                ["f_tipodoc"] = tipodoc,
                ["f_devuelta"] = devuelta,
                ["f_descuento"] = txtdesc1.Valor,
                ["f_envio"] = txtflete.Valor,
                ["f_monto"] = txttotalneto.Valor,
                ["f_itbis"] = txtitbis.Valor,
                ["f_fecha"] = txtfecha.Valor,
                ["f_hora"] = CurrentTime,
                ["f_hechopor"] = AppData.Instance.Currentuser.Codigousuario,
                ["f_costo"] = GetSumatoria(dsdetalle.Tables[0], "costo", ""),
                ["f_mostrar_itbis"] = true,
                ["f_anulado"] = false,
                ["f_cerrado"] = false,
                ["f_vendedor"] = vendedorPickerPanel1.Valor,
                ["f_cobrador"] = 0,
                ["f_depto"] = 0,
                ["f_codigo_fidelidad"] = 0,
                ["f_pago_tarjeta"] = false,
                ["f_cliente"] = txtclienteid.Valor,
                ["f_pedido"] = documentopedido,
                ["f_tipo_papel"] = 1,
                ["f_numero_control"] = 0,
                ["f_total_bultos"] = 0,
                ["f_total_kilos"] = 0,
                ["f_nombre_cliente"] = txtnombrecliente.Text,
                ["f_entrega_serial"] = false,
                ["f_monto_excento"] = txtmontoexento.Valor,
                ["f_base_imponible"] = txtbaseimponible.Valor,
                ["f_observacion"] = "",
                ["f_id_transporte"] = 0,
                ["f_descuento2"] = txtdes2.Valor,
                ["f_p_descuento1"] = txtpdesc1.Valor,
                ["f_p_descuento2"] = txtpdesc2.Valor,
                ["f_p_flete"] = txtpflete.Valor,
                ["f_efectivo"] = efectivo,
                ["f_cheque"] = montocheque,
                ["f_tarjeta_debito"] = montotarjetadeb,
                ["f_tarjeta_credito"] = montotarjetacre,
                ["f_cheque_numero"] = chequeno,
                ["f_cheque_banco"] = bancocheque,
                ["f_cheque_recibido"] = fechacheque,
                ["f_cheque_cobro"] = fechacobrocheque,
                ["f_tarjeta_db_id"] = tarjetadebno,
                ["f_tarjeta_db_banco"] = bancotarjdeb,
                ["f_tarjeta_db_autorizacion"] = noauttarjdeb,
                ["f_tarjeta_cre_id"] = tarjetacreno,
                ["f_tarjeta_cre_banco"] = bancotarkcre,
                ["f_tarjeta_cre_autorizacion"] = noauttarkcre,
                ["f_tipo_t_db"] = tipotarjetadeb,
                ["f_tipo_t_cre"] = tipotarjetacre,
                ["f_posteada"] = false,
                ["f_cajero"] = AppData.Instance.Currentuser.Codigousuario,
                ["f_monto_transferencia"] = montotrans,
                ["f_transferencia_no"] = doctrans,
                ["f_banco_transferencia"] = bancotrans,
                ["f_fecha_transferencia"] = fechatrans,
                ["f_monto_vale"] = montovale,
                ["f_vale_no"] = docvale,
                ["f_empresa_vale"] = institutionvale,
                ["f_fechavenci"] = CurrentDate,
                ["f_balance"] = txttotalneto.Valor,
                ["f_descuento_items"] = txtdescuentoitem.Valor,
                ["f_tipo_factura"] = btn_credito.Checked,
                ["f_tiene_devolucion"] = false,
                ["f_cuadre_caja"] = 0,
                ["f_pagada"] = false,
                ["f_ncf"] = ncf,
                ["f_tipo_ncf"] = cmb_tiponcf.Valor,
                ["f_cheque_confirmacion"] = 0,
                ["f_mesa"] = 0,
                ["f_factura_tipo"]=1,
                ["f_turno"]=0,
                ["f_monto_bruto"]=txttotalbruto.Valor,
                ["f_no_contrato"]=0,
                ["f_cantidad_pagare"]=0,
                ["f_monto_pagare"]=0,
                ["f_monto_inicial"]=0,
                ["f_estado"]=1,
                ["f_supervisor"]=0,
                ["f_moneda"]=cmb_moneda.Valor,
                ["f_direccion"]=txtdireccion.Text,
                ["f_telefono"]=txttelefono.Valor,
                ["f_tipo_entrega"]=true,
                ["f_entregada"]=false,
                ["f_relacionada"] = false,
                ["f_fecha_despacho"]=CurrentDate,
                ["f_documento2"]="",
                ["f_ruta"]=0,
                ["f_tasa"]=txttasa.Valor,
                ["f_contenedor"]="",
                ["f_consignatario"]=txtidconsignatario.Valor,
                ["f_tipo_venta"]=cmb_tipoventa.Valor,
                ["f_prefactura"]="",
                ["f_proyecto"]=cmb_proyecto.Valor,
            };
            //----------------Ejecuto el metodo de salvar---------------------//
            try
            {
                var doc=manager.SalvarFactura(Creando, datos, dsdetalle.Tables[0], dsdetalle.Tables[1], DocumentoCliente, documentopedido);
                //manager.PrintFactura(this, doc);
            }catch(Exception ex)
            {
                Mensaje(ex.Message);
                return;
            }
            Limpiar();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Codificar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FleteManager fleteManager = new FleteManager();
            var flete = fleteManager.getFleteTransporte(this);
            if (flete != null)
            {
                txtpflete.Valor = Convert.ToDouble(flete.Field<decimal>("f_flete"));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CambiarPrecio();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DescuentoItems();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CambiarCantidad();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GetProducto("");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BorrarLinea();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (txtcantidad.Valor == 0)
            {
                Mensaje("Elija un Cliente Para esta Autorizacion...!!");
                txtclienteid.Focus();
                return;
            }
            if (dsdetalle.Tables[0].Rows.Count == 0)
            {
                Mensaje("No existen Productos para esta Factura...!!");
                txtreferencia.Focus();
                return;
            }
            var autorizacionpendiente = autorizacionManager.GetAutorizacionPendienteCliente(txtclienteid.Valor);
            if (autorizacionpendiente != null)
            {
                if (!autorizacionpendiente.Field<bool>("f_estado"))
                    Mensaje($"Este cliente ya tiene una Autorizacion emitida, pendiente por aprovar generada en fecha {autorizacionpendiente.Field<DateTime>("f_fecha")} por un valor de {Ntos(autorizacionpendiente.Field<decimal>("f_monto"))}");
                else
                    Mensaje($"Este cliente ya tiene una Autorizacion emitida y aprovada generada en fecha {autorizacionpendiente.Field<DateTime>("f_fecha")} por un valor de {Ntos(autorizacionpendiente.Field<decimal>("f_monto"))}");
                return;
            }
            try
            {
                autorizacionManager.CreateAutorizacion(1, txttotalneto.Valor, CurrentDate, CurrentTime, vendedorPickerPanel1.Valor, txtclienteid.Valor);
            }catch(Exception ex)
            {
                Mensaje(ex.Message);
            }
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

        private void GetCliente(int clienteid)
        {
            if (clienteid == 0)
            {
                clienteid = clientesManager.SelectClienteFromGialog(this, "");
            }
            if (clienteid > 0)
            {
                clienteData = clientesManager.GetCliente(clienteid);
                if (clienteData != null)
                {
                    if (!clienteData.Field<bool>("f_activo"))
                    {
                        Mensaje("La cuenta de este cliente esta inactivo");
                        return;
                    }
                    txtclienteid.Valor = clienteData.Field<int>("f_id");
                    txtnombrecliente.Text = clienteData.Field<string>("f_nombre")+" "+ clienteData.Field<string>("f_apellido");
                    tipodoccliente = clienteData.Field<string>("f_tipo_documento");
                    txtdireccion.Text = clienteData.Field<string>("f_direccion_envio");
                    txttelefono.Text = clienteData.Field<string>("f_telefono");
                    txtfax.Text = clienteData.Field<string>("f_celular");
                    DocumentoCliente = clienteData.Field<string>("f_tipo_documento");
                    diascredito = Convert.ToInt32(clienteData.Field<decimal>("f_dias_credito"));
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
                txtcantidad.Focus();
            }
        }

        private void Codificar()
        {
            var costo = GetSumatoria(dsdetalle.Tables[0], "costo", "");
            dsdetalle.Tables[1].Clear();
            if (cmb_tipofacturas.IsEmpty())
                return;
            var tipofactura = manager.GetTipoFactura(Convert.ToInt32(cmb_tipofacturas.Valor));
            //--------------------cxc cliente------------------//
            if (btn_credito.Checked)
            {
                var row = dsdetalle.Tables[1].NewRow();
                row.SetField("cuenta", tipofactura.Field<string>("f_cuenta_db1"));
                row.SetField("nombre", cuentasContablesmanager.GetDescripcionCuenta(tipofactura.Field<string>("f_cuenta_db1")));
                row.SetField("debito", txttotalneto.Valor);
                row.SetField("credito", 0);
                row.SetField("centrocosto", 0);
                dsdetalle.Tables[1].Rows.Add(row);
                //----------------------prima de cxc cliente-------------------//
                if (Convert.ToInt32(cmb_moneda.Valor) != 1)
                {
                    var row2 = dsdetalle.Tables[1].NewRow();
                    row2.SetField("cuenta", tipofactura.Field<string>("f_cuenta_db2"));
                    row2.SetField("nombre", cuentasContablesmanager.GetDescripcionCuenta(tipofactura.Field<string>("f_cuenta_db2")));
                    row2.SetField("debito", txttotalneto.Valor*(txttasa.Valor-1));
                    row2.SetField("credito", 0);
                    row2.SetField("centrocosto", 0);
                    dsdetalle.Tables[1].Rows.Add(row2);
                }
                //-------------------FIN CXC--------------------------//
            }
            else
            {
                //--------------------cuenta caja------------------//
                var row = dsdetalle.Tables[1].NewRow();
                row.SetField("cuenta", tipofactura.Field<string>("f_cuenta_caja"));
                row.SetField("nombre", cuentasContablesmanager.GetDescripcionCuenta(tipofactura.Field<string>("f_cuenta_caja")));
                row.SetField("debito", txttotalneto.Valor);
                row.SetField("credito", 0);
                row.SetField("centrocosto", 0);
                dsdetalle.Tables[1].Rows.Add(row);
                //----------------------prima de cuenta caja-------------------//
                if (Convert.ToInt32(cmb_moneda.Valor) != 1)
                {
                    var row2 = dsdetalle.Tables[1].NewRow();
                    row2.SetField("cuenta", tipofactura.Field<string>("f_prima_caja"));
                    row2.SetField("nombre", cuentasContablesmanager.GetDescripcionCuenta(tipofactura.Field<string>("f_prima_caja")));
                    row2.SetField("debito", txttotalneto.Valor * (txttasa.Valor - 1));
                    row2.SetField("credito", 0);
                    row2.SetField("centrocosto", 0);
                    dsdetalle.Tables[1].Rows.Add(row2);
                }
            }
            

            //*---------------ITBIS-------------------------------*//
            if (txtitbis.Valor>0)
            {
                var row2 = dsdetalle.Tables[1].NewRow();
                row2.SetField("cuenta", tipofactura.Field<string>("f_cuenta_itbs"));
                row2.SetField("nombre", cuentasContablesmanager.GetDescripcionCuenta(tipofactura.Field<string>("f_cuenta_itbs")));
                row2.SetField("debito", 0);
                row2.SetField("credito", txtitbis.Valor*txttasa.Valor);
                row2.SetField("centrocosto", 0);
                dsdetalle.Tables[1].Rows.Add(row2);
            }
            //*---------------FIN ITBIS-------------------------------*//

            //--------------------ingreso x venta-----------------//
            var rowing = dsdetalle.Tables[1].NewRow();
            rowing.SetField("cuenta", tipofactura.Field<string>("f_cuenta_cre1"));
            rowing.SetField("nombre", cuentasContablesmanager.GetDescripcionCuenta(tipofactura.Field<string>("f_cuenta_cre1")));
            rowing.SetField("debito", 0);
            rowing.SetField("credito", (txttotalneto.Valor*txttasa.Valor)-((txtitbis.Valor * txttasa.Valor)+ (txtflete.Valor * txttasa.Valor)));
            rowing.SetField("centrocosto", 0);
            dsdetalle.Tables[1].Rows.Add(rowing);
            //------------------FIN INGRESO------------------------------//
            //------------------------flete-----------------------//
            if (txtitbis.Valor > 0)
            {
                var row2 = dsdetalle.Tables[1].NewRow();
                row2.SetField("cuenta", tipofactura.Field<string>("f_cuenta_flete"));
                row2.SetField("nombre", cuentasContablesmanager.GetDescripcionCuenta(tipofactura.Field<string>("f_cuenta_itbs")));
                row2.SetField("debito", 0);
                row2.SetField("credito", txtflete.Valor * txttasa.Valor);
                row2.SetField("centrocosto", 0);
                dsdetalle.Tables[1].Rows.Add(row2);
            }
            //*---------------FIN FLETE-------------------------------*//
            //--------------------Costp-----------------//
            var rowcosto = dsdetalle.Tables[1].NewRow();
            rowcosto.SetField("cuenta", tipofactura.Field<string>("f_cuenta_costo"));
            rowcosto.SetField("nombre", cuentasContablesmanager.GetDescripcionCuenta(tipofactura.Field<string>("f_cuenta_costo")));
            rowcosto.SetField("debito", costo);
            rowcosto.SetField("credito", 0);
            rowcosto.SetField("centrocosto", 0);
            dsdetalle.Tables[1].Rows.Add(rowcosto);
            //--------------------prima del costo-----------------//
            if (Convert.ToInt32(cmb_moneda.Valor) != 1)
            {
                var rowcosto2 = dsdetalle.Tables[1].NewRow();
                rowcosto2.SetField("cuenta", tipofactura.Field<string>("f_prima_costo"));
                rowcosto2.SetField("nombre", cuentasContablesmanager.GetDescripcionCuenta(tipofactura.Field<string>("f_prima_costo")));
                rowcosto2.SetField("debito", costo * (txttasa.Valor - 1));
                rowcosto2.SetField("credito", 0);
                rowcosto2.SetField("centrocosto", 0);
                dsdetalle.Tables[1].Rows.Add(rowcosto2);
            }
            //------------------FIN Costo------------------------------//
            //-----------------------Inventario------------------------//
            var rowinv = dsdetalle.Tables[1].NewRow();
            rowinv.SetField("cuenta", tipofactura.Field<string>("f_cuenta_inventario"));
            rowinv.SetField("nombre", cuentasContablesmanager.GetDescripcionCuenta(tipofactura.Field<string>("f_cuenta_inventario")));
            rowinv.SetField("debito", 0);
            rowinv.SetField("credito", costo);
            rowinv.SetField("centrocosto", 0);
            dsdetalle.Tables[1].Rows.Add(rowinv);
            //--------------------prima del Inventario-----------------//
            if (Convert.ToInt32(cmb_moneda.Valor) != 1)
            {
                var rowcosto2 = dsdetalle.Tables[1].NewRow();
                rowcosto2.SetField("cuenta", tipofactura.Field<string>("f_prima_inventario"));
                rowcosto2.SetField("nombre", cuentasContablesmanager.GetDescripcionCuenta(tipofactura.Field<string>("f_prima_inventario")));
                rowcosto2.SetField("debito", 0);
                rowcosto2.SetField("credito", costo * (txttasa.Valor - 1));
                rowcosto2.SetField("centrocosto", 0);
                dsdetalle.Tables[1].Rows.Add(rowcosto2);
            }
            //--------------------fin del Inventario-------------------//
            //------------------------Descuento------------------------//
            if (txtdesc1.Valor > 0)
            {
                var rowdesc = dsdetalle.Tables[1].NewRow();
                rowdesc.SetField("cuenta", tipofactura.Field<string>("f_cuenta_descuento"));
                rowdesc.SetField("nombre", cuentasContablesmanager.GetDescripcionCuenta(tipofactura.Field<string>("f_cuenta_descuento")));
                rowdesc.SetField("debito", txtdesc1.Valor*txttasa.Valor);
                rowdesc.SetField("credito", 0);
                rowdesc.SetField("centrocosto", 0);
                dsdetalle.Tables[1].Rows.Add(rowdesc);

                var rowdesc2 = dsdetalle.Tables[1].NewRow();
                rowdesc2.SetField("cuenta", tipofactura.Field<string>("f_cuenta_db1"));
                rowdesc2.SetField("nombre", cuentasContablesmanager.GetDescripcionCuenta(tipofactura.Field<string>("f_cuenta_db1")));
                rowdesc2.SetField("debito", 0);
                rowdesc2.SetField("credito", txtdesc1.Valor);
                rowdesc2.SetField("centrocosto", 0);
                dsdetalle.Tables[1].Rows.Add(rowdesc2);

                if (Convert.ToInt32(cmb_moneda.Valor) != 1)
                {
                    var rowdesc3 = dsdetalle.Tables[1].NewRow();
                    rowdesc3.SetField("cuenta", tipofactura.Field<string>("f_cuenta_db2"));
                    rowdesc3.SetField("nombre", cuentasContablesmanager.GetDescripcionCuenta(tipofactura.Field<string>("f_cuenta_db2")));
                    rowdesc3.SetField("debito", 0);
                    rowdesc3.SetField("credito", txtdesc1.Valor * (txttasa.Valor - 1));
                    rowdesc3.SetField("centrocosto", 0);
                    dsdetalle.Tables[1].Rows.Add(rowdesc3);
                }
            }
            //--------------------fin del descuento--------------------//

            //----------Limpiando las cuentas en blanco-----------------//            
            for (int i= dsdetalle.Tables[1].Rows.Count-1;i>=0;i--)
            {
                var row = dsdetalle.Tables[1].Rows[i];
                if (row.Field<string>("cuenta") == string.Empty)
                {
                    dsdetalle.Tables[1].Rows.Remove(row);
                }
            }            
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
    }
}
