using Software_Evolution.data;
using Software_Evolution.modalviews;
using Software_Evolution.utils.clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Evolution.managers.contabilidad
{
    public class CuentasContablesManager
    {
        private readonly QueryManager queryManager = QueryManager.Instance;
        public CuentasContablesManager()
        {

        }

        public DataRow GetCuentaByID(String cuenta)
        {
            try
            {
                var sql = $"SELECT f_no_cuenta,f_descripcion,f_cuenta_control,f_naturalezacuenta,f_tienesubcuentas,f_grupo_general,f_maneja_centro_costos," +
                    $"  f_maneja_flujo_efectivo,f_maneja_terceros,f_no_catalogo,f_aplicar_ajuste_inflacion,f_maneja_bases,f_activa," +
                    $"f_tipo_actividad,f_maneja_presupesto,f_centro_costo,f_centro_costo_fijo,f_nivel,f_tipo,f_tipo_actividad_concepto1," +
                    $"f_tipo_actividad_concepto2,f_descripcion2,f_cuenta_asociada,f_moneda,f_cuenta_prima,f_fecha_registro,f_estado," +
                    $"f_clasificacion,f_proyecto,f_fideicomiso FROM t_cuentas_contables where f_no_cuenta='{cuenta}'";
                var result = queryManager.Query(sql);
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

        public string SelectCuentaFromDialog(BaseForm parent)
        {

            string result = "";
            CuentasContablesGet dialog = new CuentasContablesGet();
            var dialolresult = dialog.ShowDialog(parent);
            if (dialolresult == System.Windows.Forms.DialogResult.OK)
            {
                result = dialog.Result;
            }
            dialog.Dispose();
            return result;
        }
    }
}
