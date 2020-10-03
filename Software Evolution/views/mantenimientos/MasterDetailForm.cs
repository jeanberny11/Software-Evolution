using Software_Evolution.data;
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
using System.Text.Json;
using System.Text.Json.Serialization;
using Software_Evolution.models;
using Software_Evolution.customcontrols;

namespace Software_Evolution.views.mantenimientos
{
    public partial class MasterDetailForm : BaseForm
    {
        QueryManager manager = QueryManager.Instance;
        private readonly string tabla;
        private DataTable masterData;
        private MasterDetailModel masterDetailModel;       
        public MasterDetailForm(string tabla)
        {
            InitializeComponent();
            btn_guardar.Enabled = false;
            this.tabla = tabla;
            setup();
            buscar();
            createComponents();
        }

        private void setup()
        {
            try
            {
                var config = manager.Query($"select obj_description(get_oidtabla('{tabla}'),'pg_class') as config");
                if (config.Rows.Count > 0)
                {
                    var json = config.Rows[0].Field<string>("config");
                    if((json is null) || json == string.Empty)
                    {
                        throw new Exception("Esta tabla no tiene la configuracion para esta pantalla");
                    }
                    masterDetailModel = JsonSerializer.Deserialize<MasterDetailModel>(json);
                    this.lbltitulo.Text = masterDetailModel.titulo;
                    this.gridView1.Columns[0].FieldName = masterDetailModel.id;
                    this.gridView1.Columns[1].FieldName = masterDetailModel.descripcion;
                }
            }
            catch(Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        private void buscar()
        {
            try
            {
                masterData= manager.Query($"select * from {tabla} order by {masterDetailModel.id}");
                this.griddata.DataSource = masterData;
                this.Refresh();
            }catch(Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void createComponents()
        {
            var columndata = manager.Query($"select column_name,data_type from information_schema.columns where table_name='{tabla}'");
            content.Controls.Clear();
            content.RowStyles.Clear();
            content.RowCount = columndata.Rows.Count;
            for (int i = 0; i < columndata.Rows.Count; i++)
            {
                var row = columndata.Rows[i];
                content.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                var label = new EvLabel();
                label.Text = row.Field<string>("column_name").Substring(2).ToUpper();
                label.Margin = new Padding(0,5,0,5);
                var control = getControl(row.Field<string>("data_type"), row.Field<string>("column_name"));                 
                content.Controls.Add(label, 0, i);
                content.Controls.Add(control, 1, i);
            }
            content.Refresh();
        }
        //Devuelve un control basandose en el tipo de dato de la columna
        private Control getControl(string datatype, string fieldname)
        {
            switch (datatype)
            {
                case "integer":
                    {
                        var forein = masterDetailModel.foreinfields.Find(x=>x.fieldname==fieldname);
                        if(!(forein is null))
                        {
                            var control = new EvComboBox();
                            control.FieldName = forein.fieldname;
                            control.NombreProcedimiento = forein.procedurename;
                            control.ValueMemberName = forein.valuename;
                            control.DisplayMemberName = forein.displayname;
                            control.Param = forein.param;
                            control.EnterTab = true;
                            control.IsLimpiar = true;
                            control.IsValidar = true;
                            control.IsSalvar = true;
                            control.Enabled = false;
                            control.Dock = DockStyle.Fill;
                            control.LoadData();
                            return control;
                        }
                        else
                        {
                            var control = new EvIntegerTextBox();
                            control.FieldName = fieldname;
                            control.EnterTab = true;
                            control.IsLimpiar = true;
                            control.IsValidar = true;
                            control.IsSalvar = ((fieldname == masterDetailModel.id && !masterDetailModel.autoincrement) || fieldname != masterDetailModel.id);
                            control.Enabled = false;
                            control.Dock = DockStyle.Fill;
                            control.IsActivar = (fieldname != masterDetailModel.id);
                            return control;
                        }
                        
                    }
                case "character varying":
                    {
                        var forein = masterDetailModel.foreinfields.Find(x => x.fieldname == fieldname);
                        if (!(forein is null))
                        {
                            var control = new EvComboBox();
                            control.FieldName = forein.fieldname;
                            control.NombreProcedimiento = forein.procedurename;
                            control.ValueMemberName = forein.valuename;
                            control.DisplayMemberName = forein.displayname;
                            control.Param = forein.param;
                            control.EnterTab = true;
                            control.IsLimpiar = true;
                            control.IsValidar = true;
                            control.IsSalvar = true;
                            control.Enabled = false;
                            control.Dock = DockStyle.Fill;
                            control.LoadData();
                            return control;
                        }
                        else
                        {
                            var control = new EvTextBox
                            {
                                FieldName = fieldname,
                                EnterTab = true,
                                IsLimpiar = true,
                                IsValidar = true,
                                IsSalvar = ((fieldname == masterDetailModel.id && !masterDetailModel.autoincrement) || fieldname != masterDetailModel.id),
                                Enabled = false,
                                Dock = DockStyle.Fill,
                                IsActivar = (fieldname != masterDetailModel.id)
                        };
                            return control;
                        }                        
                    }
                case "numeric":
                    {
                        var control = new EvNumericTextBox();
                        control.FieldName = fieldname;
                        control.EnterTab = true;
                        control.IsLimpiar = true;
                        control.IsValidar = true;
                        control.IsSalvar = ((fieldname == masterDetailModel.id && !masterDetailModel.autoincrement) || fieldname != masterDetailModel.id);
                        control.Enabled = false;
                        control.Dock = DockStyle.Fill;
                        control.IsActivar = (fieldname != masterDetailModel.id);
                        return control;
                    }
                case "boolean":
                    {
                        var control = new EvCheckBox();
                        control.FieldName = fieldname;
                        control.EnterTab = true;
                        control.IsLimpiar = true;
                        control.IsValidar = true;
                        control.IsSalvar = ((fieldname == masterDetailModel.id && !masterDetailModel.autoincrement) || fieldname != masterDetailModel.id);
                        control.Enabled = false;
                        control.IsActivar = (fieldname!=masterDetailModel.id);
                        return control;
                    }
                default:
                    {
                        throw new NotSupportedException();
                    }
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            Limpiar();
            Modificar(masterData.Rows[gridView1.GetSelectedRows()[0]]);
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (ValidarGrid(gridView1))
            {
                Limpiar();
                Modificar(masterData.Rows[gridView1.GetSelectedRows()[0]]);
                Activar(true);
                griddata.Enabled = false;
                btn_buscar.Enabled = false;
                btn_nuevo.Enabled = false;
                btn_editar.Enabled = false;
                btn_guardar.Enabled = true;
                Creando = false;
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Activar(true);
            griddata.Enabled = false;
            btn_buscar.Enabled = false;
            btn_editar.Enabled = false;
            btn_guardar.Enabled = true;
            btn_nuevo.Enabled = false;
            Creando = true;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if(!ConfirmarMensaje("Desea salvar los datos?"))
            {
                return;
            }
            var datos =new Dictionary<string, object>();
            Grabar(datos);
            if(Creando && !masterDetailModel.autoincrement)
            {
                datos[masterDetailModel.id] = manager.GetSecuencia(manager.GetTipoDoc(masterDetailModel.tipodoc));
            }
            if (Creando)
            {
                manager.CreateRecord(tabla, datos);
            }
            else
            {
                manager.UpdateRecord(tabla, datos, $"where {masterDetailModel.id}={datos[masterDetailModel.id]}");
            }
            btn_guardar.Enabled = false;
            btn_nuevo.Enabled = true;
            btn_buscar.Enabled = true;
            btn_editar.Enabled = true;
            griddata.Enabled = true;
            Activar(false);
            Limpiar();
            buscar();
        }
    }
}
