using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using UseFul.ClientApi;
using UseFul.ClientApi.Dtos;
using UseFul.Forms.Welic;
using UseFul.Uteis;
using UseFul.Uteis.UI;

namespace Welic.WinForm.Cadastros.Pessoas
{
    public partial class FrmCadastroPessoas : FormCadastro
    {
        private PessoaDto _pessoaDto;


        public FrmCadastroPessoas()
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
            this.toolStripBtnAuditoria.Visible = false;            
            this.toolStripBtnAjuda.Visible = false;
            //this.toolStripBtnAjuda.Click += new EventHandler(ClickAjuda);
            this.toolStripSeparatorAcoes.Visible = true;
            this.toolStripSeparatorOutros.Visible = false;
            this.KeyUp += new KeyEventHandler(KeyUpFechar);
        }

        private void LimpaCamposNaoChave()
        {
            LimpaCamposNaoChave(this.Controls);
            cboSexo.SelectedIndex = 0;
            if (cboUfEndereco.Items.Count > 0)
                cboUfEndereco.SelectedIndex = 0;
            if (cboUfNaturalidade.Items.Count > 0)
                cboUfNaturalidade.SelectedIndex = 0;
            if (cboUfOrgaoExpedidor.Items.Count > 0)
                cboUfOrgaoExpedidor.SelectedIndex = 0;
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
            LimpaCamposNaoChave();
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
                        _pessoaDto = (PessoaDto) BindingPessoa.DataSource;
                        
                        HttpResponseMessage
                            response = ClienteApi.Instance.RequisicaoPost($"pessoa/delete/{_pessoaDto.IdPessoa}");

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
                    _pessoaDto = new PessoaDto()
                    {
                        NomePai = txtNomePai.Text,
                        Celular = txtTelCelular.MaskFull ? txtTelCelular.Text.Replace("(", "").Replace(")", "").Replace("-", "") : "",
                        Bairro = txtBairro.Text,
                        Cep = int.Parse(txtCEP.Text.Replace(".", "").Replace("-", "").Trim()),
                        Cidade = txtCidadeEndereco.Text,
                        Complemento = txtComplemento.Text,
                        Cpf = long.Parse(txtCPF.Text.Replace(".", "").Replace("-", "").Trim()),
                        DataExpedicao = DateTime.Parse(txtDtExpedicaoRG.Text.Trim()),
                        DataNascimeto = DateTime.Parse(txtDtNascimento.Text.Trim()),
                        Email = txtEmail.Text,
                        EmailCorporativo = txtEmailCorporativo.Text,
                        Endereco = txtEndereco.Text,
                        EstadoCivil = txtEstadoCivilDesc.Text,
                        Identidade = txtRG.Text,
                        OrgaoExpeditor = cboUfOrgaoExpedidor.SelectedItem.ToString(),
                        Nacionalidade = txtNacionalidadeDesc.Text,
                        Naturalidade = txtCidadeNaturalidade.Text,
                        Nome = txtNome.Text,
                        NomeMae = txtNomeMae.Text,
                        Numero = txtNumero.Text,
                        Secao = int.Parse(txtSecao.Text),
                        Zona = int.Parse(txtZona.Text),
                        Sexo = cboSexo.SelectedIndex,//1-masculino; 2-feminino
                        Telefone = txtTelResidencial.MaskFull ? txtTelResidencial.Text.Replace("(", "").Replace(")", "").Replace("-", "") : "",
                        TelComercial = txtTelComercial.MaskFull ? txtTelComercial.Text.Replace("(", "").Replace(")", "").Replace("-", "") : "",
                        TituloEleitor = txtTituloEleitor.Text,
                        UfExpeditor = cboUfOrgaoExpedidor.SelectedIndex,
                    };

                    #region campos                   


                    //int? cidadeNaturalidade = null;
                    //if (!string.IsNullOrEmpty(txtCidadeNaturalidade.Text.Trim()))
                    //    cidadeNaturalidade = int.Parse(txtCidadeNaturalidade.Text);

                    //int? nacionalidade = null;
                    //if (!string.IsNullOrEmpty(txtNacionalidade.Text.Trim()))
                    //    nacionalidade = int.Parse(txtNacionalidade.Text);

                    //string rg = txtRG.Text;                                                         

                    //int? cidadeEndereco = null;
                    //if (!string.IsNullOrEmpty(txtCidadeEndereco.Text.Trim()))
                    //    cidadeEndereco = int.Parse(txtCidadeEndereco.Text);

                    #endregion

                    if (AcaoFormulario == CAcaoFormulario.Novo)
                    {
                        HttpResponseMessage
                            response = ClienteApi.Instance.RequisicaoPost("pessoa/save", _pessoaDto);

                        _pessoaDto =
                            ClienteApi.Instance.ObterResposta<PessoaDto>(response);

                        txtPessoa.Text = _pessoaDto.IdPessoa.ToString();

                        MensagemInsertUpdate("Salvo com sucesso.");
                    }
                    else if (AcaoFormulario == CAcaoFormulario.Editar)
                    {
                        //Busca Entidade pelas chaves
                        _pessoaDto.IdPessoa = int.Parse(txtPessoa.Text);
                        HttpResponseMessage
                            response = ClienteApi.Instance.RequisicaoPost("pessoa/update", _pessoaDto);
                        MensagemInsertUpdate("Alterado com sucesso.");
                    }                                      

                    LiberaChaveBloqueiaCampos(this.Controls);
                    ModoOpcoes();
                    AcaoFormulario = CAcaoFormulario.Gravar;
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
        }

        /// <summary>
        /// Código Padrão - Ação Botão Voltar - Tela de Cadastro
        /// Versão 0.1 - 23/08/2010
        /// </summary>
        private void ClickVoltar(object sender, EventArgs e)
        {
            LiberaChaveBloqueiaCampos(this.Controls);
            LimpaCamposNaoChave();
            ModoOpcoes();
            AcaoFormulario = CAcaoFormulario.Voltar;
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

        private async  void txtPessoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPessoa_Leave(sender, new EventArgs());
            }
            else if (e.KeyCode == Keys.F3)
            {
                Task<HttpResponseMessage> response =
                    ClienteApi.Instance.RequisicaoGetAsync("pessoa/get");
                Task<List<PessoaDto>> retorno =
                    ClienteApi.Instance.ObterRespostaAsync<List<PessoaDto>>(await response);

                if (retorno.Result.Count > 0 && retorno != null)
                {
                    var Fb = new FormBuscaPaginacao();
                    Fb.SetListAsync<PessoaDto>(retorno.Result, "Nome");
                    Fb.ShowDialog();
                    BindingPessoa.DataSource = Fb.RetornoList<PessoaDto>();
                }               
            }
        }
        private async void txtPessoa_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPessoa.Text.Trim()))
            {
                Task<HttpResponseMessage> response =
                    ClienteApi.Instance.RequisicaoGetAsync($"pessoa/getbyid/{int.Parse(txtPessoa.Text)}");
                Task<PessoaDto> retorno =
                    ClienteApi.Instance.ObterRespostaAsync<PessoaDto>(await response);

                

                if (retorno.Result != null)
                {
                    BindingPessoa.DataSource = retorno.Result;
                }
                else
                {
                    LimpaCamposNaoChave();
                }
            }
            else
            {
                LimpaCamposNaoChave();
            }
        }

        private void cboNaturalidadeUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUfNaturalidade.SelectedIndex > 0)
            {
                txtCidadeNaturalidade.Enabled = true;
                txtCidadeNaturalidade.ReadOnly = false;
            }
            else
            {
                txtCidadeNaturalidade.Enabled = false;
                txtCidadeNaturalidade.ReadOnly = true;
            }
        }
        private async  void txtCidadeNaturalidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (cboUfNaturalidade.SelectedIndex > 0)
            {
                Task<HttpResponseMessage> response =
                    ClienteApi.Instance.RequisicaoGetAsync("city/get");
                Task<List<CityDto>> retorno =
                    ClienteApi.Instance.ObterRespostaAsync<List<CityDto>>(await response);

                if (retorno != null)
                {
                    var Fb = new FormBuscaPaginacao();
                    Fb.SetListAsync<CityDto>(retorno.Result, "Cep");
                    Fb.ShowDialog();
                    BindingPessoa.DataSource = Fb.RetornoList<CityDto>();
                }
                else
                {
                    MessageBox.Show("Não foi encontrado nenhuma cidade");
                }
            }
                
        }
        private async  void txtCidadeNaturalidade_Leave(object sender, EventArgs e)
        {
            Task<HttpResponseMessage> response =
                ClienteApi.Instance.RequisicaoGetAsync($"city/getbyid/{int.Parse(txtCidadeNaturalidade.Text)}");
            Task<CityDto> retorno =
                ClienteApi.Instance.ObterRespostaAsync<CityDto>(await response);

            txtCidadeNaturalidadeDesc.Text = retorno.Result.Nome;

            if (string.IsNullOrEmpty(txtCidadeNaturalidadeDesc.Text))
                txtCidadeNaturalidade.Text = "";
        }

        private void cboEstadoEndereco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUfNaturalidade.SelectedIndex > 0)
            {
                txtCidadeEndereco.Enabled = true;
                txtCidadeEndereco.ReadOnly = false;
            }
            else
            {
                txtCidadeEndereco.Enabled = false;
                txtCidadeEndereco.ReadOnly = true;
            }
        }
        private async  void txtCidadeEndereco_KeyDown(object sender, KeyEventArgs e)
        {
            if (cboUfEndereco.SelectedIndex > 0)
            {
                Task<HttpResponseMessage> response =
                    ClienteApi.Instance.RequisicaoGetAsync("city/get");
                Task<List<CityDto>> retorno =
                    ClienteApi.Instance.ObterRespostaAsync<List<CityDto>>(await response);

                var Fb = new FormBuscaPaginacao();
                Fb.SetListAsync<CityDto>(retorno.Result, "Cep");
                Fb.ShowDialog();
                BindingPessoa.DataSource = Fb.RetornoList<CityDto>();
            }
        }
        private async void txtCidadeEndereco_Leave(object sender, EventArgs e)
        {
            Task<HttpResponseMessage> response =
                ClienteApi.Instance.RequisicaoGetAsync($"city/getbyid/{int.Parse(txtCidadeNaturalidade.Text)}");
            Task<CityDto> retorno =
                ClienteApi.Instance.ObterRespostaAsync<CityDto>(await response);

            txtCidadeEnderecoDesc.Text = retorno.Result.Nome;

            if (string.IsNullOrEmpty(txtCidadeEnderecoDesc.Text))
                txtCidadeEndereco.Text = "";
        }       
             
        private void txtTelCelular_TextChanged(object sender, EventArgs e)
        {
            if (txtTelCelular.Text.Trim().Length > 2)
                txtTelCelular.Mask = Validacao.verificaCelular(txtTelCelular.Text.Replace("-", "").Replace("(","").Replace(")",""));
        }
    }
}
