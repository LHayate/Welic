using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UseFul.Forms.Welic;

namespace UseFul.Forms.Welic
{
    public partial class FormCadastroRapido : FormCadastro
    {
        public FormCadastroRapido()
        {
            InitializeComponent();
            InicializaEventos();
        }

        /// <summary>
        /// Construtor com bloqueio para múltiplas instâncias do formulário
        /// </summary>
        /// <param name="frmP">Formulário principal do projeto.</param>
        public FormCadastroRapido(Form frmP): base(frmP)
        {
            InitializeComponent();
            InicializaEventos();
        }

        private void InicializaEventos()
        {
            //Inicialização dos Eventos.
            this.Load += new EventHandler(LoadFormulario);
            this.toolStripBtnNovo.Visible = true;
            this.toolStripBtnNovo.Click += new EventHandler(ClickNovo);
            this.toolStripBtnEditar.Visible = true;
            this.toolStripBtnEditar.Click += new EventHandler(ClickEditar);
            this.toolStripBtnExcluir.Visible = true;
            this.toolStripBtnExcluir.Click += new EventHandler(ClickExcluir);
            this.toolStripBtnGravar.Visible = true;
            this.toolStripBtnGravar.Click += new EventHandler(ClickGravar);
            this.toolStripBtnVoltar.Visible = true;
            this.toolStripBtnVoltar.Click += new EventHandler(ClickVoltar);
            this.toolStripBtnLocalizar.Visible = true;
            this.toolStripBtnLocalizar.Click += new EventHandler(ClickLocalizar);
            this.toolStripBtnImprimir.Visible = true;
            this.toolStripBtnImprimir.Click += new EventHandler(ClickImprimir);
            this.toolStripBtnAuditoria.Visible = true;
            this.toolStripBtnAuditoria.Click += new EventHandler(ClickAuditoria);
            this.toolStripBtnAjuda.Visible = true;
            this.toolStripBtnAjuda.Click += new EventHandler(ClickAjuda);
            this.toolStripSeparatorAcoes.Visible = true;
            this.toolStripSeparatorOutros.Visible = true;
            this.KeyUp += new KeyEventHandler(KeyUpFechar);
        }

        /// <summary>
        /// Código Padrão - Load do Formulário - Tela de Cadastro
        /// Versão 0.1 - 13/08/2010
        /// </summary>
        private void LoadFormulario(object sender, EventArgs e)
        {
            LiberaChaveBloqueiaCampos(this.Controls);
            LimpaCampos(this.Controls);
            ModoOpcoes();
            AcaoFormulario = CAcaoFormulario.Nenhum;
        }

        /// <summary>
        /// Código Padrão - Ação Botão Novo - Tela de Cadastro
        /// Versão 0.1 - 13/08/2010
        /// </summary>
        private void ClickNovo(object sender, EventArgs e)
        {
            LimpaCamposBloqueiaAutoIncremento(this.Controls);
            ModoGravacao();
            AcaoFormulario = CAcaoFormulario.Novo;
        }

        /// <summary>
        /// Código Padrão - Ação Botão Editar - Tela de Cadastro
        /// Versão 0.1 - 23/08/2010
        /// </summary>
        private void ClickEditar(object sender, EventArgs e)
        {
            if (!ValidaCamposObrigatorios(this.Controls))
                MessageBox.Show("Por favor, preencha os campos que identificam o registro a ser alterado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                BloqueiaChaveLiberaCampos(this.Controls);
                ModoGravacao();
                AcaoFormulario = CAcaoFormulario.Editar;
            }
        }

        /// <summary>
        /// Código Padrão - Ação Botão Excluir - Tela de Cadastro
        /// Versão 0.1 - 23/08/2010
        /// </summary>
        private void ClickExcluir(object sender, EventArgs e)
        {
            //Implementação pelo programador.
        }

        /// <summary>
        /// Código Padrão - Ação Botão Gravar - Tela de Cadastro
        /// Versão 0.1 - 23/08/2010
        /// </summary>
        private void ClickGravar(object sender, EventArgs e)
        {
            //Implementação pelo programador.
        }
            
        /// <summary>
        /// Código Padrão - Ação Botão Voltar - Tela de Cadastro
        /// Versão 0.1 - 23/08/2010
        /// </summary>
        private void ClickVoltar(object sender, EventArgs e)
        {
            LiberaChaveBloqueiaCampos(this.Controls);
            LimpaCamposNaoChave(this.Controls);
            ModoOpcoes();
            AcaoFormulario = CAcaoFormulario.Voltar;
        }

        /// <summary>
        /// Código Padrão - Ação Botão Localizar - Tela de Cadastro
        /// Versão 0.1 - 23/08/2010
        /// </summary>
        private void ClickLocalizar(object sender, EventArgs e)
        {
            AcaoFormulario = CAcaoFormulario.Buscar;
        }

        /// <summary>
        /// Código Padrão - Ação Botão Imprimir - Tela de Cadastro
        /// Versão 0.1 - 23/08/2010
        /// </summary>
        private void ClickImprimir(object sender, EventArgs e)
        {
            AcaoFormulario = CAcaoFormulario.Imprimir;
        }

        /// <summary>
        /// Código Padrão - Ação Botão Auditoria - Tela de Cadastro
        /// Versão 0.1 - 23/08/2010
        /// </summary>
        private void ClickAuditoria(object sender, EventArgs e)
        {
            AcaoFormulario = CAcaoFormulario.Auditar;
        }

        /// <summary>
        /// Código Padrão - Ação Botão Ajuda - Tela de Cadastro
        /// Versão 0.1 - 23/08/2010
        /// </summary>
        private void ClickAjuda(object sender, EventArgs e)
        {
            AcaoFormulario = CAcaoFormulario.Ajudar;
        }

        /// <summary>
        /// Código Padrão - Ação Botão Ajuda - Tela de Cadastro
        /// Versão 0.1 - 23/08/2010
        /// </summary>1 
        private void KeyUpFechar(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (AcaoFormulario == CAcaoFormulario.Novo || AcaoFormulario == CAcaoFormulario.Editar)
                    LoadFormulario(sender, new EventArgs());
                else
                    this.Close();
            }
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
