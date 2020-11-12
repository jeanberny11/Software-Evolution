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

namespace Software_Evolution.modalviews.ventasfacturacion
{
    public partial class CambiarPrecioForm : BaseForm
    {
        private readonly ProductosManager manager = new ProductosManager();
        DataRow producto;
        DataRow preferencias = AppData.Instance.Preferencias;
        public double Result { get; set; }
        public CambiarPrecioForm(string referencia)
        {
            InitializeComponent();
            producto = manager.GetProducto(referencia);
            txtreferencia.Text = producto.Field<string>("f_referencia");
            txtdescripcion.Text = producto.Field<string>("f_descripcion");
            txtprecio1.Valor = Convert.ToDouble(producto.Field<decimal>("f_precio"));
            txtprecio2.Valor = Convert.ToDouble(producto.Field<decimal>("f_precio2"));
            txtprecio3.Valor = Convert.ToDouble(producto.Field<decimal>("f_precio3"));
            txtprecio4.Valor = Convert.ToDouble(producto.Field<decimal>("f_precio4"));
            txtprecio5.Valor = Convert.ToDouble(producto.Field<decimal>("f_precio5"));
            txtprecio6.Valor = Convert.ToDouble(producto.Field<decimal>("f_precio6"));
            txtpreciootro.Valor = Convert.ToDouble(producto.Field<decimal>("f_precio"));
        }

        private void SetResult(double precio)
        {
            if(!preferencias.Field<bool>("f_facturar_costo") && precio < txtprecio1.Valor)
            {
                Mensaje("No se Puede Facturar por Debajo del Costo!");
                return;
            }
            DialogResult = DialogResult.OK;
            Result = precio;
            Close();
        }

        private void lblprecio1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetResult(txtprecio1.Valor);
        }

        private void lblprecio2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetResult(txtprecio2.Valor);
        }

        private void lblprecio3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetResult(txtprecio3.Valor);
        }

        private void lblprecio4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetResult(txtprecio4.Valor);
        }

        private void lblprecio5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetResult(txtprecio5.Valor);
        }

        private void lblprecio6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetResult(txtprecio6.Valor);
        }

        private void lblpreciootro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetResult(txtpreciootro.Valor);
        }

        private void txtpreciootro_Validated(object sender, EventArgs e)
        {
            if (txtpreciootro.Valor > 0)
            {
                SetResult(txtpreciootro.Valor);
            }
        }

        private void CambiarPrecioForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }
    }
}
