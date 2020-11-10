using Software_Evolution.managers.ventas_y_facturacion;
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

namespace Software_Evolution.views.Venta_Y_Facturacion.pedido
{
    public partial class OutPedidos : BaseForm
    {
        private readonly PedidosManager manager = new PedidosManager();
        DataTable pedidos;
        DataView pedidosview;
        public OutPedidos()
        {
            InitializeComponent();
            cmb_proyecto.LoadData();
            Buscar();
        }

        private void Buscar()
        {
            var fecha1 = Dtos(txtfecha1.Value);
            var fecha2 = Dtos(txtfecha2.Value);
            try {
                pedidos = manager.GetPedidosfecha(fecha1, fecha2);
                pedidosview = new DataView(pedidos);
                gridControl1.DataSource = pedidosview;
                Refresh();
            }catch(Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        private void txtfecha1_ValueChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void txtfecha2_ValueChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void cmb_proyecto_EditValueChanged(object sender, EventArgs e)
        {
            if (!cmb_proyecto.IsEmpty())
            {
                if(!(pedidosview is null))
                {
                    pedidosview.RowFilter = $"f_proyecto = {cmb_proyecto.Valor}";
                }
            }
            else
            {
                if (!(pedidosview is null))
                {
                    pedidosview.RowFilter="";
                }
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            var form = new InPedidos();
            (this.ParentForm as Principal).ShowOrFocusForm(form);
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                if (pedidos.Rows[e.RowHandle].Field<bool>("f_cancelada"))
                {
                    Mensaje("Esta cotizacion esta cancelada!");
                    return;
                }
                var documento = pedidos.Rows[e.RowHandle].Field<string>("f_documento");
                var form = new InPedidos(documento);
                (this.ParentForm as Principal).ShowOrFocusForm(form);
            }
        }
    }
}
