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
        private DataTable secuenciadataset;
        private DataTable cotizacionmonto;
        private DataTable cotizaciondep;
        private int preferenciaid = 1;
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
            CenterToScreen();
            try
            {
                cmb_concepto.LoadData();
                cmb_tipoformato.LoadData();
                cmb_moneda.LoadData();
                cmb_interfacefacturacion.LoadData();
                cmb_departamento.LoadData();
                cmb_moneda2.LoadData();
                var periodos = manager.GetPeriodosContables();
                gridperiodos.DataSource = periodos;
                secuenciadataset = manager.GetSecuencias();
                gridsecuencias.DataSource = secuenciadataset;
                secuenciadataset.ColumnChanged += new DataColumnChangeEventHandler(secuencias_Column_Changed);
                cotizacionmonto = manager.GetCotizacionesMonto();
                gridcotimonto.DataSource = cotizacionmonto;
                cotizaciondep = manager.GetCotizacionesDepartamento();
                gridControl4.DataSource = cotizaciondep;
                var pref = manager.GetPreferencias();
                if (!(pref is null))
                {
                    preferenciaid = pref.Field<int>("f_id");
                    this.Modificar(pref);
                }
                if (pref.Field<string>("f_logo")!=string.Empty)
                {
                    pictureBox1.Image = Base64ToImage(pref.Field<string>("f_logo"));
                }
            }catch(Exception ex)
            {
                Mensaje("Error cargando el formulario!. \n" + ex.Message);                
            }
        }

        private void secuencias_Column_Changed(object sender, DataColumnChangeEventArgs e)
        {
            try
            {        
                manager.UpdateSecuencias(e.Row);
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (cmb_moneda.IsEmpty())
            {
                Mensaje("Debe Seleccionar la moneda!");
                cmb_moneda.Focus();
                return;
            }
            if (t_montoinicial.Valor == 0)
            {
                Mensaje("Debe Digitar el monto inicial!");
                t_montoinicial.Focus();
                return;
            }
            if (t_montofinal.Valor == 0)
            {
                Mensaje("Debe Digitar el monto final!");
                t_montofinal.Focus();
                return;
            }
            if (t_cantidadcoti.Valor == 0)
            {
                Mensaje("Debe Digitar la cantidad de cotizaciones!");
                t_cantidadcoti.Focus();
                return;
            }
            var row = cotizacionmonto.NewRow();
            row.SetField<double>("f_monto_inicial", t_montoinicial.Valor);
            row.SetField<double>("f_monto_final", t_montofinal.Valor);
            row.SetField<int>("f_cantidad_cotizaciones", t_cantidadcoti.Valor);
            row.SetField<int>("f_id_moneda", Convert.ToInt32(cmb_moneda.Valor));
            row.SetField<string>("f_moneda", cmb_moneda.Text);
            cotizacionmonto.Rows.Add(row);
            gridcotimonto.Refresh();
            t_montofinal.Limpiar();
            t_montoinicial.Limpiar();
            t_cantidadcoti.Limpiar();
            t_montoinicial.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ValidarGrid(gridView3))
            {
                cotizacionmonto.Rows.Remove(cotizacionmonto.Rows[gridView3.GetSelectedRows()[0]]);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (cmb_departamento.IsEmpty())
            {
                Mensaje("Debe seleccionar el departamento!");
                cmb_departamento.Focus();
                return;
            }
            if (t_montominimo.Valor == 0)
            {
                Mensaje("Debe poner un monto minimo!");
                t_montominimo.Focus();
                return;
            }
            if (cmb_moneda2.IsEmpty())
            {
                Mensaje("Debe seleccionar la moneda!");
                cmb_moneda2.Focus();
                return;
            }
            var row = cotizaciondep.NewRow();
            row.SetField<int>("f_iddepto", Convert.ToInt32(cmb_departamento.Valor));
            row.SetField<string>("f_descripcion",cmb_departamento.Text);
            row.SetField<double>("f_monto_minimo", t_montominimo.Valor);
            row.SetField<int>("f_id_moneda", Convert.ToInt32(cmb_moneda2.Valor));
            row.SetField<string>("f_moneda", cmb_moneda2.Text);
            cotizaciondep.Rows.Add(row);
            gridControl4.Refresh();
            t_montominimo.Limpiar();
            t_montominimo.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (ValidarGrid(gridView4))
            {
                cotizaciondep.Rows.Remove(cotizaciondep.Rows[gridView4.GetSelectedRows()[0]]);                
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!ValidarForm()) {
                return;
            }

            if(!ConfirmarMensaje("Desea salvar las preferencias?"))
            {
                return;
            }

            Dictionary<string, object> datos = new Dictionary<string, object>();
            this.Grabar(datos);
            datos["f_id"] = preferenciaid;
            if(!(pictureBox1.Image is null))
            {
                var imagestring = ImageToBase64(pictureBox1);
                datos["f_logo"] = imagestring;
            }
            try
            {
                manager.SavePreferencias(datos);
                manager.SaveCotizacionMonto(cotizacionmonto);
                manager.SaveMontoMinDep(cotizaciondep);
            }catch(Exception ex)
            {
                Mensaje(ex.Message);
                return;
            }
            this.RequireCloseConfirm = false;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            { 
                pictureBox1.Image = new Bitmap(open.FileName);
                pictureBox1.Tag = open.FileName;
            }
        }
    }
}
