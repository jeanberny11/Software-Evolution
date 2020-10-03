using Software_Evolution.data;
using Software_Evolution.utils.clases;
using Software_Evolution.modalviews;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Evolution.managers.general
{
    class ProductosManager
    {
        private readonly QueryManager manager = QueryManager.Instance;

        public DataRow SelectProductoFromDialog(BaseForm parent, string filtro)
        {
            DataRow result = null;
            Qry_Out_Productos dialog = new Qry_Out_Productos(filtro);
            var dialolresult = dialog.ShowDialog(parent);
            if (dialolresult == System.Windows.Forms.DialogResult.OK)
            {
                result = dialog.Result;
            }
            dialog.Dispose();

            return result;
        }

        public DataRow GetProducto(string referencia)
        {
            var res = manager.Query($"select * from t_productos_sucursal where f_referencia='{referencia}'");
            if (res.Rows.Count > 0)
            {
                return res.Rows[0];
            }
            return null;
        }
    }
}
