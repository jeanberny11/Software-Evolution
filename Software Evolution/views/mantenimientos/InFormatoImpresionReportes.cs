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
            if (this.txtnombre.Text == string.Empty)
            {
                Mensaje("Debe poner el nombre del reporte");
                txtnombre.Focus();
                return;
            }
            if (txtnombre.Text.Substring(txtnombre.Text.Length - 4).ToLower() != ".frx")
            {
                Mensaje("Nombre de reporte invalido");
                txtnombre.Focus();
                return;
            }
            using (Report report = new Report())
            {
                report.RegisterData(manager.GetReporteHeader(), "header");
                if (txtprocedimiento.Text != string.Empty)
                {
                    try
                    {
                        var general = manager.Query(txtprocedimiento.Text,txtparametros.Text);
                        report.RegisterData(general, "general");
                    }
                    catch (Exception ex)
                    {
                        Mensaje(ex.Message);
                    }
                }

                if (Creando)
                {
                    report.FileName = txtnombre.Text;
                    report.SetName(txtnombre.Text);
                    report.Design();
                    reportebase64 = report.SaveToStringBase64();
                }
                else
                {
                    report.LoadFromString(reportebase64);
                    report.FileName = txtnombre.Text;
                    report.SetName(txtnombre.Text);
                    report.Design();
                    reportebase64 = report.SaveToStringBase64();
                }
                
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
