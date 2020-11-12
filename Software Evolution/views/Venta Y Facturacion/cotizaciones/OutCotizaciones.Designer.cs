namespace Software_Evolution.views.Venta_Y_Facturacion
{
    partial class OutCotizaciones
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_correo = new System.Windows.Forms.Button();
            this.btn_exportar = new System.Windows.Forms.Button();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.lbltitulo = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.evLabel1 = new Software_Evolution.customcontrols.EvLabel();
            this.evLabel2 = new Software_Evolution.customcontrols.EvLabel();
            this.txtfecha1 = new Software_Evolution.customcontrols.EvDateTimePicker();
            this.txtfecha2 = new Software_Evolution.customcontrols.EvDateTimePicker();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btn_correo);
            this.panel1.Controls.Add(this.btn_exportar);
            this.panel1.Controls.Add(this.btn_imprimir);
            this.panel1.Controls.Add(this.btn_buscar);
            this.panel1.Controls.Add(this.btn_nuevo);
            this.panel1.Controls.Add(this.btn_cerrar);
            this.panel1.Controls.Add(this.lbltitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 49);
            this.panel1.TabIndex = 5;
            // 
            // btn_correo
            // 
            this.btn_correo.FlatAppearance.BorderSize = 0;
            this.btn_correo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_correo.Image = global::Software_Evolution.Properties.Resources.Email_30017;
            this.btn_correo.Location = new System.Drawing.Point(537, 3);
            this.btn_correo.Margin = new System.Windows.Forms.Padding(2);
            this.btn_correo.Name = "btn_correo";
            this.btn_correo.Size = new System.Drawing.Size(39, 35);
            this.btn_correo.TabIndex = 31;
            this.btn_correo.UseVisualStyleBackColor = true;
            this.btn_correo.Click += new System.EventHandler(this.btn_correo_Click);
            // 
            // btn_exportar
            // 
            this.btn_exportar.FlatAppearance.BorderSize = 0;
            this.btn_exportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exportar.Image = global::Software_Evolution.Properties.Resources.Excel_Mac_23559;
            this.btn_exportar.Location = new System.Drawing.Point(580, 2);
            this.btn_exportar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_exportar.Name = "btn_exportar";
            this.btn_exportar.Size = new System.Drawing.Size(39, 36);
            this.btn_exportar.TabIndex = 30;
            this.btn_exportar.UseVisualStyleBackColor = true;
            this.btn_exportar.Click += new System.EventHandler(this.btn_exportar_Click);
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.FlatAppearance.BorderSize = 0;
            this.btn_imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_imprimir.Image = global::Software_Evolution.Properties.Resources.actions_document_print_15785;
            this.btn_imprimir.Location = new System.Drawing.Point(620, 3);
            this.btn_imprimir.Margin = new System.Windows.Forms.Padding(2);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(39, 35);
            this.btn_imprimir.TabIndex = 29;
            this.btn_imprimir.UseVisualStyleBackColor = true;
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // btn_buscar
            // 
            this.btn_buscar.FlatAppearance.BorderSize = 0;
            this.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_buscar.Image = global::Software_Evolution.Properties.Resources.xmag_search_find_export_locate_5984;
            this.btn_buscar.Location = new System.Drawing.Point(660, 3);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(39, 35);
            this.btn_buscar.TabIndex = 28;
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.FlatAppearance.BorderSize = 0;
            this.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_nuevo.Image = global::Software_Evolution.Properties.Resources.new_file_40454;
            this.btn_nuevo.Location = new System.Drawing.Point(700, 3);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(39, 35);
            this.btn_nuevo.TabIndex = 27;
            this.btn_nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_nuevo.UseVisualStyleBackColor = true;
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.FlatAppearance.BorderSize = 0;
            this.btn_cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cerrar.Image = global::Software_Evolution.Properties.Resources.vcsconflicting_93497;
            this.btn_cerrar.Location = new System.Drawing.Point(740, 2);
            this.btn_cerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(39, 36);
            this.btn_cerrar.TabIndex = 2;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // lbltitulo
            // 
            this.lbltitulo.AutoSize = true;
            this.lbltitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitulo.Location = new System.Drawing.Point(1, 14);
            this.lbltitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.Size = new System.Drawing.Size(107, 24);
            this.lbltitulo.TabIndex = 0;
            this.lbltitulo.Text = "Cotización";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(7, 93);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(772, 317);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.gridView1.DetailHeight = 355;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Cotización";
            this.gridColumn1.FieldName = "f_documento";
            this.gridColumn1.MinWidth = 23;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 84;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "IDCliente";
            this.gridColumn2.FieldName = "f_cliente";
            this.gridColumn2.MinWidth = 23;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 88;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Cliente";
            this.gridColumn3.FieldName = "cliente";
            this.gridColumn3.MinWidth = 23;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 187;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Monto";
            this.gridColumn4.FieldName = "f_monto";
            this.gridColumn4.MinWidth = 23;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 88;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Fecha";
            this.gridColumn5.FieldName = "f_fecha";
            this.gridColumn5.MinWidth = 23;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 88;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Itbis";
            this.gridColumn6.FieldName = "f_itbis";
            this.gridColumn6.MinWidth = 23;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 88;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Vendedor";
            this.gridColumn7.FieldName = "vendedor";
            this.gridColumn7.MinWidth = 23;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 140;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Documento";
            this.gridColumn8.FieldName = "f_factura";
            this.gridColumn8.MinWidth = 23;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 94;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Hecho por";
            this.gridColumn9.FieldName = "usuario";
            this.gridColumn9.MinWidth = 23;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            this.gridColumn9.Width = 88;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Hora";
            this.gridColumn10.FieldName = "f_hora";
            this.gridColumn10.MinWidth = 23;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            this.gridColumn10.Width = 88;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Status";
            this.gridColumn11.FieldName = "f_estado";
            this.gridColumn11.MinWidth = 23;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 10;
            this.gridColumn11.Width = 88;
            // 
            // evLabel1
            // 
            this.evLabel1.AutoSize = true;
            this.evLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel1.Location = new System.Drawing.Point(11, 50);
            this.evLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.evLabel1.Name = "evLabel1";
            this.evLabel1.Size = new System.Drawing.Size(43, 13);
            this.evLabel1.TabIndex = 7;
            this.evLabel1.Text = "Desde";
            // 
            // evLabel2
            // 
            this.evLabel2.AutoSize = true;
            this.evLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel2.Location = new System.Drawing.Point(143, 50);
            this.evLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.evLabel2.Name = "evLabel2";
            this.evLabel2.Size = new System.Drawing.Size(40, 13);
            this.evLabel2.TabIndex = 8;
            this.evLabel2.Text = "Hasta";
            // 
            // txtfecha1
            // 
            this.txtfecha1.CustomFormat = "dd-MM-yyyy";
            this.txtfecha1.EnterTab = true;
            this.txtfecha1.FieldName = "";
            this.txtfecha1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtfecha1.IsActivar = true;
            this.txtfecha1.IsLimpiar = true;
            this.txtfecha1.IsSalvar = true;
            this.txtfecha1.IsValidar = false;
            this.txtfecha1.Location = new System.Drawing.Point(11, 68);
            this.txtfecha1.Margin = new System.Windows.Forms.Padding(2);
            this.txtfecha1.Name = "txtfecha1";
            this.txtfecha1.Size = new System.Drawing.Size(116, 20);
            this.txtfecha1.TabIndex = 9;
            this.txtfecha1.Valor = new System.DateTime(2020, 10, 12, 0, 0, 0, 0);
            this.txtfecha1.Value = new System.DateTime(2020, 10, 12, 0, 0, 0, 0);
            this.txtfecha1.ValueChanged += new System.EventHandler(this.txtfecha1_ValueChanged);
            // 
            // txtfecha2
            // 
            this.txtfecha2.Checked = false;
            this.txtfecha2.CustomFormat = "dd-MM-yyyy";
            this.txtfecha2.EnterTab = true;
            this.txtfecha2.FieldName = "";
            this.txtfecha2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtfecha2.IsActivar = true;
            this.txtfecha2.IsLimpiar = true;
            this.txtfecha2.IsSalvar = true;
            this.txtfecha2.IsValidar = false;
            this.txtfecha2.Location = new System.Drawing.Point(143, 68);
            this.txtfecha2.Margin = new System.Windows.Forms.Padding(2);
            this.txtfecha2.Name = "txtfecha2";
            this.txtfecha2.Size = new System.Drawing.Size(116, 20);
            this.txtfecha2.TabIndex = 10;
            this.txtfecha2.Valor = new System.DateTime(2020, 10, 12, 0, 0, 0, 0);
            this.txtfecha2.Value = new System.DateTime(2020, 10, 12, 0, 0, 0, 0);
            this.txtfecha2.ValueChanged += new System.EventHandler(this.txtfecha2_ValueChanged);
            // 
            // searchControl1
            // 
            this.searchControl1.Client = this.gridControl1;
            this.searchControl1.Location = new System.Drawing.Point(622, 102);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Properties.Client = this.gridControl1;
            this.searchControl1.Size = new System.Drawing.Size(151, 20);
            this.searchControl1.TabIndex = 12;
            // 
            // OutCotizaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 417);
            this.Controls.Add(this.searchControl1);
            this.Controls.Add(this.txtfecha2);
            this.Controls.Add(this.txtfecha1);
            this.Controls.Add(this.evLabel2);
            this.Controls.Add(this.evLabel1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel1);
            this.Name = "OutCotizaciones";
            this.Text = "OutCotizaciones";
            this.Load += new System.EventHandler(this.OutCotizaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_correo;
        private System.Windows.Forms.Button btn_exportar;
        private System.Windows.Forms.Button btn_imprimir;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Button btn_nuevo;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Label lbltitulo;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private customcontrols.EvLabel evLabel1;
        private customcontrols.EvLabel evLabel2;
        private customcontrols.EvDateTimePicker txtfecha1;
        private customcontrols.EvDateTimePicker txtfecha2;
        private DevExpress.XtraEditors.SearchControl searchControl1;
    }
}