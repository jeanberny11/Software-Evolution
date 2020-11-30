using Software_Evolution.data;
using Software_Evolution.modalviews.ventasfacturacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Evolution.managers.general
{
    class PagosManager
    {
        private readonly QueryManager manager = QueryManager.Instance;
        public Dictionary<string,object> GetDistribucionPago(utils.clases.BaseForm parent,double monto)
        {
            Dictionary<string, object> result = null;
            InPago pago = new InPago(monto);
            var dialolresult = pago.ShowDialog(parent);
            if (dialolresult == System.Windows.Forms.DialogResult.OK)
            {
                result = pago.Distribucion;
            }
            pago.Dispose();
            return result;
        }

        public bool GetFacturaCaja()
        {
            var res = manager.Query("select f_pago_caja from t_preferencia");
            if (res.Rows.Count > 0)
            {                
                return res.Rows[0].Field<bool>("f_pago_caja");
            }
            return false;
        }
    }
}
