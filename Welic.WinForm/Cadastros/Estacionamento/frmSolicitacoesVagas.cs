using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using UseFul.ClientApi;
using UseFul.ClientApi.Dtos;
using UseFul.Forms.Welic;
using UseFul.Uteis;
using UseFul.Uteis.UI;
using Welic.WinForm.Properties;

namespace Welic.WinForm.Cadastros.Estacionamento
{
    public partial class frmSolicitacoesVagas : FormCadastro
    {
        public frmSolicitacoesVagas()
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
            this.toolStripBtnLocalizar.Visible = true;
            this.toolStripBtnLocalizar.Click += new EventHandler(ClickLocalizar);
            this.toolStripBtnImprimir.Visible = true;
            this.toolStripBtnImprimir.Click += new EventHandler(ClickImprimir);
            this.toolStripBtnAuditoria.Visible = false;
            this.toolStripBtnAjuda.Visible = false;
            this.toolStripSeparatorAcoes.Visible = true;
            this.toolStripSeparatorOutros.Visible = false;
            this.KeyUp += new KeyEventHandler(KeyUpFechar);

            InserirBotaoToolStrip();
        }
        public frmSolicitacoesVagas(string solicitacao)
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
            this.toolStripBtnImprimir.Visible = true;
            this.toolStripBtnImprimir.Click += new EventHandler(ClickImprimir);
            this.toolStripBtnAuditoria.Visible = false;
            this.toolStripBtnAjuda.Visible = false;
            this.toolStripSeparatorAcoes.Visible = true;
            this.toolStripSeparatorOutros.Visible = false;
            this.KeyUp += new KeyEventHandler(KeyUpFechar);

            InserirBotaoToolStrip();

            this.solicitacao = solicitacao;
        }

        bool veiculoBicileta;
        bool usuCartaoEstacionamento = false;

        string veiculo = string.Empty;

        public string solicitacao;

        private void FormBuscaRegistros(object sender, bool filtraDadosInformados)
        {           
            FormBuscaPaginacao fb;

            if (!filtraDadosInformados)
            {
                HttpResponseMessage response =
                    ClienteApi.Instance.RequisicaoGet("solicitacoes/get");
                var retorno =
                    ClienteApi.Instance.ObterResposta<List<SolicitacoesDto>>(response);

                if (retorno.Count > 0 )
                {
                    fb = new FormBuscaPaginacao();
                    fb.SetListAsync<SolicitacoesDto>(retorno, "IdSolicitacao");
                    fb.ShowDialog();
                    BindingSolicitacao.DataSource = fb.RetornoList<SolicitacoesDto>();

                    HttpResponseMessage responseVeic =
                        ClienteApi.Instance.RequisicaoGet($"Veiculo/get/{fb.RetornoList<SolicitacoesDto>().IdVeiculo}");
                    var retornoVeic =
                        ClienteApi.Instance.ObterResposta<VeiculoDto>(response);

                    if (retornoVeic != null)
                    {
                        var Fb = new FormBuscaPaginacao();
                        Fb.SetListAsync<SolicitacoesDto>(retorno, "IdSolicitacao");
                        fb.ShowDialog();
                        BindingSolicitacao.DataSource = Fb.RetornoList<PessoaDto>();
                    }
                }
            }
            else
                LimpaCampos();
        }

        // Inserir o método InserirBotaoToolStrip() no método construtor do formulário
        private void InserirBotaoToolStrip()
        {
            ToolStripButton botao = new ToolStripButton();

            // Deverá receber a localização do arquivo da Imagem
            botao.Image = Resources.ICancel30x30;
            botao.ImageAlign = ContentAlignment.MiddleCenter;
            botao.ImageScaling = ToolStripItemImageScaling.None;
            botao.Text = "";
            botao.AutoSize = true;
            botao.Height = botao.Image.Height;
            botao.Width = botao.Image.Width;
            botao.ToolTipText = "Cancelar Solicitação";

            // Localização do Botão no ToolStrip
            botao.Alignment = ToolStripItemAlignment.Right;

            // Adicionando o botão ao ToolStrip
            toolStripOpcoes.Items.Add(botao);

            // Deverá receber o método a ser executado no Evento Click do novo botão
            botao.Click += new EventHandler(btnBotaoCancelar_Click);
        }
        private void btnBotaoCancelar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSolicitacao.Text))
                MessageBox.Show("Por favor, preencha os campos que identificam o registro a ser cancelado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (lblSituacao.Text.Equals("CANCELADA"))
                MessageBox.Show("A Solicitação já está cancelada!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (MessageBox.Show("Confirma o CANCELAMENTO da Solicitação " + txtSolicitacao.Text + "?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {                    
                    try
                    {
                        HttpResponseMessage
                            response = ClienteApi.Instance.RequisicaoPost($"Solicitacoes/cancel/{txtSolicitacao.Text}");

                        var retorno =
                            ClienteApi.Instance.ObterResposta<SolicitacoesDto>(response);

                        MensagemStatusBar("Cancelado com sucesso.");
                        LiberaChaveBloqueiaCampos(this.Controls);
                        LimpaCampos();
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

        private void PreencherFormulario()
        {
            // Se a pesquisa retornar mais de uma Solicitação para os dados informados será exibido um FormBusca (metodo FormBuscaRegistros) 
            // com os resultados.
            // Quando o usuário selecionar uma Solicitação este método será chamado novamente com todos os 4 filtros preenchidos, 
            // retornando apenas 1 registro em dt e, com isso, o formulário será preenchido

            if (!this.Disposing)
            {

                HttpResponseMessage response =
                    ClienteApi.Instance.RequisicaoGet($"solicitacoes/getbyid/{txtSolicitacao.Text}");
                var retorno =
                    ClienteApi.Instance.ObterResposta<SolicitacoesDto>(response);

                if (retorno != null)
                {                    
                    BindingSolicitacao.DataSource = retorno;
                    HttpResponseMessage responseVeic =
                        ClienteApi.Instance.RequisicaoGet($"Veiculo/get/{retorno.IdVeiculo}");
                    var retornoVeic =
                        ClienteApi.Instance.ObterResposta<VeiculoDto>(response);

                    BindingVeiculo.DataSource = retornoVeic;
                }                                                  
                else
                {
                    MessageBox.Show("Não foram encontradas Solicitações de Vaga para os dados informados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpaCampos();
                    AcaoFormulario = CAcaoFormulario.Nenhum;

                    GerenciaCampos();
                }

                if (!mtxtDataCancel.Text.Equals("  /  /") || lblSituacao.Text.Equals("ATENDIDA"))
                    GerenciaToolStripMenu(true);
                else
                    GerenciaToolStripMenu(false);
            }
        }
        private void PreencherSituacao(int situacao, string dt_inicio)
        {
            switch (situacao)
            {
                case 1:
                    lblSituacao.Text = "PENDENTE";
                    break;
                case 2:
                    lblSituacao.Text = "ATENDIDA";
                    break;
                case 3:
                    lblSituacao.Text = "CANCELADA";
                    break;
                default:
                    lblSituacao.Text = "";
                    break;
            }

            mtxtInicio.Text = dt_inicio;
        }
        private void PreencherEstacionamentosIndicados()
        {
            if (!string.IsNullOrEmpty(txtSolicitacao.Text))
            {
                if (dgvEstacionamentosIndicados.DataSource != null)
                    ((DataTable)dgvEstacionamentosIndicados.DataSource).Clear();

                string manha = "0";
                string tarde = "0";
                string noite = "0";

                if (dgvContratos.DataSource != null)
                {
                    DataTable dtPeriodos = ((DataTable)dgvContratos.DataSource);
                    manha = (dtPeriodos.Select("MANHA = 1").Length > 0 ? "1" : "0");
                    tarde = (dtPeriodos.Select("TARDE = 1").Length > 0 ? "1" : "0");
                    noite = (dtPeriodos.Select("NOITE = 1").Length > 0 ? "1" : "0");
                }

                dgvEstacionamentosIndicados.DataSource = WBll.BuscaIndicacoesEstacionamentos(txtSolicitacao.Text, manha, tarde, noite);
            }
        }
        private void PreencherCNH()
        {
            if (string.IsNullOrEmpty(mtxtCPF.Text))
            {
                txtCNHNumero.Text = "";
                txtCNHCategoria.Text = "";
                mtxtCNHData.Text = "";
                mtxtCNHVencimento.Text = "";
            }
            else
            {
                if (!string.IsNullOrEmpty(txtColaborador.Text))
                {
                    DataTable dt = WBll.BuscaDadosCNHColaborador(long.Parse(txtColaborador.Text));

                    if (dt.Rows.Count > 0)
                    {
                        txtCNHNumero.Text = dt.Rows[0]["NUMERO"].ToString();
                        txtCNHCategoria.Text = dt.Rows[0]["CATEGORIA"].ToString();
                        mtxtCNHData.Text = dt.Rows[0]["DATA"].ToString();
                        mtxtCNHVencimento.Text = dt.Rows[0]["VENCIMENTO"].ToString();
                    }
                    else
                    {
                        txtCNHNumero.Text = "";
                        txtCNHCategoria.Text = "";
                        mtxtCNHData.Text = "";
                        mtxtCNHVencimento.Text = "";
                    }
                }
            }
        }
        private void PreencherContratos()
        {
            if (!string.IsNullOrEmpty(mtxtCPF.Text) && !this.Disposing)
            {
                //Contratos de Técnico Administrativo
                DataTable dtContratosTecAdm = WBll.BuscaContratosColaboradorTecAdm(long.Parse(mtxtCPF.Text));
                
                //Horários de Contrato de Docente
                DataTable dtHorariosDocente = WBll.BuscaHorariosColaboradorDocente(long.Parse(mtxtCPF.Text));

                DataTable dt = new DataTable();

                if (dtContratosTecAdm != null && dtContratosTecAdm.Rows.Count > 0)
                    dt = dtContratosTecAdm.Copy();

                if (dt.Rows.Count == 0)
                    foreach (DataGridViewColumn coluna in dgvContratos.Columns)
                        if (!string.IsNullOrEmpty(coluna.DataPropertyName))
                            dt.Columns.Add(coluna.DataPropertyName, typeof(string));

                if (dtHorariosDocente != null && dtHorariosDocente.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["MANHA"] = "0";
                    dr["TARDE"] = "0";
                    dr["NOITE"] = "0";

                    DateTime inicio;
                    DateTime termino;
                    bool contemHorarioForaLimites = false;

                    foreach (DataRow linha in dtHorariosDocente.Rows)
                    {
                        inicio = DateTime.Parse(linha["HORARIO_INICIO"].ToString());
                        termino = DateTime.Parse(linha["HORARIO_TERMINO"].ToString());

                        if (inicio.Hour >= 6 && inicio.Hour < 12)
                            dr["MANHA"] = "1";
                        else if (inicio.Hour >= 14 && inicio.Hour < 18)
                            dr["TARDE"] = "1";
                        else if (inicio.Hour >= 19 || inicio.Hour < 6)
                            dr["NOITE"] = "1";
                        else
                            contemHorarioForaLimites = true;
                    }

                    if(contemHorarioForaLimites)
                        foreach (DataRow linha in dtHorariosDocente.Rows)
                        {
                            inicio = DateTime.Parse(linha["HORARIO_INICIO"].ToString());
                            termino = DateTime.Parse(linha["HORARIO_TERMINO"].ToString());

                            if (inicio.Hour >= 12 && inicio.Hour < 14)
                                if (dr["TARDE"].ToString().Equals("0"))
                                    dr["MANHA"] = "1";

                            if (inicio.Hour >= 18 && inicio.Hour < 19)
                                if (dr["NOITE"].ToString().Equals("0"))
                                    dr["TARDE"] = "1";
                        }

                    dr["MATRICULA"] = dtHorariosDocente.Rows[0]["DOCENTE"].ToString();
                    dr["CATEGORIA"] = dtHorariosDocente.Rows[0]["CATEGORIA"].ToString();
                    dr["TIPO_CONTRATO"] = dtHorariosDocente.Rows[0]["TIPO_CONTRATO"].ToString();
                    dr["TIPCON"] = dtHorariosDocente.Rows[0]["TIPCON"].ToString();
                    dr["CH_MENSAL"] = dtHorariosDocente.Rows[0]["CH_MENSAL"].ToString();
                    dr["CAMPUS"] = dtHorariosDocente.Rows[0]["CAMPUS"].ToString();
                    dr["CAMPUS_DESC"] = dtHorariosDocente.Rows[0]["DESC_CAMPUS"].ToString();
                    dr["BLOCO"] = DBNull.Value; //dtHorariosDocente.Rows[0]["BLOCO"].ToString();
                    dr["BLOCO_DESC"] = ""; //dtHorariosDocente.Rows[0]["DESC_BLOCO"].ToString();
                    dr["CENTRO_CUSTO"] = dtHorariosDocente.Rows[0]["CENTRO_CUSTO"].ToString();
                    dr["CENTRO_CUSTO_DESC"] = dtHorariosDocente.Rows[0]["CENTRO_CUSTO_DESC"].ToString();
                    dt.Rows.Add(dr);
                }

                dgvContratos.DataSource = dt;

                // Buscar o registro do campo TELEFONE_VIGILANCIA da tabela mtd.colaboradores_cadastro
                if(dt.Rows.Count > 0)
                    txtContatos.Text = WBll.BuscaTelefonesVigilanciaColaborador(dt.Rows[0]["MATRICULA"].ToString());

            }
            else if (dgvContratos.DataSource != null)
                ((DataTable)dgvContratos.DataSource).Clear();
        }

        private void GerenciaToolStripMenu(bool desativaEditarExcluir)
        {
            if (desativaEditarExcluir) // CANCELADA
                toolStripBtnExcluir.Enabled = false;
            else
            {
                if (AcaoFormulario != CAcaoFormulario.Novo && AcaoFormulario != CAcaoFormulario.Editar)
                    toolStripBtnExcluir.Enabled = true;
            }
        }
        private void GerenciaCampos()
        {
            if (AcaoFormulario == CAcaoFormulario.Editar || AcaoFormulario == CAcaoFormulario.Novo)
            {
                pnlContratos.Enabled = true;
                pnlEstacionamentosIndicados.Enabled = true;
                btnVeiculos.Enabled = true;
                btnLiberarVaga.Enabled = true;
                grpCNH.Enabled = true;
                txtContatos.Enabled = true;
                txtObservacao.Enabled = true;

                LiberaCabecalho(true);
            }
            else
            {
                pnlContratos.Enabled = false;
                pnlEstacionamentosIndicados.Enabled = false;
                btnVeiculos.Enabled = false;
                btnLiberarVaga.Enabled = false;
                grpCNH.Enabled = false;

                //TratarCamposUsuCartaoEstacionamento();

                txtContatos.Enabled = false;
                txtObservacao.Enabled = false;

                LiberaCabecalho(true);
            }

            if (usuCartaoEstacionamento)
            {
                txtColaborador.Enabled = false;
                txtColaborador.TipoCampo = TextBoxUniube.CTipoCampo.Normal;
            }
        }
        private void LiberaCabecalho(bool libera)
        {
            mtxtCPF.Enabled = libera;
            mtxtPlaca.Enabled = libera;
            mtxtData.Enabled = libera;
            txtColaborador.Enabled = libera;

            

            if (AcaoFormulario == CAcaoFormulario.Novo || AcaoFormulario == CAcaoFormulario.Editar)
                txtSolicitacao.Enabled = false;
            else
                txtSolicitacao.Enabled = true;
        }
        private void LiberarCamposEdicaoVagaLiberada()
        {
            grpCNH.Enabled = true;
            txtContatos.Enabled = true;
            txtObservacao.Enabled = true;
        }
        private void LimpaOutros(object sender)
        {
            if (!mtxtCPF.Focused)
                mtxtCPF.Text = "";
            if (!txtSolicitacao.Focused)
                txtSolicitacao.Text = "";
            if (!mtxtPlaca.Focused)
            {
                mtxtPlaca.Text = "";
                mtxtPlaca.Tag = "";
            }
            if (!mtxtData.Focused)
                mtxtData.Text = "";

            txtCPFNome.Text = "";
            txtCNHNumero.Text = "";
            txtCNHCategoria.Text = "";
            mtxtCNHData.Text = "";
            mtxtCNHVencimento.Text = "";
            mtxtDataCancel.Text = "";
            txtUsuarioCancel.Text = "";
            lblSituacao.Text = "";
            mtxtInicio.Text = "";

            if (dgvContratos.DataSource != null)
                ((DataTable)dgvContratos.DataSource).Clear();

            if (dgvEstacionamentosIndicados.DataSource != null)
                ((DataTable)dgvEstacionamentosIndicados.DataSource).Clear();
        }
        private void LimpaCampos()
        {
            LimpaCampos(this.Controls);
            PreencherSituacao(0, "");
            GerenciaToolStripMenu(false);
        }
        private bool ValidaMaisDeUmaVagaMesmoEstacionamento()
        {
            List<string> listaEstacionamentos = new List<string>();

            foreach (DataGridViewRow linha in dgvEstacionamentosIndicados.Rows)
            {
                if (listaEstacionamentos.Contains(linha.Cells["colEstacionamento"].Value.ToString()))
                    return false;
                else
                    listaEstacionamentos.Add(linha.Cells["colEstacionamento"].Value.ToString());
            }

            return true;
        }
        private bool ValidaColabRecebeValeTransp(string matricula)
        {
            if (WBll.VerificaColabRecebeValeTransporte(matricula))
            {
                MessageBox.Show("Este colaborador está atualmente recebendo vale para transporte coletivo. Esta situação o impede de receber uma vaga de estacionamento.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void LiberarVaga(int solicitacao)
        {
            DbTransaction Transaction = null;

            using (EntityConnection DbConnection = new EntityConnection(Globals.GetStringConnectionEntity(JBll.GetModelPrefeituraUniversitaria()).ToString()))
            {
                try
                {
                    if (DbConnection.State == ConnectionState.Closed)
                        DbConnection.Open(); //Abrindo Conexão

                    var CurrentContext = new EntitiesPrefeituraUniversitaria(DbConnection); //Passando como parametro o estado da Conexão
                    Transaction = CurrentContext.Connection.BeginTransaction(); //Iniciando a Transação

                    //Inicio da transação
                    SOLICITACOES_VAGAS_LIBERADAS vaga;
                    SOLICITACOES_ESTACIONAMENTOS estacionamento;
                    long chave1;

                    foreach (DataGridViewRow linha in dgvEstacionamentosIndicados.Rows)
                    {
                        #region Cria registros de Solicitações de Vagas Liberadas

                        vaga = new SOLICITACOES_VAGAS_LIBERADAS();

                        // Valor passado apenas para não dar erro na Modelagem
                        // Como o campo Vaga é uma chave auto incremento, o banco atribuirá o valor, independente do valor recebido pelo sistema
                        vaga.VAGA = linha.Index;

                        vaga.ESTACIONAMENTO = int.Parse(linha.Cells["colEstacionamento"].Value.ToString());
                        vaga.VEICULO = int.Parse(mtxtPlaca.Tag.ToString());
                        vaga.MANHA = int.Parse(linha.Cells["colEstacionamentoManha"].Value.ToString());
                        vaga.TARDE = int.Parse(linha.Cells["colEstacionamentoTarde"].Value.ToString());
                        vaga.NOITE = int.Parse(linha.Cells["colEstacionamentoNoite"].Value.ToString());
                        vaga.USUARIO = Globals.Usuario;
                        vaga.DT_LIBERACAO = Globals.Sysdate;
                        vaga.DT_VALIDADE = DateTime.Parse(CurrentContext.PARAMETROS_GERAIS.FirstOrDefault(x => x.PARAMETRO == 58).VALOR);
                        vaga.SITUACAO = 1;
                        vaga.TIPO_IDENTIFICACAO = ((ESTACIONAMENTOS)CurrentContext.ESTACIONAMENTOS.FirstOrDefault(x => x.ESTACIONAMENTO == vaga.ESTACIONAMENTO)).TIPO_IDENTIFICACAO_PADRAO;
                        
                        CurrentContext.AddToSOLICITACOES_VAGAS_LIBERADAS(vaga);
                        CurrentContext.SaveChanges();
                        CurrentContext.AcceptAllChanges();

                        #endregion

                        #region Atualiza campos Vaga e Situação das Solicitações de Estacionamentos (tabela de estacionamentos indicados da solicitação)

                        chave1 = long.Parse(linha.Cells["colEstacionamento"].Value.ToString());

                        estacionamento = CurrentContext.SOLICITACOES_ESTACIONAMENTOS.FirstOrDefault(x => x.SOLICITACAO == solicitacao && x.ESTACIONAMENTO == chave1);

                        if (estacionamento == null)
                            throw new Exception("Ocorreu um erro ao atualizar a situação das Sugestões de Estacionamentos. Registro não encontrado.");

                        estacionamento.SITUACAO = 2; // Situação 2 - Atendida
                        estacionamento.VAGA = CurrentContext.SOLICITACOES_VAGAS_LIBERADAS.Max(x => x.VAGA);

                        CurrentContext.SaveChanges();

                        #endregion
                    }

                    #region Atualiza situação Solicitação de Vaga

                    SOLICITACOES_VAGAS solic = CurrentContext.SOLICITACOES_VAGAS.FirstOrDefault(x => x.SOLICITACAO == solicitacao);

                    if (solic == null)
                        throw new Exception("Falha ao atualizar a Situação da Solicitação de Vaga. Solicitação não encontrada");

                    solic.SITUACAO = 2; // Situação 2 - Atendida
                    solic.DT_INICIO = Globals.Sysdate;

                    CurrentContext.SaveChanges();

                    #endregion

                    //Fim da transãção
                    Transaction.Commit();
                    PreencherFormulario();
                }
                catch (Exception ex)
                {
                    Transaction.Rollback();

                    if (ex.InnerException != null)
                        MessageBox.Show(this, "Ocorreu um erro durante a Liberação da(s) Vaga(s). Contate o Administrador do Sistema para verificar o problema." + "\nErro: " + ex.InnerException.Message, "Erro - Liberar Vaga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show(this, "Ocorreu um erro durante a Liberação da(s) Vaga(s). Contate o Administrador do Sistema para verificar o problema." + "\nErro: " + ex.Message, "Erro - Liberar Vaga", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    throw ex;
                }
                finally
                {
                    if (DbConnection != null)
                        if (DbConnection.State == ConnectionState.Open)
                            DbConnection.Close(); //Fechando Conexão
                }
            }
        }

        private void RelatorioSGAGradeHorariaDocente(string matricula)
        {
            string executavelRede = @"S:\SGA\academico.exe";
            string executavelLocal = @"C:\sistemas\academico.exe";

            if (!Directory.Exists(@"S:\SGA\") || !System.IO.File.Exists(executavelRede))
            {
                MessageBox.Show("O caminho '" + executavelRede + "' não é válido. Por favor, contate o Administrador do Sistema para verificar o problema.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (!System.IO.File.Exists(executavelLocal))
                    File.Copy(executavelRede, executavelLocal);
                else
                {
                    FileInfo rede = new FileInfo(executavelRede);
                    FileInfo local = new FileInfo(executavelLocal);

                    if (rede.LastWriteTime != local.LastWriteTime)
                    {
                        File.Delete(executavelLocal);
                        File.Copy(executavelRede, executavelLocal);
                    }
                }
            }

            string usuario = Globals.Usuario.ToString();
            string senha = Globals.Login;
            string conexao = Globals.Conexao.Equals("ACAD_TESTE") ? "DBTESTE" : Globals.Conexao;
            string acao = "1";

            string parametros = usuario + " " + senha + " " + conexao + " " + acao + " " + matricula;

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = executavelLocal;
            process.StartInfo.Arguments = parametros;
            process.Start();

            while (!process.HasExited)
                Application.DoEvents();
        }
        private void GerarDeclaracaoExterna()
        {
            try
            {
                if (MessageBox.Show("Deseja imprimir a Declaração de Acesso ao Estacionamento B.V?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    string caminho = @"C:\sistemas\declaracao_externa.docx";
                    
                    string matricula = (dgvContratos.DataSource == null ? "---" : dgvContratos.Rows[0].Cells["colMatricula"].Value.ToString());

                    WBll.GerarAutorizacaoVagaEstacionamento(txtCPFNome.Text, matricula, mtxtCPF.Text, caminho, mtxtPlaca.Text, null, 2, null, null, null, null, false);

                    System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(caminho);

                    info.Verb = "PrintTo";
                    info.Arguments = System.Printing.LocalPrintServer.GetDefaultPrintQueue().FullName;
                    info.CreateNoWindow = true;
                    info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

                    System.Diagnostics.Process.Start(info);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    MessageBox.Show(this, "" + "\nErro: " + ex.InnerException.Message, "Erro - Declaração Externa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(this, "" + "\nErro: " + ex.Message, "Erro - Declaração Externa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GerarDeclaracaoInterna(DataRow dados_estacionamento)
        {
            try
            {
                if (MessageBox.Show("Deseja imprimir a Declaração de Acesso de Estacionamentos Internos?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    return;

                DataTable dtVeiculo = WBll.BuscaVeiculosColaboradores(mtxtPlaca.Text, 1, null);

                string caminho = @"C:\sistemas\declaracao_interna - Cópia.docx";

                string matricula = (dgvContratos.DataSource == null ? "---" : dgvContratos.Rows[0].Cells["colMatricula"].Value.ToString());

                WBll.GerarAutorizacaoVagaEstacionamento(txtCPFNome.Text, matricula, mtxtCPF.Text, caminho, mtxtPlaca.Text, dtVeiculo.Rows[0]["MODELO"].ToString(), 1, dados_estacionamento, null, null, null, false);

                System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(caminho);

                info.Verb = "PrintTo";
                info.Arguments = System.Printing.LocalPrintServer.GetDefaultPrintQueue().FullName;
                info.CreateNoWindow = true;
                info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

                System.Diagnostics.Process.Start(info);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    MessageBox.Show(this, "" + "\nErro: " + ex.InnerException.Message, "Erro - Declaração Interna", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(this, "" + "\nErro: " + ex.Message, "Erro - Declaração Interna", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GerarDeclaracaoBicicleta(DataRow dados_estacionamento, bool veiculoBicileta)
        {
            try
            {
                if (MessageBox.Show("Deseja imprimir a Declaração de Acesso ao Estacionamento para Bicicletas?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    DataTable dtVeiculo = WBll.BuscaVeiculosColaboradores(veiculo, 2, null);

                    if (dtVeiculo.Rows.Count > 0)
                    {
                        string modelo = dtVeiculo.Rows[0]["modelo"].ToString();
                        string marca = dtVeiculo.Rows[0]["marca"].ToString();
                        string cor = dtVeiculo.Rows[0]["cor"].ToString();
                        string chassi_quadro = dtVeiculo.Rows[0]["chassi_quadro"].ToString();
                        string matricula = string.Empty;

                        if (dgvContratos.DataSource != null)
                            matricula = dgvContratos.Rows[0].Cells["colMatricula"].Value.ToString();

                        string caminho = @"C:\sistemas\Termo Bicicletário.docx";

                        WBll.GerarAutorizacaoVagaEstacionamento(txtCPFNome.Text, matricula, mtxtCPF.Text, caminho, mtxtPlaca.Text, modelo, 3, dados_estacionamento, chassi_quadro, marca, cor, veiculoBicileta);

                        System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(caminho);

                        info.Verb = "PrintTo";
                        info.Arguments = System.Printing.LocalPrintServer.GetDefaultPrintQueue().FullName;
                        info.CreateNoWindow = true;
                        info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

                        System.Diagnostics.Process.Start(info);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao buscar dados do veículo", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    MessageBox.Show(this, "" + "\nErro: " + ex.InnerException.Message, "Erro - Declaração Bicicleta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(this, "" + "\nErro: " + ex.Message, "Erro - Declaração Bicicleta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable FormataDataTableSugestaoEstac(DataTable dt)
        {
            DataColumn coluna;

            if (!dt.Columns.Contains("SITUACAO"))
            {
                coluna = new DataColumn("SITUACAO", typeof(string));
                coluna.DefaultValue = "1";
                dt.Columns.Add(coluna);
            }

            if (!dt.Columns.Contains("SITUACAO_DESC"))
            {
                coluna = new DataColumn("SITUACAO_DESC", typeof(string));
                coluna.DefaultValue = "PENDENTE";
                dt.Columns.Add(coluna);
            }

            if (!dt.Columns.Contains("SOLICITACAO"))
            {
                coluna = new DataColumn("SOLICITACAO", typeof(string));
                dt.Columns.Add(coluna);
            }

            if (!dt.Columns.Contains("VAGA"))
            {
                coluna = new DataColumn("VAGA", typeof(string));
                dt.Columns.Add(coluna);
            }

            return dt;
        }

        private DataTable BuscaEstacionamentosSugeridosDocente()
        {
            DataTable dtPeriodos = ((DataTable)dgvContratos.DataSource);

            string manha = (dtPeriodos.Select("MANHA = 1").Length > 0 ? "1" : "0");
            string tarde = (dtPeriodos.Select("TARDE = 1").Length > 0 ? "1" : "0");
            string noite = (dtPeriodos.Select("NOITE = 1").Length > 0 ? "1" : "0");
            string tipo_veiculo = WBll.BuscaTipoVeiculo(mtxtPlaca.Text);

            DataTable dtEstacionamentos = new DataTable();
            DataTable dtHorariosDocente = WBll.BuscaHorariosColaboradorDocente(long.Parse(mtxtCPF.Text));


            if (WBll.VerificaDocenteExclusivoEAD(mtxtCPF.Text)) // docente é exclusivo do EAD
            {
                dtEstacionamentos = WBll.BuscaEstacAtendemExclusivosEAD(null, tipo_veiculo);

                if (dtEstacionamentos.Rows.Count == 0) // nao existe estacionamento cadastrado para atender EAD (mtd.estacionamentos.atende_exclusivos_ead)
                {
                    string msg = "O Colaborador é um Docente exclusivo da Educação a Distância e ";
                    msg += "atualmente não existem Estacionamentos cadastrados para atender esta situação.";
                    msg += "\nPara fazer o cadastro vá até o Cadastro de Estacionamentos e marque o campo \"Atende docentes exclusivos da EAD\".";

                    MessageBox.Show(this, msg, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return dtEstacionamentos;
                }
                else // retorna os estacionamentos que atendem docentes exclusivos do EAD
                {
                    return FormataDataTableSugestaoEstac(dtEstacionamentos);
                }
            }
            else if (dtHorariosDocente.Rows.Count > 0)
            {
                // INICIO - Pesquisa Estacionamentos que atendam especificamente aos cursos em que o Docente ministra aulas
                List<DataRow> listaCursos = new List<DataRow>();

                // Busca todos os cursos em que o docente ministra aulas
                foreach (DataRow linha in dtHorariosDocente.Rows)
                    if (!listaCursos.Contains(linha) && !string.IsNullOrEmpty(linha["CURSO"].ToString()) && !string.IsNullOrEmpty(linha["CAMPUS"].ToString()))
                        listaCursos.Add(linha);

                // estacionamentos que atendem a algum dos cursos que o docente ministra aulas
                dtEstacionamentos = WBll.BuscaEstacionamentosAtendemCursos(listaCursos, tipo_veiculo, manha, tarde, noite);

                if (dtEstacionamentos.Rows.Count > 0)
                    return FormataDataTableSugestaoEstac(dtEstacionamentos);

                // FIM - Pesquisa Estacionamentos que atendam especificamente aos cursos em que o Docente ministra aulas

                // INICIO - Pesquisa Estacionamentos que atendam ao Bloco em que o Docente mais ministra aulas
                DataTable dtBlocoCampusMaiorCHoraria = WBll.BuscaBlocoCampusMaiorCargaHorariaDocente(mtxtCPF.Text);

                if (dtBlocoCampusMaiorCHoraria.Rows.Count == 1)
                {
                    dtEstacionamentos = WBll.BuscaEstacionamentosAtendemBloco(dtBlocoCampusMaiorCHoraria.Rows[0]["BLOCO"].ToString(), dtBlocoCampusMaiorCHoraria.Rows[0]["CAMPUS"].ToString(), tipo_veiculo, manha, tarde, noite);

                    if (dtEstacionamentos.Rows.Count > 0)
                        return FormataDataTableSugestaoEstac(dtEstacionamentos);
                }
                // FIM - Pesquisa Estacionamentos que atendam ao Bloco em que o Docente mais ministra aulas
            }

            MessageBox.Show("Não existem Estacionamentos com Vagas Disponíveis que atendam às necessidades do Colaborador.", "Titulo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            return dtEstacionamentos;
        }
        private void SugerirEstacionamentosDocente()
        {
            DataTable dt = BuscaEstacionamentosSugeridosDocente();
            
            if(dt != null && dt.Rows.Count > 0)
                dgvEstacionamentosIndicados.DataSource = dt;
        }
        private void SugerirEstacionamentosTecADM(string campus, string tipo_veiculo)
        {
            DataTable dtPeriodos = ((DataTable)dgvContratos.DataSource);

            string manha = (dtPeriodos.Select("MANHA = 1").Length > 0? "1":"0");
            string tarde = (dtPeriodos.Select("TARDE = 1").Length > 0? "1":"0");
            string noite = (dtPeriodos.Select("NOITE = 1").Length > 0? "1":"0");

            DataTable dt = WBll.BuscaEstacionamentosComVagasAdministrativas(campus, tipo_veiculo, manha, tarde, noite);

            DataColumn coluna = new DataColumn("SOLICITACAO", typeof(string));
            dt.Columns.Add(coluna);

            dgvEstacionamentosIndicados.DataSource = dt;

            if(dt.Rows.Count == 0)
                MessageBox.Show("Não existem Estacionamentos que atendam as necessidades do Colaborador.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void SugerirEstacionamentosBicicletas()
        {
            DataTable dtPeriodos = ((DataTable)dgvContratos.DataSource);

            string manha, tarde, noite;

            if (!usuCartaoEstacionamento)
            {
                manha = (dtPeriodos.Select("MANHA = 1").Length > 0 ? "1" : "0");
                tarde = (dtPeriodos.Select("TARDE = 1").Length > 0 ? "1" : "0");
                noite = (dtPeriodos.Select("NOITE = 1").Length > 0 ? "1" : "0");
            }
            else
            { 
                manha = "0";
                tarde = "0";
                noite = "0";
            }

            DataTable dt = WBll.BuscaEstacionamentosComVagasBicicletas(manha, tarde, noite);

            DataColumn coluna = new DataColumn("SOLICITACAO", typeof(string));
            dt.Columns.Add(coluna);

            dgvEstacionamentosIndicados.DataSource = dt;

            if (dt.Rows.Count == 0)
                MessageBox.Show("Não existem Estacionamentos que atendam as necessidades do Colaborador.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Código Padrão - Load do Formulário - Tela de Cadastro
        /// Versão 0.1 - 13/08/2010
        /// </summary>
        private void LoadFormulario(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.solicitacao))
            {
                LiberaChaveBloqueiaCampos(this.Controls);
                LimpaCampos();
                ModoOpcoes();
                AcaoFormulario = CAcaoFormulario.Nenhum;

                GerenciaCampos();
            }
            else
            {
                txtSolicitacao.Text = this.solicitacao;
                txtSolicitacao_Leave(null, null);
            }
        }
        /// <summary>
        /// Código Padrão - Ação Botão Novo - Tela de Cadastro
        /// Versão 0.1 - 13/08/2010
        /// </summary>
        private void ClickNovo(object sender, EventArgs e)
        {
            LimpaCamposBloqueiaAutoIncremento(this.Controls);
            mtxtData.Text = Globals.Sysdate.ToShortDateString();
            PreencherSituacao(0, "");
            ModoGravacao();
            AcaoFormulario = CAcaoFormulario.Novo;

            txtColaborador.Enabled = true;
            txtColaborador.TipoCampo = TextBoxUniube.CTipoCampo.Chave;
            usuCartaoEstacionamento = false;

            GerenciaCampos();
            txtColaborador.Focus();
        }
        /// <summary>
        /// Código Padrão - Ação Botão Editar - Tela de Cadastro
        /// Versão 0.1 - 23/08/2010
        /// </summary>
        private void ClickEditar(object sender, EventArgs e)
        {
            if (!mtxtDataCancel.Text.Equals("  /  /") || lblSituacao.Text.Equals("ATENDIDA"))
            {
                BloqueiaChaveLiberaCampos(this.Controls);
                LiberarCamposEdicaoVagaLiberada();
                ModoGravacao();
                AcaoFormulario = CAcaoFormulario.Editar;
            }
            else
            {
                if (!ValidaCamposObrigatorios(this.Controls))
                    MessageBox.Show("Por favor, preencha os campos que identificam o registro a ser alterado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    BloqueiaChaveLiberaCampos(this.Controls);
                    ModoGravacao();
                    AcaoFormulario = CAcaoFormulario.Editar;

                    GerenciaCampos();

                    TratarCamposUsuCartaoEstacionamento();
                }
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
                if (MessageBox.Show("Confirma a EXCLUSÃO da Solicitação " + txtSolicitacao.Text + "?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        using (EntitiesPrefeituraUniversitaria mde = new EntitiesPrefeituraUniversitaria(Globals.GetStringConnectionEntity(JBll.GetModelPrefeituraUniversitaria()).ToString()))
                        {
                            //Declara e busca Entidade pela chave
                            int chave = int.Parse(txtSolicitacao.Text);
                            SOLICITACOES_VAGAS solicitacao = mde.SOLICITACOES_VAGAS.FirstOrDefault(x => x.SOLICITACAO == chave);

                            if (solicitacao == null)
                                throw new Exception("Registro não encontrado!");

                            //Deleta Objeto ec.DeleteObject(instancia);
                            mde.DeleteObject(solicitacao);

                            //SaveChanges() (Commit)                       
                            mde.SaveChanges();

                            MensagemStatusBar("Excluído com sucesso.");
                            LiberaChaveBloqueiaCampos(this.Controls);
                            LimpaCampos();
                            AcaoFormulario = CAcaoFormulario.Excluir;
                        }
                        GerenciaCampos();
                    }
                    catch (Exception ex)
                    {
                        if (ex.InnerException != null)
                            MessageBox.Show(this, "Não foi possível excluir o registro." + "\nErro: " + ex.InnerException.Message, "Erro - Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show(this, "Não foi possível excluir o registro." + "\nErro: " + ex.Message, "Erro - Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else if (!ValidaMaisDeUmaVagaMesmoEstacionamento())
                MessageBox.Show("Não é possível salvar mais de 1 vaga para um mesmo Estacionamento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                DbTransaction Transaction = null;
                string mensagem = string.Empty;

                using (EntityConnection DbConnection = new EntityConnection(Globals.GetStringConnectionEntity(JBll.GetModelPrefeituraUniversitaria()).ToString()))
                {
                    try
                    {                        
                        int chave;
                        string msg = "";
                        if (DbConnection.State == ConnectionState.Closed)
                            DbConnection.Open(); //Abrindo Conexão

                        var CurrentContext = new EntitiesPrefeituraUniversitaria(DbConnection); //Passando como parametro o estado da Conexão
                        Transaction = CurrentContext.Connection.BeginTransaction(); //Iniciando a Transação

                        //Inicio da transação

                        #region Gravar registro Solicitação de Vaga

                        // Declaração da Entidade
                        SOLICITACOES_VAGAS solicitacao;

                        if (AcaoFormulario == CAcaoFormulario.Novo)
                        {
                            //Instância da Entidade
                            solicitacao = new SOLICITACOES_VAGAS();

                            //Seta campos
                            solicitacao.CPF = mtxtCPF.Text;
                            solicitacao.VEICULO = int.Parse(mtxtPlaca.Tag.ToString());
                            solicitacao.DT_SOLICITACAO = DateTime.Parse(mtxtData.Text);
                            solicitacao.USUARIO = Globals.Usuario;
                            solicitacao.SITUACAO = 1;
                            solicitacao.OBSERVACAO = txtObservacao.Text;

                            //Insere Registro
                            CurrentContext.AddToSOLICITACOES_VAGAS(solicitacao);

                            //SaveChanges() (Commit)
                            CurrentContext.SaveChanges();

                            //Busca Chave AutoNumeracao
                            txtSolicitacao.Text = CurrentContext.SOLICITACOES_VAGAS.Max(x => x.SOLICITACAO).ToString();

                            msg = "Salvo com sucesso.";
                        }
                        else if (AcaoFormulario == CAcaoFormulario.Editar)
                        {
                            //Busca Entidade pelas chaves
                            chave = int.Parse(txtSolicitacao.Text);
                            solicitacao = CurrentContext.SOLICITACOES_VAGAS.FirstOrDefault(x => x.SOLICITACAO == chave);

                            if (solicitacao == null)
                                throw new Exception("Registro não encontrado!");

                            //Seta campos
                            solicitacao.CPF = mtxtCPF.Text;
                            solicitacao.VEICULO = int.Parse(mtxtPlaca.Tag.ToString());
                            solicitacao.DT_SOLICITACAO = DateTime.Parse(mtxtData.Text);
                            solicitacao.OBSERVACAO = txtObservacao.Text;

                            //SaveChanges() (Commit)
                            CurrentContext.SaveChanges();

                            msg = "Alterado com sucesso.";
                        }

                        #endregion

                        #region Atualiza Campos CNH do Colaborador e Campo TELEFONE_VIGILANCIA da tabela colaboradores_cadastro

                        if (!usuCartaoEstacionamento)
                        {
                            R034CPL vet;

                            foreach (DataGridViewRow linha in dgvContratos.Rows)
                            {
                                chave = int.Parse(linha.Cells["colMatricula"].Value.ToString());
                                vet = CurrentContext.R034CPL.FirstOrDefault(x => x.NUMCAD == chave);

                                string cnh = string.Empty;
                                DateTime dataCnh = new DateTime();
                                DateTime dataVenCnh = new DateTime();

                                string atualizarCampos = string.Empty;

                                if (vet == null)
                                    throw new Exception("Erro ao atualizar CNH.");

                                if (txtCNHNumero.Text.Length < 11)
                                    cnh = txtCNHNumero.Text.PadLeft(11, '0');
                                else
                                    cnh = txtCNHNumero.Text;

                                if (!mtxtCNHData.Text.Equals("  /  /"))
                                {
                                    dataCnh = DateTime.Parse(mtxtCNHData.Text);
                                    atualizarCampos += " ,c.datcnh = trunc(to_date('" + dataCnh + @"', 'dd/mm/yyyy hh24:mi:ss')) ";
                                }
                                else
                                    atualizarCampos += " ,c.datcnh = null ";

                                if (!mtxtCNHVencimento.Text.Equals("  /  /"))
                                {
                                    dataVenCnh = DateTime.Parse(mtxtCNHVencimento.Text);
                                    atualizarCampos += " ,c.vencnh = trunc(to_date('" + dataVenCnh + "', 'dd/mm/yyyy hh24:mi:ss')) ";
                                }
                                else
                                    atualizarCampos += " ,c.vencnh = null ";

                                Conexao dal = new Conexao(Globals.GetStringConnection(), 2);
                                StringBuilder sql = new StringBuilder();
                                sql.Append(@"update vetorh.r034cpl c set c.numcnh = '" + cnh + "' " + atualizarCampos + ", c.catcnh = '" + txtCNHCategoria.Text + "' where c.numcad = " + chave);

                                dal.ExecuteNonQuery(sql.ToString());

                                if (Globals.Usuario != 16272)
                                {
                                    mensagem = "Telefone Contato";
                                    sql.Clear();
                                    sql.Append("call bhora.up_r034fun_telvig(" + txtColaborador.Text + ", '" + txtContatos.Text + "')");
                                    dal.ExecuteNonQuery(sql.ToString());
                                }
                            }
                        }
                        else
                        {
                            EntitiesPrefeituraUniversitaria mde = new EntitiesPrefeituraUniversitaria(Globals.GetStringConnectionEntity(JBll.GetModelPrefeituraUniversitaria()).ToString());

                            long chave3 = long.Parse(mtxtCPF.Text);
                            CARTOES_ESTACIONAMENTOS cartao = mde.CARTOES_ESTACIONAMENTOS.FirstOrDefault(x => x.CPF == chave3);

                            //Seta campos
                            cartao.NOME = txtCPFNome.Text;
                            cartao.CONTATO = txtContatos.Text;
                            cartao.OBSERVACAO = txtObservacao.Text;

                            mde.SaveChanges();
                        }

                        #endregion

                        if (AcaoFormulario == CAcaoFormulario.Novo)
                        {
                            PreencherSituacao(1, "");
                            txtSolicitacao.Text = CurrentContext.SOLICITACOES_VAGAS.Max(x => x.SOLICITACAO).ToString();
                        }

                        #region grava indicações de vagas

                        SOLICITACOES_ESTACIONAMENTOS estacionamento;
                        long solic = long.Parse(txtSolicitacao.Text);
                        int estac;
                        bool novo;

                        foreach (DataGridViewRow linha in dgvEstacionamentosIndicados.Rows)
                        {
                            if(AcaoFormulario == CAcaoFormulario.Novo)
                            {
                                estacionamento = new SOLICITACOES_ESTACIONAMENTOS();
                                estacionamento.SOLICITACAO = long.Parse(txtSolicitacao.Text);
                                estacionamento.ESTACIONAMENTO = int.Parse(linha.Cells["colEstacionamento"].Value.ToString());
                                estacionamento.TIPO_VAGA = int.Parse(linha.Cells["colTipoVaga"].Value.ToString());
                                estacionamento.MANHA = int.Parse(linha.Cells["colEstacionamentoManha"].Value.ToString());
                                estacionamento.TARDE = int.Parse(linha.Cells["colEstacionamentoTarde"].Value.ToString());
                                estacionamento.NOITE = int.Parse(linha.Cells["colEstacionamentoNoite"].Value.ToString());
                                estacionamento.SITUACAO = 1;
                                
                                CurrentContext.AddToSOLICITACOES_ESTACIONAMENTOS(estacionamento);
                                CurrentContext.SaveChanges();
                            }
                            else if(AcaoFormulario == CAcaoFormulario.Editar)
                            {
                                estac = int.Parse(linha.Cells["colEstacionamento"].Value.ToString());
                                estacionamento = CurrentContext.SOLICITACOES_ESTACIONAMENTOS.FirstOrDefault(x => x.SOLICITACAO == solic &&
                                                                                                                 x.ESTACIONAMENTO == estac);
                                if (estacionamento == null)
                                {
                                    estacionamento = new SOLICITACOES_ESTACIONAMENTOS();
                                    novo = true;
                                }
                                else
                                    novo = false;

                                estacionamento.SOLICITACAO = long.Parse(txtSolicitacao.Text);
                                estacionamento.ESTACIONAMENTO = int.Parse(linha.Cells["colEstacionamento"].Value.ToString());
                                estacionamento.TIPO_VAGA = int.Parse(linha.Cells["colTipoVaga"].Value.ToString());
                                estacionamento.MANHA = int.Parse(linha.Cells["colEstacionamentoManha"].Value.ToString());
                                estacionamento.TARDE = int.Parse(linha.Cells["colEstacionamentoTarde"].Value.ToString());
                                estacionamento.NOITE = int.Parse(linha.Cells["colEstacionamentoNoite"].Value.ToString());
                                estacionamento.SITUACAO = int.Parse(linha.Cells["colSituacao"].Value.ToString());

                                if (novo)
                                    CurrentContext.AddToSOLICITACOES_ESTACIONAMENTOS(estacionamento);

                                CurrentContext.SaveChanges();
                            }
                        }

                        #endregion

                        //Fim da transãção
                        Transaction.Commit();

                        MensagemInsertUpdate(msg);
                    }
                    catch (Exception ex)
                    {
                        Transaction.Rollback();

                        if (ex.InnerException != null)
                            MessageBox.Show(this, "Ocorreu um erro ao gravar o registro.\n" + mensagem + "\nErro: " + ex.InnerException.Message, "Erro - Gravar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show(this, "Ocorreu um erro ao gravar o registro.\n" + mensagem + "\nErro: " + ex.Message, "Erro - Gravar", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        throw ex;
                    }
                    finally
                    {
                        if (DbConnection != null)
                            if (DbConnection.State == ConnectionState.Open)
                                DbConnection.Close(); //Fechando Conexão
                    }
                }
            }
        }
        private void MensagemInsertUpdate(string mensagem)
        {
            AcaoFormulario = CAcaoFormulario.Gravar;
            ModoOpcoes();
            GerenciaCampos();
            MensagemStatusBar(mensagem);
        }
        /// <summary>
        /// Código Padrão - Ação Botão Voltar - Tela de Cadastro
        /// Versão 0.1 - 23/08/2010
        /// </summary>
        private void ClickVoltar(object sender, EventArgs e)
        {
            LiberaChaveBloqueiaCampos(this.Controls);
            LimpaCampos();
            ModoOpcoes();
            AcaoFormulario = CAcaoFormulario.Voltar;

            txtColaborador.Enabled = true;
            txtColaborador.TipoCampo = TextBoxUniube.CTipoCampo.Chave;
            usuCartaoEstacionamento = false;

            GerenciaCampos();
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
        /// <summary>
        /// Código Padrão - Ação Botão Imprimir - Tela de Cadastro
        /// Versão 0.1 - 23/08/2010
        /// </summary>
        private void ClickImprimir(object sender, EventArgs e)
        {
            AcaoFormulario = CAcaoFormulario.Imprimir;

            if (dgvContratos.Rows.Count == 0 && !usuCartaoEstacionamento)
                MessageBox.Show("Colaborador Não possui contrato para gerar a Declaração!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                try
                {
                    if (dgvEstacionamentosIndicados.Rows.Count == 0)                    
                        MessageBox.Show("Nenhum estacionamento indicado para gerar a Declaração!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                    else
                    {
                        foreach (DataRow linha in ((DataTable)dgvEstacionamentosIndicados.DataSource).Rows)
                        {
                            string emissao = WBll.VerificaEmissaoDeclaracaoEstacionamento(linha["ESTACIONAMENTO"].ToString()).ToString();

                            if (!string.IsNullOrEmpty(emissao))
                            {
                                if (!veiculoBicileta)//Sugestão para vagas de carros e motos
                                {
                                    switch (emissao)
                                    {
                                        case "3": // BELA VISTA PARKING
                                            GerarDeclaracaoExterna();
                                            break;
                                        case "2": // Estacionamentos Internos (blocos)
                                            GerarDeclaracaoInterna(linha);
                                            break;
                                        default:
                                            if (sender != null)
                                                MessageBox.Show("O Estacionamento " + linha["ESTACIONAMENTO_DESC"].ToString() + " não emite declarações!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            break;
                                    }
                                }
                                else
                                {
                                    GerarDeclaracaoBicicleta(linha, veiculoBicileta);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                        MessageBox.Show(this, "Ocorreu um erro ao gerar uma Declaração de Acesso a Estacionamentos. Contate o Administrador do Sistema para verificar o problema" + "\nErro: " + ex.InnerException.Message, "Erro - Impressão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show(this, "Ocorreu um erro ao gerar uma Declaração de Acesso a Estacionamentos. Contate o Administrador do Sistema para verificar o problema" + "\nErro: " + ex.Message, "Erro - Impressão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClickLocalizar(object sender, EventArgs e)
        {
            AcaoFormulario = CAcaoFormulario.Buscar;
            txtSolicitacao_KeyDown(txtSolicitacao, new KeyEventArgs(Keys.F3));
        }        

        private void mtxtCPF_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mtxtCPF.Text) && AcaoFormulario != CAcaoFormulario.Novo && AcaoFormulario != CAcaoFormulario.Editar)
                LimpaCampos();
            else if (string.IsNullOrEmpty(mtxtCPF.Text))
            {
                txtCPFNome.Text = "";
                txtColaborador.Text = "";
                mtxtPlaca.Text = "";

                if (dgvContratos.DataSource != null)
                    ((DataTable)dgvContratos.DataSource).Clear();
            }
        }
        private void txtColaborador_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtColaborador.Text) && AcaoFormulario != CAcaoFormulario.Novo && AcaoFormulario != CAcaoFormulario.Editar)
                LimpaCampos();
            else if (string.IsNullOrEmpty(txtColaborador.Text))
            {
                txtCPFNome.Text = "";
                mtxtCPF.Text = "";
                mtxtPlaca.Text = "";

                if (dgvContratos.DataSource != null)
                    ((DataTable)dgvContratos.DataSource).Clear();
            }
        }
        private void mtxtPlaca_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mtxtPlaca.Text))
            {
                if (AcaoFormulario != CAcaoFormulario.Novo && AcaoFormulario != CAcaoFormulario.Editar)
                    LimpaCampos();
                else
                {
                    if (dgvEstacionamentosIndicados.DataSource != null)
                        ((DataTable)dgvEstacionamentosIndicados.DataSource).Clear();
                }
            }
        }
        private void txtSolicitacao_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSolicitacao.Text))
                LimpaCampos();
        }
        private void mtxtData_TextChanged(object sender, EventArgs e)
        {
            if (mtxtData.Text.Equals("  /  /") && AcaoFormulario != CAcaoFormulario.Novo && AcaoFormulario != CAcaoFormulario.Editar)
                LimpaCampos();
        }

        private void mtxtCPF_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mtxtCPF.Text))
                mtxtCPF.SelectionStart = 0;
        }
        private void mtxtData_Click(object sender, EventArgs e)
        {
            if (mtxtData.Text.Equals("  /  /"))
                mtxtData.SelectionStart = 0;
        }
        private void mtxtPlaca_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mtxtPlaca.Text))
                mtxtPlaca.SelectionStart = 0;
        }
        private void mtxtCNHData_Click(object sender, EventArgs e)
        {
            if (mtxtCNHData.Text.Equals("  /  /"))
                mtxtCNHData.SelectionStart = 0;
        }
        private void mtxtCNHVencimento_Click(object sender, EventArgs e)
        {
            if (mtxtCNHVencimento.Text.Equals("  /  /"))
                mtxtCNHVencimento.SelectionStart = 0;
        }

        private void mtxtCPF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (AcaoFormulario != CAcaoFormulario.Novo)
                    FormBuscaRegistros(sender, false);
                else // Ação = Novo
                {
                    FormBusca fb = new FormBusca(WBll.QueryBuscaColaboradorPorCPF("").ToString(), new List<System.Data.OracleClient.OracleParameter>(), true, "COLABORADORES", "NOME", txtCPFNome.Text, "Nenhum registro encontrado!", false, "NOME");
                    fb.ShowDialog();

                    if (fb.retorno != null)
                    {
                        mtxtCPF.Text = fb.retorno["CPF"].ToString();
                        txtColaborador.Text = fb.retorno["matricula"].ToString();
                        mtxtPlaca.Focus();
                    }
                }
            }
        }
        private void mtxtCPF_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mtxtCPF.Text))
            {
                // Se o formulário estiver na Ação Novo, trará apenas o nome, dados de CNH e Contratos do colaborador
                // Se não irá procurar uma Solicitação para o CPF informado.
                if (AcaoFormulario == CAcaoFormulario.Novo || AcaoFormulario == CAcaoFormulario.Editar)
                {
                    DataTable dt = WBll.BuscaColaboradorPorCPF(mtxtCPF.Text);                    
                    bool UsuarioOk = true;

                    //Caso o cpf não seja de colaborador, verifica se é de usuario de cartao de estacionamento
                    if (dt.Rows.Count == 0)
                    {
                        dt = WBll.BuscaUsuarioCartaoEstacionamento(mtxtCPF.Text);
                        if (dt.Rows.Count > 0)
                        {
                            usuCartaoEstacionamento = true;
                            txtObservacao.Text = dt.Rows[0]["OBSERVACAO"].ToString();
                            txtContatos.Text = dt.Rows[0]["CONTATO"].ToString();
                            txtColaborador.Enabled = false;
                            txtColaborador.TipoCampo = TextBoxUniube.CTipoCampo.Normal;
                        }
                        else if (AcaoFormulario == CAcaoFormulario.Novo)                                        
                        { 
                            //se não for usuario de cartao de estacionamento, busca na tabela de alunos
                            dt = WBll.BuscaAluno(mtxtCPF.Text);
                            if (dt.Rows.Count > 0)
                            {
                                if (MessageBox.Show("Aluno não cadastrado como usuário de cartão de estacionamento.\nDeseja cadastra-lo??", Globals.TituloSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    try
                                    {
                                        using (EntitiesPrefeituraUniversitaria mde = new EntitiesPrefeituraUniversitaria(Globals.GetStringConnectionEntity(JBll.GetModelPrefeituraUniversitaria()).ToString()))
                                        {
                                            // Declaração da Entidade
                                            CARTOES_ESTACIONAMENTOS cartao;

                                            //Instância da Entidade
                                            cartao = new CARTOES_ESTACIONAMENTOS();

                                            //Seta campos
                                            cartao.CPF = long.Parse(mtxtCPF.Text);
                                            cartao.NOME = dt.Rows[0]["nome"].ToString();
                                            cartao.CONTATO = dt.Rows[0]["contato"].ToString();

                                            //Insere Registro
                                            mde.CARTOES_ESTACIONAMENTOS.AddObject(cartao);

                                            //SaveChanges() (Commit)
                                            mde.SaveChanges();

                                            txtCPFNome.Text = dt.Rows[0]["nome"].ToString();
                                            txtContatos.Text = dt.Rows[0]["contato"].ToString();

                                            usuCartaoEstacionamento = true;

                                            txtColaborador.Enabled = false;
                                            mtxtPlaca.Focus();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao inserir o usuário de cartão de estacionamento.\nErro: " + ex.Message, "Erro - Buscar CPF", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        LimpaCampos(mtxtCPF);
                                        mtxtCPF.Focus();
                                        return;
                                    }
                                }
                                else
                                {
                                    LimpaCampos(mtxtCPF);
                                    mtxtCPF.Focus();
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        txtColaborador.Enabled = true;
                        txtColaborador.TipoCampo = TextBoxUniube.CTipoCampo.Chave;
                    }

                    TratarCamposUsuCartaoEstacionamento();

                    if (dt.Rows.Count > 0)
                    {
                        txtCPFNome.Text = dt.Rows[0]["NOME"].ToString();

                        if (!usuCartaoEstacionamento)
                        {
                            txtColaborador.Text = dt.Rows[0]["MATRICULA"].ToString();

                            DataTable dtCargoLocal = WBll.BuscaCargoLocal(txtColaborador.Text);

                            if (dtCargoLocal.Rows.Count > 0)
                            {
                                txtCargo.Text = dtCargoLocal.Rows[0]["ds_cargo"].ToString();
                                txtLocal.Text = dtCargoLocal.Rows[0]["ds_local"].ToString();
                            }

                            if (!ValidaColabRecebeValeTransp(txtColaborador.Text))
                            {
                                txtColaborador.Text = "";
                                txtCPFNome.Text = "";
                                mtxtCPF.Text = "";
                                mtxtCPF.Focus();

                                UsuarioOk = false;
                            }
                            else if (WBll.VerificaExisteSolicitacoesPendentes(mtxtCPF.Text))
                            {
                                MessageBox.Show("Existem solicitações pendentes para o colaborador. Verifique antes de continuar.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                txtColaborador.Text = "";
                                txtCPFNome.Text = "";
                                mtxtCPF.Text = "";
                                mtxtCPF.Focus();
                                UsuarioOk = false;
                            }
                        }
                        
                        if(UsuarioOk || usuCartaoEstacionamento)
                        {
                            // Buscar veículos do colaborador
                            DataTable dtVeiculo = WBll.BuscaVeiculosColaboradores(mtxtCPF.Text, 3, null);
                            if (dtVeiculo.Rows.Count > 0)
                            {
                                if (string.IsNullOrEmpty(mtxtPlaca.Text))
                                {
                                    if (dtVeiculo.Rows.Count == 1)
                                    {
                                        mtxtPlaca.Text = dtVeiculo.Rows[0]["PLACA"].ToString();
                                        mtxtPlaca_Leave(null, null);
                                    }
                                    else
                                    {
                                        if (MessageBox.Show("Atualmente existem " + dtVeiculo.Rows.Count + " Veículos cadastrados para este colaborador. Deseja utilizar algum destes?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                        {
                                            FormBusca fb = new FormBusca(WBll.QueryBuscaVeiculosColaboradores(3).ToString(), WBll.ParametrosBuscaVeiculosColaboradores(null, null, mtxtCPF.Text), true, "VEÍCULOS DO COLABORADOR", "VEICULO", "", "Nenhum Veículo encontrado!");
                                            fb.ShowDialog();

                                            if (fb.retorno != null)
                                            {
                                                mtxtPlaca.Text = fb.retorno["PLACA"].ToString();
                                                mtxtPlaca_Leave(null, null);
                                            }
                                        }
                                    }
                                }
                            }

                            if (!usuCartaoEstacionamento)
                            {
                                PreencherCNH();
                                PreencherContratos();
                            }

                            if(veiculoBicileta && !string.IsNullOrEmpty(mtxtPlaca.Text))            
                            {
                                if (AcaoFormulario == CAcaoFormulario.Novo)
                                    btnSugerirEstacionamento_Click(sender, e);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Colaborador não cadastrado!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCPFNome.Text = "";
                        txtColaborador.Text = "";
                    }
                }
                else // Acao != Novo
                    PreencherFormulario();
            }
            else if (AcaoFormulario != CAcaoFormulario.Editar && AcaoFormulario != CAcaoFormulario.Novo)
                LimpaCampos();
            else
            {
                txtCPFNome.Text = "";
                txtColaborador.Text = "";
                PreencherCNH();
                PreencherContratos();
                PreencherEstacionamentosIndicados();
            }
        }

        private void txtColaborador_Leave(object sender, EventArgs e)
        {
            if (!usuCartaoEstacionamento)
            {
                if (!string.IsNullOrEmpty(txtColaborador.Text))
                {
                    // Se o formulário estiver na Ação Novo, trará apenas o nome, dados de CNH e Contratos do colaborador
                    // Se não irá procurar uma Solicitação para o CPF informado.
                    if (AcaoFormulario == CAcaoFormulario.Novo || AcaoFormulario == CAcaoFormulario.Editar)
                    {
                        DataTable dt = WBll.BuscaColaboradorTrabalhando(txtColaborador.Text);

                        if (dt.Rows.Count > 0)
                        {
                            txtCPFNome.Text = dt.Rows[0]["NOME"].ToString();
                            mtxtCPF.Text = dt.Rows[0]["CPF"].ToString();

                            if (!ValidaColabRecebeValeTransp(txtColaborador.Text))
                            {
                                txtColaborador.Text = "";
                                txtCPFNome.Text = "";
                                mtxtCPF.Text = "";
                                txtColaborador.Focus();
                            }
                            else if (WBll.VerificaExisteSolicitacoesPendentes(mtxtCPF.Text))
                            {
                                MessageBox.Show("Existem solicitações pendentes para o colaborador. Verifique antes de continuar.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                txtColaborador.Text = "";
                                txtCPFNome.Text = "";
                                mtxtCPF.Text = "";
                                mtxtCPF.Focus();
                            }
                            else
                            {
                                DataTable dtCargoLocal = WBll.BuscaCargoLocal(txtColaborador.Text);

                                if (dtCargoLocal.Rows.Count > 0)
                                {
                                    txtCargo.Text = dtCargoLocal.Rows[0]["ds_cargo"].ToString();
                                    txtLocal.Text = dtCargoLocal.Rows[0]["ds_local"].ToString();
                                }

                                // Buscar veículos do colaborador
                                DataTable dtVeiculo = WBll.BuscaVeiculosColaboradores(mtxtCPF.Text, 3, null);
                                if (dtVeiculo.Rows.Count > 0)
                                {
                                    if (string.IsNullOrEmpty(mtxtPlaca.Text))
                                    {
                                        if (dtVeiculo.Rows.Count == 1)
                                        {
                                            mtxtPlaca.Text = dtVeiculo.Rows[0]["PLACA"].ToString();
                                            veiculoBicileta = (dtVeiculo.Rows[0]["TIPO"].ToString().Equals("3") ? true : false);
                                            veiculo = dtVeiculo.Rows[0]["VEICULO"].ToString();
                                            mtxtPlaca_Leave(null, null);
                                        }
                                        else
                                        {
                                            if (MessageBox.Show("Atualmente existem " + dtVeiculo.Rows.Count + " Veículos cadastrados para este colaborador. Deseja utilizar algum destes?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                            {
                                                FormBusca fb = new FormBusca(WBll.QueryBuscaVeiculosColaboradores(3).ToString(), WBll.ParametrosBuscaVeiculosColaboradores(null, null, mtxtCPF.Text), true, "VEÍCULOS DO COLABORADOR", "VEICULO", "", "Nenhum Veículo encontrado!");
                                                fb.ShowDialog();

                                                if (fb.retorno != null)
                                                {
                                                    mtxtPlaca.Text = fb.retorno["PLACA"].ToString();
                                                    veiculoBicileta = (fb.retorno["TIPO"].ToString().Equals("3") ? true : false);
                                                    veiculo = dtVeiculo.Rows[0]["VEICULO"].ToString();
                                                    mtxtPlaca_Leave(null, null);
                                                }
                                            }
                                        }
                                    }
                                }

                                PreencherCNH();
                                PreencherContratos();

                                if (dtVeiculo.Rows.Count > 0)
                                {
                                    if (veiculoBicileta)
                                    {
                                        if (dgvEstacionamentosIndicados.Rows.Count == 0)
                                        {
                                            if (AcaoFormulario == CAcaoFormulario.Novo)
                                                btnSugerirEstacionamento_Click(sender, e);
                                        }
                                    }
                                }

                                mtxtPlaca.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Colaborador não cadastrado!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtCPFNome.Text = "";
                            mtxtCPF.Text = "";
                        }
                    }
                    else // Acao != Novo
                        PreencherFormulario();
                }
                else if (AcaoFormulario != CAcaoFormulario.Editar && AcaoFormulario != CAcaoFormulario.Novo)
                    LimpaCampos();
                else
                {
                    txtCPFNome.Text = "";
                    mtxtCPF.Text = "";
                    PreencherCNH();
                    PreencherContratos();
                    PreencherEstacionamentosIndicados();
                }
            }
        }
        private void txtColaborador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (AcaoFormulario != CAcaoFormulario.Novo)
                    FormBuscaRegistros(sender, false);
                else // Ação = Novo
                {
                    FormBusca fb = new FormBusca(WBll.QueryBuscaColaboradorPorCPF("").ToString(), new List<System.Data.OracleClient.OracleParameter>(), true, "COLABORADORES", "NOME", txtCPFNome.Text, "Nenhum registro encontrado!", false, "NOME");
                    fb.ShowDialog();

                    if (fb.retorno != null)
                    {
                        txtColaborador.Text = fb.retorno["MATRICULA"].ToString();
                        mtxtPlaca.Focus();
                    }
                }
            }
        }

        private void txtSolicitacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
                FormBuscaRegistros(sender, false);
        }
        private void txtSolicitacao_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSolicitacao.Text))
                PreencherFormulario();
            else
                LimpaCampos();
        }

        private void mtxtPlaca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (AcaoFormulario != CAcaoFormulario.Novo && AcaoFormulario != CAcaoFormulario.Editar)
                    FormBuscaRegistros(sender, false);
                else
                {
                    FormBusca fb = new FormBusca(WBll.QueryBuscaVeiculosColaboradores(3).ToString(), WBll.ParametrosBuscaVeiculosColaboradores(null, null, mtxtCPF.Text), true, "VEÍCULOS DE COLABORADORES", "VEICULO", "", "Nenhum Veículo encontrado!");
                    fb.ShowDialog();

                    if (fb.retorno != null)
                        mtxtPlaca.Text = fb.retorno["PLACA"].ToString();
                }
            }
        }
        private void mtxtPlaca_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mtxtPlaca.Text))
            {
                DataTable dt = WBll.BuscaVeiculosColaboradores(mtxtPlaca.Text, 4, mtxtCPF.Text);

                //Caso o cpf não seja de colaborador, verifica se é de usuario de cartao de estacionamento
                if (dt.Rows.Count == 0)
                {
                    dt = WBll.BuscaUsuarioCartaoEstacionamento(mtxtCPF.Text);
                    txtObservacao.Text = dt.Rows[0]["OBSERVACAO"].ToString();
                    txtContatos.Text = dt.Rows[0]["CONTATO"].ToString();
                }

                if (dt.Rows.Count > 0)
                {
                    mtxtPlaca.Text = dt.Rows[0]["PLACA"].ToString();
                    mtxtPlaca.Tag = dt.Rows[0]["VEICULO"].ToString();

                    veiculoBicileta = (dt.Rows[0]["TIPO"].ToString().Equals("3") ? true : false);
                    veiculo = dt.Rows[0]["VEICULO"].ToString();

                    if (AcaoFormulario != CAcaoFormulario.Novo && AcaoFormulario != CAcaoFormulario.Editar)
                        PreencherFormulario();
                }
                else
                {
                    MessageBox.Show("Veículo não Cadastrado!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mtxtPlaca.Text = "";
                    mtxtPlaca.Tag = "";
                }
            }
            else
            {
                if (dgvEstacionamentosIndicados.DataSource != null)
                    ((DataTable)dgvEstacionamentosIndicados.DataSource).Clear();

                if (AcaoFormulario != CAcaoFormulario.Novo && AcaoFormulario != CAcaoFormulario.Editar)
                    LimpaCampos();
            }
        }
        private void mtxtPlaca_Enter(object sender, EventArgs e)
        {
            if (AcaoFormulario == CAcaoFormulario.Novo || AcaoFormulario == CAcaoFormulario.Editar)
            {
                if (string.IsNullOrEmpty(mtxtCPF.Text))
                {
                    MessageBox.Show("Informe o Colaborador.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtxtPlaca.Text = "";
                    mtxtCPF.Focus();
                }
            }
        }

        private void mtxtData_KeyDown(object sender, KeyEventArgs e)
        {
            if (AcaoFormulario != CAcaoFormulario.Novo)
            {
                if (e.KeyCode == Keys.F3)
                    FormBuscaRegistros(sender, false);
            }
        }
        private void mtxtData_Leave(object sender, EventArgs e)
        {
            if (!mtxtData.Text.Equals("  /  /"))
            {
                try
                {
                    DateTime.Parse(mtxtData.Text);
                }
                catch
                {
                    MessageBox.Show("Data inválida.", "Erro - Data Invália", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtxtData.Text = "";
                    return;
                }

                if (AcaoFormulario != CAcaoFormulario.Novo && AcaoFormulario != CAcaoFormulario.Editar)
                    PreencherFormulario();
            }
            else if (AcaoFormulario != CAcaoFormulario.Novo && AcaoFormulario != CAcaoFormulario.Editar)            
                LimpaCampos();
        }

        private void btnPlacas_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mtxtCPF.Text))
            {
                MessageBox.Show("Informe o Colaborador.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mtxtCPF.Focus();
            }
            else
            {
                if (string.IsNullOrEmpty(mtxtPlaca.Text))
                {
                    frmCadastroVeiculosColaboradores frmVC = new frmCadastroVeiculosColaboradores(mtxtCPF.Text, !usuCartaoEstacionamento);
                    frmVC.ShowInTaskbar = false;
                    frmVC.MinimizeBox = false;                    
                    frmVC.ShowDialog();

                    if (AcaoFormulario == CAcaoFormulario.Novo || AcaoFormulario == CAcaoFormulario.Editar)
                    {
                        if (!string.IsNullOrEmpty(frmVC.retorno))
                        {
                            mtxtPlaca.Text = frmVC.retorno;
                            mtxtPlaca_Leave(null, null);
                        }
                    }
                }
                else
                {
                    DataTable dt = WBll.BuscaVeiculosColaboradores(mtxtPlaca.Text, 1, mtxtCPF.Text);

                    if (dt.Rows.Count == 1)
                    {
                        frmCadastroVeiculosColaboradores frmVC = new frmCadastroVeiculosColaboradores(int.Parse(dt.Rows[0]["VEICULO"].ToString()));
                        frmVC.ShowInTaskbar = false;
                        frmVC.MinimizeBox = false;
                        frmVC.ShowDialog();
                        mtxtPlaca.Text = frmVC.retorno;
                    }
                }
            }
        }

        private void dgvContratos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dgvContratos.Columns["colGradeHoraria"].Index)
            {
                if (dgvContratos.Rows[e.RowIndex].Cells["colTipcon"].Value.ToString().Equals("10"))
                {
                    // Chama Relatório de Grade Horária do Docente (Relatório do Fox)
                    RelatorioSGAGradeHorariaDocente(dgvContratos.Rows[e.RowIndex].Cells["colMatricula"].Value.ToString());
                }
                else
                {
                    List<OracleParameter> parametros = new List<OracleParameter>();
                    parametros.Add(new OracleParameter("matricula", dgvContratos.Rows[e.RowIndex].Cells["colMatricula"].Value.ToString()));

                    FormBusca fb = new FormBusca(WBll.QueryBuscaHorariosTecAdministrativo().ToString(), parametros, true, "GRADE HORÁRIA DO COLABORADOR", "CODIGO_HORA", "", "Grade Horária não encontrada", false, "CODIGO_HORA, SEQUENCIA");
                    fb.ShowDialog();
                }
            }
        }

        private void btnLiberarVaga_Click(object sender, EventArgs e)
        {
            if (!ValidaCamposObrigatorios(this.Controls))
                MessageBox.Show("Por favor, preencha os campos que identificam o registro", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (!mtxtCNHVencimento.Text.Equals("  /  /") && DateTime.Parse(mtxtCNHVencimento.Text) < DateTime.Now)
                MessageBox.Show("A CNH informada ultrapassou sua Data de Validade. Para Liberar a vaga renove o documento.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (dgvEstacionamentosIndicados.Rows.Count < 1)
                {
                    MessageBox.Show("Não existem Vagas para serem liberadas!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("ATENÇÃO!! \n\n" + dgvEstacionamentosIndicados.Rows.Count + " Vaga(s) Liberada(s) serão geradas. \nTem certeza que deseja continuar?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        ClickGravar(null, null);
                        LiberarVaga(int.Parse(txtSolicitacao.Text));
                        ClickImprimir(null, null);
                    }
                    catch (Exception ex)
                    {
                        if (ex.InnerException != null)
                            MessageBox.Show(this, "Ocorreu um erro." + "\nContate o Administrador do Sistema para verificar o problema. \nErro: " + ex.InnerException.Message, "Erro - Liberar Vaga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show(this, "Ocorreu um erro." + "\nContate o Administrador do Sistema para verificar o problema. \nErro: " + ex.Message, "Erro - Liberar Vaga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSugerirEstacionamento_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mtxtPlaca.Text))
            {
                MessageBox.Show("Informe o Veículo do Colaborador.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mtxtPlaca.Focus();
                return;
            }

            try
            {
                if (dgvEstacionamentosIndicados.Rows.Count > 0)
                    if (MessageBox.Show("Atenção!!\n\nGerar uma Sugestão de Estacionamentos fará com que todos os Estacionamentos Indicados existentes sejam excluídos. Tem certeza que deseja continuar?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                        return;

                if (!string.IsNullOrEmpty(txtSolicitacao.Text))
                    using (EntitiesPrefeituraUniversitaria mde = new EntitiesPrefeituraUniversitaria(Globals.GetStringConnectionEntity(JBll.GetModelPrefeituraUniversitaria()).ToString()))
                        mde.ExecuteStoreCommand("delete from mtd.solicitacoes_estacionamentos where solicitacao = " + txtSolicitacao.Text);

                if (dgvContratos.Rows.Count > 0 || usuCartaoEstacionamento)
                {
                    DataTable dt = (DataTable)dgvContratos.DataSource;
                    double maiorCarga = 0.0;

                    DataRow[] dr = new DataRow[1];

                    if (!usuCartaoEstacionamento)
                    {
                        foreach (DataRow l in dt.Rows)
                        {
                            if (double.Parse(l["CH_MENSAL"].ToString()) > maiorCarga)
                                maiorCarga = double.Parse(l["CH_MENSAL"].ToString());
                        }

                        dr = dt.Select("CH_MENSAL = " + maiorCarga.ToString());
                    }                                       
                    
                    if (!veiculoBicileta)//Sugestão para vagas de carros e motos
                    {
                        if (!usuCartaoEstacionamento)
                        {
                            switch (dr[0]["TIPCON"].ToString())
                            {
                                case "10":
                                    SugerirEstacionamentosDocente();
                                    break;
                                case "13":
                                    SugerirEstacionamentosDocente();
                                    break;
                                default:
                                    SugerirEstacionamentosTecADM(dr[0]["CAMPUS"].ToString(), WBll.BuscaTipoVeiculo(mtxtPlaca.Text));
                                    break;
                            }
                        }
                    }
                    else //sugestão para bicicleta
                    {
                        SugerirEstacionamentosBicicletas();
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    MessageBox.Show(this, "Ocorreu um erro ao pesquisar as Sugestões de Estacionamentos. Contate o Administrador do Sistema para verificar o problema." + "\nErro: " + ex.InnerException.Message, "Erro - Sugestão Estacionamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(this, "Ocorreu um erro ao pesquisar as Sugestões de Estacionamentos. Contate o Administrador do Sistema para verificar o problema." + "\nErro: " + ex.Message, "Erro - Sugestão Estacionamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEstacionamentosIndicados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == dgvEstacionamentosIndicados.Columns["colExcluir"].Index)
            {
                if (MessageBox.Show("Tem certeza que deseja excluir o Estacionamento?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (!string.IsNullOrEmpty(txtSolicitacao.Text))
                    {
                        using (EntitiesPrefeituraUniversitaria mde = new EntitiesPrefeituraUniversitaria(Globals.GetStringConnectionEntity(JBll.GetModelPrefeituraUniversitaria()).ToString()))
                        {
                            long chave1 = long.Parse(txtSolicitacao.Text);
                            long chave2 = long.Parse(dgvEstacionamentosIndicados.Rows[e.RowIndex].Cells["colEstacionamento"].Value.ToString());
                            SOLICITACOES_ESTACIONAMENTOS estacionamento = mde.SOLICITACOES_ESTACIONAMENTOS.FirstOrDefault(x => x.SOLICITACAO == chave1 && x.ESTACIONAMENTO == chave2);
                            if (estacionamento != null)
                            {
                                mde.DeleteObject(estacionamento);
                                mde.SaveChanges();
                            }
                        }
                    }
                    ((DataTable)dgvEstacionamentosIndicados.DataSource).Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void btnAdicionarEstacionamento_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mtxtPlaca.Text))
            {
                MessageBox.Show("Informe o Veículo do Colaborador.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mtxtPlaca.Focus();
            }
            else
            {
                try
                {
                    DataTable dtPeriodos = ((DataTable)dgvContratos.DataSource);

                    string manha, tarde, noite;

                    if (!usuCartaoEstacionamento)
                    {
                        manha = (dtPeriodos.Select("MANHA = 1").Length > 0 ? "1" : "0");
                        tarde = (dtPeriodos.Select("TARDE = 1").Length > 0 ? "1" : "0");
                        noite = (dtPeriodos.Select("NOITE = 1").Length > 0 ? "1" : "0");
                    }
                    else
                    {
                        manha = "1";
                        tarde = "1";
                        noite = "1";
                    }

                    FormBusca fb = new FormBusca(WBll.QueryBuscaEstacionamentosDisponiveisNaoNomeadas(false).ToString(), new List<OracleParameter>() { new OracleParameter("tipo_veiculo", WBll.BuscaTipoVeiculo(mtxtPlaca.Text)), new OracleParameter("manha", manha), new OracleParameter("tarde", tarde), new OracleParameter("noite", noite) }, true, "ESTACIONAMENTOS DISPONÍVEIS", "ESTACIONAMENTO", "", "Nenhum Estacionamento Disponível!");
                    fb.ShowDialog();

                    if (fb.retorno != null)
                    {
                        DataTable dt;
                        if (dgvEstacionamentosIndicados.DataSource == null)
                        {
                            dt = new DataTable();

                            foreach (DataGridViewColumn coluna in dgvEstacionamentosIndicados.Columns)
                            {
                                if (!string.IsNullOrEmpty(coluna.DataPropertyName))
                                    dt.Columns.Add(coluna.DataPropertyName, typeof(string));
                            }

                            dt.ImportRow(fb.retorno);
                        }
                        else
                        {
                            dt = ((DataTable)dgvEstacionamentosIndicados.DataSource);
                            dt.ImportRow(fb.retorno);
                        }

                        dt.Rows[dt.Rows.Count - 1]["SITUACAO_DESC"] = "PENDENTE";
                        dt.Rows[dt.Rows.Count - 1]["MANHA"] = manha;
                        dt.Rows[dt.Rows.Count - 1]["TARDE"] = tarde;
                        dt.Rows[dt.Rows.Count - 1]["NOITE"] = noite;
                        dt.Rows[dt.Rows.Count - 1]["SITUACAO"] = "1";
                        dgvEstacionamentosIndicados.DataSource = dt;
                    }

                    dgvEstacionamentosIndicados.Refresh();
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                        MessageBox.Show(this, "Ocorreu um erro ao adicionar um Estacionamento. Contate o Administrador do Sistema para verificar o problema." + "\nErro: " + ex.InnerException.Message, "Erro - Adicionar Estacionamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show(this, "Ocorreu um erro ao adicionar um Estacionamento. Contate o Administrador do Sistema para verificar o problema." + "\nErro: " + ex.Message, "Erro - Adicionar Estacionamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void TratarCamposUsuCartaoEstacionamento()
        {
            if (usuCartaoEstacionamento)
            {
                txtCargo.Enabled = false;
                txtLocal.Enabled = false;
                grpCNH.Enabled = false;
            }
            else
            {
                txtCargo.Enabled = true;
                txtLocal.Enabled = true;
                grpCNH.Enabled = true;
            }
        }
    }
}