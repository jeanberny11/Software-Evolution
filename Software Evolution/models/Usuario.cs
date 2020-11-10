using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Evolution.models
{
    public class Usuario
    {
        public Usuario(int codigousuario, String username, string password, string apellido, string nombre, string direccion, int idgrupo, bool permisoslibre, string telefono, string email,string emailPassword,bool cambiarprecio,bool aplicardescuentoitem)
        {
            this.Codigousuario = codigousuario;
            this.Username = username;
            this.Password = password;
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Idgrupo = idgrupo;
            this.Permisoslibre = permisoslibre;
            this.Telefono = telefono;
            this.Email = email;
            this.EmailPassword = emailPassword;
            this.CambiarPrecio = cambiarprecio;
            this.AplicarDescuentoItems = aplicardescuentoitem;
        }

        public int Codigousuario { get; set; }
        public String Username { get; set; }
        public string Password { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Idgrupo { get; set; }
        public bool Permisoslibre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string EmailPassword { get; set; }
        public bool CambiarPrecio { get; set; }
        public bool AplicarDescuentoItems { get; set; }
    }
}
