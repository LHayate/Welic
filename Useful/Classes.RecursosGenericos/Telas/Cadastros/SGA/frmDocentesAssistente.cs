using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Uniube;

namespace Classes.RecursosGenericos.Telas.Cadastros.SGA
{
    public partial class frmDocentesAssistente : FormAssistenteCadastro
    {
        public frmDocentesAssistente()
        {
            InitializeComponent();
            base.frmBase = new frmDocentes();
            base.typeClasse = typeof(BLL);
            base.nomeMetodo = "BuscarSgaSgaDocentes";
            btnBuscar_Click(null, null);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void dgv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
