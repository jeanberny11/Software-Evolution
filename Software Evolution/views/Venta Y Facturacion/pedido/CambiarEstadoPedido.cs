using Software_Evolution.managers.ventas_y_facturacion;
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

namespace Software_Evolution.views.Venta_Y_Facturacion.pedido
{
    public partial class CambiarEstadoPedido : BaseForm
    {
        PedidosManager manager = new PedidosManager();
        DataTable pedidos;
        public CambiarEstadoPedido()
        {
            InitializeComponent();
            Buscar();
        }

        private void Buscar()
        {
            var fecha1 = Dtos(txtfecha1.Value);
            var fecha2 = Dtos(txtfecha2.Value);
            pedidos = manager.GetPedidosfecha(fecha1, fecha2);
            gridControl1.DataSource = pedidos;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            int estado = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "f_estado_pedido"));
            var msg = "";
            if(radioButton1.Checked)
                msg = "Sin aprobar";
            if(radioButton2.Checked)
                msg = "Aprobado";
            if(radioButton3.Checked)
                msg = "Cancelado";
            if (radioButton4.Checked)
                msg="Pendiente Entrega";
            if (radioButton5.Checked)
                msg = "Aprobado";

            if (ValidarGrid(gridView1))
            {
                if (estado == 4)
                {
                    Mensaje("No se Puede Cambiar el Estado de un Pedido que Fue Eliminado...? ");
                    return;
                }
                if (estado == 2)
                {
                    Mensaje("Este Pedido ya Fue Aprobado... ");
                    return;
                }
                if (estado == 2)
                {
                    Mensaje("Este Pedido ya Fue Aprobado... ");
                    return;
                }
                if (estado == 2)
                {
                    Mensaje("Este Pedido ya Fue Aprobado... ");
                    return;
                }
                if (ConfirmarMensaje($"Desea cambiar el estado de este pedido a '{msg}'"))
                {
                    int esta = 1;
                    if (radioButton1.Checked)
                        esta = 1;
                    else if (radioButton2.Checked)
                        esta = 2;
                    else if (radioButton3.Checked)
                        esta = 2;
                    else if (radioButton4.Checked)
                        esta = 4;
                    else if (radioButton5.Checked)
                        esta = 5;
                    manager.UpdateEstadoPedido(esta, gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0],"f_documento").ToString());
                    Buscar();
                }
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            int estado = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "f_estado_pedido"));
            btn_guardar.Enabled = estado != 5;
            switch (estado)
            {
                case 1:
                    {
                        radioButton1.Checked = true;
                        break;
                    }
                case 2:
                    {
                        radioButton2.Checked=true;
                        break;
                    }
                case 3:
                    {
                        radioButton4.Checked = true;
                        break;
                    }
                case 4:
                    {
                        radioButton3.Checked = true;
                        break;
                    }
                case 5:
                    {
                        radioButton5.Checked = true;
                        break;
                    }
                default:
                    {
                        radioButton1.Checked = true;
                        break;
                    }
            }
        }
    }
}
