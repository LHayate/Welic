using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UseFul.ClientApi;
using UseFul.Forms.Welic;

namespace UseFul.Forms.Welic
{
    public partial class FormProcesso : FormWelic
    {
        public FormProcesso()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Construtor com bloqueio para múltiplas instâncias do formulário
        /// </summary>
        /// <param name="frmP">Formulário principal do projeto.</param>
        public FormProcesso(Form frmP): base(frmP)
        {
            InitializeComponent();
        }

        protected void LiberaTelaPermissao()
        {
            if (string.IsNullOrEmpty(this.IdProgram))
                btnPermissao.Visible = false;
            else
                btnPermissao.Visible = true;
        }

        private void FormProcesso_Load(object sender, EventArgs e)
        {
            LiberaTelaPermissao();
        }

        private void btnPermissao_Click(object sender, EventArgs e)
        {
            //Todo: PErmissão
            //frmManutencaoPermissoes frmMP = new frmManutencaoPermissoes();
            //frmMP.UsuarioLogado = Globals.Usuario;
            //frmMP.CodPrograma = this.CodigoSeguranca;
            //frmMP.ShowDialog();
        }
    }
}
