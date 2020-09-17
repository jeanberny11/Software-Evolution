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
        PreferenciasRepository preferencias = new PreferenciasRepository();
        CotizacionMontoRepository CotizacionMontoRepository = new CotizacionMontoRepository();


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

        public DataTable GetSecuencias()
        {
            return secuenciaRepository.GetSecuencias();
        }

        public int UpdateSecuencias(DataRow row)
        {
            return secuenciaRepository.CreateOrUpdateSecuencia(row);
        }

        public DataTable GetCotizacionesMonto()
        {
            return preferencias.GetCotizacionesMonto();
        }

        public DataTable GetCotizacionesDepartamento()
        {
            return preferencias.GetCotizacionesDepartamento();
        }

        public DataRow GetPreferencias()
        {
            return preferencias.GetPreferencias();
        }

        public void SavePreferencias(Dictionary<string,object> data)
        {
            preferencias.SavePreferencias(data);
        }

        public void SaveCotizacionMonto(DataTable cotizaciones)
        {
            CotizacionMontoRepository.DeleteAll();
            foreach(DataRow row in cotizaciones.Rows)
            {
                CotizacionMontoRepository.Create(row);
            }
        }
    }
}
