using Software_Evolution.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Evolution.modalviews.ventasfacturacion
{
    public partial class GetCotizacionAbierta : Form
    {
        public string Result { get; set; }
        private readonly QueryManager manager = QueryManager.Instance;
        public GetCotizacionAbierta(int clienteid)
        {
            InitializeComponent();
            Buscar(clienteid);
        }

        private void Buscar(int clienteid)
        {
            var sql = (clienteid > 0) ?
                $"select *,get_nombre_usuario(f_hechopor)as usuario,get_nombre_cliente(f_cliente)as cliente,get_nombre_vendedor(f_vendedor)as vendedor from t_factura_cotizacion where get_cantidad_productos_cotizado(f_documento)>0 and f_cliente={clienteid}" :
                "select *,get_nombre_usuario(f_hechopor)as usuario,get_nombre_cliente(f_cliente)as cliente,get_nombre_vendedor(f_vendedor)as vendedor from t_factura_cotizacion where get_cantidad_productos_cotizado(f_documento)>0 ";
            var cotizaciones = manager.Query(sql);
            gridControl1.DataSource = cotizaciones;

        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                Result = gridView1.GetRowCellValue(e.RowHandle, "f_documento").ToString();
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
