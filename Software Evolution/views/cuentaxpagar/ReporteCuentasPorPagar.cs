using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Software_Evolution.utils.clases;
using Software_Evolution.views.general;
using Software_Evolution.views.mantenimientos;
using Software_Evolution.managers.cuentaxpagar;
using FastReport;

namespace Software_Evolution.views.cuentaxpagar
{
    public partial class ReporteCuentasPorPagar : BaseForm
    {
        readonly CuentasPorPagarManager CuentasPorPagarManager = new CuentasPorPagarManager();
        private DataTable datos;
        public ReporteCuentasPorPagar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f2 = Dtos(fecha2.Value);
            datos = CuentasPorPagarManager.GetCuentaPorPagarFecha(f2);
            gridControl1.DataSource = datos;
        }

        private void btn_exportar_Click(object sender, EventArgs e)
        {
            InExportarDatos export = new InExportarDatos(gridControl1, "Cuentas Por Pagar");
            export.ShowDialog(this);
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            var reportesmanager = new managers.reportes.FormatoImpresionReportesManager();
            reportesmanager.PrintReport(this, 9000, datos, new Dictionary<string, string>());
        }

        private void btn_correo_Click(object sender, EventArgs e)
        {
            //reporte 
            var reportesmanager = new managers.reportes.FormatoImpresionReportesManager();
            var reporte=reportesmanager.GetReporte(9000, datos, new Dictionary<string, string>());
            //enviar correo
            InEnviarCorreo inEnviarCorreo = new InEnviarCorreo("info@softwareevolutionarpa.com", "", "prueba", reporte);
            inEnviarCorreo.ShowDialog(this);
        }

        private void ReporteCuentasPorPagar_Load(object sender, EventArgs e)
        {

        }
    }
}
