namespace Software_Evolution.modalviews
{
    partial class Qry_provincia_municipio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Qry_provincia_municipio));
            this.evLabel1 = new Software_Evolution.customcontrols.EvLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtparaje = new Software_Evolution.customcontrols.EvTextBox();
            this.evLabel4 = new Software_Evolution.customcontrols.EvLabel();
            this.txtdistrito = new Software_Evolution.customcontrols.EvTextBox();
            this.evLabel5 = new Software_Evolution.customcontrols.EvLabel();
            this.txtmunicipio = new Software_Evolution.customcontrols.EvTextBox();
            this.evLabel3 = new Software_Evolution.customcontrols.EvLabel();
            this.txtprovincia = new Software_Evolution.customcontrols.EvTextBox();
            this.evLabel2 = new Software_Evolution.customcontrols.EvLabel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // evLabel1
            // 
            this.evLabel1.AutoSize = true;
            this.evLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel1.Location = new System.Drawing.Point(11, 24);
            this.evLabel1.Name = "evLabel1";
            this.evLabel1.Size = new System.Drawing.Size(363, 25);
            this.evLabel1.TabIndex = 0;
            this.evLabel1.Text = "Buscando en Provincia  &&  Municipio";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btn_cerrar);
            this.panel1.Controls.Add(this.evLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(891, 71);
            this.panel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(738, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 60);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.FlatAppearance.BorderSize = 0;
            this.btn_cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cerrar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cerrar.Image")));
            this.btn_cerrar.Location = new System.Drawing.Point(822, 4);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(60, 60);
            this.btn_cerrar.TabIndex = 3;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtparaje);
            this.panel2.Controls.Add(this.evLabel4);
            this.panel2.Controls.Add(this.txtdistrito);
            this.panel2.Controls.Add(this.evLabel5);
            this.panel2.Controls.Add(this.txtmunicipio);
            this.panel2.Controls.Add(this.evLabel3);
            this.panel2.Controls.Add(this.txtprovincia);
            this.panel2.Controls.Add(this.evLabel2);
            this.panel2.Location = new System.Drawing.Point(32, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(836, 108);
            this.panel2.TabIndex = 3;
            // 
            // txtparaje
            // 
            this.txtparaje.EnterTab = true;
            this.txtparaje.FieldName = "";
            this.txtparaje.IsActivar = true;
            this.txtparaje.IsLimpiar = true;
            this.txtparaje.IsSalvar = true;
            this.txtparaje.IsValidar = true;
            this.txtparaje.Location = new System.Drawing.Point(502, 63);
            this.txtparaje.Name = "txtparaje";
            this.txtparaje.Size = new System.Drawing.Size(310, 22);
            this.txtparaje.TabIndex = 7;
            this.txtparaje.Valor = "";
            this.txtparaje.Validated += new System.EventHandler(this.evTextBox1_Validated);
            // 
            // evLabel4
            // 
            this.evLabel4.AutoSize = true;
            this.evLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel4.Location = new System.Drawing.Point(421, 66);
            this.evLabel4.Name = "evLabel4";
            this.evLabel4.Size = new System.Drawing.Size(55, 17);
            this.evLabel4.TabIndex = 6;
            this.evLabel4.Text = "Paraje";
            // 
            // txtdistrito
            // 
            this.txtdistrito.EnterTab = true;
            this.txtdistrito.FieldName = "";
            this.txtdistrito.IsActivar = true;
            this.txtdistrito.IsLimpiar = true;
            this.txtdistrito.IsSalvar = true;
            this.txtdistrito.IsValidar = true;
            this.txtdistrito.Location = new System.Drawing.Point(502, 15);
            this.txtdistrito.Name = "txtdistrito";
            this.txtdistrito.Size = new System.Drawing.Size(310, 22);
            this.txtdistrito.TabIndex = 5;
            this.txtdistrito.Valor = "";
            this.txtdistrito.Validated += new System.EventHandler(this.evTextBox1_Validated);
            // 
            // evLabel5
            // 
            this.evLabel5.AutoSize = true;
            this.evLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel5.Location = new System.Drawing.Point(421, 18);
            this.evLabel5.Name = "evLabel5";
            this.evLabel5.Size = new System.Drawing.Size(60, 17);
            this.evLabel5.TabIndex = 4;
            this.evLabel5.Text = "Distrito";
            // 
            // txtmunicipio
            // 
            this.txtmunicipio.EnterTab = true;
            this.txtmunicipio.FieldName = "";
            this.txtmunicipio.IsActivar = true;
            this.txtmunicipio.IsLimpiar = true;
            this.txtmunicipio.IsSalvar = true;
            this.txtmunicipio.IsValidar = true;
            this.txtmunicipio.Location = new System.Drawing.Point(105, 63);
            this.txtmunicipio.Name = "txtmunicipio";
            this.txtmunicipio.Size = new System.Drawing.Size(294, 22);
            this.txtmunicipio.TabIndex = 3;
            this.txtmunicipio.Valor = "";
            this.txtmunicipio.Validated += new System.EventHandler(this.evTextBox1_Validated);
            // 
            // evLabel3
            // 
            this.evLabel3.AutoSize = true;
            this.evLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel3.Location = new System.Drawing.Point(8, 66);
            this.evLabel3.Name = "evLabel3";
            this.evLabel3.Size = new System.Drawing.Size(76, 17);
            this.evLabel3.TabIndex = 2;
            this.evLabel3.Text = "Municipio";
            // 
            // txtprovincia
            // 
            this.txtprovincia.EnterTab = true;
            this.txtprovincia.FieldName = "";
            this.txtprovincia.IsActivar = true;
            this.txtprovincia.IsLimpiar = true;
            this.txtprovincia.IsSalvar = true;
            this.txtprovincia.IsValidar = true;
            this.txtprovincia.Location = new System.Drawing.Point(105, 15);
            this.txtprovincia.Name = "txtprovincia";
            this.txtprovincia.Size = new System.Drawing.Size(294, 22);
            this.txtprovincia.TabIndex = 1;
            this.txtprovincia.Valor = "";
            this.txtprovincia.Validated += new System.EventHandler(this.evTextBox1_Validated);
            // 
            // evLabel2
            // 
            this.evLabel2.AutoSize = true;
            this.evLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel2.Location = new System.Drawing.Point(8, 18);
            this.evLabel2.Name = "evLabel2";
            this.evLabel2.Size = new System.Drawing.Size(75, 17);
            this.evLabel2.TabIndex = 0;
            this.evLabel2.Text = "Provincia";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(6, 188);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(879, 379);
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
            this.gridColumn6});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView1_SelectionChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Provincia";
            this.gridColumn1.FieldName = "f_des_provincia";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 163;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Municipio";
            this.gridColumn2.FieldName = "f_des_municipio";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 164;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Distrito";
            this.gridColumn3.FieldName = "f_des_distrito";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 148;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Seccion";
            this.gridColumn4.FieldName = "f_des_seccion";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 134;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Barrio/Paraje";
            this.gridColumn5.FieldName = "f_des_barrio";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 128;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Paraje";
            this.gridColumn6.FieldName = "f_descripcion";
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 140;
            // 
            // Qry_provincia_municipio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 572);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Qry_provincia_municipio";
            this.Text = "Qry_provincia_municipio";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private customcontrols.EvLabel evLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Panel panel2;
        private customcontrols.EvTextBox txtparaje;
        private customcontrols.EvLabel evLabel4;
        private customcontrols.EvTextBox txtdistrito;
        private customcontrols.EvLabel evLabel5;
        private customcontrols.EvTextBox txtmunicipio;
        private customcontrols.EvLabel evLabel3;
        private customcontrols.EvTextBox txtprovincia;
        private customcontrols.EvLabel evLabel2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}