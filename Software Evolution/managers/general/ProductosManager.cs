using Software_Evolution.data;
using Software_Evolution.utils.clases;
using Software_Evolution.modalviews;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Software_Evolution.modalviews.ventasfacturacion;

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

        public DataRow GetProducto(string referencia,int almacenid)
        {
            var res = manager.Query($"select get_existencia_inventario_almacen(f_referencia,current_date,{almacenid})as f_existencia_almacen" +
                $",a.*,b.f_descripcion as f_categoria from t_productos_sucursal a,t_categorias b where  a.f_idcategoria=b.f_idcategoria and f_referencia='{referencia}'");
            if (res.Rows.Count > 0)
            {
                return res.Rows[0];
            }
            return null;
        }

        public DataRow GetVentasDecimales(double monto)
        {
            var res = manager.Query($"select * from t_ventas_decimales where f_monto={monto}");
            if (res.Rows.Count > 0)
            {
                return res.Rows[0];
            }
            return null;
        }

        public string GetMarcaProducto(string referencia)
        {
            var res = manager.Query($"select get_marca_prod(f_idmarca)as marca from t_productos_sucursal where f_referencia='{referencia}'");
            return res.Rows[0].Field<string>("marca");
        }

        public string GetCategoriaProducto(string referencia)
        {
            var res = manager.Query($"select get_categoria_prod(f_idcategoria)as categoria from t_productos_sucursal where f_referencia='{referencia}'");
            return res.Rows[0].Field<string>("categoria");
        }      
        
        public double GetCambiarPrecioProducto(BaseForm parent,string referencia)
        {
            double precio = 0;
            CambiarPrecioForm dialog = new CambiarPrecioForm(referencia);
            var dialolresult = dialog.ShowDialog(parent);
            if (dialolresult == System.Windows.Forms.DialogResult.OK)
            {
                precio = dialog.Result;
            }
            dialog.Dispose();
            return precio;
        }

        public DataTable GetExistenciaAlmacenProducto(string referencia)
        {
            return manager.Query($"SELECT get_descripcion_almacen(f_almacen)as almacen,f_existencia FROM t_almacen_productos where f_existencia>0 and f_referencia='{referencia}' order by f_almacen");
        }
    }
}
