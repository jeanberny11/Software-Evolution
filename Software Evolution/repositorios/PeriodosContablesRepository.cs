using Software_Evolution.data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Evolution.repositorios
{
    public class PeriodosContablesRepository
    {
        private readonly QueryManager manager = QueryManager.Instance;

        public DataTable GetPeriodosContables()
        {
            try
            {
                var sql = "select * from t_periodo_contable order by f_id";
                var result = manager.Query(sql);
                return result;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        
        public int BloquearPeriodo(int periodoid)
        {
            return manager.Execute($"update t_periodo_contable set f_activo=true where f_id={periodoid}");
        }

        public int DesBloquearPeriodo(int periodoid)
        {
            return manager.Execute($"update t_periodo_contable set f_activo=false where f_id={periodoid}");
        }
    }
}
