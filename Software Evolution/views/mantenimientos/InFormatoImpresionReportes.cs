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
using FastReport;
using Software_Evolution.managers.reportes;

namespace Software_Evolution.views.mantenimientos
{
    public partial class InFormatoImpresionReportes : BaseForm
    {
        private string reportebase64="";
        FormatoImpresionReportesManager manager = new FormatoImpresionReportesManager();
        public InFormatoImpresionReportes()
        {
            InitializeComponent();
            cmb_tipoformato.LoadData();
            Creando = true;
        }

        public InFormatoImpresionReportes(int id) : this()
        {
            Creando = false;
            var data = manager.GetFormato(id);
            if(data is null){
                Mensaje("No se encontro el formato");
                return;
            }
            Modificar(data);
            reportebase64 = data.Field<string>("f_archivo");

        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {
                reportebase64 = manager.EditarFormato(txtnombre.Text, reportebase64, txtprocedimiento.Text, txtparametros.Text);
            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!ValidarForm())
            {
                return;
            }

            if (reportebase64 == string.Empty)
            {
                Mensaje("No se encontro el diseño del reporte");
                return;
            }

            if(!ConfirmarMensaje("Desea salvar este registro?"))
            {
                return;
            }
            Dictionary<string, object> datos = new Dictionary<string, object>();
            Grabar(datos);
            datos["f_archivo"] = reportebase64;
            try
            {
                manager.SalvarReporte(Creando, datos);
            }catch(Exception ex)
            {
                Mensaje(ex.Message);
                return;
            }
            Close();
        }
    }
}
