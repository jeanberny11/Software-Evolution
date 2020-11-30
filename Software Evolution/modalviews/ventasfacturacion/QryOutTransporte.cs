using Software_Evolution.data;
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

namespace Software_Evolution.modalviews.ventasfacturacion
{
    public partial class QryOutTransporte : BaseForm
    {
        private readonly QueryManager manager = QueryManager.Instance;
        public DataRow Result { get; set; }
        public QryOutTransporte()
        {
            InitializeComponent();
            Buscar();
        }

        private void Buscar()
        {
            var sql = "select * from t_transporte";
            var data = manager.Query(sql);
            gridControl1.DataSource = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                Result = gridView1.GetDataRow(e.RowHandle);
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
