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
    public partial class FormCadastro : FormWelic
    {
        public FormCadastro()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Construtor com bloqueio para múltiplas instâncias do formulário
        /// </summary>
        /// <param name="frmP">Formulário principal do projeto.</param>
        public FormCadastro(Form frmP)
            : base(frmP)
        {
            InitializeComponent();
        }

        protected void ModoOpcoes()
        {
            toolStripBtnNovo.Enabled = SegurancaForm.Insert;
            toolStripBtnEditar.Enabled = SegurancaForm.Update;
            toolStripBtnExcluir.Enabled = SegurancaForm.Delete;
            toolStripBtnGravar.Enabled = false;
            toolStripBtnVoltar.Enabled = false;
            toolStripBtnLocalizar.Enabled = true;
            toolStripBtnImprimir.Enabled = true;
        }

        protected void ModoGravacao()
        {
            toolStripBtnNovo.Enabled = false;
            toolStripBtnEditar.Enabled = false;
            toolStripBtnExcluir.Enabled = false;
            toolStripBtnGravar.Enabled = true;
            toolStripBtnVoltar.Enabled = true;
            toolStripBtnLocalizar.Enabled = false;
            toolStripBtnImprimir.Enabled = false;
            MensagemStatusBar("");
        }

        /// <summary>
        /// Validação do componente MaskedTextBox
        /// </summary>
        /// <param name="txt">MaskedTextBoxWelic.</param>
        /// <param name="textoMensagem">Texto mensagem ex: Informe o Cep.</param>
        /// <param name="campo_obrigatorio">Verifica se o campo e obrigatorio.</param>
        /// <returns>True ou False</returns>

        protected bool ValidaMask(MaskedTextBoxWelic txt, string textoMensagem, bool campo_obrigatorio)
        {
            if (campo_obrigatorio == true)
            {
                if (txt.MaskFull == false)
                {
                    MessageBox.Show("Campo " + textoMensagem + " obrigatorio. Favor preencher.", nomePrograma, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt.Focus();
                    return false;
                }
                return true;
            }

            var Digitos = "0123456789";
            for (int i = 0; i < txt.Text.Length; i++)
            {
                string stv = txt.Text.Substring(i, 1);
                if (stv != " " || string.IsNullOrEmpty(txt.Text))
                {
                    if (Digitos.IndexOf(stv) >= 0)
                    {
                        if (txt.MaskFull == false)
                        {
                            MessageBox.Show("Favor informe o " + textoMensagem + " completo.", nomePrograma, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txt.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        protected void LiberaTelaPermissao()
        {
            if (string.IsNullOrEmpty(this.IdProgram))
                toolStripBtnPermissao.Visible = false;
            else
                toolStripBtnPermissao.Visible = true;
        }

        //Utilizado para bloquear campos da tela quando a mesma for aberta através do Assistente de Cadastro pela opção "Ver" (AcaoFormulario = Buscar)
        private void BloquearComponentesAssistente(Control.ControlCollection controls)
        {
            List<Control> list = new List<Control>();
            foreach (Control item in controls)
            {
                list.Add(item);
            }

            foreach (Control ctrl in list)
            {
                if (ctrl is ButtonWelic)
                    ctrl.Enabled = false;

                if (ctrl is DataGridViewWelic)
                {
                    foreach (DataGridViewColumn item in ((DataGridViewWelic)ctrl).Columns)
                    {
                        if (item.Name.ToUpper().Contains("IMGEDITAR"))
                            item.Visible = false;
                        else if (item.Name.ToUpper().Contains("IMGEXCLUIR"))
                            item.Visible = false;
                    }
                }

                //Se for um Container, executa a função novamente, passando os controles que existem dentro do container
                if (ctrl.HasChildren)
                {
                    BloquearComponentesAssistente(ctrl.Controls);
                }
            }
        }

        //Utilizado na AcaoFormulario Buscar para bloquear todos os componentes
        private void BloquearTodosComponentes(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is ButtonWelic)
                    ctrl.Enabled = false;

                if (ctrl is TextBoxWelic)
                {
                    ((TextBoxWelic)ctrl).Enabled = true;
                    ((TextBoxWelic)ctrl).ReadOnly = true;
                }

                if (ctrl is MaskedTextBoxWelic)
                {
                    ((MaskedTextBoxWelic)ctrl).Enabled = true;
                    ((MaskedTextBoxWelic)ctrl).ReadOnly = true;
                }

                if (ctrl is ComboBoxWelic)
                    ctrl.Enabled = false;

                if (ctrl is RadioButtonWelic)
                    ctrl.Enabled = false;

                if (ctrl is CheckBoxWelic)
                    ctrl.Enabled = false;

                if (ctrl is DataGridViewWelic)
                {
                    foreach (DataGridViewColumn item in ((DataGridViewWelic)ctrl).Columns)
                    {
                        if (item.Name.ToUpper().Contains("IMGEDITAR"))
                            item.Visible = false;
                        else if (item.Name.ToUpper().Contains("IMGEXCLUIR"))
                            item.Visible = false;
                    }
                }

                if (ctrl is DateTimePickerWelic)
                    ctrl.Enabled = false;

                if (ctrl.HasChildren)
                    BloquearTodosComponentes(ctrl.Controls);
            }
        }

        public void ConfigurarTelaCadastroAssistente()
        {
            if (this.AcaoFormulario == CAcaoFormulario.Novo)
            {
                toolStripBtnNovo.PerformClick();
            }
            if (this.AcaoFormulario == CAcaoFormulario.Buscar)
            {
                this.toolStripBtnNovo.Enabled = false;
                this.toolStripBtnEditar.Enabled = false;
                this.toolStripBtnExcluir.Enabled = false;
                this.toolStripBtnGravar.Enabled = false;
                this.toolStripBtnVoltar.Enabled = false;

                BloqueiaChaves(this.Controls);

                BloquearComponentesAssistente(this.Controls);
            }
            else if (this.AcaoFormulario == CAcaoFormulario.Editar)
            {
                toolStripBtnEditar.PerformClick();
            }
            else if (this.AcaoFormulario == CAcaoFormulario.Excluir)
            {
                this.toolStripBtnNovo.Enabled = false;
                this.toolStripBtnEditar.Enabled = false;
                BloqueiaChaves(this.Controls);

                //para mostrar a tela antes da msg de exclusao
                this.Show();
                this.Focus();
                toolStripBtnExcluir.PerformClick();

                BloqueiaChaves(this.Controls);
            }

            toolStripBtnVoltar.Enabled = false;
        }
        public void ConfigurarTelaCadastroAssistente(bool InativarComponentes)
        {
            if (this.AcaoFormulario == CAcaoFormulario.Nenhum)
            {
                toolStripBtnGravar.Enabled = false;
                toolStripBtnExcluir.Enabled = false;
            }
            else if (this.AcaoFormulario == CAcaoFormulario.Novo)
            {
                toolStripBtnNovo.PerformClick();
            }
            if (this.AcaoFormulario == CAcaoFormulario.Buscar)
            {
                this.toolStripBtnNovo.Enabled = false;
                this.toolStripBtnEditar.Enabled = false;
                this.toolStripBtnExcluir.Enabled = false;
                this.toolStripBtnGravar.Enabled = false;
                this.toolStripBtnVoltar.Enabled = false;

                BloqueiaChaves(this.Controls);

                BloquearComponentesAssistente(this.Controls);

                if (InativarComponentes)
                {
                    #region desativar todos os componentes
                    BloquearTodosComponentes(this.Controls);
                    #endregion
                }
            }
            else if (this.AcaoFormulario == CAcaoFormulario.Editar)
            {
                toolStripBtnEditar.PerformClick();
            }
            else if (this.AcaoFormulario == CAcaoFormulario.Excluir)
            {
                this.toolStripBtnNovo.Enabled = false;
                this.toolStripBtnEditar.Enabled = false;
                BloqueiaChaves(this.Controls);

                //para mostrar a tela antes da msg de exclusao
                this.Show();
                this.Focus();
                toolStripBtnExcluir.PerformClick();

                BloqueiaChaves(this.Controls);
            }

            toolStripBtnVoltar.Enabled = false;
        }

        protected void MensagemStatusBar(string mensagem)
        {
            toolStripStatuslblPrincipal.Text = mensagem;
        }

        private void FormCadastro_Load(object sender, EventArgs e)
        {
            //Todo: Resolver permissões 
            //LiberaTelaPermissao();
        }

        private void toolStripBtnNovo_Click(object sender, EventArgs e)
        {
            toolStripOpcoes.Focus();
        }
        private void toolStripBtnEditar_Click(object sender, EventArgs e)
        {
            toolStripOpcoes.Focus();
        }
        private void toolStripBtnExcluir_Click(object sender, EventArgs e)
        {
            toolStripOpcoes.Focus();
        }
        private void toolStripBtnGravar_Click(object sender, EventArgs e)
        {
            toolStripOpcoes.Focus();
        }
        private void toolStripBtnVoltar_Click(object sender, EventArgs e)
        {
            toolStripOpcoes.Focus();
        }
        private void toolStripBtnLocalizar_Click(object sender, EventArgs e)
        {
            toolStripOpcoes.Focus();
        }
        private void toolStripBtnImprimir_Click(object sender, EventArgs e)
        {
            toolStripOpcoes.Focus();
        }
        private void toolStripBtnAuditoria_Click(object sender, EventArgs e)
        {
            toolStripOpcoes.Focus();
        }
        private void toolStripBtnAjuda_Click(object sender, EventArgs e)
        {
            toolStripOpcoes.Focus();
        }
        private void toolStripBtnPermissao_Click(object sender, EventArgs e)
        {
            //toolStripOpcoes.Focus();

            //frmManutencaoPermissoes frmMP = new frmManutencaoPermissoes();
            //frmMP.UsuarioLogado = Globals.Usuario;
            //frmMP.CodPrograma = this.CodigoSeguranca;
            //frmMP.ShowDialog();
        }

        private const string WMCLOSE = "WmClose";

        public static bool IsFormClosing()
        {
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace();
            foreach (System.Diagnostics.StackFrame sf in stackTrace.GetFrames())
            {
                if (sf.GetMethod().Name == WMCLOSE)
                {
                    return true;
                }
            }
            return false;
        }

        public static void RegistroNaoEncontrado(TextBoxWelic txt)
        {
            if (IsFormClosing() == true)
                return;

            MessageBox.Show("Registro não encontrado", "Validação registro não encontrado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txt.Text = "";
            txt.Focus();
        }
        public static void RegistroNaoEncontrado(MaskedTextBoxWelic txt)
        {
            if (IsFormClosing() == true)
                return;

            MessageBox.Show("Registro não encontrado", "Validação registro não encontrado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txt.Text = "";
            txt.Focus();
        }

        public static bool MensagemCampoVazio(MaskedTextBoxWelic txt, string mensagem)
        {
            if (IsFormClosing() == true)
                return false;

            if (txt.MaskFull == false)
            {
                MessageBox.Show(mensagem, "Validação campo vazio.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt.Focus();
                return false;
            }
            return true;
        }
        public static bool MensagemCampoVazio(MaskedTextBoxDataWelic txt, string mensagem)
        {
            if (IsFormClosing() == true)
                return false;

            if (txt.MaskFull == false)
            {
                MessageBox.Show(mensagem, "Validação campo vazio.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt.Focus();
                return false;
            }
            return true;
        }
        public static bool MensagemCampoVazio(TextBoxWelic txt, string mensagem)
        {
            if (IsFormClosing() == true)
                return false;

            if (string.IsNullOrEmpty(txt.Text))
            {
                MessageBox.Show(mensagem, "Validação campo vazio.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt.Focus();
                return false;
            }
            return true;
        }
    }
}
