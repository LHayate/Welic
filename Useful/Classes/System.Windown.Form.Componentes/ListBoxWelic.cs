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
    [ToolboxBitmap(@"S:\Sistemas dotNet\Figuras\iListbox.ico")]
    public partial class ListBoxWelic : ListBox
    {
        public ListBoxWelic()
        {
            InitializeComponent();
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        public ListBoxWelic(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private bool _limpaCampo = true;

        public bool LimpaCampo
        {
            get { return _limpaCampo; }
            set { _limpaCampo = value; }
        }
    }
}
