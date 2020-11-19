namespace Software_Evolution.views.mantenimientos
{
    partial class InEnviarCorreo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InEnviarCorreo));
            this.evLabel1 = new Software_Evolution.customcontrols.EvLabel();
            this.txtremitente = new Software_Evolution.customcontrols.EvTextBox();
            this.evLabel2 = new Software_Evolution.customcontrols.EvLabel();
            this.evLabel3 = new Software_Evolution.customcontrols.EvLabel();
            this.evLabel4 = new Software_Evolution.customcontrols.EvLabel();
            this.evLabel5 = new Software_Evolution.customcontrols.EvLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtdestinatario = new Software_Evolution.customcontrols.EvTextBox();
            this.txtasunto = new Software_Evolution.customcontrols.EvTextBox();
            this.txtadjunto = new Software_Evolution.customcontrols.EvTextBox();
            this.txtmensaje = new Software_Evolution.customcontrols.EvTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lbltitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // evLabel1
            // 
            this.evLabel1.AutoSize = true;
            this.evLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel1.Location = new System.Drawing.Point(10, 77);
            this.evLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.evLabel1.Name = "evLabel1";
            this.evLabel1.Size = new System.Drawing.Size(23, 13);
            this.evLabel1.TabIndex = 0;
            this.evLabel1.Text = "De";
            // 
            // txtremitente
            // 
            this.txtremitente.Enabled = false;
            this.txtremitente.EnterTab = true;
            this.txtremitente.FieldName = "";
            this.txtremitente.IsActivar = true;
            this.txtremitente.IsLimpiar = true;
            this.txtremitente.IsSalvar = false;
            this.txtremitente.IsValidar = true;
            this.txtremitente.Location = new System.Drawing.Point(119, 75);
            this.txtremitente.Margin = new System.Windows.Forms.Padding(2);
            this.txtremitente.Name = "txtremitente";
            this.txtremitente.Size = new System.Drawing.Size(396, 20);
            this.txtremitente.TabIndex = 1;
            this.txtremitente.Valor = "";
            // 
            // evLabel2
            // 
            this.evLabel2.AutoSize = true;
            this.evLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel2.Location = new System.Drawing.Point(10, 106);
            this.evLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.evLabel2.Name = "evLabel2";
            this.evLabel2.Size = new System.Drawing.Size(33, 13);
            this.evLabel2.TabIndex = 2;
            this.evLabel2.Text = "Para";
            // 
            // evLabel3
            // 
            this.evLabel3.AutoSize = true;
            this.evLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel3.Location = new System.Drawing.Point(10, 136);
            this.evLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.evLabel3.Name = "evLabel3";
            this.evLabel3.Size = new System.Drawing.Size(46, 13);
            this.evLabel3.TabIndex = 3;
            this.evLabel3.Text = "Asunto";
            // 
            // evLabel4
            // 
            this.evLabel4.AutoSize = true;
            this.evLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel4.Location = new System.Drawing.Point(10, 165);
            this.evLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.evLabel4.Name = "evLabel4";
            this.evLabel4.Size = new System.Drawing.Size(97, 13);
            this.evLabel4.TabIndex = 4;
            this.evLabel4.Text = "Archivo Adjunto";
            // 
            // evLabel5
            // 
            this.evLabel5.AutoSize = true;
            this.evLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evLabel5.Location = new System.Drawing.Point(10, 192);
            this.evLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.evLabel5.Name = "evLabel5";
            this.evLabel5.Size = new System.Drawing.Size(54, 13);
            this.evLabel5.TabIndex = 5;
            this.evLabel5.Text = "Mensaje";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::Software_Evolution.Properties.Resources.Email_30017;
            this.button1.Location = new System.Drawing.Point(472, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 33);
            this.button1.TabIndex = 6;
            this.Fromtooltip.SetToolTip(this.button1, "Enviar Correo");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtdestinatario
            // 
            this.txtdestinatario.EnterTab = true;
            this.txtdestinatario.FieldName = "";
            this.txtdestinatario.IsActivar = true;
            this.txtdestinatario.IsLimpiar = true;
            this.txtdestinatario.IsSalvar = false;
            this.txtdestinatario.IsValidar = true;
            this.txtdestinatario.Location = new System.Drawing.Point(119, 104);
            this.txtdestinatario.Margin = new System.Windows.Forms.Padding(2);
            this.txtdestinatario.Name = "txtdestinatario";
            this.txtdestinatario.Size = new System.Drawing.Size(396, 20);
            this.txtdestinatario.TabIndex = 7;
            this.txtdestinatario.Valor = "";
            // 
            // txtasunto
            // 
            this.txtasunto.EnterTab = true;
            this.txtasunto.FieldName = "";
            this.txtasunto.IsActivar = true;
            this.txtasunto.IsLimpiar = true;
            this.txtasunto.IsSalvar = false;
            this.txtasunto.IsValidar = true;
            this.txtasunto.Location = new System.Drawing.Point(119, 133);
            this.txtasunto.Margin = new System.Windows.Forms.Padding(2);
            this.txtasunto.Name = "txtasunto";
            this.txtasunto.Size = new System.Drawing.Size(396, 20);
            this.txtasunto.TabIndex = 8;
            this.txtasunto.Valor = "";
            // 
            // txtadjunto
            // 
            this.txtadjunto.EnterTab = true;
            this.txtadjunto.FieldName = "";
            this.txtadjunto.IsActivar = true;
            this.txtadjunto.IsLimpiar = true;
            this.txtadjunto.IsSalvar = false;
            this.txtadjunto.IsValidar = false;
            this.txtadjunto.Location = new System.Drawing.Point(119, 162);
            this.txtadjunto.Margin = new System.Windows.Forms.Padding(2);
            this.txtadjunto.Name = "txtadjunto";
            this.txtadjunto.Size = new System.Drawing.Size(344, 20);
            this.txtadjunto.TabIndex = 9;
            this.txtadjunto.Valor = "";
            // 
            // txtmensaje
            // 
            this.txtmensaje.EnterTab = false;
            this.txtmensaje.FieldName = "";
            this.txtmensaje.IsActivar = true;
            this.txtmensaje.IsLimpiar = true;
            this.txtmensaje.IsSalvar = false;
            this.txtmensaje.IsValidar = true;
            this.txtmensaje.Location = new System.Drawing.Point(119, 192);
            this.txtmensaje.Margin = new System.Windows.Forms.Padding(2);
            this.txtmensaje.Multiline = true;
            this.txtmensaje.Name = "txtmensaje";
            this.txtmensaje.Size = new System.Drawing.Size(396, 163);
            this.txtmensaje.TabIndex = 10;
            this.txtmensaje.Valor = "";
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(472, 154);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(38, 34);
            this.button2.TabIndex = 11;
            this.Fromtooltip.SetToolTip(this.button2, "Adjuntar Archivo");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbltitulo
            // 
            this.lbltitulo.AutoSize = true;
            this.lbltitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitulo.Location = new System.Drawing.Point(9, 15);
            this.lbltitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.Size = new System.Drawing.Size(139, 24);
            this.lbltitulo.TabIndex = 12;
            this.lbltitulo.Text = "Enviar Correo";
            // 
            // InEnviarCorreo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 366);
            this.Controls.Add(this.lbltitulo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtmensaje);
            this.Controls.Add(this.txtadjunto);
            this.Controls.Add(this.txtasunto);
            this.Controls.Add(this.txtdestinatario);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.evLabel5);
            this.Controls.Add(this.evLabel4);
            this.Controls.Add(this.evLabel3);
            this.Controls.Add(this.evLabel2);
            this.Controls.Add(this.txtremitente);
            this.Controls.Add(this.evLabel1);
            this.Name = "InEnviarCorreo";
            this.Text = "Enviar Correo";
            this.Load += new System.EventHandler(this.InEnviarCorreo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private customcontrols.EvLabel evLabel1;
        private customcontrols.EvTextBox txtremitente;
        private customcontrols.EvLabel evLabel2;
        private customcontrols.EvLabel evLabel3;
        private customcontrols.EvLabel evLabel4;
        private customcontrols.EvLabel evLabel5;
        private System.Windows.Forms.Button button1;
        private customcontrols.EvTextBox txtdestinatario;
        private customcontrols.EvTextBox txtasunto;
        private customcontrols.EvTextBox txtadjunto;
        private customcontrols.EvTextBox txtmensaje;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbltitulo;
    }
}