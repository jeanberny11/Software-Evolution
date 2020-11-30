using Software_Evolution.managers.general;
using Software_Evolution.utils.clases;
using Software_Evolution.views.cuentaxpagar;
using Software_Evolution.views.mantenimientos;
using Software_Evolution.views.Venta_Y_Facturacion;
using Software_Evolution.views.Venta_Y_Facturacion.facturacion;
using Software_Evolution.views.Venta_Y_Facturacion.pedido;
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
    public partial class Principal : BaseForm
    {
        public MenuStrip MenuPrincipal { get => this.menuStrip1; set => this.menuStrip1 = value; }

        public Principal()
        {
            InitializeComponent();
        }

        private void ventasFacturacionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOrFocusForm(new OutUsuarios());
        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowOrFocusForm(BaseForm form)
        {
            if (form.MultipleScreen)
            {
                form.MdiParent = this;
                form.StartPosition = FormStartPosition.CenterParent;
                form.Show();
            }
            else
            {
                var isOpen = false;
                foreach (Form openform in Application.OpenForms)
                {
                    if (openform.Name == form.Name)
                    {
                        isOpen = true;
                        openform.Focus();
                        break;
                    }
                }
                if (!isOpen)
                {
                    form.MdiParent = this;
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.Show();
                }
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            var manager = new UsuariosManager();
            manager.IniciarMenu(menuStrip1, true);
            // manager.PermisosUsuarios(menuStrip1, AppData.Instance.Currentuser.Codigousuario);
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOrFocusForm(new InCambiarClave());
        }

        private void preferenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOrFocusForm(new Preferencias());
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var clienteform = new OutClientes();
            ShowOrFocusForm(clienteform);
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void bancosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var clienteform = new OutClientes();
            ShowOrFocusForm(clienteform);
        }

        private void almacenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mantenimiento = new MasterDetailForm("t_almacen");
            ShowOrFocusForm(mantenimiento);
        }

        private void configuracionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new OutFormatoImpresionReportes();
            ShowOrFocusForm(form);
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new OutSuplidores();
            ShowOrFocusForm(form);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            var form = new OutCotizaciones();
            ShowOrFocusForm(form);
        }

        private void configuracionReportesGeneralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new OutFormatoImpresionGeneral();
            ShowOrFocusForm(form);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            var form = new CambiarEstadoCotizacion();
            ShowOrFocusForm(form);
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            var form = new OutPedidos();
            ShowOrFocusForm(form);
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            var form = new CambiarEstadoPedido();
            ShowOrFocusForm(form);
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            var form = new DepurarPedido();
            ShowOrFocusForm(form);
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            var form = new InFacturacion();
            ShowOrFocusForm(form);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new OutSuplidores();
            ShowOrFocusForm(form);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form = new OutCotizaciones();
            ShowOrFocusForm(form);
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void maestrosDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
