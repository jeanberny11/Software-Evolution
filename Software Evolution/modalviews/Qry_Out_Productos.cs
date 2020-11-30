using Software_Evolution.data;
using Software_Evolution.utils.clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Evolution.modalviews
{
    public partial class Qry_Out_Productos : BaseForm
    {
        private readonly QueryManager manager = QueryManager.Instance;
        public DataRow Result { get; set; }

        private DataTable data;
        public Qry_Out_Productos(string filtro)
        {
            InitializeComponent();
            Buscar();
            if (filtro != string.Empty)
            {
                searchControl1.Text = filtro;                
            }
        }

        private void Buscar()
        {   
            var exist= (!(cmb_almacen.Valor is null)) ? $"get_existencia_inventario_almacen(f_referencia,current_date,{cmb_almacen.Valor})" : "get_existencia_inventario_almacen(f_referencia,current_date,1)";
            var sql = "select p.f_cigar,f_estado_producto,f_controlinventario,f_referencia_suplidor,f_precio,f_precio2,f_precio6,f_ultimocosto,f_cuenta_venta,get_subtipo_prod(f_subtipo)as subcategoria,get_grupo_prod(f_grupo)as grupo,get_divicion_prod(f_divicion)as division," +
                    $"f_year,f_almacen,{exist} as f_existencia,p.f_referencia,p.f_descripcion,p.f_precio,get_nombre_suplidor(p.f_codigo_proveedor)as nombre,c.f_descripcion as f_categoria,get_modelo_prod(p.f_idmodelo) as modelo" +
                    " from t_productos_sucursal p,t_categorias c where p.f_estado_producto=1 and p.f_idcategoria=c.f_idcategoria ";
            if(!(cmb_categoria.Valor is null))
            {
                sql += $" and p.f_idcategoria={cmb_categoria.Valor}";
            }
            if(!(cmb_subcategoria.Valor is null))
            {
                sql += $" and p.f_subtipo={cmb_subcategoria.Valor}";
            }
            sql += " order by  p.f_descripcion";
            data = manager.Query(sql);
            gridControl1.DataSource = data;
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void cmb_almacen_EditValueChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void cmb_categoria_EditValueChanged(object sender, EventArgs e)
        {
            cmb_subcategoria.Param = cmb_categoria.EditValue.ToString();
            cmb_subcategoria.LoadData();
            Buscar();
        }

        private void cmb_subcategoria_EditValueChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Qry_Out_Productos_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            cmb_almacen.LoadData();
            cmb_categoria.LoadData();
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Result = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (ValidarGrid(gridView1))
            {
                Result = gridView1.GetDataRow(gridView1.GetSelectedRows()[0]);
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                Result = gridView1.GetDataRow(e.RowHandle);
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (Result != null)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
