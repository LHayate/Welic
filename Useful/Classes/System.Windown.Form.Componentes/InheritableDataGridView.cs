using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.Design;
using System.ComponentModel;

namespace UseFul.Forms.Welic
{
    [Designer(typeof(ControlDesigner))]
    public class InheritableDataGridView : DataGridViewWelic
    {
        public InheritableDataGridView()
            : base()
        { }
    }
}
