using Software_Evolution.managers.cuentaxpagar;
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

namespace Software_Evolution.views.cuentaxpagar
{
    public partial class InSuplidores : BaseForm
    {
        private DataTable tdescxprontopago;
        private readonly SuplidoresManager manager = new SuplidoresManager();
        public InSuplidores()
        {
            InitializeComponent();
            InitData();
            Creando = true;
        }

        public InSuplidores(int suplidorid) : this()
        {
            try
            {
                var datos = manager.GetSuplidor(suplidorid);
                Modificar(datos);
                tdescxprontopago= manager.Get_desc_x_pago_proveedor(txtcodigo.Valor);
                gridControl1.DataSource = tdescxprontopago;
                Refresh();
                Creando = false;
            }
            catch(Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        private void InitData()
        {
            cmb_pais.LoadData();
            cmb_moneda.LoadData();
            cmb_tiposuplidor.LoadData();
            cmb_estado.LoadData();
            cmb_comprador.LoadData();
            cmb_tipobeneficiario.LoadData();
            cmb_clasificacion.LoadData();
            tdescxprontopago = manager.Get_desc_x_pago_proveedor(0);
            gridControl1.DataSource = tdescxprontopago;

        }

        private void evLabel6_Click(object sender, EventArgs e)
        {

        }

        private void evLabel7_Click(object sender, EventArgs e)
        {

        }

        private void evMaskTextBox4_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void evMaskTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void evComboBox1_EditValueChanged(object sender, EventArgs e)
        {
            if (cmb_pais.Valor != null) {
                cmb_region.Param = cmb_pais.Valor.ToString();
                cmb_region.LoadData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtdiainicio.Valor == 0)
            {
                Mensaje("EL dia inicio no debe ser 0");
                txtdiainicio.Focus();
                return;
            }
            if (txtdiafin.Valor == 0)
            {
                Mensaje("EL dia fin no debe ser 0");
                txtdiafin.Focus();
                return;
            }
            if (tdescxprontopago.Select($"f_dia_inicio={txtdiainicio.Valor}").Length > 0)
            {
                Mensaje("Existe un registro con estos dias de inicio");
                txtdiainicio.Focus();
                return;
            }
            var row = tdescxprontopago.NewRow();
            row.SetField("f_dia_inicio", txtdiainicio.Valor);
            row.SetField("f_dia_fin", txtdiafin.Valor);
            row.SetField("f_descuento1", txtdescuento1.Valor);
            row.SetField("f_descuento2", txtdescuento2.Valor);
            tdescxprontopago.Rows.Add(row);
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidarGrid(gridView1))
            {
                tdescxprontopago.Rows.Remove(tdescxprontopago.Rows[gridView1.GetSelectedRows()[0]]);
                Refresh();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var res = manager.GetConceptos_impuesto(this);
            if (res > 0)
            {
                evIntegerTextBox4.Valor = res;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var res = manager.GetConceptos_islr(this);
            if (res > 0)
            {
                evIntegerTextBox5.Valor = res;
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!ValidarForm())
            {
                Mensaje("No ha llenado todos los campos obligatorias revise las pestañas");
                return;
            }

            // valido si el rnc existe
            if (txtcodigo.Valor == 0)
            {
                var res = manager.ValidarRnc(txtrnc.Text);
                if (!(res is null))
                {
                    Mensaje($"Este RNC/CED Esta registrado al Proveedor '{res.Field<string>("f_nombre")}' De Codigo '{res.Field<int>("f_id")}'");
                    return;
                }
            }
            // Fin


            if(cmb_tiposuplidor.IsValid())
                if (Convert.ToInt32(cmb_tiposuplidor.Valor) == 1)
                {
                    if(txtrnc.Text.Length>11 || txtrnc.Text.Length < 9)
                    {
                        Mensaje("El Rnc/Cedula no puede tener mas de 11 digitos ni menos de 9.");
                        txtrnc.Focus();
                        return;
                    }
                }
            if(!ConfirmarMensaje("Desea salvar los datos?"))
            {
                return;
            }
            var datos = new Dictionary<string, object>();
            Grabar(datos);
            try
            {
                manager.SalvarSuplidor(Creando, datos, tdescxprontopago);
            }catch(Exception ex)
            {
                Mensaje(ex.Message);
                return;
            }
            Limpiar();
            tdescxprontopago.Clear();
            tabControl1.SelectedTab = tabPage1;
        }
    }
}
