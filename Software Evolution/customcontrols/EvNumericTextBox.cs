﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace Software_Evolution.customcontrols
{
    public class EvNumericTextBox : TextEdit, IEvBaseComponent<double>
    {

        public EvNumericTextBox()
        {
            this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Properties.Mask.EditMask = "n";
            this.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.EditValue = 0.00;
        }

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Hace que la tecla enter funcione como 'TAB'")]
        public bool EnterTab { get; set; } = true;

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Indica si hay que validar que el texto no este vacio")]
        public bool IsValidar { get; set; } = true;

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Indica si hay que limpiar el texto")]
        public bool IsLimpiar { get; set; } = true;

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Indica si el text se va a salvar")]
        public bool IsSalvar { get; set; } = true;

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("El nombre del campo de la tabla al que debe guardar este texto")]
        public string FieldName { get; set; } = "";

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Indica si el componente de puede habilitar y deshabilitar")]
        public bool IsActivar { get; set; } = true;

        [DefaultValue(0.00)]
        public double Valor { get =>Convert.ToDouble(this.EditValue) ; set=>this.EditValue=value ; }

        public bool IsEmpty()
        {
            if (this.EditValue is null)
            {
                return true;
            }
            else
            {
                return this.EditValue.Equals(0);
            }
        }

        public bool IsValid()
        {
            return !IsEmpty();
        }

        public void Limpiar()
        {
            this.EditValue = 0.00;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter) && EnterTab)
            {
                SendKeys.Send("{TAB}");
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
