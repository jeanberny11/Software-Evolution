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

namespace Software_Evolution.views.Venta_Y_Facturacion
{
    public partial class CambiarEstadoCotizacion : BaseForm
    {
     
        private DataTable cotizaciones;
        public CambiarEstadoCotizacion()
        {
            InitializeComponent();
        
        }

       

        private void btn_buscar_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtfecha1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void txtfecha2_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
