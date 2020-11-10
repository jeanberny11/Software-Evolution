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
    public partial class DepurarPedido :  BaseForm
    {
        private readonly PedidosManager manager = new PedidosManager();
        private DataTable pedidos;
        public DepurarPedido()
        {
            InitializeComponent();
            Buscar();
        }

        private void Buscar()
        {
            var fecha1 = Dtos(txtfecha1.Value);
            var fecha2 = Dtos(txtfecha2.Value);
            pedidos = manager.GetPedidosDepurarfecha(fecha1, fecha2);
            gridControl1.DataSource = pedidos;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if(ValidarGrid(gridView1) && ConfirmarMensaje("Desea borrar el pedido seleccionado?"))
            {
                try
                {
                    var documento = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "f_documento").ToString();
                    manager.BorrarPedido(documento);
                    Mensaje("Pedido depurado con estito...!");
                }catch(Exception ex)
                {
                    Mensaje(ex.Message);
                    return;
                }
                Buscar();
            }
        }
    }
}
