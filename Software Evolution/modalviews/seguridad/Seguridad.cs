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

namespace Software_Evolution.modalviews.seguridad
{
    public partial class Seguridad : BaseForm
    {
        private string campo;
        private readonly UsuariosManager manager = new UsuariosManager();
        public bool Result { get; set; }
        public Seguridad(string campovalidar,string mensaje)
        {
            this.campo = campovalidar;
            InitializeComponent();
            lblmensaje.Text = mensaje;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtusuario.IsEmpty())
            {
                Mensaje("El usuario no debe estar en blanco");
                txtusuario.Focus();
                return;
            }

            if (txtpass.IsEmpty())
            {
                Mensaje("La contraseña no debe estar en blanco");
                txtpass.Focus();
                return;
            }
            try
            {
                var vadlidate = manager.ValidarCampo(campo, txtusuario.Text, txtpass.Text);
                if(vadlidate is null)
                {
                    DialogResult = DialogResult.OK;
                    Result = false;
                    Close();
                }
                else
                {
                    DialogResult = DialogResult.OK;
                    Result = true;
                    Close();
                }

            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
