using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UseFul.ClientApi;
using UseFul.Forms.Welic;

namespace IntervaloCampos
{
    [ToolboxBitmap(@"S:\Sistemas dotNet\Figuras\intervalo.ico")]
    public partial class Competencia : UserControl
    {
        public Competencia()
        {
            InitializeComponent();
            txtAno.Enabled = false;
            txtMes.Enabled = false;
        }

        private string _textChk = "Competência";
        public string TextCheck
        {
            get { lblTitulo.Text = _textChk; return _textChk; }
            set { lblTitulo.Text = value; _textChk = value; }
        }

        private void chkTitulo_CheckedChanged(object sender, EventArgs e)
        {
            if (lblTitulo.Checked)
            {
                txtAno.Enabled = true;
                txtMes.Enabled = true;
                txtAno.Focus();
            }
            else
            {
                txtAno.Enabled = false;
                txtMes.Enabled = false;
            }

        }

        public bool Checado()
        {
            if (lblTitulo.Checked && !(string.IsNullOrEmpty(txtAno.Text)) && !(string.IsNullOrEmpty(txtMes.Text)))
                return true;
            else
                return false;
        }

        public string RetornoTxtInicial()
        {
            return txtAno.Text;
        }

        public string RetornoTxtFinal()
        {
            return txtMes.Text;
        }

        private void txtMes_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMes.Text))
            {
                int valor = int.Parse(txtMes.Text);
                if (valor < 1 || valor > 12)
                {
                    MessageBox.Show(this, "O valor do mês deve estar entre 1 e 12!", Globals.TituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtMes.Text = "";
                    txtMes.Focus();
                }
            }
        }
    }
}
