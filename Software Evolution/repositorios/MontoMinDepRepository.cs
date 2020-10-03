using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Evolution.repositorios
{
    class MontoMinDepRepository : Repository
    {
        private readonly string tabla = "t_monto_minimo_departamento";
        public MontoMinDepRepository() { }

        public int DeleteAll()
        {
            try
            {
                return manager.Execute($"delete from {tabla}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Create(DataRow row)
        {
            try
            {
                manager.CreateRecord(tabla, new Dictionary<string, object>
                {
                    ["f_id_departamento"] = row.Field<int>("f_iddepto"),
                    ["f_monto_minimo"] = row.Field<decimal?>("f_monto_minimo"),                  
                    ["f_id_moneda"] = row.Field<int>("f_id_moneda")
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
