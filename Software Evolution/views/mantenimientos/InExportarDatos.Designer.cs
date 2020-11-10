namespace Software_Evolution.views.mantenimientos
{
    partial class InExportarDatos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InExportarDatos));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_export = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.lbltitulo = new System.Windows.Forms.Label();
            this.evLabel1 = new Software_Evolution.customcontrols.EvLabel();
            this.cmb_formato = new System.Windows.Forms.ComboBox();
            this.evLabel2 = new Software_Evolution.customcontrols.EvLabel();
            this.txtnombre = new Software_Evolution.customcontrols.EvTextBox();
            this.evLabel3 = new Software_Evolution.customcontrols.EvLabel();
            this.button2 = new System.Windows.Forms.Button();
            this.txtfolder = new Software_Evolution.customcontrols.EvTextBox();
            this.lblextencion = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btn_export);
            this.panel1.Controls.Add(this.btn_cerrar);
            this.panel1.Controls.Add(this.lbltitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 72);
            this.panel1.TabIndex = 4;
            // 
            // btn_export
            // 
            this.btn_export.FlatAppearance.BorderSize = 0;
            this.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_export.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export.Image = ((System.Drawing.Image)(resources.GetObject("btn_export.Image")));
            this.btn_export.Location = new System.Drawing.Point(536, 11);
            this.btn_export.Margin = new System.Windows.Forms.Padding(4);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(55, 49);
            this.btn_export.TabIndex = 27;
            this.btn_export.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Fromtooltip.SetToolTip(this.btn_export, "Exportar Datos");
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.FlatAppearance.BorderSize = 0;
            this.btn_cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cerrar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cerrar.Image")));
            this.btn_cerrar.Location = new System.Drawing.Point(459, 11);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(55, 49);
            this.btn_cerrar.TabIndex = 2;
            this.Fromtooltip.SetToolTip(this.btn_cerrar, "Cerrar Pantalla");
            this.btn_cerrar.UseVisualStyleBackColor = true;
            // 
            // lbltitulo
            // 
            this.lbltitulo.AutoSize = true;
            this.lbltitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitulo.Location = new System.Drawing.Point(10, 17);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.Size = new System.Drawing.Size(185, 29);
            this.lbltitulo.TabIndex = 0;
            this.lbltitulo.Text = "Exportar Datos";
            // 
            // evLabel1
            // 
            this.evLabel1.AutoSize = true;
            this.evLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel1.Location = new System.Drawing.Point(14, 102);
            this.evLabel1.Name = "evLabel1";
            this.evLabel1.Size = new System.Drawing.Size(67, 17);
            this.evLabel1.TabIndex = 5;
            this.evLabel1.Text = "Formato";
            // 
            // cmb_formato
            // 
            this.cmb_formato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_formato.FormattingEnabled = true;
            this.cmb_formato.Items.AddRange(new object[] {
            "Archivo Pdf",
            "Archivo Microsoft Excel",
            "Archivo Microsoft Word",
            "Archivo Texto"});
            this.cmb_formato.Location = new System.Drawing.Point(143, 98);
            this.cmb_formato.Name = "cmb_formato";
            this.cmb_formato.Size = new System.Drawing.Size(327, 24);
            this.cmb_formato.TabIndex = 6;
            this.cmb_formato.SelectedIndexChanged += new System.EventHandler(this.cmb_formato_SelectedIndexChanged);
            // 
            // evLabel2
            // 
            this.evLabel2.AutoSize = true;
            this.evLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel2.Location = new System.Drawing.Point(14, 153);
            this.evLabel2.Name = "evLabel2";
            this.evLabel2.Size = new System.Drawing.Size(123, 17);
            this.evLabel2.TabIndex = 7;
            this.evLabel2.Text = "Nombre Archivo";
            // 
            // txtnombre
            // 
            this.txtnombre.EnterTab = true;
            this.txtnombre.FieldName = "";
            this.txtnombre.IsActivar = true;
            this.txtnombre.IsLimpiar = true;
            this.txtnombre.IsSalvar = true;
            this.txtnombre.IsValidar = true;
            this.txtnombre.Location = new System.Drawing.Point(143, 150);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(327, 22);
            this.txtnombre.TabIndex = 8;
            this.txtnombre.Valor = "";
            // 
            // evLabel3
            // 
            this.evLabel3.AutoSize = true;
            this.evLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel3.Location = new System.Drawing.Point(14, 203);
            this.evLabel3.Name = "evLabel3";
            this.evLabel3.Size = new System.Drawing.Size(125, 17);
            this.evLabel3.TabIndex = 9;
            this.evLabel3.Text = "Carpeta Destino";
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(476, 190);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(51, 42);
            this.button2.TabIndex = 13;
            this.Fromtooltip.SetToolTip(this.button2, "Adjuntar Archivo");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtfolder
            // 
            this.txtfolder.Enabled = false;
            this.txtfolder.EnterTab = true;
            this.txtfolder.FieldName = "";
            this.txtfolder.IsActivar = true;
            this.txtfolder.IsLimpiar = true;
            this.txtfolder.IsSalvar = false;
            this.txtfolder.IsValidar = false;
            this.txtfolder.Location = new System.Drawing.Point(143, 200);
            this.txtfolder.Name = "txtfolder";
            this.txtfolder.Size = new System.Drawing.Size(327, 22);
            this.txtfolder.TabIndex = 12;
            this.txtfolder.Valor = "";
            // 
            // lblextencion
            // 
            this.lblextencion.AutoSize = true;
            this.lblextencion.Location = new System.Drawing.Point(488, 153);
            this.lblextencion.Name = "lblextencion";
            this.lblextencion.Size = new System.Drawing.Size(0, 17);
            this.lblextencion.TabIndex = 14;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.SelectedPath = "C:\\Users\\Jean Berny\\Desktop";
            // 
            // InExportarDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 263);
            this.Controls.Add(this.lblextencion);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtfolder);
            this.Controls.Add(this.evLabel3);
            this.Controls.Add(this.txtnombre);
            this.Controls.Add(this.evLabel2);
            this.Controls.Add(this.cmb_formato);
            this.Controls.Add(this.evLabel1);
            this.Controls.Add(this.panel1);
            this.Name = "InExportarDatos";
            this.Text = "InExportarDatos";
            this.Load += new System.EventHandler(this.InExportarDatos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbltitulo;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Button btn_cerrar;
        private customcontrols.EvLabel evLabel1;
        private System.Windows.Forms.ComboBox cmb_formato;
        private customcontrols.EvLabel evLabel2;
        private customcontrols.EvTextBox txtnombre;
        private customcontrols.EvLabel evLabel3;
        private System.Windows.Forms.Button button2;
        private customcontrols.EvTextBox txtfolder;
        private System.Windows.Forms.Label lblextencion;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}