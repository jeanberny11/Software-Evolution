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
    public partial class NumericInputDialog : BaseForm
    {
        public double Result { get; set; }
        public NumericInputDialog(string titulo,string mensaje,double valordefault)
        {
            InitializeComponent();
            this.Text = titulo;
            label1.Text = mensaje;
            evNumericTextBox1.Valor = valordefault;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Result = evNumericTextBox1.Valor;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void NumericInputDialog_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }
    }
}
