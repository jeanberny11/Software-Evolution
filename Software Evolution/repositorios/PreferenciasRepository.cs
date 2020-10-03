using Software_Evolution.data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Evolution.repositorios
{
    public class PreferenciasRepository:Repository
    {
        public DataTable GetCotizacionesMonto()
        {
            try
            {
                var sql = "select a.*,get_moneda(a.f_id_moneda) as f_moneda from t_cotizaciones_por_monto a order by f_id_moneda";
                return manager.Query(sql);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetCotizacionesDepartamento()
        {
            try
            {
                var sql = "select d.f_iddepto,d.f_descripcion,m.f_monto_minimo,m.f_id_moneda,get_moneda(m.f_id_moneda) as f_moneda " +
                    "from t_monto_minimo_departamento m,nomina.t_departamento d where m.f_id_departamento = d.f_iddepto";
                return manager.Query(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataRow GetPreferencias()
        {
            try
            {
                var sql = "select * from t_preferencia";
                var result = manager.Query(sql);
                if (result.Rows.Count > 0)
                {
                    return result.Rows[0];
                }
                return null;
            }catch(Exception ex)
            {
                throw ex;
            }

        }

        public void SavePreferencias(Dictionary<string,object> data)
        {
            try
            {
                manager.UpdateRecord("t_preferencia", data, $"where f_id={data["f_id"]}");                
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
