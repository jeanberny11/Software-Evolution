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

namespace Software_Evolution.modalviews.ventasfacturacion
{
    public partial class InPago : BaseForm
    {
        public static readonly string EFECTIVOKEY="EFECVTIVO", DEVUELTAKEY="DEVUELTA", MONTOCHEQUEKEY="CHEQUE", NUMEROCHEQUEKEY="CHEQUENO", 
            BANCOCHEQUEKEY="BANCOCHEQUE", CLAVECONFCHEQUEKEY="CLAVECHEQUE", FECHARECCHEQUEKEY="FECHAREC",FECHACOBROCHEQUEKEY="FECHACOBRO", 
            TIPOTARJETADEBKEY="TIPTARDEB", NOTARJETADEBKEY="TARJDEBNO", MONTOTARJETADEBKEY="MONTODEB", AUTTARJETADEBKEY="AUTDEB", 
            BANCOTARJETADEBKEY="BANCODEB", MONTOTARJETACREKEY="MONTOCRE",TIPOTARJETACREKEY="TIPTARCRE", NOTARJETACREKEY="TARJCRENO", 
            AUTTARJETACREKEY="AUTCRE", BANCOTARJETACREKEY="BANCECRE", MONTOTRANSKEY="MONTOTRANS", DOCTRANSKEY="DOCTRANS", BANCOTRANSKEY="BANCOTRANS", 
            FECHATRANSKEY="FECHATRANS",MONTOVALEKEY="MONTOVALE", DOCVALEKEY="DOCVALE", INSTVALEKEY="INSTVALE";
        private double montototal,totalpagado;
        public Dictionary<string, object> Distribucion;
        public InPago(double montototal)
        {            
            InitializeComponent();
            cmb_banco.LoadData();
            cmb_bancodeb.LoadData();
            cmb_bancocre.LoadData();
            cmb_bancodep.LoadData();
            cmb_institucion.LoadData();
            cmb_tarjetacre.LoadData();
            cmb_tarjetadeb.LoadData();
            this.montototal = montototal;
            lblmonto.Text = Ntos(montototal);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtmontodeb.Valor > 0 && cmb_tarjetadeb.IsEmpty())
            {
                Mensaje("Elija el tipo de tarjeta Débito");
                tabControl1.SelectedTab = tabTarjetaDeb;
                cmb_tarjetadeb.Focus();
                return;
            }
            if (txtmontocre.Valor > 0 && cmb_tarjetacre.IsEmpty())
            {
                Mensaje("Digite el tipo de tarjeta de Crédito");
                tabControl1.SelectedTab = tabTarjetaCre;
                cmb_tarjetacre.Focus();
                return;
            }
            if (totalpagado < montototal)
            {
                Mensaje("El Monto Total no es Suficiente para Cerrar Esta Factura");
                return;
            }

            Distribucion = new Dictionary<string, object>()
            {
                [EFECTIVOKEY] = txtefectivo.Valor,
                [DEVUELTAKEY] = totalpagado - montototal,
                [MONTOCHEQUEKEY] = txtmontocheque.Valor,
                [NUMEROCHEQUEKEY] = txtchequeno.Valor,
                [BANCOCHEQUEKEY] = cmb_banco.Valor,
                [CLAVECONFCHEQUEKEY] = txtclaveconf.Valor,
                [FECHARECCHEQUEKEY] = txtfecharecibido.Valor,
                [FECHACOBROCHEQUEKEY] = txtfechacobro.Valor,
                [NOTARJETADEBKEY] = txttarjetadebno.Valor,
                [TIPOTARJETADEBKEY] = cmb_tarjetadeb.Valor,
                [MONTOTARJETADEBKEY] = txtmontodeb.Valor,
                [AUTTARJETADEBKEY] = txtautorizaciondeb.Valor,
                [BANCOTARJETADEBKEY] = cmb_bancodeb.Valor,
                [NOTARJETACREKEY] = txttarjetacreno.Valor,
                [TIPOTARJETACREKEY] = cmb_tarjetacre.Valor,
                [MONTOTARJETACREKEY] = txtmontocre.Valor,
                [AUTTARJETACREKEY] = txtautorizacioncre.Valor,
                [BANCOTARJETACREKEY] = cmb_bancocre.Valor,
                [MONTOTRANSKEY] = txtmontotrans.Valor,
                [DOCTRANSKEY] = evIntegerTextBox1.Valor,
                [BANCOTRANSKEY] = cmb_bancodep.Valor,
                [FECHATRANSKEY] = evDateTimePicker1.Valor,
                [MONTOVALEKEY] = txtmontovale.Valor,
                [DOCVALEKEY] = evIntegerTextBox2.Valor,
                [INSTVALEKEY] = cmb_institucion.Valor
            };
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtmontovale_EditValueChanged(object sender, EventArgs e)
        {
            Calcular();
        }

        private void txtmontotrans_EditValueChanged(object sender, EventArgs e)
        {
            Calcular();
        }

        private void txtmontocre_EditValueChanged(object sender, EventArgs e)
        {
            Calcular();
        }

        private void txtmontodeb_EditValueChanged(object sender, EventArgs e)
        {
            Calcular();
        }

        private void txtmontocheque_EditValueChanged(object sender, EventArgs e)
        {
            Calcular();
        }

        private void txtefectivo_EditValueChanged(object sender, EventArgs e)
        {
            Calcular();
        }

        private void lblmonto_Click(object sender, EventArgs e)
        {
            txtefectivo.Valor = montototal;
        }

        private void Calcular()
        {
            totalpagado = txtefectivo.Valor + txtmontocheque.Valor + txtmontodeb.Valor + txtmontocre.Valor + txtmontotrans.Valor + txtmontovale.Valor;
            var devuelta = totalpagado - montototal;
            var pendiente = montototal - totalpagado;
            lbldevuelta.Text = Ntos(devuelta);
            lblpendiente.Text = Ntos(pendiente);
        }
    }
}
