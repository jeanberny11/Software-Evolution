using Software_Evolution.utils.clases;
using System;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace Software_Evolution.views.mantenimientos
{
    public partial class InEnviarCorreo : BaseForm
    {
        public InEnviarCorreo()
        {
            InitializeComponent();
            txtremitente.Text = AppData.Instance.Currentuser.Email;
        }

        public InEnviarCorreo(string destinatario,string mensaje,string asunto,FastReport.Report report) : this()
        {
            txtdestinatario.Text = destinatario;
            txtasunto.Text = asunto;
            txtmensaje.Text = mensaje;
            var pdfExport = new FastReport.Export.Pdf.PDFExport();
            pdfExport.ShowPrintDialog = false;
            pdfExport.ShowProgress = false;
            report.Export(pdfExport, $"C:\\archivos_recibidos\\documento_{destinatario}.pdf");
            txtadjunto.Text = $"C:\\archivos_recibidos\\documento_{destinatario}.pdf";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidarForm())
            {
                return;
            }
            if (!ConfirmarMensaje("Desea enviar el correo?"))
                return;
            try
            {
                var message = new MailMessage();
                var smtpClient = new SmtpClient();

                smtpClient.Credentials = new NetworkCredential(AppData.Instance.Currentuser.Email, AppData.Instance.Currentuser.EmailPassword);
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;

                message.From = new MailAddress(txtremitente.Text);
                message.To.Add(txtdestinatario.Text.Trim());
                message.Subject = txtasunto.Text;
                message.Body = txtmensaje.Text;
                message.IsBodyHtml = true;
                if (txtadjunto.Text != string.Empty)
                {
                    message.Attachments.Add(new Attachment(txtadjunto.Text));
                }
                smtpClient.Send(message);
                Mensaje("Correo enviado con exito!");
            }catch(Exception ex)
            {
                Mensaje(ex.Message);
                return;
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtadjunto.Text = open.FileName;
            }
        }
    }
}
