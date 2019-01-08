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
    public partial class IntervaloCampoData : UserControl
    {
        public IntervaloCampoData()
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
                dtpInicial.Enabled = true;
                dtpFinal.Enabled = true;
                dtpInicial.Focus();
            }
            else
            {
                dtpInicial.Enabled = false;
                dtpFinal.Enabled = false;
            }


        }
    }
}
