using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UseFul.Forms.Welic;




namespace IntervaloCampos
{
    [ToolboxBitmap(@"S:\Sistemas dotNet\Figuras\intervalo.ico")]
    public partial class IntervaloCampos : UserControl
    {
        public IntervaloCampos()
        {
            InitializeComponent();
            txtInicial.Enabled = false;
            txtFinal.Enabled = false;
        }
        public enum CTipoValor { Geral = 1, Numerico = 2 };
        private CTipoValor _tipoValor = CTipoValor.Geral;
        public CTipoValor TipoValor
        {
            get { return _tipoValor; }
            set
            {
                _tipoValor = value;
                txtInicial.TipoValor = (TextBoxWelic.CTipoValor)value;
                txtFinal.TipoValor = (TextBoxWelic.CTipoValor)value;
            }
        }

        private string _textChk = "Inter. Campo";
        public string TextCheck
        {
            get { lblTitulo.Text = _textChk; return _textChk; }
            set { lblTitulo.Text = value; _textChk = value; }
        }

        private int _maxLength;
        public int MaxLengthTextBox
        {
            get
            {
                txtInicial.MaxLength = _maxLength;
                txtFinal.MaxLength = _maxLength;
                return _maxLength;
            }
            set
            {
                txtInicial.MaxLength = value;
                txtFinal.MaxLength = value;
                _maxLength = value;
            }
        }

        private void chkTitulo_CheckedChanged(object sender, EventArgs e)
        {
            if (lblTitulo.Checked)
            {
                txtInicial.Enabled = true;
                txtFinal.Enabled = true;
                txtInicial.Focus();
            }
            else
            {
                txtInicial.Enabled = false;
                txtFinal.Enabled = false;
            }

        }

        public bool Checado()
        {
            if (lblTitulo.Checked && !(string.IsNullOrEmpty(txtInicial.Text)) && !(string.IsNullOrEmpty(txtFinal.Text)))
                return true;
            else
                return false;
        }

        private void txtInicial_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFinal.Text))
            {
                txtFinal.SelectAll();
                txtFinal.Text = txtInicial.Text;
            }

            if (string.IsNullOrEmpty(txtInicial.Text))
                txtFinal.Text = "";
        }
        public string RetornoTxtInicial()
        {
            return txtInicial.Text;
        }
        public string RetornoTxtFinal()
        {
            return txtFinal.Text;
        }

        public void OcultarLabelTxtFinal(bool ocultar)
        {
            txtFinal.Visible = !ocultar;
            lbFinal.Visible = !ocultar;
        }

        public void OcultarLabelTxtInicial(bool ocultar)
        {
            txtInicial.Visible = !ocultar;
            lbInicial.Visible = !ocultar;
        }
    }
}
