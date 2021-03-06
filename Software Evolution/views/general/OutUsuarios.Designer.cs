﻿namespace Software_Evolution.views.general
{
    partial class OutUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutUsuarios));
            this.grid1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_correo = new System.Windows.Forms.Button();
            this.btn_exportar = new System.Windows.Forms.Button();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.grid1.Location = new System.Drawing.Point(0, 76);
            this.grid1.MainView = this.gridView1;
            this.grid1.Margin = new System.Windows.Forms.Padding(2);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(600, 288);
            this.grid1.TabIndex = 0;
            this.grid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grid1.DoubleClick += new System.EventHandler(this.grid1_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gridView1.DetailHeight = 284;
            this.gridView1.GridControl = this.grid1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Usuario ID";
            this.gridColumn1.FieldName = "f_codigo_usuario";
            this.gridColumn1.MinWidth = 19;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "f_codigo_usuario", "{0}")});
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 57;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Nombre";
            this.gridColumn2.FieldName = "f_nombre";
            this.gridColumn2.MinWidth = 19;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 103;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Apellido";
            this.gridColumn3.FieldName = "f_apellido";
            this.gridColumn3.MinWidth = 19;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 103;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Direccion";
            this.gridColumn4.FieldName = "f_direccion";
            this.gridColumn4.MinWidth = 19;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 103;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Grupo";
            this.gridColumn5.FieldName = "f_id_grupo";
            this.gridColumn5.MinWidth = 19;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 103;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Usuario";
            this.gridColumn6.FieldName = "f_id_usuario";
            this.gridColumn6.MinWidth = 19;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 106;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.panelControl1.Controls.Add(this.btn_correo);
            this.panelControl1.Controls.Add(this.btn_exportar);
            this.panelControl1.Controls.Add(this.btn_imprimir);
            this.panelControl1.Controls.Add(this.btn_buscar);
            this.panelControl1.Controls.Add(this.btn_cerrar);
            this.panelControl1.Controls.Add(this.button9);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(2, 8, 2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(600, 46);
            this.panelControl1.TabIndex = 1;
            // 
            // btn_correo
            // 
            this.btn_correo.FlatAppearance.BorderSize = 0;
            this.btn_correo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_correo.Image = global::Software_Evolution.Properties.Resources.Email_30017;
            this.btn_correo.Location = new System.Drawing.Point(343, 6);
            this.btn_correo.Margin = new System.Windows.Forms.Padding(2);
            this.btn_correo.Name = "btn_correo";
            this.btn_correo.Size = new System.Drawing.Size(41, 36);
            this.btn_correo.TabIndex = 37;
            this.btn_correo.UseVisualStyleBackColor = true;
            // 
            // btn_exportar
            // 
            this.btn_exportar.FlatAppearance.BorderSize = 0;
            this.btn_exportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exportar.Image = global::Software_Evolution.Properties.Resources.Excel_Mac_23559;
            this.btn_exportar.Location = new System.Drawing.Point(388, 5);
            this.btn_exportar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_exportar.Name = "btn_exportar";
            this.btn_exportar.Size = new System.Drawing.Size(41, 36);
            this.btn_exportar.TabIndex = 36;
            this.Fromtooltip.SetToolTip(this.btn_exportar, "Exportar a excell.");
            this.btn_exportar.UseVisualStyleBackColor = true;
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.FlatAppearance.BorderSize = 0;
            this.btn_imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_imprimir.Image = global::Software_Evolution.Properties.Resources.actions_document_print_15785;
            this.btn_imprimir.Location = new System.Drawing.Point(433, 4);
            this.btn_imprimir.Margin = new System.Windows.Forms.Padding(2);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(41, 36);
            this.btn_imprimir.TabIndex = 35;
            this.Fromtooltip.SetToolTip(this.btn_imprimir, "Imprimir");
            this.btn_imprimir.UseVisualStyleBackColor = true;
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // btn_buscar
            // 
            this.btn_buscar.FlatAppearance.BorderSize = 0;
            this.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_buscar.Image = global::Software_Evolution.Properties.Resources.xmag_search_find_export_locate_5984;
            this.btn_buscar.Location = new System.Drawing.Point(478, 6);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(35, 36);
            this.btn_buscar.TabIndex = 34;
            this.Fromtooltip.SetToolTip(this.btn_buscar, "Buscar todos los Clientes.");
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.FlatAppearance.BorderSize = 0;
            this.btn_cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cerrar.Image = global::Software_Evolution.Properties.Resources.vcsconflicting_93497;
            this.btn_cerrar.Location = new System.Drawing.Point(563, 5);
            this.btn_cerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(33, 36);
            this.btn_cerrar.TabIndex = 32;
            this.Fromtooltip.SetToolTip(this.btn_cerrar, "Cerrar la ventana de Cliente.");
            this.btn_cerrar.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Image = ((System.Drawing.Image)(resources.GetObject("button9.Image")));
            this.button9.Location = new System.Drawing.Point(518, 5);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(40, 36);
            this.button9.TabIndex = 26;
            this.button9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // searchControl1
            // 
            this.searchControl1.Client = this.grid1;
            this.searchControl1.Location = new System.Drawing.Point(459, 51);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Properties.Client = this.grid1;
            this.searchControl1.Size = new System.Drawing.Size(141, 20);
            this.searchControl1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(104, 369);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 31);
            this.button1.TabIndex = 5;
            this.button1.Text = "Permisos Consulta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(248, 369);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 31);
            this.button2.TabIndex = 6;
            this.button2.Text = "Permisos Tabla";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(392, 369);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 31);
            this.button3.TabIndex = 7;
            this.button3.Text = "Permisos Vista";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // OutUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 403);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.searchControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.grid1);
            this.Name = "OutUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OutUsuarios";
            this.Activated += new System.EventHandler(this.OutUsuarios_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Button button9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.SearchControl searchControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_correo;
        private System.Windows.Forms.Button btn_exportar;
        private System.Windows.Forms.Button btn_imprimir;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Button btn_cerrar;
    }
}