using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace UseFul.Forms.Welic
{
    [ToolboxBitmap(@"S:\Sistemas dotNet\Figuras\iCombobox.ico")]
    public partial class ComboBoxWelic : ComboBox
    {
        public ComboBoxWelic()
        {
            InitializeComponent();
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        public ComboBoxWelic(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

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

        private bool _limpaCampo = true;

        public bool LimpaCampo
        {
            get { return _limpaCampo; }
            set { _limpaCampo = value; }
        }
    }
}
