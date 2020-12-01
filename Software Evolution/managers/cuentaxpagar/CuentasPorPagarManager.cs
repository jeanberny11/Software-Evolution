using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Software_Evolution.data;

namespace Software_Evolution.managers.cuentaxpagar
{
    class CuentasPorPagarManager
    {
        private readonly QueryManager manager = QueryManager.Instance;

        public DataTable GetCuentaPorPagarFecha(string fecha2)
        { 
        return manager.QueryProcedure("p_reporte_cuenta_pagar_fecha", $"'{fecha2}'");
    }
}
}
