using Software_Evolution.data;
using Software_Evolution.modalviews.cuentaxpagar;
using Software_Evolution.utils.clases;
using Software_Evolution.views.cuentaxpagar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Evolution.managers.cuentaxpagar
{
    class SuplidoresManager
    {
        private readonly QueryManager manager = QueryManager.Instance;


        public DataTable GetSuplidores()
        {
            var sql = "select *,get_nombre_comprador(f_id_comprador)as comprador,Get_pais(f_pais)as Pais,get_ciudad(f_ciudad)as ciudad," +
                "get_estado(f_estado)as estado,get_tipo_proveedor(f_tipo_suplidor)as tipo_p from t_suplidores order by f_id";
            return manager.Query(sql);
        }

        public DataRow GetSuplidor(int suplidorid)
        {
            var res = manager.Query($"select * from t_suplidores where f_id={suplidorid}");
            if (res.Rows.Count > 0)
            {
                return res.Rows[0];
            }
            return null;
        }

        public DataTable Get_desc_x_pago_proveedor(int suplidorid)
        {
            return manager.Query($"select f_dia_inicio,f_dia_fin,f_descuento1,f_descuento2 from t_desc_x_pago_proveedor where f_proveedor={suplidorid}");
        }

        public int GetConceptos_impuesto(BaseForm parent)
        {
            int result = 0;
            Qry_out_concepto_retencion_imp dialog = new Qry_out_concepto_retencion_imp();
            var dialolresult = dialog.ShowDialog(parent);
            if (dialolresult == System.Windows.Forms.DialogResult.OK)
            {
                result = dialog.Result;
            }
            dialog.Dispose();
            return result;
        }

        public int GetConceptos_islr(BaseForm parent)
        {
            int result = 0;
            Qry_out_concepto_retencion dialog = new Qry_out_concepto_retencion();
            var dialolresult = dialog.ShowDialog(parent);
            if (dialolresult == System.Windows.Forms.DialogResult.OK)
            {
                result = dialog.Result;
            }
            dialog.Dispose();
            return result;
        }

        public DataRow ValidarRnc(string rnc)
        {
            var result = manager.Query($"select f_rif,f_nombre,f_id from t_suplidores where f_rif='{rnc}'");
            if (result.Rows.Count > 0)
            {
                return result.Rows[0];
            }
            return null;
        }

        internal void EnviarEstadoCorreo(OutSuplidores outSuplidores, int cliente, DateTime currentDate)
        {
            throw new NotImplementedException();
        }

        public void SalvarSuplidor(bool creando,Dictionary<string,object> datos,DataTable tdescuento)
        {
            manager.BeginWork();
            try
            {
                if (creando)
                {
                    datos["f_id"] = manager.GetSecuencia(manager.GetTipoDoc(2));
                    datos["f_balance"] = 0;
                    manager.CreateRecord("t_suplidores", datos);
                }
                else
                {
                    manager.UpdateRecord("t_suplidores", datos, $"where f_id={datos["f_id"]}");
                }
                manager.Execute($"delete from t_desc_x_pago_proveedor where f_proveedor={datos["f_id"]}");
                foreach(DataRow row in tdescuento.Rows)
                {
                    var data = new Dictionary<string, object>()
                    {
                        ["f_proveedor"] = datos["f_id"],
                        ["f_dia_inicio"] = row.Field<int>("f_dia_inicio"),
                        ["f_dia_fin"] = row.Field<int>("f_dia_fin"),
                        ["f_descuento1"] = row.Field<decimal>("f_descuento1"),
                        ["f_descuento2"] = row.Field<decimal>("f_descuento2"),
                        ["f_activo"]=true
                    };
                    manager.CreateRecord("t_desc_x_pago_proveedor", data);
                }

                manager.CommitWork();
            }catch(Exception ex)
            {
                manager.RollBack();
                throw ex;
            }

        }
    }
}
