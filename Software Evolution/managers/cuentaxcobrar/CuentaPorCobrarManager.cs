using Software_Evolution.data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Evolution.managers.cuentaxcobrar
{
    class CuentaPorCobrarManager
    {
        private readonly QueryManager manager = QueryManager.Instance;

        public DataTable GetCuentaPorCobrarFecha(string fecha1,string fecha2)
        {
            return manager.QueryProcedure("p_reporte_cuenta_cobrar_fecha", $"'{fecha1}','{fecha2}'");
        }
    }
}
