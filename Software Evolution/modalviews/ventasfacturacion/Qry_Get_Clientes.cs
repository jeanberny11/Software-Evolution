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
    public partial class Qry_Get_Clientes : BaseForm
    {
        private readonly QueryManager queryManager = QueryManager.Instance;
        public int Result { get; set; }

        private DataTable clientes;

        public Qry_Get_Clientes()
        {
            InitializeComponent();
            Buscar();
        }

        public Qry_Get_Clientes(string textfilter) : this()
        {
            searchControl1.Text = textfilter;
        }

        private void Buscar()
        {
            var sql = "select f_id,f_nombre,f_direccion,f_rif,f_telefono,f_balance,f_email from t_clientes where f_activo=true order by f_nombre";
            clientes = queryManager.Query(sql);
            gridControl1.DataSource = clientes;
            Refresh();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                Result = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "f_id"));
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (ValidarGrid(gridView1))
            {
                Result = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "f_id"));
            }
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (Result != 0)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
            }
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
    }
}
