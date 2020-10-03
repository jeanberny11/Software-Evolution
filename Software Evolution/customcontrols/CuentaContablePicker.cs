using Software_Evolution.managers.contabilidad;
using Software_Evolution.utils.clases;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Software_Evolution.customcontrols
{
    public class CuentaContablePicker : FlowLayoutPanel, IEvBaseComponent<string>
    {
        private EvTextBox txtcuenta;
        private EvTextBox txtdescripcion;
        private LinkLabel lblcuenta;
        private Panel labelarea;
        private Panel idarea;
        private Panel nombrearea;
        private readonly CuentasContablesManager manager = new CuentasContablesManager();        
        public Size LaberAreaSize { get => this.labelarea.Size; set => this.labelarea.Size = value; }
        public Size IdAreaSize { get => this.idarea.Size; set => this.idarea.Size = value; }
        public Size NombreAreaSize { get => this.nombrearea.Size; set => this.nombrearea.Size = value; }
        public Size TxtCuentaSize { get => this.txtcuenta.Size; set => this.txtcuenta.Size = value; }
        public Size TxtDescripcionSize { get => this.txtdescripcion.Size; set => this.txtdescripcion.Size = value; }

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
        [Description("Indica si el componente de puede habilitar y deshabilitar")]
        public bool IsActivar { get; set; } = true;

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("El nombre del campo de la tabla al que debe guardar este texto")]
        public string FieldName { get; set; } = "";
        public string Valor { get => this.txtcuenta.Valor; set {
                this.txtcuenta.Valor = value;
                buscar();
            } }

        public BaseForm parent { get; set; }

        public string NombreCuenta { get => this.lblcuenta.Text; set => this.lblcuenta.Text = value; }


        public bool IsEmpty()
        {
            return this.txtcuenta.IsEmpty();
        }

        public bool IsValid()
        {
            return txtcuenta.IsValid();
        }

        public void Limpiar()
        {
            this.txtcuenta.Limpiar();
            this.txtdescripcion.Limpiar();
        }

        public CuentaContablePicker()
        {
            InitializeComponent();
            labelarea.Controls.Add(lblcuenta);
            idarea.Controls.Add(txtcuenta);
            nombrearea.Controls.Add(txtdescripcion);
            this.Controls.Add(labelarea);
            this.Controls.Add(idarea);
            this.Controls.Add(nombrearea);
        }

        private void buscar()
        {
            if (!this.txtcuenta.IsEmpty())
            {
                DataRow res = manager.GetCuentaByID(this.txtcuenta.Valor);
                if (res != null)
                {            
                    this.txtdescripcion.Text = res.Field<string>("f_descripcion") ;
                }
            }
        }

        private void InitializeComponent()
        {
            this.lblcuenta = new System.Windows.Forms.LinkLabel();
            this.labelarea = new System.Windows.Forms.Panel();
            this.idarea = new System.Windows.Forms.Panel();
            this.nombrearea = new System.Windows.Forms.Panel();
            this.txtcuenta = new Software_Evolution.customcontrols.EvTextBox();
            this.txtdescripcion = new Software_Evolution.customcontrols.EvTextBox();
            this.SuspendLayout();
            // 
            // lblcuenta
            // 
            this.lblcuenta.AutoSize = true;
            this.lblcuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcuenta.Location = new System.Drawing.Point(0, 0);
            this.lblcuenta.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblcuenta.Name = "lblcuenta";
            this.lblcuenta.Size = new System.Drawing.Size(100, 23);
            this.lblcuenta.TabIndex = 0;
            this.lblcuenta.TabStop = true;
            this.lblcuenta.Text = "Vendedor";
            this.lblcuenta.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblcuenta_LinkClicked);
            // 
            // labelarea
            // 
            this.labelarea.Location = new System.Drawing.Point(0, 0);
            this.labelarea.Name = "labelarea";
            this.labelarea.Size = new System.Drawing.Size(200, 25);
            this.labelarea.TabIndex = 0;
            // 
            // idarea
            // 
            this.idarea.Location = new System.Drawing.Point(0, 0);
            this.idarea.Name = "idarea";
            this.idarea.Size = new System.Drawing.Size(200, 25);
            this.idarea.TabIndex = 0;
            // 
            // nombrearea
            // 
            this.nombrearea.Location = new System.Drawing.Point(0, 0);
            this.nombrearea.Name = "nombrearea";
            this.nombrearea.Size = new System.Drawing.Size(200, 25);
            this.nombrearea.TabIndex = 0;
            // 
            // txtcuenta
            // 
            this.txtcuenta.EnterTab = true;
            this.txtcuenta.FieldName = "";
            this.txtcuenta.IsLimpiar = false;
            this.txtcuenta.IsSalvar = false;
            this.txtcuenta.IsValidar = false;
            this.txtcuenta.Location = new System.Drawing.Point(0, 0);
            this.txtcuenta.Name = "txtcuenta";
            this.txtcuenta.Size = new System.Drawing.Size(100, 22);
            this.txtcuenta.TabIndex = 0;
            this.txtcuenta.Valor = "";
            this.txtcuenta.Validated += new System.EventHandler(this.txtcuenta_Validated);
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Enabled = false;
            this.txtdescripcion.EnterTab = true;
            this.txtdescripcion.FieldName = "";
            this.txtdescripcion.IsLimpiar = false;
            this.txtdescripcion.IsSalvar = false;
            this.txtdescripcion.IsValidar = false;
            this.txtdescripcion.Location = new System.Drawing.Point(0, 0);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(100, 22);
            this.txtdescripcion.TabIndex = 0;
            this.txtdescripcion.Valor = "";
            // 
            // CuentaContablePicker
            // 
            this.Size = new System.Drawing.Size(200, 30);
            this.ResumeLayout(false);

        }

        private void lblcuenta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var cuenta = manager.SelectCuentaFromDialog(parent);
            if (cuenta != "")
            {
                this.Valor = cuenta;
            }
        }

        private void txtcuenta_Validated(object sender, EventArgs e)
        {
            buscar();
        }
    }
}
