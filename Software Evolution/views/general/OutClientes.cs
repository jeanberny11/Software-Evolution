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
    public partial class OutClientes : BaseForm
    {
        private readonly ClientesManager manager = new ClientesManager();
        private DataTable clientes;
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
    }
}
