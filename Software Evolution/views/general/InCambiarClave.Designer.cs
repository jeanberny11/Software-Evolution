namespace Software_Evolution.views.general
{
    partial class InCambiarClave
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
            this.evLabel1 = new Software_Evolution.customcontrols.EvLabel();
            this.tpass = new Software_Evolution.customcontrols.EvPassWordTextBox();
            this.tnewpass = new Software_Evolution.customcontrols.EvPassWordTextBox();
            this.evLabel2 = new Software_Evolution.customcontrols.EvLabel();
            this.tconfirmpass = new Software_Evolution.customcontrols.EvPassWordTextBox();
            this.evLabel3 = new Software_Evolution.customcontrols.EvLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // evLabel1
            // 
            this.evLabel1.AutoSize = true;
            this.evLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel1.Location = new System.Drawing.Point(12, 53);
            this.evLabel1.Name = "evLabel1";
            this.evLabel1.Size = new System.Drawing.Size(154, 17);
            this.evLabel1.TabIndex = 0;
            this.evLabel1.Text = "Contraseña Anterior";
            // 
            // tpass
            // 
            this.tpass.EnterTab = true;
            this.tpass.FieldName = "";
            this.tpass.IsLimpiar = true;
            this.tpass.IsSalvar = true;
            this.tpass.IsValidar = true;
            this.tpass.Location = new System.Drawing.Point(172, 50);
            this.tpass.Name = "tpass";
            this.tpass.PasswordChar = '*';
            this.tpass.Size = new System.Drawing.Size(259, 22);
            this.tpass.TabIndex = 1;
            this.tpass.Valor = "";
            // 
            // tnewpass
            // 
            this.tnewpass.EnterTab = true;
            this.tnewpass.FieldName = "";
            this.tnewpass.IsLimpiar = true;
            this.tnewpass.IsSalvar = true;
            this.tnewpass.IsValidar = true;
            this.tnewpass.Location = new System.Drawing.Point(172, 96);
            this.tnewpass.Name = "tnewpass";
            this.tnewpass.PasswordChar = '*';
            this.tnewpass.Size = new System.Drawing.Size(259, 22);
            this.tnewpass.TabIndex = 3;
            this.tnewpass.Valor = "";
            // 
            // evLabel2
            // 
            this.evLabel2.AutoSize = true;
            this.evLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel2.Location = new System.Drawing.Point(12, 99);
            this.evLabel2.Name = "evLabel2";
            this.evLabel2.Size = new System.Drawing.Size(91, 17);
            this.evLabel2.TabIndex = 2;
            this.evLabel2.Text = "Contraseña";
            // 
            // tconfirmpass
            // 
            this.tconfirmpass.EnterTab = true;
            this.tconfirmpass.FieldName = "";
            this.tconfirmpass.IsLimpiar = true;
            this.tconfirmpass.IsSalvar = true;
            this.tconfirmpass.IsValidar = true;
            this.tconfirmpass.Location = new System.Drawing.Point(172, 142);
            this.tconfirmpass.Name = "tconfirmpass";
            this.tconfirmpass.PasswordChar = '*';
            this.tconfirmpass.Size = new System.Drawing.Size(259, 22);
            this.tconfirmpass.TabIndex = 5;
            this.tconfirmpass.Valor = "";
            // 
            // evLabel3
            // 
            this.evLabel3.AutoSize = true;
            this.evLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel3.Location = new System.Drawing.Point(12, 145);
            this.evLabel3.Name = "evLabel3";
            this.evLabel3.Size = new System.Drawing.Size(147, 17);
            this.evLabel3.TabIndex = 4;
            this.evLabel3.Text = "Validar Contraseña";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(172, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 33);
            this.button1.TabIndex = 6;
            this.button1.Text = "&Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(339, 199);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 33);
            this.button2.TabIndex = 7;
            this.button2.Text = "&Aceptar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // InCambiarClave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 260);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tconfirmpass);
            this.Controls.Add(this.evLabel3);
            this.Controls.Add(this.tnewpass);
            this.Controls.Add(this.evLabel2);
            this.Controls.Add(this.tpass);
            this.Controls.Add(this.evLabel1);
            this.Name = "InCambiarClave";
            this.Text = "InCambiarClave";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private customcontrols.EvLabel evLabel1;
        private customcontrols.EvPassWordTextBox tpass;
        private customcontrols.EvPassWordTextBox tnewpass;
        private customcontrols.EvLabel evLabel2;
        private customcontrols.EvPassWordTextBox tconfirmpass;
        private customcontrols.EvLabel evLabel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}