using Software_Evolution.managers.ventas_y_facturacion;
using Software_Evolution.utils.clases;
using Software_Evolution.views.general;
using Software_Evolution.views.mantenimientos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Evolution.views.Venta_Y_Facturacion
{
    public partial class OutCotizaciones : BaseForm
    {
        private CotizacionManager manager = new CotizacionManager();
        private DataTable cotizaciones;
        public OutCotizaciones()
        {
            InitializeComponent();
            txtfecha1.Value = DateTime.Now;
            txtfecha2.Value = DateTime.Now;
        }

        private void Buscar()
        {
            var fecha1 = Dtos(txtfecha1.Value);
            var fecha2 = Dtos(txtfecha2.Value);
            cotizaciones = manager.GetCotizacionesFecha(fecha1, fecha2);
            gridControl1.DataSource = cotizaciones;
            Refresh();
        }

        private void txtfecha1_ValueChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void txtfecha2_ValueChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            var form =new InCotizaciones();
            (this.ParentForm as Principal).ShowOrFocusForm(form);
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_correo_Click(object sender, EventArgs e)
        {
            if (ValidarGrid(gridView1))
            {
                var data = cotizaciones.Rows[gridView1.GetSelectedRows()[0]];
                try
                {
                    manager.EnviarCotizacionCorreo(this, data.Field<string>("f_documento"), data.Field<string>("f_email"));
                }catch(Exception ex)
                {
                    Mensaje(ex.Message);
                }
            }
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            if (ValidarGrid(gridView1))
            {
                try
                {
                    manager.PrintCotizacion(this, gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "f_documento").ToString());
                }
                catch (Exception ex)
                {
                    Mensaje(ex.Message);
                }
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                if (cotizaciones.Rows[e.RowHandle].Field<bool>("f_cancelada"))
                {
                    Mensaje("Esta cotizacion esta cancelada!");
                    return;
                }
                var documento = cotizaciones.Rows[e.RowHandle].Field<string>("f_documento");
                var form = new InCotizaciones(documento);
                (this.ParentForm as Principal).ShowOrFocusForm(form);
            }
        }

        private void btn_exportar_Click(object sender, EventArgs e)
        {
            InExportarDatos exportarDatos = new InExportarDatos(gridControl1,"Cotizaciones");
            exportarDatos.ShowDialog(this);
        }
    }
}
