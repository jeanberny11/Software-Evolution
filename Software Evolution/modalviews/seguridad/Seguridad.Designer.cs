namespace Software_Evolution.modalviews.seguridad
{
    partial class Seguridad
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
            this.lblmensaje = new Software_Evolution.customcontrols.EvLabel();
            this.evLabel2 = new Software_Evolution.customcontrols.EvLabel();
            this.evLabel3 = new Software_Evolution.customcontrols.EvLabel();
            this.txtpass = new Software_Evolution.customcontrols.EvPassWordTextBox();
            this.txtusuario = new Software_Evolution.customcontrols.EvTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblmensaje
            // 
            this.lblmensaje.AutoSize = true;
            this.lblmensaje.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblmensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmensaje.Location = new System.Drawing.Point(0, 0);
            this.lblmensaje.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblmensaje.Name = "lblmensaje";
            this.lblmensaje.Size = new System.Drawing.Size(53, 13);
            this.lblmensaje.TabIndex = 0;
            this.lblmensaje.Text = "EvLabel";
            this.lblmensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // evLabel2
            // 
            this.evLabel2.AutoSize = true;
            this.evLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel2.Location = new System.Drawing.Point(9, 87);
            this.evLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.evLabel2.Name = "evLabel2";
            this.evLabel2.Size = new System.Drawing.Size(50, 13);
            this.evLabel2.TabIndex = 1;
            this.evLabel2.Text = "Usuario";
            // 
            // evLabel3
            // 
            this.evLabel3.AutoSize = true;
            this.evLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel3.Location = new System.Drawing.Point(9, 124);
            this.evLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.evLabel3.Name = "evLabel3";
            this.evLabel3.Size = new System.Drawing.Size(71, 13);
            this.evLabel3.TabIndex = 2;
            this.evLabel3.Text = "Contraseña";
            // 
            // txtpass
            // 
            this.txtpass.EnterTab = true;
            this.txtpass.FieldName = "";
            this.txtpass.IsActivar = true;
            this.txtpass.IsLimpiar = true;
            this.txtpass.IsSalvar = true;
            this.txtpass.IsValidar = true;
            this.txtpass.Location = new System.Drawing.Point(93, 122);
            this.txtpass.Margin = new System.Windows.Forms.Padding(2);
            this.txtpass.Name = "txtpass";
            this.txtpass.PasswordChar = '*';
            this.txtpass.Size = new System.Drawing.Size(200, 20);
            this.txtpass.TabIndex = 4;
            this.txtpass.Valor = "";
            // 
            // txtusuario
            // 
            this.txtusuario.EnterTab = true;
            this.txtusuario.FieldName = "";
            this.txtusuario.IsActivar = true;
            this.txtusuario.IsLimpiar = true;
            this.txtusuario.IsSalvar = true;
            this.txtusuario.IsValidar = true;
            this.txtusuario.Location = new System.Drawing.Point(93, 84);
            this.txtusuario.Margin = new System.Windows.Forms.Padding(2);
            this.txtusuario.Name = "txtusuario";
            this.txtusuario.Size = new System.Drawing.Size(200, 20);
            this.txtusuario.TabIndex = 3;
            this.txtusuario.Valor = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 156);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 26);
            this.button2.TabIndex = 6;
            this.button2.Text = "&Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(206, 156);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 26);
            this.button1.TabIndex = 5;
            this.button1.Text = "&Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Seguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 198);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.txtusuario);
            this.Controls.Add(this.evLabel3);
            this.Controls.Add(this.evLabel2);
            this.Controls.Add(this.lblmensaje);
            this.Name = "Seguridad";
            this.Text = "Seguridad";
            this.Load += new System.EventHandler(this.Seguridad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private customcontrols.EvLabel lblmensaje;
        private customcontrols.EvLabel evLabel2;
        private customcontrols.EvLabel evLabel3;
        private customcontrols.EvPassWordTextBox txtpass;
        private customcontrols.EvTextBox txtusuario;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}