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
    public partial class InCambiarClave : BaseForm
    {
        private UsuariosManager manager = new UsuariosManager();
        public InCambiarClave()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!this.ValidarForm())
            {
                return;
            }
            var claveant = manager.ToMD5(tpass.Text);
            if (claveant != AppData.Instance.Currentuser.Password)
            {
                Mensaje("La Contraseña Anterior no es valida!!!");
                tpass.Focus();
                return;
            }
            if (tnewpass.Text != tconfirmpass.Text)
            {
                Mensaje("Las contraseñas no coinciden!");
                tnewpass.Focus();
                return;
            }
            try
            {
                var pass=manager.UpdateUserPassword(AppData.Instance.Currentuser.Username,tnewpass.Text);
                AppData.Instance.Currentuser.Password = pass;
                Mensaje("Contraseña cambiada con exito!");
                this.Close();
            }
            catch(Exception ex)
            {
                Mensaje(ex.Message);
            }
           
        }
    }
}
