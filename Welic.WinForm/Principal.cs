using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UseFul.ClientApi;
using UseFul.Forms.Welic;
using Welic.WinForm.Cadastros.Estacionamento;
using Welic.WinForm.Cadastros.Pessoas;

namespace Welic.WinForm
{
    public partial class Principal : MainForm
    {        
        public Principal()
        {
            InitializeComponent();
            Globals.Sistema = 2;          

            ConfigurarFundoFormularioPrincipal("ERP Welic",
                "",
                "",
                "",
                "");            

        }
        void frmL_Load(object sender, EventArgs e)
        {
            new Seguranca().TrataPermissaoMenu(MenuPrincipal, true);
        }

        private void cadastrarNovoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadastroPessoas frm = new FrmCadastroPessoas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void estacionamentoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmCadastroEstacionamentos frm = new FrmCadastroEstacionamentos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mensalistaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
