namespace Software_Evolution.modalviews.ventasfacturacion
{
    partial class NumericInputDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.evNumericTextBox1 = new Software_Evolution.customcontrols.EvNumericTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evNumericTextBox1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(321, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(321, 46);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 24);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // evNumericTextBox1
            // 
            this.evNumericTextBox1.EditValue = 0D;
            this.evNumericTextBox1.EnterTab = true;
            this.evNumericTextBox1.FieldName = "";
            this.evNumericTextBox1.IsActivar = true;
            this.evNumericTextBox1.IsLimpiar = true;
            this.evNumericTextBox1.IsSalvar = true;
            this.evNumericTextBox1.IsValidar = true;
            this.evNumericTextBox1.Location = new System.Drawing.Point(5, 81);
            this.evNumericTextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.evNumericTextBox1.Name = "evNumericTextBox1";
            this.evNumericTextBox1.Properties.Appearance.Options.UseTextOptions = true;
            this.evNumericTextBox1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.evNumericTextBox1.Properties.Mask.EditMask = "n";
            this.evNumericTextBox1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.evNumericTextBox1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.evNumericTextBox1.Size = new System.Drawing.Size(308, 20);
            this.evNumericTextBox1.TabIndex = 3;
            // 
            // NumericInputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 106);
            this.Controls.Add(this.evNumericTextBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "NumericInputDialog";
            this.Text = "NumericInputDialog";
            this.Load += new System.EventHandler(this.NumericInputDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evNumericTextBox1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private customcontrols.EvNumericTextBox evNumericTextBox1;
    }
}