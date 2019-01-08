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
    public partial class frmUnidadesCustosDiretosAssistente : FormAssistenteCadastro
    {
        public frmUnidadesCustosDiretosAssistente()
        {
            InitializeComponent();
            base.frmBase = new frmUnidadesCustosDiretos();
            base.typeClasse = typeof(BLL);
            base.nomeMetodo = "BuscarSgaUnidadesCustosDiretos";

            btnBuscar_Click(null, null);
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            base.parametros = new object[] { null };
            base.PreencherGrid();
        }

        private void dgv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            base.frmBase.GetType().GetProperty("unidade").SetValue(base.frmBase, dgv.SelectedRows[0].Cells["colUnidade"].Value.ToString(), null);
            base.dgv_CellClick(sender, e);
        }
    }
}
