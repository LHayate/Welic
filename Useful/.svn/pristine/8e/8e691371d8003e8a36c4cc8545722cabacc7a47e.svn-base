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
    public partial class frmCustosDiretosAssistente : FormAssistenteCadastro
    {
        public frmCustosDiretosAssistente()
        {
            InitializeComponent();
            base.frmBase = new frmCustosDiretos();
            base.typeClasse = typeof(BLL);
            base.nomeMetodo = "BuscarSgaCustosDiretos";

            base.parametros = new object[] { null };
            base.PreencherGrid();
        }

        private void dgv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            base.frmBase.GetType().GetProperty("custo").SetValue(base.frmBase, dgv.SelectedRows[0].Cells["colCusto"].Value.ToString(), null);
            base.dgv_CellClick(sender, e);
        }              
    }
}
