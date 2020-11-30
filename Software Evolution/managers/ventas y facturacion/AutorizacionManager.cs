using Software_Evolution.data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Evolution.managers.ventas_y_facturacion
{
    class AutorizacionManager
    {
        private readonly QueryManager manager = QueryManager.Instance;

        public DataRow GetAutorizacionPendienteCliente(int clienteid)
        {
            var result= manager.Query($"select * from t_autorizaciones_venta where (f_estado=false or f_aplicada=false) and f_rechazada=false and f_cliente={clienteid}");
            if (result.Rows.Count > 0)
            {
                return result.Rows[0];
            }
            return null;
        }

        public int GetSecuenciAutorizacion()
        {
            return manager.GetSecuencia(manager.GetTipoDoc(150));
        }

        public void CreateAutorizacion(int tipo,double monto,DateTime fecha,string hora,int vendedorid,int clienteid)
        {
            var datos = new Dictionary<string, object>();
            datos.Add("f_id", GetSecuenciAutorizacion());
            datos.Add("f_tipo", tipo);
            datos.Add("f_monto", monto);
            datos.Add("f_fecha", fecha);
            datos.Add("f_hora", hora);
            datos.Add("f_vendedor", vendedorid);
            datos.Add("f_cliente", clienteid);
            manager.CreateRecord("t_autorizaciones_venta", datos);
        }
    }
}
