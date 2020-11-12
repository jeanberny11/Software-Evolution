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

namespace Software_Evolution.modalviews
{
    public partial class Qry_provincia_municipio : BaseForm
    {
        private readonly QueryManager manager = QueryManager.Instance;
        public DataRow Result { get; set; }

        public Qry_provincia_municipio()
        {
            InitializeComponent();
            Buscar();
        }

        private void Buscar()
        {
            var sql = "select * from t_sector order by f_provincia";
            var result = manager.Query(sql);
            this.gridControl1.DataSource = result;
            Refresh();
        }

        private void Buscar2(string provincia,string municipio,string distrito,string paraje)
        {
            var sql = "select * from t_sector where f_id > 0";
            if(provincia != string.Empty)
                sql += $" and f_des_provincia ilike '%{provincia}%'";

            if (municipio != string.Empty)
                sql += $" and f_des_municipio ilike '%{municipio}%'";

            if (distrito != string.Empty)
                sql += $" and f_des_distrito ilike '%{distrito}%'";

            if (paraje != string.Empty)
                sql += $" and f_descripcion ilike '%{paraje}%'";

            var result = manager.Query(sql);
            this.gridControl1.DataSource = result;
            Refresh();
        }

        private void evTextBox1_Validated(object sender, EventArgs e)
        {
            Buscar2(txtprovincia.Text, txtmunicipio.Text, txtdistrito.Text, txtparaje.Text);
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Result = null;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (ValidarGrid(gridView1))
            {
                Result = gridView1.GetDataRow(gridView1.GetSelectedRows()[0]);
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2)
            {                
                Result = gridView1.GetDataRow(e.RowHandle);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar== (char)13)
            {
                if(Result != null)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
            }
        }

        private void Qry_provincia_municipio_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }
    }
}
