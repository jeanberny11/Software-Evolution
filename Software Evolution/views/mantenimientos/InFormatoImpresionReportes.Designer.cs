namespace Software_Evolution.views.mantenimientos
{
    partial class InFormatoImpresionReportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InFormatoImpresionReportes));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_editar = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.evLabel1 = new Software_Evolution.customcontrols.EvLabel();
            this.txtcodigo = new Software_Evolution.customcontrols.EvIntegerTextBox();
            this.cmb_tipoformato = new Software_Evolution.customcontrols.EvComboBox();
            this.evLabel2 = new Software_Evolution.customcontrols.EvLabel();
            this.evLabel3 = new Software_Evolution.customcontrols.EvLabel();
            this.evLabel4 = new Software_Evolution.customcontrols.EvLabel();
            this.evLabel5 = new Software_Evolution.customcontrols.EvLabel();
            this.txtnombre = new Software_Evolution.customcontrols.EvTextBox();
            this.txtdescripcion = new Software_Evolution.customcontrols.EvTextBox();
            this.c_activo = new Software_Evolution.customcontrols.EvCheckBox();
            this.c_mostrar = new Software_Evolution.customcontrols.EvCheckBox();
            this.report1 = new FastReport.Report();
            this.txtprocedimiento = new Software_Evolution.customcontrols.EvTextBox();
            this.txtparametros = new Software_Evolution.customcontrols.EvTextBox();
            this.evLabel6 = new Software_Evolution.customcontrols.EvLabel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtcodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_tipoformato.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btn_editar);
            this.panel1.Controls.Add(this.btn_cerrar);
            this.panel1.Controls.Add(this.btn_guardar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(713, 72);
            this.panel1.TabIndex = 3;
            // 
            // btn_editar
            // 
            this.btn_editar.FlatAppearance.BorderSize = 0;
            this.btn_editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editar.Image = ((System.Drawing.Image)(resources.GetObject("btn_editar.Image")));
            this.btn_editar.Location = new System.Drawing.Point(578, 3);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(60, 60);
            this.btn_editar.TabIndex = 30;
            this.btn_editar.UseVisualStyleBackColor = true;
            this.btn_editar.Click += new System.EventHandler(this.btn_editar_Click);
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.FlatAppearance.BorderSize = 0;
            this.btn_cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cerrar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cerrar.Image")));
            this.btn_cerrar.Location = new System.Drawing.Point(508, 3);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(60, 60);
            this.btn_cerrar.TabIndex = 2;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // btn_guardar
            // 
            this.btn_guardar.FlatAppearance.BorderSize = 0;
            this.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_guardar.Image")));
            this.btn_guardar.Location = new System.Drawing.Point(643, 3);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(60, 60);
            this.btn_guardar.TabIndex = 1;
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(387, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Formato De Impresion Reportes";
            // 
            // evLabel1
            // 
            this.evLabel1.AutoSize = true;
            this.evLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel1.Location = new System.Drawing.Point(24, 124);
            this.evLabel1.Name = "evLabel1";
            this.evLabel1.Size = new System.Drawing.Size(58, 17);
            this.evLabel1.TabIndex = 4;
            this.evLabel1.Text = "Codigo";
            // 
            // txtcodigo
            // 
            this.txtcodigo.EditValue = 0;
            this.txtcodigo.EnterTab = true;
            this.txtcodigo.FieldName = "f_id";
            this.txtcodigo.IsActivar = true;
            this.txtcodigo.IsLimpiar = true;
            this.txtcodigo.IsSalvar = true;
            this.txtcodigo.IsValidar = true;
            this.txtcodigo.Location = new System.Drawing.Point(157, 121);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Properties.Appearance.Options.UseTextOptions = true;
            this.txtcodigo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtcodigo.Properties.Mask.EditMask = "f0";
            this.txtcodigo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtcodigo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtcodigo.Size = new System.Drawing.Size(154, 22);
            this.txtcodigo.TabIndex = 5;
            // 
            // cmb_tipoformato
            // 
            this.cmb_tipoformato.DisplayMemberName = "f_descripcion";
            this.cmb_tipoformato.EnterTab = true;
            this.cmb_tipoformato.FieldName = "f_formato_impresion";
            this.cmb_tipoformato.IsActivar = true;
            this.cmb_tipoformato.IsLimpiar = true;
            this.cmb_tipoformato.IsSalvar = true;
            this.cmb_tipoformato.IsValidar = true;
            this.cmb_tipoformato.Location = new System.Drawing.Point(451, 121);
            this.cmb_tipoformato.Name = "cmb_tipoformato";
            this.cmb_tipoformato.NombreProcedimiento = "p_tipo_impresion_reportes";
            this.cmb_tipoformato.Param = "";
            this.cmb_tipoformato.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_tipoformato.Size = new System.Drawing.Size(231, 22);
            this.cmb_tipoformato.TabIndex = 6;
            this.cmb_tipoformato.Valor = null;
            this.cmb_tipoformato.ValueMemberName = "f_id";
            // 
            // evLabel2
            // 
            this.evLabel2.AutoSize = true;
            this.evLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel2.Location = new System.Drawing.Point(337, 124);
            this.evLabel2.Name = "evLabel2";
            this.evLabel2.Size = new System.Drawing.Size(104, 17);
            this.evLabel2.TabIndex = 7;
            this.evLabel2.Text = "Tipo Formato";
            // 
            // evLabel3
            // 
            this.evLabel3.AutoSize = true;
            this.evLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel3.Location = new System.Drawing.Point(24, 161);
            this.evLabel3.Name = "evLabel3";
            this.evLabel3.Size = new System.Drawing.Size(93, 17);
            this.evLabel3.TabIndex = 8;
            this.evLabel3.Text = "Descripcion";
            // 
            // evLabel4
            // 
            this.evLabel4.AutoSize = true;
            this.evLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel4.Location = new System.Drawing.Point(24, 197);
            this.evLabel4.Name = "evLabel4";
            this.evLabel4.Size = new System.Drawing.Size(127, 17);
            this.evLabel4.TabIndex = 9;
            this.evLabel4.Text = "Nombre Reporte";
            // 
            // evLabel5
            // 
            this.evLabel5.AutoSize = true;
            this.evLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel5.Location = new System.Drawing.Point(24, 234);
            this.evLabel5.Name = "evLabel5";
            this.evLabel5.Size = new System.Drawing.Size(111, 17);
            this.evLabel5.TabIndex = 10;
            this.evLabel5.Text = "Procedimiento";
            // 
            // txtnombre
            // 
            this.txtnombre.EnterTab = true;
            this.txtnombre.FieldName = "f_nombre_archivo";
            this.txtnombre.IsActivar = true;
            this.txtnombre.IsLimpiar = true;
            this.txtnombre.IsSalvar = true;
            this.txtnombre.IsValidar = true;
            this.txtnombre.Location = new System.Drawing.Point(157, 194);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(525, 22);
            this.txtnombre.TabIndex = 11;
            this.txtnombre.Valor = "";
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.EnterTab = true;
            this.txtdescripcion.FieldName = "f_descripcion";
            this.txtdescripcion.IsActivar = true;
            this.txtdescripcion.IsLimpiar = true;
            this.txtdescripcion.IsSalvar = true;
            this.txtdescripcion.IsValidar = true;
            this.txtdescripcion.Location = new System.Drawing.Point(157, 158);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(525, 22);
            this.txtdescripcion.TabIndex = 12;
            this.txtdescripcion.Valor = "";
            // 
            // c_activo
            // 
            this.c_activo.AutoSize = true;
            this.c_activo.Checked = true;
            this.c_activo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.c_activo.DefaultValue = true;
            this.c_activo.EnterTab = false;
            this.c_activo.FieldName = "f_activo";
            this.c_activo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c_activo.IsActivar = true;
            this.c_activo.IsLimpiar = false;
            this.c_activo.IsSalvar = true;
            this.c_activo.IsValidar = false;
            this.c_activo.Location = new System.Drawing.Point(158, 84);
            this.c_activo.Name = "c_activo";
            this.c_activo.Size = new System.Drawing.Size(74, 21);
            this.c_activo.TabIndex = 14;
            this.c_activo.Text = "Activo";
            this.c_activo.UseVisualStyleBackColor = true;
            this.c_activo.Valor = true;
            // 
            // c_mostrar
            // 
            this.c_mostrar.AutoSize = true;
            this.c_mostrar.Checked = true;
            this.c_mostrar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.c_mostrar.DefaultValue = true;
            this.c_mostrar.EnterTab = false;
            this.c_mostrar.FieldName = "f_impresion_por_pantalla";
            this.c_mostrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c_mostrar.IsActivar = true;
            this.c_mostrar.IsLimpiar = false;
            this.c_mostrar.IsSalvar = true;
            this.c_mostrar.IsValidar = false;
            this.c_mostrar.Location = new System.Drawing.Point(302, 84);
            this.c_mostrar.Name = "c_mostrar";
            this.c_mostrar.Size = new System.Drawing.Size(173, 21);
            this.c_mostrar.TabIndex = 15;
            this.c_mostrar.Text = "Mostrar En Pantalla";
            this.c_mostrar.UseVisualStyleBackColor = true;
            this.c_mostrar.Valor = true;
            // 
            // report1
            // 
            this.report1.NeedRefresh = false;
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            this.report1.Tag = null;
            // 
            // txtprocedimiento
            // 
            this.txtprocedimiento.EnterTab = true;
            this.txtprocedimiento.FieldName = "f_procedimiento";
            this.txtprocedimiento.IsActivar = true;
            this.txtprocedimiento.IsLimpiar = true;
            this.txtprocedimiento.IsSalvar = true;
            this.txtprocedimiento.IsValidar = true;
            this.txtprocedimiento.Location = new System.Drawing.Point(157, 231);
            this.txtprocedimiento.Name = "txtprocedimiento";
            this.txtprocedimiento.Size = new System.Drawing.Size(525, 22);
            this.txtprocedimiento.TabIndex = 16;
            this.txtprocedimiento.Valor = "";
            // 
            // txtparametros
            // 
            this.txtparametros.EnterTab = true;
            this.txtparametros.FieldName = "f_parametros";
            this.txtparametros.IsActivar = true;
            this.txtparametros.IsLimpiar = true;
            this.txtparametros.IsSalvar = true;
            this.txtparametros.IsValidar = true;
            this.txtparametros.Location = new System.Drawing.Point(157, 268);
            this.txtparametros.Name = "txtparametros";
            this.txtparametros.Size = new System.Drawing.Size(525, 22);
            this.txtparametros.TabIndex = 18;
            this.txtparametros.Valor = "";
            // 
            // evLabel6
            // 
            this.evLabel6.AutoSize = true;
            this.evLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel6.Location = new System.Drawing.Point(24, 271);
            this.evLabel6.Name = "evLabel6";
            this.evLabel6.Size = new System.Drawing.Size(91, 17);
            this.evLabel6.TabIndex = 17;
            this.evLabel6.Text = "Parametros";
            // 
            // InFormatoImpresionReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 326);
            this.Controls.Add(this.txtparametros);
            this.Controls.Add(this.evLabel6);
            this.Controls.Add(this.txtprocedimiento);
            this.Controls.Add(this.c_mostrar);
            this.Controls.Add(this.c_activo);
            this.Controls.Add(this.txtdescripcion);
            this.Controls.Add(this.txtnombre);
            this.Controls.Add(this.evLabel5);
            this.Controls.Add(this.evLabel4);
            this.Controls.Add(this.evLabel3);
            this.Controls.Add(this.evLabel2);
            this.Controls.Add(this.cmb_tipoformato);
            this.Controls.Add(this.txtcodigo);
            this.Controls.Add(this.evLabel1);
            this.Controls.Add(this.panel1);
            this.Name = "InFormatoImpresionReportes";
            this.Text = "InFormatoImpresionReportes";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtcodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_tipoformato.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Label label1;
        private customcontrols.EvLabel evLabel1;
        private customcontrols.EvIntegerTextBox txtcodigo;
        private customcontrols.EvComboBox cmb_tipoformato;
        private customcontrols.EvLabel evLabel2;
        private customcontrols.EvLabel evLabel3;
        private customcontrols.EvLabel evLabel4;
        private customcontrols.EvLabel evLabel5;
        private customcontrols.EvTextBox txtnombre;
        private customcontrols.EvTextBox txtdescripcion;
        private customcontrols.EvCheckBox c_activo;
        private customcontrols.EvCheckBox c_mostrar;
        private System.Windows.Forms.Button btn_editar;
        private FastReport.Report report1;
        private customcontrols.EvTextBox txtprocedimiento;
        private customcontrols.EvTextBox txtparametros;
        private customcontrols.EvLabel evLabel6;
    }
}