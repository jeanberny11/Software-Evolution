
namespace Software_Evolution.views.cuentasporcobrar
{
    partial class ReportesCuentaPorCobrar
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Codigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Nombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Dias_Credito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.No_Documento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Fecha_Documento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Fecha_Vencimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Monto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Balance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Moneda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.btn_correo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_exportar = new System.Windows.Forms.Button();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.lbltitulo = new System.Windows.Forms.Label();
            this.fecha1 = new Software_Evolution.customcontrols.EvDateTimePicker();
            this.fecha2 = new Software_Evolution.customcontrols.EvDateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(0, 77);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(796, 361);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Codigo,
            this.Nombre,
            this.Dias_Credito,
            this.No_Documento,
            this.Fecha_Documento,
            this.Fecha_Vencimiento,
            this.Monto,
            this.Balance,
            this.Moneda});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // Codigo
            // 
            this.Codigo.Caption = "Codigo";
            this.Codigo.FieldName = "f_id";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = true;
            this.Codigo.VisibleIndex = 0;
            this.Codigo.Width = 46;
            // 
            // Nombre
            // 
            this.Nombre.Caption = "Nombre";
            this.Nombre.FieldName = "f_nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.Visible = true;
            this.Nombre.VisibleIndex = 1;
            this.Nombre.Width = 237;
            // 
            // Dias_Credito
            // 
            this.Dias_Credito.Caption = "Dias Credito";
            this.Dias_Credito.FieldName = "f_dias_credito";
            this.Dias_Credito.Name = "Dias_Credito";
            this.Dias_Credito.Visible = true;
            this.Dias_Credito.VisibleIndex = 2;
            this.Dias_Credito.Width = 69;
            // 
            // No_Documento
            // 
            this.No_Documento.Caption = "No Documento";
            this.No_Documento.FieldName = "f_nodoc";
            this.No_Documento.Name = "No_Documento";
            this.No_Documento.Visible = true;
            this.No_Documento.VisibleIndex = 3;
            this.No_Documento.Width = 82;
            // 
            // Fecha_Documento
            // 
            this.Fecha_Documento.Caption = "Fecha";
            this.Fecha_Documento.FieldName = "f_fecha";
            this.Fecha_Documento.Name = "Fecha_Documento";
            this.Fecha_Documento.Visible = true;
            this.Fecha_Documento.VisibleIndex = 4;
            this.Fecha_Documento.Width = 62;
            // 
            // Fecha_Vencimiento
            // 
            this.Fecha_Vencimiento.Caption = "Vencimiento";
            this.Fecha_Vencimiento.FieldName = "f_fecha_vencimiento";
            this.Fecha_Vencimiento.Name = "Fecha_Vencimiento";
            this.Fecha_Vencimiento.Visible = true;
            this.Fecha_Vencimiento.VisibleIndex = 5;
            this.Fecha_Vencimiento.Width = 81;
            // 
            // Monto
            // 
            this.Monto.Caption = "Monto";
            this.Monto.FieldName = "f_monto";
            this.Monto.Name = "Monto";
            this.Monto.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "f_monto", "{0:#.##}")});
            this.Monto.Visible = true;
            this.Monto.VisibleIndex = 6;
            this.Monto.Width = 59;
            // 
            // Balance
            // 
            this.Balance.Caption = "Balance";
            this.Balance.FieldName = "f_balance";
            this.Balance.Name = "Balance";
            this.Balance.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "f_balance", "{0:#.##}")});
            this.Balance.Visible = true;
            this.Balance.VisibleIndex = 7;
            this.Balance.Width = 63;
            // 
            // Moneda
            // 
            this.Moneda.Caption = "Moneda";
            this.Moneda.FieldName = "moneda";
            this.Moneda.Name = "Moneda";
            this.Moneda.Visible = true;
            this.Moneda.VisibleIndex = 8;
            this.Moneda.Width = 64;
            // 
            // btn_buscar
            // 
            this.btn_buscar.FlatAppearance.BorderSize = 0;
            this.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_buscar.Image = global::Software_Evolution.Properties.Resources.xmag_search_find_export_locate_5984;
            this.btn_buscar.Location = new System.Drawing.Point(735, 11);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(41, 40);
            this.btn_buscar.TabIndex = 29;
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // btn_correo
            // 
            this.btn_correo.FlatAppearance.BorderSize = 0;
            this.btn_correo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_correo.Image = global::Software_Evolution.Properties.Resources.Email_30017;
            this.btn_correo.Location = new System.Drawing.Point(573, 2);
            this.btn_correo.Margin = new System.Windows.Forms.Padding(2);
            this.btn_correo.Name = "btn_correo";
            this.btn_correo.Size = new System.Drawing.Size(41, 40);
            this.btn_correo.TabIndex = 31;
            this.btn_correo.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btn_correo);
            this.panel1.Controls.Add(this.btn_exportar);
            this.panel1.Controls.Add(this.btn_imprimir);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btn_cerrar);
            this.panel1.Controls.Add(this.lbltitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 46);
            this.panel1.TabIndex = 30;
            // 
            // btn_exportar
            // 
            this.btn_exportar.FlatAppearance.BorderSize = 0;
            this.btn_exportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exportar.Image = global::Software_Evolution.Properties.Resources.Excel_Mac_23559;
            this.btn_exportar.Location = new System.Drawing.Point(618, 2);
            this.btn_exportar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_exportar.Name = "btn_exportar";
            this.btn_exportar.Size = new System.Drawing.Size(41, 40);
            this.btn_exportar.TabIndex = 30;
            this.Fromtooltip.SetToolTip(this.btn_exportar, "Exportar a excell.");
            this.btn_exportar.UseVisualStyleBackColor = true;
            this.btn_exportar.Click += new System.EventHandler(this.btn_exportar_Click);
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.FlatAppearance.BorderSize = 0;
            this.btn_imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_imprimir.Image = global::Software_Evolution.Properties.Resources.actions_document_print_15785;
            this.btn_imprimir.Location = new System.Drawing.Point(663, 2);
            this.btn_imprimir.Margin = new System.Windows.Forms.Padding(2);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(41, 40);
            this.btn_imprimir.TabIndex = 29;
            this.Fromtooltip.SetToolTip(this.btn_imprimir, "Imprimir");
            this.btn_imprimir.UseVisualStyleBackColor = true;
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::Software_Evolution.Properties.Resources.xmag_search_find_export_locate_5984;
            this.button1.Location = new System.Drawing.Point(708, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 40);
            this.button1.TabIndex = 28;
            this.Fromtooltip.SetToolTip(this.button1, "Buscar todos los Clientes.");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.FlatAppearance.BorderSize = 0;
            this.btn_cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cerrar.Image = global::Software_Evolution.Properties.Resources.vcsconflicting_93497;
            this.btn_cerrar.Location = new System.Drawing.Point(753, 2);
            this.btn_cerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(41, 40);
            this.btn_cerrar.TabIndex = 2;
            this.Fromtooltip.SetToolTip(this.btn_cerrar, "Cerrar la ventana de Cliente.");
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // lbltitulo
            // 
            this.lbltitulo.AutoSize = true;
            this.lbltitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitulo.Location = new System.Drawing.Point(2, 14);
            this.lbltitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.Size = new System.Drawing.Size(288, 24);
            this.lbltitulo.TabIndex = 0;
            this.lbltitulo.Text = "Cuentas Por Cobrar A Fechas";
            // 
            // fecha1
            // 
            this.fecha1.CustomFormat = "dd-MM-yyyy";
            this.fecha1.EnterTab = true;
            this.fecha1.FieldName = "";
            this.fecha1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fecha1.IsActivar = true;
            this.fecha1.IsLimpiar = true;
            this.fecha1.IsSalvar = true;
            this.fecha1.IsValidar = false;
            this.fecha1.Location = new System.Drawing.Point(8, 51);
            this.fecha1.Name = "fecha1";
            this.fecha1.Size = new System.Drawing.Size(96, 20);
            this.fecha1.TabIndex = 31;
            this.fecha1.Valor = new System.DateTime(1991, 9, 14, 0, 0, 0, 0);
            this.fecha1.Value = new System.DateTime(1991, 9, 14, 0, 0, 0, 0);
            this.fecha1.Visible = false;
            // 
            // fecha2
            // 
            this.fecha2.Checked = false;
            this.fecha2.CustomFormat = "dd-MM-yyyy";
            this.fecha2.EnterTab = true;
            this.fecha2.FieldName = "";
            this.fecha2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fecha2.IsActivar = true;
            this.fecha2.IsLimpiar = true;
            this.fecha2.IsSalvar = true;
            this.fecha2.IsValidar = false;
            this.fecha2.Location = new System.Drawing.Point(122, 51);
            this.fecha2.Name = "fecha2";
            this.fecha2.Size = new System.Drawing.Size(100, 20);
            this.fecha2.TabIndex = 32;
            this.fecha2.Valor = new System.DateTime(2020, 11, 11, 0, 0, 0, 0);
            this.fecha2.Value = new System.DateTime(2020, 11, 11, 0, 0, 0, 0);
            // 
            // ReportesCuentaPorCobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fecha2);
            this.Controls.Add(this.fecha1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.gridControl1);
            this.Name = "ReportesCuentaPorCobrar";
            this.Text = "ReportesCuentaPorCobrar";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Codigo;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Button btn_correo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_exportar;
        private System.Windows.Forms.Button btn_imprimir;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Label lbltitulo;
        private customcontrols.EvDateTimePicker fecha1;
        private customcontrols.EvDateTimePicker fecha2;
        private DevExpress.XtraGrid.Columns.GridColumn Nombre;
        private DevExpress.XtraGrid.Columns.GridColumn Dias_Credito;
        private DevExpress.XtraGrid.Columns.GridColumn No_Documento;
        private DevExpress.XtraGrid.Columns.GridColumn Fecha_Documento;
        private DevExpress.XtraGrid.Columns.GridColumn Fecha_Vencimiento;
        private DevExpress.XtraGrid.Columns.GridColumn Monto;
        private DevExpress.XtraGrid.Columns.GridColumn Balance;
        private DevExpress.XtraGrid.Columns.GridColumn Moneda;
    }
}