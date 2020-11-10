using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Evolution.customcontrols
{
    public class EvProyectoCmb : EvComboBox
    {
        public EvProyectoCmb():base()
        {
            this.NombreProcedimiento = "p_proyecto";
            this.ValueMemberName = "f_id";
            this.DisplayMemberName = "f_descripcion";
        }
    }
}
