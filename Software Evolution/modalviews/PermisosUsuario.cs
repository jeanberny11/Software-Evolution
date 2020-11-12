using Software_Evolution.managers.general;
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

namespace Software_Evolution.modalviews
{
    public partial class PermisosUsuario : BaseForm
    {
        private readonly UsuariosManager manager = new UsuariosManager();
        private DataTable data = new DataTable();
        private String tabla;
        private int usuarioid;
        public PermisosUsuario(String tabla,int usuarioid)
        {
            InitializeComponent();
            this.tabla = tabla;
            this.usuarioid = usuarioid;
        }

        private void PermisosUsuario_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            data = manager.GetPermisosTemp();
            this.gridControl1.DataSource = data;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(ConfirmarMensaje("Desea salvar estos permisos?"))
            {
                try
                {
                    manager.Salvar_permisos2(usuarioid, tabla, data);
                    this.Close();
                }catch(Exception ex)
                {
                    Mensaje(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            for(int fila = 0; fila < gridView1.RowCount; fila++)
            {
                gridView1.SetRowCellValue(fila, "f_marcado", true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int fila = 0; fila < gridView1.RowCount; fila++)
            {
                gridView1.SetRowCellValue(fila, "f_marcado", false);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ValidarGrid(gridView1))
            {
                var modulo = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "f_caption_columna").ToString();
                for (int fila = 0; fila < gridView1.RowCount; fila++)
                {
                    if(gridView1.GetRowCellValue(fila, "f_caption_columna").ToString()==modulo)
                    gridView1.SetRowCellValue(fila, "f_marcado", true);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ValidarGrid(gridView1))
            {
                var modulo = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "f_caption_columna").ToString();
                for (int fila = 0; fila < gridView1.RowCount; fila++)
                {
                    if (gridView1.GetRowCellValue(fila, "f_caption_columna").ToString() == modulo)
                        gridView1.SetRowCellValue(fila, "f_marcado", false);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
