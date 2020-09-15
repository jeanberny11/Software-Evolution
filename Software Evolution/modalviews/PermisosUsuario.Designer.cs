namespace Software_Evolution.modalviews
{
    partial class PermisosUsuario
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
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button8 = new System.Windows.Forms.Button();
            this.evCheckBox1 = new Software_Evolution.customcontrols.EvCheckBox();
            this.evComboBox2 = new Software_Evolution.customcontrols.EvComboBox();
            this.evLabel2 = new Software_Evolution.customcontrols.EvLabel();
            this.button7 = new System.Windows.Forms.Button();
            this.evComboBox1 = new Software_Evolution.customcontrols.EvComboBox();
            this.evLabel1 = new Software_Evolution.customcontrols.EvLabel();
            this.evLabel3 = new Software_Evolution.customcontrols.EvLabel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.evComboBox2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evComboBox1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6);
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(6);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(588, 604);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.DetailHeight = 682;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Modulos";
            this.gridColumn1.FieldName = "f_caption_columna";
            this.gridColumn1.MinWidth = 39;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 146;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.Caption = "Menu";
            this.gridColumn2.FieldName = "f_caption";
            this.gridColumn2.MinWidth = 39;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 361;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.Caption = "Marcado";
            this.gridColumn3.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn3.FieldName = "f_marcado";
            this.gridColumn3.MinWidth = 39;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 97;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(672, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 58);
            this.button1.TabIndex = 1;
            this.button1.Text = "Todos los Permisos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(672, 115);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(198, 58);
            this.button2.TabIndex = 2;
            this.button2.Text = "Ningun Permiso";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(672, 180);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(198, 58);
            this.button3.TabIndex = 3;
            this.button3.Text = "Permiso Modulo";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(672, 245);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(198, 58);
            this.button4.TabIndex = 4;
            this.button4.Text = "Ningun Permiso Modulo";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(672, 310);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(198, 58);
            this.button5.TabIndex = 5;
            this.button5.Text = "Salvar Permisos";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(672, 375);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(198, 58);
            this.button6.TabIndex = 6;
            this.button6.Text = "Cancelar";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.evCheckBox1);
            this.groupBox1.Controls.Add(this.evComboBox2);
            this.groupBox1.Controls.Add(this.evLabel2);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.evComboBox1);
            this.groupBox1.Controls.Add(this.evLabel1);
            this.groupBox1.Location = new System.Drawing.Point(598, 439);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 159);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Copia de Permisos";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(204, 86);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(121, 40);
            this.button8.TabIndex = 6;
            this.button8.Text = "Salvar Permisos";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // evCheckBox1
            // 
            this.evCheckBox1.AutoSize = true;
            this.evCheckBox1.DefaultValue = false;
            this.evCheckBox1.EnterTab = false;
            this.evCheckBox1.FieldName = "";
            this.evCheckBox1.IsLimpiar = false;
            this.evCheckBox1.IsSalvar = true;
            this.evCheckBox1.IsValidar = false;
            this.evCheckBox1.Location = new System.Drawing.Point(9, 124);
            this.evCheckBox1.Name = "evCheckBox1";
            this.evCheckBox1.Size = new System.Drawing.Size(132, 21);
            this.evCheckBox1.TabIndex = 5;
            this.evCheckBox1.Text = "Permisos Grupo";
            this.evCheckBox1.UseVisualStyleBackColor = true;
            this.evCheckBox1.Valor = false;
            // 
            // evComboBox2
            // 
            this.evComboBox2.DisplayMemberName = null;
            this.evComboBox2.EnterTab = true;
            this.evComboBox2.FieldName = "";
            this.evComboBox2.IsLimpiar = true;
            this.evComboBox2.IsSalvar = true;
            this.evComboBox2.IsValidar = true;
            this.evComboBox2.Location = new System.Drawing.Point(9, 94);
            this.evComboBox2.Margin = new System.Windows.Forms.Padding(5);
            this.evComboBox2.Name = "evComboBox2";
            this.evComboBox2.NombreProcedimiento = null;
            this.evComboBox2.Param = "";
            this.evComboBox2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.evComboBox2.Size = new System.Drawing.Size(190, 22);
            this.evComboBox2.TabIndex = 4;
            this.evComboBox2.Valor = null;
            this.evComboBox2.ValueMemberName = null;
            // 
            // evLabel2
            // 
            this.evLabel2.AutoSize = true;
            this.evLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel2.Location = new System.Drawing.Point(6, 72);
            this.evLabel2.Name = "evLabel2";
            this.evLabel2.Size = new System.Drawing.Size(64, 17);
            this.evLabel2.TabIndex = 3;
            this.evLabel2.Text = "Usuario";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(204, 34);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(121, 40);
            this.button7.TabIndex = 2;
            this.button7.Text = "Cargar Permisos";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // evComboBox1
            // 
            this.evComboBox1.DisplayMemberName = null;
            this.evComboBox1.EnterTab = true;
            this.evComboBox1.FieldName = "";
            this.evComboBox1.IsLimpiar = true;
            this.evComboBox1.IsSalvar = true;
            this.evComboBox1.IsValidar = true;
            this.evComboBox1.Location = new System.Drawing.Point(9, 46);
            this.evComboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.evComboBox1.Name = "evComboBox1";
            this.evComboBox1.NombreProcedimiento = null;
            this.evComboBox1.Param = "";
            this.evComboBox1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.evComboBox1.Size = new System.Drawing.Size(190, 22);
            this.evComboBox1.TabIndex = 1;
            this.evComboBox1.Valor = null;
            this.evComboBox1.ValueMemberName = null;
            // 
            // evLabel1
            // 
            this.evLabel1.AutoSize = true;
            this.evLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel1.Location = new System.Drawing.Point(6, 25);
            this.evLabel1.Name = "evLabel1";
            this.evLabel1.Size = new System.Drawing.Size(61, 17);
            this.evLabel1.TabIndex = 0;
            this.evLabel1.Text = "Grupos";
            // 
            // evLabel3
            // 
            this.evLabel3.AutoSize = true;
            this.evLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel3.Location = new System.Drawing.Point(621, 13);
            this.evLabel3.Name = "evLabel3";
            this.evLabel3.Size = new System.Drawing.Size(285, 20);
            this.evLabel3.TabIndex = 8;
            this.evLabel3.Text = "Permisos del Usuario al Sistema";
            // 
            // PermisosUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 604);
            this.Controls.Add(this.evLabel3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gridControl1);
            this.Name = "PermisosUsuario";
            this.Text = "PermisosUsuario";
            this.Load += new System.EventHandler(this.PermisosUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.evComboBox2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evComboBox1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button8;
        private customcontrols.EvCheckBox evCheckBox1;
        private customcontrols.EvComboBox evComboBox2;
        private customcontrols.EvLabel evLabel2;
        private System.Windows.Forms.Button button7;
        private customcontrols.EvComboBox evComboBox1;
        private customcontrols.EvLabel evLabel1;
        private customcontrols.EvLabel evLabel3;
    }
}