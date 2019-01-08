using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UseFul.Forms.Welic;

namespace Componentes
{
    [ToolboxBitmap(@"S:\Sistemas dotNet\Figuras\intervalo_comp.png")]
    public partial class IntervaloCompetencias : UserControl
    {
        public IntervaloCompetencias()
        {
            InitializeComponent();
            
        }
        private string _textChk = "Inter. Comp.";
        public string TextCheck
        {
            get { chkTitulo.Text = _textChk; return _textChk; }
            set { chkTitulo.Text = value; _textChk = value; }
        }

        

        private void chkTitulo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTitulo.Checked)
            {
                dtpAnoInicial.Enabled = true;
                dtpAnoFinal.Enabled = true;
                cbInicial.Enabled = true;
                cbFinal.Enabled = true;
                dtpAnoInicial.Focus();
            }
            else
            {
                dtpAnoInicial.Enabled = false;
                dtpAnoFinal.Enabled = false;
                cbInicial.Enabled = false;
                cbFinal.Enabled = false;
            }
        }

        private void cbInicial_Leave(object sender, EventArgs e)
        {
            if (cbInicial.Text != "")
            {
                if (int.Parse(cbInicial.Text) > 12)
                {
                    cbInicial.Text = cbInicial.Text.Substring(1, 1);
                    if (int.Parse(cbInicial.Text) == 0)
                    {
                        cbInicial.Text = Convert.ToString((int.Parse(cbInicial.Text) + 1));
                    }             
                }
                else
                {
                    if (int.Parse(cbInicial.Text) == 0)
                    {
                        cbInicial.Text = Convert.ToString((int.Parse(cbInicial.Text) + 1));
                    }
                }
            }
            else
            {                
              cbInicial.Text = "1";                
            }                   
        }

        private void cbFinal_Leave(object sender, EventArgs e)
        {
            if (cbFinal.Text != "")
            {
                if (int.Parse(cbFinal.Text) > 12)
                {
                    if (int.Parse(cbFinal.Text) != 0)
                    {
                        cbFinal.Text = cbFinal.Text.Substring(1, 1);
                        if (int.Parse(cbFinal.Text) == 0)
                        {
                           cbFinal.Text = Convert.ToString((int.Parse(cbFinal.Text) + 1));
                        }
                    }
                    else
                    {
                        if (int.Parse(cbFinal.Text) == 0)
                        {
                            cbFinal.Text = Convert.ToString((int.Parse(cbFinal.Text) + 1));     
                        }                                                                
                    }
                }
            }
            else
            {
                cbFinal.Text = "12";
            }
        }

        private void cbInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((Convert.ToInt32(e.KeyChar) > 47 && Convert.ToInt32(e.KeyChar) < 58) || (Convert.ToInt32(e.KeyChar) == 13) || (Convert.ToInt32(e.KeyChar) == 8)))
                e.Handled = true;
        }

        private void cbFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((Convert.ToInt32(e.KeyChar) > 47 && Convert.ToInt32(e.KeyChar) < 58) || (Convert.ToInt32(e.KeyChar) == 13) || (Convert.ToInt32(e.KeyChar) == 8)))
                e.Handled = true;
        }

        public bool Checado()
        {
            if ((!this.chkTitulo.Checked) || (string.IsNullOrEmpty(this.cbInicial.Text) || string.IsNullOrEmpty(this.cbFinal.Text)))
                return false;
            return true;
        }
    }
}
