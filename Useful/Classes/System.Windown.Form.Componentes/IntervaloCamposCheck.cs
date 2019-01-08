using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IntervaloCamposCheck
{
    public partial class IntervaloCamposCheck : UserControl
    {
        public IntervaloCamposCheck()
        {
            InitializeComponent();
        }
        private string _textChk = "Inter. Campos Check";
        public string TextCheck
        {
            get { lbTitulo.Text = _textChk; return _textChk; }
            set { lbTitulo.Text = value; _textChk = value; }
        }

        public bool ChecadoSim()
        {
            if (chkSim.Checked)
                return true;
            else
                return false;
        }
        public bool ChecadoNao()
        {
            if (chkNao.Checked)
                return true;
            else
                return false;
        }


    }
}
