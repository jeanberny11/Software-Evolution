using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Evolution.repositorios
{
    public class CotizacionMontoRepository:Repository
    {
        private readonly string tabla = "t_cotizaciones_por_monto";
        public CotizacionMontoRepository() { }

        public int DeleteAll()
        {
            try
            {
                return manager.Execute($"delete from {tabla}");
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Create(DataRow row)
        {
            try
            {
                manager.SaveRecord(tabla, new Dictionary<string, object>
                {
                    ["f_monto_inicial"] = row.Field<double>("f_monto_inicial"),
                    ["f_monto_final"] = row.Field<double>("f_monto_final"),
                    ["f_cantidad_cotizaciones"] = row.Field<int>("f_cantidad_cotizaciones"),
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
