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
using Software_Evolution.managers.general;

namespace Software_Evolution.views.general
{
    public partial class Preferencias : BaseForm
    {
        private readonly PreferenciasManager manager = new PreferenciasManager();
        private DataSet secuenciadataset;
        public Preferencias()
        {
            InitializeComponent();
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Preferencias_Load(object sender, EventArgs e)
        {
            cmb_concepto.LoadData();
            cmb_tipoformato.LoadData();
            cmb_moneda.LoadData();
            cmb_interfacefacturacion.LoadData();
            cmb_departamento.LoadData();
            var periodos = manager.GetPeriodosContables();
            gridperiodos.DataSource = periodos;
            secuenciadataset = manager.GetSecuencias();
            gridsecuencias.DataSource = secuenciadataset.Tables[0];
            secuenciadataset.Tables[0].ColumnChanged += new DataColumnChangeEventHandler(secuencias_Column_Changed);
        }

        private void secuencias_Column_Changed(object sender, DataColumnChangeEventArgs e)
        {
            try
            {
                secuenciadataset.AcceptChanges();
                manager.UpdateSecuencias(secuenciadataset);
            }catch(Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidarGrid(gridViewperiodos))
            {
                var periodoid = (gridperiodos.DataSource as DataTable).Rows[gridViewperiodos.GetSelectedRows()[0]].Field<int>("f_id");
                try
                {
                    manager.BloquearPeriodo(periodoid);
                    gridViewperiodos.SetRowCellValue(gridViewperiodos.GetSelectedRows()[0], "f_activo", true);
                }catch(Exception ex)
                {
                    Mensaje(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ValidarGrid(gridViewperiodos))
            {
                var periodoid = (gridperiodos.DataSource as DataTable).Rows[gridViewperiodos.GetSelectedRows()[0]].Field<int>("f_id");
                try
                {
                    manager.DesBloquearPeriodo(periodoid);
                    gridViewperiodos.SetRowCellValue(gridViewperiodos.GetSelectedRows()[0], "f_activo", false);
                }
                catch (Exception ex)
                {
                    Mensaje(ex.Message);
                }
            }
        }
    }
}
