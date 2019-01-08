using System;
using System.Net.Http;
using System.Windows.Forms;
using UseFul.ClientApi;
using UseFul.ClientApi.Dtos;
using UseFul.Forms.Welic;
using UseFul.Uteis;
using UseFul.Uteis.UI;

namespace Welic.WinForm.Cadastros.Estacionamento
{
    public partial class FrmCadastroEstacionamentoVagas : FormCadastro
    {
        private readonly int _estacionamento;
     
        public FrmCadastroEstacionamentoVagas(int estacionamento)
        {
            _estacionamento = estacionamento;
            InitializeComponent();

            //Inicialização dos Eventos.
            Load += LoadFormulario;
            toolStripBtnNovo.Visible = true;
            toolStripBtnNovo.Click += ClickNovo;
            toolStripBtnEditar.Visible = false;            
            toolStripBtnExcluir.Visible = false;
            toolStripBtnGravar.Visible = true;
            toolStripBtnGravar.Click += ClickGravar;
            toolStripBtnVoltar.Visible = true;
            toolStripBtnVoltar.Click += ClickVoltar;
            toolStripBtnLocalizar.Visible = false;            
            toolStripBtnImprimir.Visible = false;
            toolStripBtnAuditoria.Visible = false;            
            toolStripBtnAjuda.Visible = false;            
            toolStripSeparatorAcoes.Visible = true;
            toolStripSeparatorOutros.Visible = false;            
        }

        private bool ValidaCampos()
        {
            if (!ValidaCamposObrigatorios(Controls) ||
                (!rdHorista.Checked &&
                 !rdDiarista.Checked &&
                 !rdMensalista.Checked) ||
                (!radVeiculoCarro.Checked &&
                 !radVeiculoMoto.Checked &&
                 !radVeiculoBicicleta.Checked))
                return false;

            return true;
        }

        /// <summary>
        /// Código Padrão - Load do Formulário - Tela de Cadastro
        /// Versão 0.1 - 13/08/2010
        /// </summary>
        private void LoadFormulario(object sender, EventArgs e)
        {
            LiberaChaveBloqueiaCampos(Controls);
            LimpaCampos(Controls);
            ModoOpcoes();
            AcaoFormulario = CAcaoFormulario.Nenhum;

            HttpResponseMessage response =
                ClienteApi.Instance.RequisicaoGet($"estacionamento/getbyid/{_estacionamento.ToString()}");
            var retorno =
                ClienteApi.Instance.ObterResposta<EstacionamentoDto>(response);            

            if (retorno != null)
            {
                txtEstacionamento.Text = retorno.IdEstacionamento.ToString();
                txtEstacionamentoDesc.Text = retorno.Descricao;

                ClickNovo(null, null);
            }
            else
            {
                MessageBox.Show(@"Estacionamento não encontrado!", @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Dispose();
            }
        }

        /// <summary>
        /// Código Padrão - Ação Botão Novo - Tela de Cadastro
        /// Versão 0.1 - 13/08/2010
        /// </summary>
        private void ClickNovo(object sender, EventArgs e)
        {
            LimpaCamposBloqueiaAutoIncremento(Controls);
            ModoGravacao();
            AcaoFormulario = CAcaoFormulario.Novo;

            txtQuantidadeVaga.Focus();
        }

        /// <summary>
        /// Código Padrão - Ação Botão Gravar - Tela de Cadastro
        /// Versão 0.1 - 23/08/2010
        /// </summary>
        private void ClickGravar(object sender, EventArgs e)
        {
            if (!ValidaCampos())
                MessageBox.Show(@"Por favor, preencha os campos que identificam o registro.", @"Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                try
                {
                    int chave2 = 0;

                    if (rdHorista.Checked)
                        chave2 = 1;
                    else if (rdDiarista.Checked)
                        chave2 = 2;
                    else if (rdMensalista.Checked)
                        chave2 = 3;


                    int tpVeiculo = 0;
                    if (radVeiculoCarro.Checked)
                        tpVeiculo = 1;
                    else if (radVeiculoMoto.Checked)
                        tpVeiculo = 2;
                    else if (radVeiculoBicicleta.Checked)
                        tpVeiculo = 3;

                    var vagas = new EstacionamentoVagaDto()
                    {
                        IdEstacionamento = int.Parse(txtEstacionamento.Text),
                        Quantidade = int.Parse(txtQuantidadeVaga.Text),
                        TipoVaga = chave2,
                        TipoVeiculo = tpVeiculo,
                        
                    };

                                            
                    if (AcaoFormulario == CAcaoFormulario.Novo)
                    {

                        HttpResponseMessage
                            response = ClienteApi.Instance.RequisicaoPost("estacionamento/saveVagas", vagas);

                        ClienteApi.Instance.ObterResposta<EstacionamentoVagaDto>(response);

                                               
                        MensagemInsertUpdate("Salvo com sucesso.");
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
            LiberaChaveBloqueiaCampos(Controls);
            ModoOpcoes();
            AcaoFormulario = CAcaoFormulario.Gravar;
        }

        /// <summary>
        /// Código Padrão - Ação Botão Voltar - Tela de Cadastro
        /// Versão 0.1 - 23/08/2010
        /// </summary>
        private void ClickVoltar(object sender, EventArgs e)
        {
            LiberaChaveBloqueiaCampos(Controls);
            LimpaCamposNaoChave(Controls);
            ModoOpcoes();
            AcaoFormulario = CAcaoFormulario.Voltar;
        }   
    }
}