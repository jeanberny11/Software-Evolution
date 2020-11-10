using Software_Evolution.managers.contabilidad;
using Software_Evolution.managers.general;
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

namespace Software_Evolution.views.general
{
    public partial class In_Clientes : BaseForm
    {
        private readonly ClientesManager manager = new ClientesManager();
        private DataTable tdescuento;
        private DataTable tlistaprecio;
        public In_Clientes()
        {
            InitializeComponent();
            InitData();
        }

        public In_Clientes(int clienteid) : this()
        {
            var cliente = manager.GetCliente(clienteid);
            if (cliente != null)
            {
                Modificar(cliente);
                cmb_precioventa.SelectedItem = cliente.Field<int>("f_precio_venta");
                tdescuento = manager.GetDescuentoXProntoPago(clienteid);
                gridControl1.DataSource = tdescuento;
                tlistaprecio = manager.GetListaPreciosCliente(clienteid);
                gridControl2.DataSource = tlistaprecio;
                Refresh();
            }
            else
            {
                Mensaje("No se puedo encontrar el cliente especificado");
            }
        }

        private void In_Clientes_Load(object sender, EventArgs e)
        {
            
        }

        private void InitData()
        {
            cmb_clasificacion.LoadData();
            cmb_pais.LoadData();
            cmb_region.LoadData();
            cmb_vendedor.LoadData();
            cmb_transporte.LoadData();
            cmb_zona.LoadData();
            cmb_ruta.LoadData();
            cmb_tipocliente.LoadData();
            cmb_cobrador.LoadData();
            cmb_moneda.LoadData();
            cmb_clasificacioncredito.LoadData();
            cmb_formapago.LoadData();
            cmb_termino.LoadData();
            cmb_diascaja.LoadData();
            cmb_tipocomprobante.LoadData();
            cmb_tipocontribuyente.LoadData();
            tdescuento = manager.GetDescuentoXProntoPago(0);
            gridControl1.DataSource = tdescuento;
            tlistaprecio = manager.GetListaPreciosCliente(0);
            gridControl2.DataSource = tlistaprecio;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var prov = manager.SelectProvinciasFromDialog(this);
                if(prov != null)
                {
                    txtidprovincia.EditValue = prov.Field<string>("f_provincia");
                    txtidmunicipio.EditValue = prov.Field<string>("f_municipio");
                    txtiddistrito.EditValue = prov.Field<string>("f_distrito");
                    txtidseccion.EditValue = prov.Field<string>("f_seccion");
                    txtidbarrio.EditValue = prov.Field<string>("f_barrio");
                    txtidparaje.EditValue = prov.Field<string>("f_sub_barrio");
                    txtdescprovincia.Text= prov.Field<string>("f_des_provincia");
                    txtdescmunicipio.Text = prov.Field<string>("f_des_municipio");
                    txtdescdistrito.Text = prov.Field<string>("f_des_distrito");
                    txtdescseccion.Text = prov.Field<string>("f_des_seccion");
                    txtdescbarrio.Text = prov.Field<string>("f_des_barrio");
                    txtdescparaje.Text = prov.Field<string>("f_descripcion");
                }
            }catch(Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            /*if(e.TabPage == tabPage3)
            {
                if(tdescuento is null)
                {
                    try
                    {
                        tdescuento = manager.GetDescuentoXProntoPago(txtcodigo.Valor);
                        gridControl1.DataSource = tdescuento;
                        Refresh();
                    }
                    catch (Exception ex)
                    {
                        Mensaje(ex.Message);
                    }
                }
            }
            if (e.TabPage == tabPage5)
            {
                if(tlistaprecio is null)
                {
                    try
                    {
                        tlistaprecio = manager.GetListaPreciosCliente(txtcodigo.Valor);
                        gridControl2.DataSource = tlistaprecio;
                        Refresh();
                    }
                    catch (Exception ex)
                    {
                        Mensaje(ex.Message);
                    }
                }
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tdescuento.Select($"f_dia_inicio={txtdiainicio.Valor}").Length > 0)
            {
                Mensaje("Existe un registro con estos dias de inicio");
                txtdiainicio.Focus();
                return;
            }
            var row = tdescuento.NewRow();
            row.SetField("f_dia_inicio", txtdiainicio.Valor);
            row.SetField("f_dia_fin", txtdiafin.Valor);
            row.SetField("f_descuento1", txtdescuento1.Valor);
            row.SetField("f_descuento2", txtdescuento2.Valor);
            tdescuento.Rows.Add(row);
            Refresh();
            txtdiainicio.Limpiar();
            txtdiafin.Limpiar();
            txtdescuento1.Limpiar();
            txtdescuento2.Limpiar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidarGrid(gridView1))
            {
                tdescuento.Rows.Remove(tdescuento.Rows[gridView1.GetSelectedRows()[0]]);
                Refresh();
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProductosManager productosManager = new ProductosManager();
            var producto = productosManager.SelectProductoFromDialog(this,"");
            if (producto != null) {
                txtrefrencia.Text = producto.Field<string>("f_referencia");
                txtrefrencia_Validated(null, null);
            }
        }

        private void txtrefrencia_Validated(object sender, EventArgs e)
        {
            ProductosManager productosManager = new ProductosManager();
            if (txtrefrencia.Text != string.Empty)
            {
                var prod = productosManager.GetProducto(txtrefrencia.Text);
                if (!(prod is null))
                {
                    txtrefrencia.Text = prod.Field<string>("f_referencia");
                    txtdescripcion.Text = prod.Field<string>("f_descripcion");
                    txtprecio.EditValue = prod.Field<decimal>("f_precio");
                    txtprecio.Focus();
                }
                else {
                    Mensaje("Este producto no existe");
                    txtrefrencia.Focus();
                    return;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtrefrencia.Text == string.Empty)
            {
                Mensaje("Elija El Producto...");
                txtrefrencia.Focus();
                return;
            }
            if (txtprecio.Valor <= 0) {
                Mensaje("Escriba el Precio Del Producto");
                txtrefrencia.Focus();
                return;
            }
            var row = tlistaprecio.NewRow();
            row.SetField("f_referencia", txtrefrencia.Text);
            row.SetField("f_descripcion", txtdescripcion.Text);
            row.SetField("f_precio", txtprecio.Valor);
            tlistaprecio.Rows.Add(row);
            txtrefrencia.Limpiar();
            txtdescripcion.Limpiar();
            txtprecio.Limpiar();
            txtrefrencia.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ValidarGrid(gridView2))
            {
                tlistaprecio.Rows.Remove(tlistaprecio.Rows[gridView2.GetSelectedRows()[0]]);
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!ValidarForm())
            {
                Mensaje("Debe llenar todos los campos requeridos, revisar las diferentes para ver dichos campos!");
                return;
            }
            Creando = txtcodigo.Valor == 0;
            if (!ConfirmarMensaje("Desea salvar los datos?"))
            {
                return;
            }

            if (Creando)
            {
                var vcedula = manager.ValidarCedula(evTextBox1.Text);
                if (vcedula != null)
                {
                    Mensaje($"Esta cedula esta asignada al codio {vcedula.Field<int>("f_id")} de nombre: {vcedula.Field<string>("f_nombre")} por Favor Verifique...");
                    tabControl1.SelectedTab = tabPage1;
                    evTextBox1.Focus();
                    return;
                }
            }
           
            try
            {
                Dictionary<string, object> datos = new Dictionary<string, object>();
                Grabar(datos);
                if(cmb_precioventa.Text!=string.Empty)
                    datos["f_precio_venta"] = Convert.ToInt32(cmb_precioventa.SelectedItem);

                manager.CreateCliente(Creando, datos, tdescuento, tlistaprecio);
                Limpiar();
                tabControl1.SelectedTab = tabPage1;
            }catch(Exception ex)
            {
                Mensaje(ex.Message);
                return;
            }
        }

        protected override void Limpiar()
        {
            base.Limpiar();
            cmb_precioventa.SelectedIndex = -1;
            evTextBox16.Limpiar();
            tdescuento.Clear();
            tlistaprecio.Clear();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var cuentamanager = new CuentasContablesManager();
            txtcuentaprima.Text = cuentamanager.SelectCuentaFromDialog(this);
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var cuentamanager = new CuentasContablesManager();
            txtcuenta.Text = cuentamanager.SelectCuentaFromDialog(this);
        }
    }
}
