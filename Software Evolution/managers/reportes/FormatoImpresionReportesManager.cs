using Software_Evolution.data;
using System;
using System.Collections.Generic;
using System.Data;
using FastReport;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Evolution.managers.reportes
{
    class FormatoImpresionReportesManager
    {
        private readonly QueryManager manager = QueryManager.Instance;

        public DataTable GetFormatos()
        {
            var sql = "select f_id,f_descripcion,get_descripcion_formato_rep(f_formato_impresion)as tipo from t_formato_impresion_reportes order by tipo,f_id";
            return manager.Query(sql);
        }

        public DataRow GetFormato(int id)
        {
            var sql = $"select * from t_formato_impresion_reportes where f_id={id}";
            var result = manager.Query(sql);
            if (result.Rows.Count > 0)
            {
                return result.Rows[0];
            }
            return null;
        }        

        private DataTable GetReporteHeader()
        {
            var sql = $"select '{AppData.Instance.Currentuser.Nombre}' as usuario,f_empresa as f_empresa,f_telefono as telefono,f_direccion as direccion,f_nombrecia as f_nombrecia,f_rnc as f_rnc,f_email,f_fax from t_preferencia";
            return manager.Query(sql);
        }

        public string EditarFormato(string nombrereporte, string reportebase64, string procedurename, string param)
        {
            string result = "";            
            using (Report report = new Report())
            {
                if (reportebase64==string.Empty)
                {
                    report.RegisterData(GetReporteHeader(), "fxheader");
                    report.RegisterData(manager.QueryProcedure(procedurename, param), "fxgeneral");
                    report.SetName(nombrereporte);
                    report.Design();
                    result = report.SaveToStringBase64();
                }
                else
                {
                    report.LoadFromString(reportebase64);
                    report.RegisterData(GetReporteHeader(), "fxheader");
                    report.RegisterData(manager.QueryProcedure(procedurename, param), "fxgeneral");
                    report.FileName = nombrereporte;
                    report.SetName(nombrereporte);
                    report.Design();
                    result = report.SaveToStringBase64();
                }
            }
            return result;
        }

        public void SalvarReporte(bool creando, Dictionary<string, object> datos)
        {
            manager.BeginWork();
            try
            {
                if (creando)
                {
                    manager.CreateRecord("t_formato_impresion_reportes", datos);
                }
                else
                {
                    manager.UpdateRecord("t_formato_impresion_reportes", datos, $"where f_id={datos["f_id"]}");
                }
                manager.CommitWork();
            }catch(Exception ex)
            {
                manager.RollBack();
                throw ex;
            }
           
        }

        public int Get_tipo_papel_reportes(string campo)
        {
            var res = manager.Query($"select {campo} from t_preferencia");
            if (res.Rows.Count > 0)
            {
                return res.Rows[0].Field<int>(campo);
            }
            return 0;
        }

        public void PrintReport(IWin32Window parent, int formatoid, DataTable reportdata, Dictionary<string, string> parameters)
        {
            var formato = GetFormato(formatoid);
            if (formato is null)
            {
                throw new Exception("No se encontro el formato solicitado");
            }
            using (Report report = new Report())
            {
                report.LoadFromString(formato.Field<string>("f_archivo"));
                report.RegisterData(GetReporteHeader(), "fxheader");
                report.RegisterData(reportdata, "fxgeneral");
                report.FileName = formato.Field<string>("f_nombre_archivo");
                report.SetName(formato.Field<string>("f_nombre_archivo"));
                foreach (KeyValuePair<string, string> entry in parameters)
                {
                    report.SetParameterValue(entry.Key, entry.Value);
                }
                report.Prepare();
                if (formato.Field<bool>("f_impresion_por_pantalla"))
                {
                    report.ShowPrepared(modal: true, owner: parent);
                }
                else
                {
                    report.PrintSettings.ShowDialog = true;
                    report.Print();
                }
            }
        }

        public Report GetReporte(int formatoid, DataTable reportdata, Dictionary<string, string> parameters)
        {
            var formato = GetFormato(formatoid);
            if (formato is null)
            {
                throw new Exception("No se encontro el formato solicitado");
            }
            Report report = new Report();
            report.LoadFromString(formato.Field<string>("f_archivo"));
            report.RegisterData(GetReporteHeader(), "fxheader");
            report.RegisterData(reportdata, "fxgeneral");
            report.FileName = formato.Field<string>("f_nombre_archivo");
            report.SetName(formato.Field<string>("f_nombre_archivo"));
            foreach (KeyValuePair<string, string> entry in parameters)
            {
                report.SetParameterValue(entry.Key, entry.Value);
            }
            report.Prepare();
            return report;
        }
    }
}
