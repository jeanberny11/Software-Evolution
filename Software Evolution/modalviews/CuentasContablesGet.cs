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
    public partial class CuentasContablesGet : BaseForm
    {
        private readonly QueryManager queryManager = QueryManager.Instance;
        public string Result { get; set; }

        public CuentasContablesGet()
        {
            InitializeComponent();
            Result = "";
            buscar();
        }

        public CuentasContablesGet(string filter) : this()
        {
            if (filter != String.Empty)
            {
                this.searchControl1.Text = filter;
            }
        }

        private void buscar()
        {
            var sql = "select * from t_cuentas_contables where f_estado=true order by f_no_cuenta";
            try
            {
                var res = queryManager.Query(sql);
                gridControl1.DataSource = res;
                gridControl1.Focus();
            }catch(Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (ValidarGrid(gridView1))
            {
                Result = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "f_no_cuenta").ToString();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Result = "";
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}
