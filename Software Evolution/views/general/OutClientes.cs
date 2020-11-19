using Software_Evolution.managers.general;
using Software_Evolution.utils.clases;
using Software_Evolution.views.mantenimientos;
using System;
using System.Data;
using Software_Evolution.data;
using Software_Evolution.managers;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace Software_Evolution.views.general
{
    public partial class OutClientes : BaseForm
    {
        private readonly ClientesManager manager = new ClientesManager();
        private DataTable clientes;
        private DataTable datos;
        private readonly QueryManager manager2 = QueryManager.Instance;

        public OutClientes()
        {
            InitializeComponent();           
            Buscar();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            var inclientes = new In_Clientes();
            (this.ParentForm as Principal).ShowOrFocusForm(inclientes);
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Buscar()
        {
            try
            {
                clientes = manager.GetAllClientes();
                gridControl1.DataSource = clientes;
            }
            catch(Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                var clienteid = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "f_id"));
                var cliente = new In_Clientes(clienteid);
                (this.ParentForm as Principal).ShowOrFocusForm(cliente);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidarGrid(gridView1))
            {
                try
                {
                    var cliente = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "f_id"));
                    manager.PrintEstadoCuentaCliente(this,cliente, CurrentDate);
                }catch(Exception ex)
                {
                    Mensaje(ex.Message);
                }
            }
        }

        private void btn_correo_Click(object sender, EventArgs e)
        {
            if (ValidarGrid(gridView1))
            {
                try
                {
                    var cliente = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "f_id"));
                    manager.EnviarEstadoCorreo(this, cliente, CurrentDate);
                }
                catch (Exception ex)
                {
                    Mensaje(ex.Message);
                }
            }
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            datos = manager2.QueryProcedure("p_reporte_clientes", "");
            var reportesmanager = new managers.reportes.FormatoImpresionReportesManager();
            reportesmanager.PrintReport(this,3506,datos, new Dictionary<string, string>());

        }

        private void OutClientes_Resize(object sender, EventArgs e)
        {

        }

        private void OutClientes_Shown(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void OutClientes_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void btn_exportar_Click(object sender, EventArgs e)
        {
        InExportarDatos export = new InExportarDatos(gridControl1, "Lista de suplidores");
        export.ShowDialog(this);
    }
    }
}
