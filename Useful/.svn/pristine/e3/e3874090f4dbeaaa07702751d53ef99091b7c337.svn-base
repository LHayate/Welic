using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Componentes
{
    [ToolboxBitmap(@"S:\Sistemas dotNet\Figuras\intervalo_data.png")]
    public partial class IntervaloCampoData2 : UserControl
    {
        public IntervaloCampoData2()
        {
            InitializeComponent();
        }
        private string _textChk = "Inter. Campo Dt";
        public string TextCheck
        {
            get { chkTitulo.Text = _textChk; return _textChk; }
            set { chkTitulo.Text = value; _textChk = value; }
        }

        private void chkTitulo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTitulo.Checked)
            {
                txtDtInicial.Enabled = true;
                txtDtFinal.Enabled = true;
                txtDtInicial.Focus();
            }
            else
            {
                txtDtInicial.Enabled = false;
                txtDtFinal.Enabled = false;
            }
        }

        public bool Checado()
        {
            if (chkTitulo.Checked && txtDtInicial.MaskFull && txtDtFinal.MaskFull)
                return true;
            else
                return false;
        }

        private void txtDtInicial_Leave(object sender, EventArgs e)
        {
            if ((!txtDtFinal.MaskFull) && (txtDtInicial.MaskFull))
            {                
                txtDtFinal.Text = txtDtInicial.Text;
                txtDtFinal.SelectAll();
            }
        }

        public void OcultarLabelTxtFinal(bool ocultar)
        {
            txtDtFinal.Visible = !ocultar;
            lbFinal.Visible = !ocultar;
        }

        public void OcultarLabelTxtInicial(bool ocultar)
        {
            txtDtInicial.Visible = !ocultar;
            lbInicial.Visible = !ocultar;
        }
    }
}
