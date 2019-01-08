using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UseFul.Forms.Welic
{
    [ToolboxBitmap(@"S:\Sistemas dotNet\Figuras\iButton.ico")]
    public partial class NumericUpDownWelic : NumericUpDown
    {
        /// <summary>
        /// Nome da coluna no DataTable, utilizado pelo método PreencherCampos(ControlCollection controls, DataTable dtDados)
        /// </summary>
        private string _NomeCampoDadosDataTable;
        public string NomeCampoDadosDataTable
        {
            get { return _NomeCampoDadosDataTable; }
            set
            { _NomeCampoDadosDataTable = value; }
        }

        public NumericUpDownWelic()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
