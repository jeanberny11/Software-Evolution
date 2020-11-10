using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Software_Evolution.data;

namespace Software_Evolution.customcontrols
{
    public class EvComboBox : LookUpEdit, IEvBaseComponent<object>
    {
        private new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit fProperties;

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Hace que la tecla enter funcione como 'TAB'")]
        public bool EnterTab { get; set; } = true;

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Indica si hay que validar que el texto no este vacio")]
        public bool IsValidar { get; set; } = true;

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Indica si hay que limpiar el texto")]
        public bool IsLimpiar { get; set; } = true;

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Indica si el text se va a salvar")]
        public bool IsSalvar { get; set; } = true;

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("El nombre del campo de la tabla al que debe guardar este texto")]
        public string FieldName { get; set; } = "";

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Indica si el componente de puede habilitar y deshabilitar")]
        public bool IsActivar { get; set; } = true;


        public object Valor { get =>this.EditValue; set=>this.EditValue=value ; }
        [Browsable(true)]
        [Category("Extended Properties")]
        public String NombreProcedimiento { get; set; }
        [Browsable(true)]
        [Category("Extended Properties")]
        public String DisplayMemberName { get; set; }
        [Browsable(true)]
        [Category("Extended Properties")]
        public String ValueMemberName { get; set; }
        [Browsable(true)]
        [Category("Extended Properties")]
        public String Param { get; set; } = "";

        public EvComboBox()
        {
            InitializeComponent();
            this.Properties.NullText = "";
        }

        public bool IsEmpty()
        {
            return this.EditValue is null;
        }


        public void Limpiar()
        {
            this.EditValue = null;
        }

        public void LoadData()
        {
            if (NombreProcedimiento == "")
            {
                throw new Exception("No se ha especificado el nombre del procedimiento");                
            }
            var qm = QueryManager.Instance;
            var data = qm.QueryProcedure(NombreProcedimiento, Param);
            this.Properties.DataSource = data;
            this.Properties.ValueMember = ValueMemberName;
            this.Properties.DisplayMember = DisplayMemberName;
            this.Properties.Columns.Clear();
            this.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(DisplayMemberName,"Descripcion",35));
            this.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(ValueMemberName, "ID", 10));
        }

        public bool IsValid()
        {
            return !(this.EditValue is null);
        }

        private void InitializeComponent()
        {
            this.fProperties = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.fProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // fProperties
            // 
            this.fProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fProperties.Name = "fProperties";
            // 
            // EvComboBox
            // 
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EvComboBox_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.fProperties)).EndInit();
            this.ResumeLayout(false);

        }

        private void EvComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.Clicks==1) {
                this.Limpiar();
            }
        }
    }
}
