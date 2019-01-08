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
    [ToolboxBitmap(@"S:\Sistemas dotNet\Figuras\iLabel.ico")]
    public partial class LabelWelic : Label
    {
        public LabelWelic()
        {
            InitializeComponent();
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
