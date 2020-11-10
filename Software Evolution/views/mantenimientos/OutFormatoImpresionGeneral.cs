using Software_Evolution.managers.reportes;
using Software_Evolution.utils.clases;
using Software_Evolution.views.general;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Evolution.views.mantenimientos
{
    public partial class OutFormatoImpresionGeneral : BaseForm
    {
        private readonly FormatoImpresionGeneralManager manager = new FormatoImpresionGeneralManager();
        public OutFormatoImpresionGeneral()
        {
            InitializeComponent();
            Buscar();
        }

        private void Buscar()
        {
            try
            {
                var data = manager.GetFormatos();
                this.gridControl1.DataSource = data;
                Refresh();
            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            var form = new InFormatoImpresionGeneral();
            (this.ParentForm as Principal).ShowOrFocusForm(form);
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                var form = new InFormatoImpresionGeneral(Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle,"f_id")));
                (this.ParentForm as Principal).ShowOrFocusForm(form);
            }
        }
    }
}
