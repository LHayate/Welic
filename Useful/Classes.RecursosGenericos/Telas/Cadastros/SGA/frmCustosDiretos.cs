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
    public partial class frmCustosDiretos : FormCadastro
    {
        public object custo { get; set; }
        public frmCustosDiretos()
        {
            InitializeComponent();


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
            this.toolStripBtnLocalizar.Visible = false;
            //this.toolStripBtnLocalizar.Click += new EventHandler(ClickLocalizar);
            this.toolStripBtnImprimir.Visible = false;
            //this.toolStripBtnImprimir.Click += new EventHandler(ClickImprimir);
            this.toolStripBtnAuditoria.Visible = true;
            this.toolStripBtnAuditoria.Click += new EventHandler(ClickAuditoria);
            this.toolStripBtnAjuda.Visible = false;
            //this.toolStripBtnAjuda.Click += new EventHandler(ClickAjuda);
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

            if (custo != null )
            {
                PreencherCampos(this.Controls, BLL.BuscarSgaCustosDiretos(custo));
            }

            ConfigurarTelaCadastroAssistente();
           
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
            if (!ValidaCamposObrigatorios(this.Controls))
                MessageBox.Show("Por favor, preencha os campos que identificam o registro a ser excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (MessageBox.Show("Confirma a exclusão do registro?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        //Declaração do seu objeto da modelagem passando o string Entities      
                        EntitiesSGA md = new EntitiesSGA(Classes.Entity.Globals.GetStringConnectionEntity(BLL.GetModelSGA()).ToString());

                        //Declaração da entidade (tabela)
                        CUSTOS_DIRETOS c;

                        //Busca pela chave
                        int custo = int.Parse(txtCusto.Text);
                        c = md.CUSTOS_DIRETOS.FirstOrDefault(w => w.CUSTO == custo);

                        //Deleta a entidade 
                        md.DeleteObject(c);

                        //Comita as alterações
                        md.SaveChanges();

                        //Seta null para as instancias do Entity            
                        md = null;
                        c = null;

                        MensagemStatusBar("Excluído com sucesso.");
                        LiberaChaveBloqueiaCampos(this.Controls);
                        LimpaCampos(this.Controls);
                        AcaoFormulario = CAcaoFormulario.Excluir;
                    }
                    catch (Exception ex)
                    {
                        #region Tratamento de erro
                        string msgErro = ex.Message;
                        if (ex.InnerException != null)
                        {
                            msgErro = ex.InnerException.ToString();
                            if (msgErro.Contains("ORA-02292"))
                            {
                                msgErro = "Existem outros registros no banco de dados que estão vinculados a este registro. Para excluir este registro é preciso primeiramente remover todos seus vínculos.";
                            }
                        }
                        MessageBox.Show("Não foi possível excluir o registro.\nMotivo: " + msgErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        #endregion
                    }
                }
            }
        }

        /// <summary>
        /// Código Padrão - Ação Botão Gravar - Tela de Cadastro
        /// Versão 0.1 - 23/08/2010
        /// </summary>
        private void ClickGravar(object sender, EventArgs e)
        {
            if (!ValidaCamposObrigatorios(this.Controls))
                MessageBox.Show("Por favor, preencha os campos que identificam o registro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                try
                {
                    //Declaração do seu objeto da modelagem passando o string Entities      
                    EntitiesSGA md = new EntitiesSGA(Classes.Entity.Globals.GetStringConnectionEntity(BLL.GetModelSGA()).ToString());

                    //Declaração da entidade (tabela)
                    CUSTOS_DIRETOS c;


                    if (AcaoFormulario == CAcaoFormulario.Novo)
                    {
                        //Seta campos
                        c = new CUSTOS_DIRETOS();

                        c.DESCRICAO = txtDescricao.Text.Trim();

                        //Insere Registro                    
                        md.AddToCUSTOS_DIRETOS(c);
                    }
                    else if (AcaoFormulario == CAcaoFormulario.Editar)
                    {
                        //Busca Entidade pelas chaves
                        int custo = int.Parse(txtCusto.Text);
                        c = md.CUSTOS_DIRETOS.FirstOrDefault(w => w.CUSTO == custo);

                        c.DESCRICAO = txtDescricao.Text.Trim();
                    }

                    //Comita as alterações
                    md.SaveChanges();

                    if (AcaoFormulario == CAcaoFormulario.Novo)
                    {
                        //Busca Chave AutoIncremento
                        txtCusto.Text = md.CUSTOS_DIRETOS.Max(x => x.CUSTO).ToString();
                    }

                    MensagemStatusBar("Salvo com sucesso.");
                    LiberaChaveBloqueiaCampos(this.Controls);
                    ModoOpcoes();
                    AcaoFormulario = CAcaoFormulario.Gravar;
                }
                catch (Exception ex)
                {
                    #region Tratamento de erro
                    string msgErro = ex.Message;
                    if (ex.InnerException != null)
                    {
                        msgErro = ex.InnerException.ToString();
                        if (msgErro.Contains("ORA-00001"))
                        {
                            msgErro = "O registro que você está tentando inserir já existe.";
                        }
                    }
                    MessageBox.Show("Não foi possível gravar o registro.\nMotivo: " + msgErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    #endregion
                }
            }
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
        /// Código Padrão - Ação Botão Auditoria - Tela de Cadastro
        /// Versão 0.2 - 21/03/2011
        /// </summary>
        private void ClickAuditoria(object sender, EventArgs e)
        {
            AcaoFormulario = CAcaoFormulario.Auditar;

            //  Caso a tabela possua mais de uma chave os campos "Nome da Chave" e "Chave' devem estar separados por ponto e vírgula ";" sem espaço. 
            //   Descomente o código abaixo e preencha os campos de acordo com suas necessidades.    

            frmAuditoriaFormulario frmAuditoriaFormulario = new frmAuditoriaFormulario("CUSTOS_DIRETOS", "SGA", "CUSTO", txtCusto.Text);
            if (frmAuditoriaFormulario.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                frmAuditoriaFormulario.ShowDialog();
            }
        }

        /// <summary>
        /// Código Padrão - Ação KeyUp Fechar(Esc) - Tela de Cadastro
        /// Versão 0.1 - 23/08/2010
        /// </summary>
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
    }
}