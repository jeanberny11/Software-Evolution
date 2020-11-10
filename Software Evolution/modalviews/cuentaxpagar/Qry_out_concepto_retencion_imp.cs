﻿using Software_Evolution.data;
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

namespace Software_Evolution.modalviews.cuentaxpagar
{
    public partial class Qry_out_concepto_retencion_imp : BaseForm
    {
        private readonly QueryManager queryManager = QueryManager.Instance;
        private DataTable data;
        public int Result { get; set; }
        public Qry_out_concepto_retencion_imp()
        {
            InitializeComponent();
            Buscar();
        }
        private void Buscar()
        {
            data = queryManager.Query("select * from t_concepto_retenciones where f_tipo_impuesto=false");
            gridControl1.DataSource = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                Result = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle,"f_id"));
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
