using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Evolution.repositorios
{
    public class SecuenciaRepository:Repository
    {
        public DataSet GetSecuenciasLive()
        {
            return manager.QueryLive("select * from t_secuencias ");
        }

        public int SaveSecuencias(DataSet data)
        {
            return manager.SaveFromDataset("t_secuencias", data);
        }
    }
}
