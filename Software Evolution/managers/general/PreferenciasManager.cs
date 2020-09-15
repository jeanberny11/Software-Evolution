using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Software_Evolution.repositorios;

namespace Software_Evolution.managers.general
{
    class PreferenciasManager
    {
        PeriodosContablesRepository periodosContables = new PeriodosContablesRepository();
        SecuenciaRepository secuenciaRepository = new SecuenciaRepository();


        public DataTable GetPeriodosContables()
        {
            return periodosContables.GetPeriodosContables();
        }

        public int BloquearPeriodo(int periodoid)
        {
            return periodosContables.BloquearPeriodo(periodoid);
        }

        public int DesBloquearPeriodo(int periodoid)
        {
            return periodosContables.DesBloquearPeriodo(periodoid);
        }

        public DataSet GetSecuencias()
        {
            return secuenciaRepository.GetSecuenciasLive();
        }

        public int UpdateSecuencias(DataSet data)
        {
            return secuenciaRepository.SaveSecuencias(data);
        }
    }
}
