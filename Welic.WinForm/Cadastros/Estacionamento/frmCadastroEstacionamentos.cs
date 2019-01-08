using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Windows.Forms;
using UseFul.ClientApi;
using UseFul.ClientApi.Dtos;
using UseFul.Forms.Welic;
using UseFul.Uteis;
using UseFul.Uteis.UI;

namespace Welic.WinForm.Cadastros.Estacionamento
{
    public partial class FrmCadastroEstacionamentos : FormCadastro
    {
        public FrmCadastroEstacionamentos()
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
            this.toolStripBtnImprimir.Visible = false;
            this.toolStripBtnAuditoria.Visible = false;
            this.toolStripBtnAjuda.Visible = false;
            this.toolStripSeparatorAcoes.Visible = true;
            this.toolStripSeparatorOutros.Visible = false;
        }
      
        private void PreencherVagas()
        {
            if (!string.IsNullOrEmpty(txtEstacionamento.Text))
            {
                HttpResponseMessage response =
                    ClienteApi.Instance.RequisicaoGet($"estacionamento/GetVagasByEstacionamento/{txtEstacionamento.Text}");
                var retorno =
                    ClienteApi.Instance.ObterResposta<List<EstacionamentoVagaDto>>(response);

               BindingVagas.DataSource = retorno;
            }
                
            else if (BindingVagas.DataSource != null)
                ((DataTable)BindingVagas.DataSource).Clear();
        }       

        private void PreencherFormulario()
        {
            try
            {
                if (string.IsNullOrEmpty(txtEstacionamento.Text))
                {
                    LimpaCampos(this.Controls);                    
                    AcaoFormulario = CAcaoFormulario.Nenhum;
                    GerenciaCampos();
                    return;
                }

                HttpResponseMessage response =
                    ClienteApi.Instance.RequisicaoGet($"estacionamento/Getbyid/{txtEstacionamento.Text}");
                var retorno =
                    ClienteApi.Instance.ObterResposta<EstacionamentoDto>(response);
               
                if (retorno != null)
                {
                    txtNome.Text = retorno.Descricao;
                    txtRelacao.Text = retorno.Relacao.ToString();                                        
                    
                    chkValidaVencimento.Checked = retorno.ValidaVencimento;                    
                    
                    PreencherVagas();                    

                    AcaoFormulario = CAcaoFormulario.Buscar;
                }
                else
                {
                    MessageBox.Show("Estacionamento não encontrado!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpaCampos(this.Controls);
                    
                    AcaoFormulario = CAcaoFormulario.Nenhum;
                }

                GerenciaCampos();
            }
            catch (CustomException ex)
            {
                ProcessMessage(ex.Message, MessageType.Error);
            }
            catch (Exception exception)
            {
                ProcessException(exception);
            }
        }

        private void GerenciaCampos()
        {
            if (AcaoFormulario == CAcaoFormulario.Novo || AcaoFormulario == CAcaoFormulario.Editar)
                pnBlocoVagaCurso.Enabled = true;
            else
                pnBlocoVagaCurso.Enabled = false;
        }

        private void SetaCamposEntidade(EstacionamentoDto estacionamento)
        {
            estacionamento.Descricao = txtNome.Text;
            estacionamento.Relacao = int.Parse(txtRelacao.Text) == 0 ? 1 : int.Parse(txtRelacao.Text);                        
            estacionamento.ValidaVencimento = chkValidaVencimento.Checked;
           
        }

        /// <summary>
        /// Código Padrão - Load do Formulário - Tela de Cadastro
        /// Versão 0.1 - 13/08/2010
        /// </summary>
        private void LoadFormulario(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEstacionamento.Text))
            {
                LiberaChaveBloqueiaCampos(this.Controls);
                LimpaCampos(this.Controls);
                ModoOpcoes();
                AcaoFormulario = CAcaoFormulario.Nenhum;

                GerenciaCampos();
            }
            else if (!string.IsNullOrEmpty(txtEstacionamento.Text))
            {
                PreencherVagas();
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

                    var estacionamento = new EstacionamentoDto();
                  
                    SetaCamposEntidade(estacionamento);
                  
                   
                    if (AcaoFormulario == CAcaoFormulario.Novo)
                    {
                        HttpResponseMessage
                            response = ClienteApi.Instance.RequisicaoPost("estacionamento/save", estacionamento);

                        estacionamento = ClienteApi.Instance.ObterResposta<EstacionamentoDto>(response);

                        txtEstacionamento.Text = estacionamento.IdEstacionamento.ToString();

                        MensagemInsertUpdate("Salvo com sucesso.");
                    }
                    else if (AcaoFormulario == CAcaoFormulario.Editar)
                    {
                        int chave = int.Parse(txtEstacionamento.Text);                       

                        //Valida Atualização da Relação Motos/Carro
                        int relacao = int.Parse(txtRelacao.Text);

                        if (relacao <= 1)
                            estacionamento.Relacao = 1;
                        else
                        {
                            for (int i = 1; i <= 3; i++)
                            {
                                HttpResponseMessage response =
                                    ClienteApi.Instance.RequisicaoGet($"estacionamento/GetListVagas/{txtEstacionamento.Text}");
                                var retorno =
                                    ClienteApi.Instance.ObterResposta<List<EstacionamentoVagaDto>>(response);

                                List<EstacionamentoVagaDto> lista = retorno;
                                if (lista.Count > 1)
                                    throw new Exception("Atenção!! \n\nEstacionamentos que possuem vagas para mais de 1 Tipo de Veículo no mesmo Tipo de Vaga não podem possuir Relação Motos/Carro diferente de 1. ");
                            }
                            estacionamento.Relacao = int.Parse(txtRelacao.Text);
                        }

                        SetaCamposEntidade(estacionamento);

                        HttpResponseMessage
                            responseUpdate = ClienteApi.Instance.RequisicaoPost("estacionamento/update", estacionamento);

                        ClienteApi.Instance.ObterResposta<EstacionamentoDto>(responseUpdate);

                        MensagemInsertUpdate("Alterado com sucesso.");
                    }
                    
                }
                catch (CustomException ex)
                {
                    ProcessMessage(ex.Message, MessageType.Error);
                }
                catch (Exception exception)
                {
                    ProcessException(exception);
                }
            }
        }
        private void MensagemInsertUpdate(string mensagem)
        {
            MensagemStatusBar(mensagem);
            LiberaChaveBloqueiaCampos(this.Controls);
            ModoOpcoes();
            AcaoFormulario = CAcaoFormulario.Gravar;

            GerenciaCampos();
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

                        HttpResponseMessage
                            response = ClienteApi.Instance.RequisicaoPost($"estacionamento/delete/{txtEstacionamento.Text}");

                        ClienteApi.Instance.ObterResposta(response);                        

                        MensagemStatusBar("Excluído com sucesso.");
                        LiberaChaveBloqueiaCampos(this.Controls);
                        LimpaCampos(this.Controls);                        
                        AcaoFormulario = CAcaoFormulario.Excluir;
                    }
                    catch (CustomException ex)
                    {
                        ProcessMessage(ex.Message, MessageType.Error);
                    }
                    catch (Exception exception)
                    {
                        ProcessException(exception);
                    }
                    GerenciaCampos();
                }
            }
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

            GerenciaCampos();
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

                GerenciaCampos();
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

            GerenciaCampos();
        }
        
        private void txtEstacionamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                HttpResponseMessage response =
                    ClienteApi.Instance.RequisicaoGet($"estacionamento/get");
                var retorno =
                    ClienteApi.Instance.ObterResposta<List<EstacionamentoDto>>(response);

                if (retorno.Count > 0)
                {
                    var fb = new FormBuscaPaginacao();
                    fb.SetList(retorno, "IdEstacionamento");
                    fb.ShowDialog();

                    if (fb.RetornoList<EstacionamentoDto>() != null)
                    {
                        txtEstacionamento.Text = fb.RetornoList<EstacionamentoDto>().IdEstacionamento.ToString();
                        PreencherFormulario();
                    }
                }

                
            }
        }

        private void txtEstacionamento_Leave(object sender, EventArgs e)
        {
            PreencherFormulario();
        }

        private void txtEstacionamento_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEstacionamento.Text))
                PreencherFormulario();
        }
        
        private void btnAddVagas_Click(object sender, EventArgs e)
        {
            if (!ValidaCamposObrigatorios(this.Controls))
                MessageBox.Show("Por favor, preencha os campos que identificam o registro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (string.IsNullOrEmpty(txtEstacionamento.Text))
                {
                    ClickGravar(sender, e);
                    ClickEditar(sender, e);
                }

                FrmCadastroEstacionamentoVagas frmCEV = new FrmCadastroEstacionamentoVagas(int.Parse(txtEstacionamento.Text));                               
                frmCEV.ShowDialog();
                PreencherVagas();
            }
        }        
        
        private void dgvVagas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvVagas.Columns["colVagaExcluir"].Index)
            {
                if (MessageBox.Show("Tem certeza que deseja EXCLUIR a Vaga?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {                        
                        int chave2 = int.Parse(dgvVagas.SelectedRows[0].Cells["ColTipoVaga"].Value.ToString());
                        int chave3 = int.Parse(dgvVagas.SelectedRows[0].Cells["ColTipoVeiculo"].Value.ToString());


                        HttpResponseMessage
                            response = ClienteApi.Instance.RequisicaoPost($"estacionamento/deleteVagas/{txtEstacionamento.Text}/{chave2}/{chave3}");

                        ClienteApi.Instance.ObterResposta(response);

                        PreencherVagas();
                        
                    }
                    catch (Exception ex)
                    {
                        if (ex.InnerException != null)
                            MessageBox.Show(this, "Não foi possível excluir o registro." + "\nErro: " + ex.InnerException.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show(this, "Não foi possível excluir o registro." + "\nErro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        
    }
}