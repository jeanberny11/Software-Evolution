using Software_Evolution.managers.cuentaxcobrar;
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
using Software_Evolution.views.general;
using Software_Evolution.views.mantenimientos;



namespace Software_Evolution.views.cuentasporcobrar
{
    public partial class ReportesCuentaPorCobrar : BaseForm
    {
        CuentaPorCobrarManager cuentaPorCobrarManager = new CuentaPorCobrarManager();
        private DataTable datos;
        public ReportesCuentaPorCobrar()
        {
            InitializeComponent();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f1 = Dtos(fecha1.Value);
            var f2 = Dtos(fecha2.Value);
            datos = cuentaPorCobrarManager.GetCuentaPorCobrarFecha(f1,f2);
            gridControl1.DataSource = datos;
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            var reportesmanager = new managers.reportes.FormatoImpresionReportesManager();
            reportesmanager.PrintReport(this, 2001,datos , new Dictionary<string, string>());
        }

        private void btn_exportar_Click(object sender, EventArgs e)
        {
            InExportarDatos export = new InExportarDatos(gridControl1, "Cuentas Por Cobrar");
            export.ShowDialog(this);
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
