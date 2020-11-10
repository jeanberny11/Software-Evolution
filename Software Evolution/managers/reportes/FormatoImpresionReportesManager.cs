using Software_Evolution.data;
using System;
using System.Collections.Generic;
using System.Data;
using FastReport;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void SalvarReporte(bool creando,Dictionary<string,object> datos)
        {
            if (creando)
            {
                manager.CreateRecord("t_formato_impresion_reportes", datos);
            }
            else
            {
                manager.UpdateRecord("t_formato_impresion_reportes", datos, $"where f_id={datos["f_id"]}");
            }
        }

        public DataTable GetReporteHeader()
        {
            var sql = $"select '{AppData.Instance.Currentuser.Nombre}' as usuario,f_empresa as f_empresa,f_telefono as telefono,f_direccion as direccion,f_nombrecia as f_nombrecia,f_rnc as f_rnc,f_email,f_fax from t_preferencia";
            return manager.Query(sql);
        }

        public DataTable Query(string procedimiento,string parametros)
        {
            return manager.QueryProcedure(procedimiento, parametros);
        }

        public Report GetReporte(DataRow formato)
        {
            Report report = new Report();
            report.LoadFromString(formato.Field<string>("f_archivo"));
            report.FileName = formato.Field<string>("f_nombre_archivo");
            report.SetName(formato.Field<string>("f_descripcion"));
            report.RegisterData(GetReporteHeader(), "fxheader");
            return report;
        }
    }
}
