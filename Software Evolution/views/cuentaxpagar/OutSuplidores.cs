using Software_Evolution.managers.cuentaxpagar;
using Software_Evolution.utils.clases;
using Software_Evolution.views.general;
using Software_Evolution.views.mantenimientos;
using System;
using System.Data;
using System.Windows.Forms;

namespace Software_Evolution.views.cuentaxpagar
{
    public partial class OutSuplidores : BaseForm
    {
        private readonly SuplidoresManager manager = new SuplidoresManager();
        private DataTable suplidores;
        public OutSuplidores()
        {
            InitializeComponent();
            Buscar();
        }

        private void btn_cerrar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void Buscar()
        {
            try
            {
                suplidores = manager.GetSuplidores();
                gridControl1.DataSource = suplidores;
                Refresh();
            }catch(Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btn_exportar_Click(object sender, EventArgs e)
        {
            InExportarDatos export = new InExportarDatos(gridControl1,"Lista de suplidores");
            export.ShowDialog(this);
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            InSuplidores form = new InSuplidores();
            (this.ParentForm as Principal).ShowOrFocusForm(form);
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                var suplidorid = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "f_id"));
                InSuplidores form = new InSuplidores(suplidorid);
                (this.ParentForm as Principal).ShowOrFocusForm(form);
            }
        }

        private void OutSuplidores_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }
    }
}
