using DevExpress.XtraGrid;
using Software_Evolution.utils.clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Evolution.views.mantenimientos
{
    public partial class InExportarDatos : BaseForm
    {
        private readonly GridControl gridControl;

        public InExportarDatos(GridControl gridControl,string filename):this()
        {
            this.gridControl = gridControl;
            this.txtnombre.Text = filename;
            this.cmb_formato.SelectedIndex = 1;
        }

        public InExportarDatos()
        {
            InitializeComponent();
        }

        private void InExportarDatos_Load(object sender, EventArgs e)

        {
            CenterToScreen();
            txtfolder.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtfolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void cmb_formato_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmb_formato.SelectedIndex)
            {
                case 0:
                    {
                        lblextencion.Text = ".pdf";
                        break;
                    }
                case 1:
                    {
                        lblextencion.Text = ".xlsx";
                        break;
                    }
                case 2:
                    {
                        lblextencion.Text = ".docx";
                        break;
                    }
                case 3:
                    {
                        lblextencion.Text = ".txt";
                        break;
                    }
                default:
                    {
                        lblextencion.Text = "";
                        break;
                    }
            }
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            if (cmb_formato.Text == string.Empty)
            {
                Mensaje("Debe elegir el formato de salida");
                cmb_formato.Focus();
                return;
            }
            if (txtnombre.Text == string.Empty)
            {
                Mensaje("Debe digitar el nombre del archivo!");
                txtnombre.Focus();
                return;
            }
            string filename;
            switch (cmb_formato.SelectedIndex)
            {
                case 0:
                    {
                        filename = $"{txtfolder.Text}\\{txtnombre.Text}{lblextencion.Text}";
                        gridControl.ExportToPdf(filename);
                        break;
                    }
                case 1:
                    {
                        filename = $"{txtfolder.Text}\\{txtnombre.Text}{lblextencion.Text}";
                        gridControl.ExportToXlsx(filename);
                        break;
                    }
                case 2:
                    {
                        filename = $"{txtfolder.Text}\\{txtnombre.Text}{lblextencion.Text}";
                        gridControl.ExportToDocx(filename);
                        break;
                    }
                case 3:
                    {
                        filename = $"{txtfolder.Text}\\{txtnombre.Text}{lblextencion.Text}";
                        gridControl.ExportToText(filename);
                        break;
                    }
                default:
                    {
                        throw new Exception("Formato no soportado!");
                    }
            }
            if(ConfirmarMensaje("Desea abrir el archivo?"))
            {
                System.Diagnostics.Process.Start(filename);
            }
            Close();
        }

        private void txtfolder_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
