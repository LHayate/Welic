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
    public partial class frmAreasConcentracoesCursosAssistente : FormAssistenteCadastro
    {
        public frmAreasConcentracoesCursosAssistente()
        {
            InitializeComponent();

            base.frmBase = new frmAreasConcentracoesCursos();
            base.typeClasse = typeof(BLL);
            base.nomeMetodo = "BuscarSgaAreasConcentracoesCursos";
            base.parametros = new object[] { null };
            base.PreencherGrid();
        }

        private void dgv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            base.frmBase.GetType().GetProperty("area").SetValue(base.frmBase, dgv.SelectedRows[0].Cells["colArea"].Value.ToString(), null);
            base.dgv_CellClick(sender, e);
        }

    }
}
