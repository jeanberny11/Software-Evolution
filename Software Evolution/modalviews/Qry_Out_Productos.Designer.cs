namespace Software_Evolution.modalviews
{
    partial class Qry_Out_Productos
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
            this.button1 = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.evLabel1 = new Software_Evolution.customcontrols.EvLabel();
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
            this.evLabel2 = new Software_Evolution.customcontrols.EvLabel();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.evLabel3 = new Software_Evolution.customcontrols.EvLabel();
            this.cmb_almacen = new Software_Evolution.customcontrols.EvComboBox();
            this.cmb_categoria = new Software_Evolution.customcontrols.EvComboBox();
            this.evLabel4 = new Software_Evolution.customcontrols.EvLabel();
            this.cmb_subcategoria = new Software_Evolution.customcontrols.EvComboBox();
            this.evLabel5 = new Software_Evolution.customcontrols.EvLabel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_almacen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_categoria.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_subcategoria.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btn_cerrar);
            this.panel1.Controls.Add(this.evLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 42);
            this.panel1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::Software_Evolution.Properties.Resources.xmag_search_find_export_locate_5984;
            this.button1.Location = new System.Drawing.Point(658, 3);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 34);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.FlatAppearance.BorderSize = 0;
            this.btn_cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cerrar.Image = global::Software_Evolution.Properties.Resources.vcsconflicting_93497;
            this.btn_cerrar.Location = new System.Drawing.Point(702, 3);
            this.btn_cerrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(39, 34);
            this.btn_cerrar.TabIndex = 3;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // evLabel1
            // 
            this.evLabel1.AutoSize = true;
            this.evLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel1.Location = new System.Drawing.Point(2, 8);
            this.evLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.evLabel1.Name = "evLabel1";
            this.evLabel1.Size = new System.Drawing.Size(151, 20);
            this.evLabel1.TabIndex = 0;
            this.evLabel1.Text = "Buscar Productos";
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControl1.Location = new System.Drawing.Point(8, 105);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 323);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridControl1_KeyPress);
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
            this.gridColumn10});
            this.gridView1.DetailHeight = 444;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView1_SelectionChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn1.Caption = "Codigo";
            this.gridColumn1.FieldName = "f_referencia";
            this.gridColumn1.MinWidth = 29;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 49;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn2.Caption = "Descripcion";
            this.gridColumn2.FieldName = "f_descripcion";
            this.gridColumn2.MinWidth = 29;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 350;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn3.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn3.Caption = "Precio Lista";
            this.gridColumn3.FieldName = "f_precio";
            this.gridColumn3.MinWidth = 29;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 109;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn4.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn4.Caption = "Existencia";
            this.gridColumn4.FieldName = "f_existencia";
            this.gridColumn4.MinWidth = 29;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 109;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn5.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn5.Caption = "Referencia";
            this.gridColumn5.FieldName = "f_referencia_suplidor";
            this.gridColumn5.MinWidth = 29;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 111;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn6.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn6.Caption = "Marca";
            this.gridColumn6.FieldName = "marca";
            this.gridColumn6.MinWidth = 29;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 127;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn7.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.gridColumn7.AppearanceHeader.Options.UseFont = true;
            this.gridColumn7.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn7.Caption = "Precio 2";
            this.gridColumn7.FieldName = "f_precio2";
            this.gridColumn7.MinWidth = 29;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 109;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn8.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.gridColumn8.AppearanceHeader.Options.UseFont = true;
            this.gridColumn8.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn8.Caption = "Precio 3";
            this.gridColumn8.FieldName = "f_precio3";
            this.gridColumn8.MinWidth = 29;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 109;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn9.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.gridColumn9.AppearanceHeader.Options.UseFont = true;
            this.gridColumn9.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn9.Caption = "Precio 4";
            this.gridColumn9.FieldName = "f_precio4";
            this.gridColumn9.MinWidth = 29;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            this.gridColumn9.Width = 109;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn10.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.gridColumn10.AppearanceHeader.Options.UseFont = true;
            this.gridColumn10.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn10.Caption = "Modelo";
            this.gridColumn10.FieldName = "modelo";
            this.gridColumn10.MinWidth = 29;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            this.gridColumn10.Width = 128;
            // 
            // evLabel2
            // 
            this.evLabel2.AutoSize = true;
            this.evLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel2.Location = new System.Drawing.Point(1, 50);
            this.evLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.evLabel2.Name = "evLabel2";
            this.evLabel2.Size = new System.Drawing.Size(50, 13);
            this.evLabel2.TabIndex = 5;
            this.evLabel2.Text = "Buscar:";
            // 
            // searchControl1
            // 
            this.searchControl1.Client = this.gridControl1;
            this.searchControl1.Location = new System.Drawing.Point(62, 48);
            this.searchControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Properties.Client = this.gridControl1;
            this.searchControl1.Properties.FindDelay = 100;
            this.searchControl1.Size = new System.Drawing.Size(216, 20);
            this.searchControl1.TabIndex = 6;
            // 
            // evLabel3
            // 
            this.evLabel3.AutoSize = true;
            this.evLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel3.Location = new System.Drawing.Point(1, 79);
            this.evLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.evLabel3.Name = "evLabel3";
            this.evLabel3.Size = new System.Drawing.Size(55, 13);
            this.evLabel3.TabIndex = 7;
            this.evLabel3.Text = "Almacen";
            // 
            // cmb_almacen
            // 
            this.cmb_almacen.DisplayMemberName = "f_descripcion";
            this.cmb_almacen.EnterTab = true;
            this.cmb_almacen.FieldName = "";
            this.cmb_almacen.IsActivar = true;
            this.cmb_almacen.IsLimpiar = true;
            this.cmb_almacen.IsSalvar = true;
            this.cmb_almacen.IsValidar = true;
            this.cmb_almacen.Location = new System.Drawing.Point(62, 77);
            this.cmb_almacen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_almacen.Name = "cmb_almacen";
            this.cmb_almacen.NombreProcedimiento = "p_almacen";
            this.cmb_almacen.Param = "";
            this.cmb_almacen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_almacen.Properties.NullText = "";
            this.cmb_almacen.Size = new System.Drawing.Size(216, 20);
            this.cmb_almacen.TabIndex = 8;
            this.cmb_almacen.Valor = null;
            this.cmb_almacen.ValueMemberName = "f_iddepto";
            this.cmb_almacen.EditValueChanged += new System.EventHandler(this.cmb_almacen_EditValueChanged);
            // 
            // cmb_categoria
            // 
            this.cmb_categoria.DisplayMemberName = "f_descripcion";
            this.cmb_categoria.EnterTab = true;
            this.cmb_categoria.FieldName = "";
            this.cmb_categoria.IsActivar = true;
            this.cmb_categoria.IsLimpiar = true;
            this.cmb_categoria.IsSalvar = true;
            this.cmb_categoria.IsValidar = true;
            this.cmb_categoria.Location = new System.Drawing.Point(392, 49);
            this.cmb_categoria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_categoria.Name = "cmb_categoria";
            this.cmb_categoria.NombreProcedimiento = "p_categorias";
            this.cmb_categoria.Param = "";
            this.cmb_categoria.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_categoria.Properties.NullText = "";
            this.cmb_categoria.Size = new System.Drawing.Size(268, 20);
            this.cmb_categoria.TabIndex = 10;
            this.cmb_categoria.Valor = null;
            this.cmb_categoria.ValueMemberName = "f_idcategoria";
            this.cmb_categoria.EditValueChanged += new System.EventHandler(this.cmb_categoria_EditValueChanged);
            // 
            // evLabel4
            // 
            this.evLabel4.AutoSize = true;
            this.evLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel4.Location = new System.Drawing.Point(295, 51);
            this.evLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.evLabel4.Name = "evLabel4";
            this.evLabel4.Size = new System.Drawing.Size(61, 13);
            this.evLabel4.TabIndex = 9;
            this.evLabel4.Text = "Categoria";
            // 
            // cmb_subcategoria
            // 
            this.cmb_subcategoria.DisplayMemberName = "f_descripcion";
            this.cmb_subcategoria.EnterTab = true;
            this.cmb_subcategoria.FieldName = "";
            this.cmb_subcategoria.IsActivar = true;
            this.cmb_subcategoria.IsLimpiar = true;
            this.cmb_subcategoria.IsSalvar = true;
            this.cmb_subcategoria.IsValidar = true;
            this.cmb_subcategoria.Location = new System.Drawing.Point(392, 78);
            this.cmb_subcategoria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_subcategoria.Name = "cmb_subcategoria";
            this.cmb_subcategoria.NombreProcedimiento = "p_subcategorias";
            this.cmb_subcategoria.Param = "";
            this.cmb_subcategoria.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_subcategoria.Properties.NullText = "";
            this.cmb_subcategoria.Size = new System.Drawing.Size(268, 20);
            this.cmb_subcategoria.TabIndex = 12;
            this.cmb_subcategoria.Valor = null;
            this.cmb_subcategoria.ValueMemberName = "f_id";
            this.cmb_subcategoria.EditValueChanged += new System.EventHandler(this.cmb_subcategoria_EditValueChanged);
            // 
            // evLabel5
            // 
            this.evLabel5.AutoSize = true;
            this.evLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel5.Location = new System.Drawing.Point(295, 80);
            this.evLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.evLabel5.Name = "evLabel5";
            this.evLabel5.Size = new System.Drawing.Size(87, 13);
            this.evLabel5.TabIndex = 11;
            this.evLabel5.Text = "Sub-Categoria";
            // 
            // Qry_Out_Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 436);
            this.Controls.Add(this.cmb_subcategoria);
            this.Controls.Add(this.evLabel5);
            this.Controls.Add(this.cmb_categoria);
            this.Controls.Add(this.evLabel4);
            this.Controls.Add(this.cmb_almacen);
            this.Controls.Add(this.evLabel3);
            this.Controls.Add(this.searchControl1);
            this.Controls.Add(this.evLabel2);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel1);
            this.Name = "Qry_Out_Productos";
            this.Text = "Qry_Out_Productos";
            this.Load += new System.EventHandler(this.Qry_Out_Productos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_almacen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_categoria.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_subcategoria.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_cerrar;
        private customcontrols.EvLabel evLabel1;
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
        private customcontrols.EvLabel evLabel2;
        private DevExpress.XtraEditors.SearchControl searchControl1;
        private customcontrols.EvLabel evLabel3;
        private customcontrols.EvComboBox cmb_almacen;
        private customcontrols.EvComboBox cmb_categoria;
        private customcontrols.EvLabel evLabel4;
        private customcontrols.EvComboBox cmb_subcategoria;
        private customcontrols.EvLabel evLabel5;
    }
}