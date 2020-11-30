using Software_Evolution.data;
using Software_Evolution.modalviews.ventasfacturacion;
using Software_Evolution.utils.clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Evolution.managers.general
{
    class FleteManager
    {
        private readonly QueryManager manager = QueryManager.Instance;

        public DataRow getFleteTransporte(BaseForm parent)
        {
            DataRow result = null;
            QryOutTransporte flete = new QryOutTransporte();
            var dialolresult = flete.ShowDialog(parent);
            if (dialolresult == System.Windows.Forms.DialogResult.OK)
            {
                result = flete.Result;
            }
            flete.Dispose();

            return result;
        }
    }
}
