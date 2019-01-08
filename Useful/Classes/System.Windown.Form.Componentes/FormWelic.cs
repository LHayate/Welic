using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using UseFul.ClientApi;
using UseFul.ClientApi.Dtos;
using UseFul.Uteis.UI;

namespace UseFul.Forms.Welic
{
    public partial class FormWelic : Form, IMessage
    {
        private bool _IsFormularioPrincipal;
        private string _MsgTitulo;
        private string _MsgSubTitulo;
        private string _MsgDuvidas;
        private string _MsgEquipe;
        private string _MsgGerencia;

        public FormWelic()
        {
            InitializeComponent();
            this.MdiChildActivate += new EventHandler(FormWelic_MdiChildActivate);
            this.Resize += new EventHandler(FormWelic_Resize);
            this.ResizeEnd += new EventHandler(FormWelic_Resize);
            SetStyle(
                ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
        }



        /// <summary>
        /// Construtor com bloqueio para múltiplas instâncias do formulário
        /// </summary>
        /// <param name="frmP">Formulário MDI principal do projeto.</param>
        public FormWelic(Form frmP)
        {
            this.MdiParent = frmP;
            InitializeComponent();
            SetStyle(
                ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
        }

        #region Nova Implementação 
        public bool HasChanges { get; set; }

        public void ProcessMessage(string message, MessageType type)
        {
            UiControlUtil.ProcessMessage(message, type);
        }

        public void ProcessMessage(string message)
        {
            UiControlUtil.ProcessMessage(message, MessageType.Information);
        }

        public Result ProcessDialog(string message)
        {
            return UiControlUtil.ProcessDialog(message);
        }

        public static void ProcessStaticMessage(string message, MessageType type)
        {
            UiControlUtil.ProcessStaticMessage(message, type);
        }

        public static Result ProcessStaticDialog(string message, MessageBoxButtons buttons)
        {
            return UiControlUtil.ProcessStaticDialog(message, buttons);
        }

        public void ProcessMessage(string message, string exceptionMessage, MessageType type)
        {
            UiControlUtil.ProcessMessage(message, exceptionMessage, type);
        }

        public Result ProcessDialog(string message, MessageBoxButtons buttons)
        {
            return UiControlUtil.ProcessDialog(message, buttons);
        }

        protected void DisposeForm(Form form)
        {
            form.Controls.Clear();
            form.Dispose();
            GC.WaitForPendingFinalizers();
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Optimized);
        }

        protected virtual void ProcessException(Exception ex)
        {
            UiControlUtil.ProcessException(this, ex);
        }

        public static void StartWaitCursor()
        {
            UiControlUtil.StartWaitCursor();
        }

        public static void StopWaitCursor()
        {
            UiControlUtil.StopWaitCursor();
        }

        public virtual void CloseForm()
        {
            Close();
        }

        protected void AtribuiIconePesquisa(object campoText, EventHandler eventoClick)
        {
            PictureBox pb = new PictureBox { Cursor = Cursors.Hand };

            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream imageStream = assembly.GetManifestResourceStream("ACSolutions.SGC.Util.Imagens.F3.png");
            if (imageStream != null)
            {
                pb.Image = new Bitmap(imageStream);
            }
            pb.BackgroundImageLayout = ImageLayout.None;
            pb.BorderStyle = BorderStyle.None;
            pb.BackColor = Color.Transparent;

            pb.Click += eventoClick;

            if (campoText.GetType() == typeof(MaskedTextBox))
            {
                pb.Size = new Size(16, ((MaskedTextBox)campoText).ClientSize.Height - 5);
                ((MaskedTextBox)campoText).TextAlign = HorizontalAlignment.Left;
                ((MaskedTextBox)campoText).Controls.Add(pb);
                ((MaskedTextBox)campoText).Controls[1].Location =
                    new Point(((MaskedTextBox)campoText).ClientSize.Width - 20, 2);
            }
            else
            {
                pb.Size = new Size(16, ((TextBox)campoText).ClientSize.Height - 5);
                ((TextBox)campoText).TextAlign = HorizontalAlignment.Left;
                ((TextBox)campoText).Controls.Add(pb);
                ((TextBox)campoText).Controls[1].Location =
                    new Point(((TextBox)campoText).ClientSize.Width - 20, 2);
            }

            pb.BringToFront();
        }

        protected void AtribuiIconeForm()
        {
            Assembly assembly;
            Stream imageStream;

            assembly = Assembly.GetExecutingAssembly();
            imageStream = assembly.GetManifestResourceStream("ACSolutions.SGC.Util.Imagens.Icon.ico");
            //Icon = new Icon(_imageStream);
        }

        protected void MudarTabStop(Control controle)
        {
            controle.TabStop = controle.Enabled;
        }

    #endregion
        //Esse override impede que uma tecla ou combinação de teclas seja executada
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //No caso, o ctrl+tab será impedido dentro do formulario principal para que não haja 
            //risco de um childform ser jogado para trás do FormFundoPrincipal
            if (this._IsFormularioPrincipal && (keyData == (Keys.Control | Keys.Tab)))
            {
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }
        void FormWelic_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is FormFundoPrincipal)
            {
                this.ActiveMdiChild.SendToBack();
            }
        }
        void FormWelic_Resize(object sender, EventArgs e)
        {
            if (!this._IsFormularioPrincipal && this.MdiParent != null)
            {
                FormWindowState f = ((FormWelic)sender).WindowState;
                FormFundoPrincipal principal = null;
                if (f == FormWindowState.Minimized)
                {
                    foreach (Form item in this.MdiParent.MdiChildren)
                    {
                        if (item is FormFundoPrincipal)
                        {
                            principal = (FormFundoPrincipal)item;
                        }
                        else
                        {
                            item.BringToFront();
                        }
                    }
                    if (principal != null)
                        principal.SendToBack();
                }
            }
        }

        public void ConfigurarFundoFormularioPrincipal(string titulo, string subTitulo, string duvidas, string equipe, string gerencia)
        {
            this._MsgTitulo = titulo;
            this._MsgSubTitulo = subTitulo;
            this._MsgGerencia = gerencia;

            /*Caso o código do sistema estiver preenchido na classe Global
              busca os dados da equipe no banco de dados
            */
            if (Globals.Sistema > 0)
            {
                //TODO: Revisar para adicionar dados automaticamente 
                //DataTable dtb = RetornaDadosEquipes(Globals.Sistema);

                //if (dtb.Rows.Count > 0)
                //{
                //    this._MsgEquipe = dtb.Rows[0][0].ToString();
                //    this._MsgDuvidas = "Dúvidas/Solicitações: " + dtb.Rows[0][2].ToString();

                //    if (!string.IsNullOrEmpty(dtb.Rows[0][2].ToString()) && !string.IsNullOrEmpty(dtb.Rows[0][1].ToString()))
                //        this._MsgDuvidas += " - ramal ";

                //    if (!string.IsNullOrEmpty(dtb.Rows[0][1].ToString()))
                //        this._MsgDuvidas += dtb.Rows[0][1].ToString();
                //}
                //else
                //{
                    this._MsgDuvidas = duvidas;
                    this._MsgEquipe = equipe;
                //}

               // dtb = null;
            }
            else
            {

                this._MsgDuvidas = duvidas;
                this._MsgEquipe = equipe;
            }

            this._IsFormularioPrincipal = true;
        }

        //Todo: Revisar Para buscar dados
        //private DataTable RetornaDadosEquipes(int sistema)
        //{
        //    DataTable dtb = new DataTable();

        //    if (Globals.Sistema != 0)
        //    {
        //        if (Globals.Usuario != 0)
        //        {
        //            try
        //            {
        //                //Busca o nome da equipe e ramal para preencher o label do fundo

        //                StringBuilder sql = new StringBuilder();


        //                sql.Append(@"SELECT E.DESCRICAO, E.RAMAL, E.EMAIL
        //                           FROM SEG.SISTEMAS S 
        //                           JOIN SEG.EQUIPES E ON(E.EQUIPE = S.EQUIPE_DES)
        //                          WHERE S.SISTEMA =  " + sistema.ToString());

        //                Conexao dal = new Conexao(Globals.GetStringConnection(), 2);

        //                dtb = dal.ExecuteQuery(sql.ToString());
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //    }

        //    return dtb;
        //}

        private void ExibirFundoFormularioPrincipal()
        {
            if (this._IsFormularioPrincipal)
            {
                FormFundoPrincipal frmFundo = new FormFundoPrincipal();
                frmFundo.MdiParent = this;
                frmFundo.MsgTitulo = this._MsgTitulo;
                frmFundo.MsgSubTitulo = this._MsgSubTitulo;
                frmFundo.MsgDuvidas = this._MsgDuvidas;
                frmFundo.MsgEquipe = this._MsgEquipe;
                frmFundo.MsgGerencia = this._MsgGerencia;
                frmFundo.Dock = DockStyle.Fill;
                frmFundo.Show();
            }
        }

        /// <summary>
        /// Método para retornar a instância aberta do formulário dentro dos formulários MDIChildren existentes
        /// </summary>
        /// <returns>Instância aberta do formulário chamado</returns>
        /// <remarks>Deve ser utilizado com formulários MDI. Retorna NULL caso o MDIParent não tenha sido definido</remarks>
        public Form GetInstancia()
        {
            if (this.MdiParent != null)
            {
                object tipoForm = this.GetType();
                IEnumerable<Form> resultado = this.MdiParent.MdiChildren.Where(c => c.GetType() == tipoForm);

                if (resultado.Count() > 1)
                {
                    if (WaitWindow.IsShowing)
                        WaitWindow.End();
                    resultado.First().WindowState = FormWindowState.Normal;
                    this.Dispose();
                }

                return resultado.First();
            }
            else
            {
                return null;
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private string _idProgram = string.Empty;
        /// <summary>
        /// Código do formulario para validar permissões 
        /// </summary>
        public string IdProgram
        {
            get { return _idProgram; }
            set { _idProgram = value; }
        }

        private Seguranca _segurancaForm = new Seguranca();
        /// <summary>
        /// Atributos da Segurança do Formulário
        /// </summary>
        public Seguranca SegurancaForm
        {
            get { return _segurancaForm; }
            set { _segurancaForm = value; }
        }

        public enum CAcaoFormulario { Nenhum, Novo, Gravar, Editar, Voltar, Excluir, Buscar, Imprimir, Auditar, Ajudar };
        private CAcaoFormulario _acaoFormulario = CAcaoFormulario.Nenhum;
        public CAcaoFormulario AcaoFormulario
        {
            get { return _acaoFormulario; }
            set { _acaoFormulario = value; }
        }

        private void FormWelic_Load(object sender, EventArgs e)
        {
            ExibirFundoFormularioPrincipal();

            ///Executa Automaticamente
            if (!string.IsNullOrEmpty(Globals.Senha))
            {
                if (!string.IsNullOrEmpty(this.IdProgram))
                {
                    string usuario = Globals.IdUser;
                    string programa = this.IdProgram;

                    List<Seguranca> permissao = (from p in Globals.listaSeguranca
                                                 where p.IdUser == usuario && p.IdProgram == programa
                                                 select p).ToList();

                    if (permissao.Count <= 0)
                    {
                        MessageBox.Show("Você não tem permissão para acessar esta tela. \nSolicite seu acesso.", "Segurança", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        //Quanto é MDI não pode fechar o formulario direto
                        this.BeginInvoke(new MethodInvoker(FechaFormulario));
                    }
                    else
                    {
                        SegurancaForm = permissao.First();
                        if (!SegurancaForm.Active)
                        {
                            MessageBox.Show("Este formulário esta desativado!", "Segurança", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            //Quanto é MDI não pode fechar o formulario direto
                            this.BeginInvoke(new MethodInvoker(FechaFormulario));
                        }
                        else if (!SegurancaForm.Read)
                        {
                            MessageBox.Show("Você não tem permissão para acessar esta tela. \nSolicite seu acesso.", "Segurança", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            //Quanto é MDI não pode fechar o formulario direto
                            this.BeginInvoke(new MethodInvoker(FechaFormulario));
                        }
                    }
                }
                else
                {
                    Seguranca seg = new Seguranca();
                    seg.IdProgram = "";
                    seg.IdUser = Globals.Usuario;
                    seg.All = true;
                    seg.Read = true;
                    seg.Insert = true;
                    seg.Update = true;
                    seg.Delete = true;
                    SegurancaForm = seg;
                }
            }

            //PreencherMensagensToolTips();
            //AbrirTelasAutomaticamente();

            this.DelegateEnterFocusMaskedTextBoxWelic(this);
            this.DelegateEnterFocusMaskedTextBoxDataWelic(this);
        }

        //TODO: Revisar se é necessario. 
        //public void AbrirFormularioOutroSistema(int codigoSistema, string nomeProjeto, string nomeFormulario, string parametros = "")
        //{
        //    Classes.Dal.Conexao dal = new Classes.Dal.Conexao(Globals.GetStringConnection(), 2);
        //    StringBuilder sql = new StringBuilder();

        //    sql.Append(@"
        //    SELECT executavel
        //      FROM seg.sistemas s
        //     WHERE s.sistema = " + codigoSistema);
        //    DataTable dtSistema = dal.ExecuteQuery(sql.ToString());

        //    if (dtSistema.Rows.Count > 0)
        //    {
        //        string caminho = dtSistema.Rows[0][0].ToString();

        //        sql.Clear();
        //        sql.Append(@"SELECT seg.f_gera_autenticacao(" + Globals.Usuario + @",'" +
        //                                                                Globals.Login + @"','" +
        //                                                                Globals.Conexao + @"') FROM dual");
        //        DataTable dt = dal.ExecuteQuery(sql.ToString());

        //        sql.Clear();
        //        sql.Append(@"
        //        SELECT *
        //          FROM seg.parametros_temporarios pt
        //         WHERE pt.sistema = " + codigoSistema + @"
        //           AND pt.usuario = " + Globals.Usuario + @"
        //           AND pt.projeto = '" + nomeProjeto + @"'
        //           AND pt.formulario = '" + nomeFormulario + "'");
        //        dt = ExecutarSQL(sql.ToString());
        //        if (dt.Rows.Count == 0)
        //        {
        //            sql.Clear();
        //            sql.Append(@"
        //            INSERT INTO seg.parametros_temporarios pt 
        //                   (pt.sistema, pt.usuario, pt.projeto, pt.formulario, pt.parametros)
        //            VALUES (" + codigoSistema + "," + Globals.Usuario + ",'" + nomeProjeto + "','" + nomeFormulario + "','" + parametros + "')");
        //            dal.ExecuteNonQuery(sql.ToString());
        //        }

        //        System.Diagnostics.Process.Start(caminho);
        //    }
        //}
        //private void AbrirTelasAutomaticamente()
        //{
        //    if (this.IsMdiContainer && Globals.Conexao != null)
        //    {
                
        //        try
        //        {
        //            StringBuilder sql = new StringBuilder();
        //            sql.Append(@"
        //            SELECT pt.sistema, pt.usuario, pt.projeto, pt.formulario, nvl(pt.parametros,' ') AS parametros
        //              FROM seg.parametros_temporarios pt 
        //             WHERE pt.sistema = " + Globals.Sistema + @"
        //               AND pt.usuario = " + Globals.Usuario);
        //            DataTable dt = ExecutarSQL(sql.ToString());

        //            if (dt.Rows.Count > 0)
        //            {
                        

        //                this.Visible = false;

        //                foreach (DataRow item in dt.Rows)
        //                {
        //                    string projectName = item["projeto"].ToString();
        //                    string formName = item["formulario"].ToString();
        //                    List<string> propriedades = new List<string>();
        //                    List<string> valores = new List<string>();

        //                    if (!item["parametros"].ToString().Trim().Equals(""))
        //                    {
        //                        string[] parametros = item["parametros"].ToString().Split(new Char[] { ';' });

        //                        for (int i = 0; i < parametros.Length; i++)
        //                        {
        //                            if (i % 2 == 0)
        //                                propriedades.Add(parametros[i]);
        //                            else
        //                                valores.Add(parametros[i]);
        //                        }
        //                    }
        //                    //MessageBox.Show(propriedades.Count + "\n" + valores.Count);
        //                    #region Carregar Assembly
        //                    System.Reflection.Assembly assembly;
        //                    try
        //                    {
        //                        //Tenta carregar o projeto informado
        //                        assembly = System.Reflection.Assembly.Load(projectName);
        //                    }
        //                    catch (Exception)
        //                    {
        //                        //Caso não consiga, carrega o projeto atual
        //                        assembly = System.Reflection.Assembly.GetExecutingAssembly();
        //                    }
        //                    Type[] types = assembly.GetTypes();
        //                    #endregion

        //                    #region Encontrar e abrir o formulário
        //                    foreach (Type type in types)
        //                    {
        //                        if (!type.FullName.Equals(this.GetType().FullName))
        //                        {
        //                            try
        //                            {
        //                                switch (type.BaseType.FullName)
        //                                {
        //                                    case "UseFul.Forms.Welic.FormWelic":
        //                                        FormWelic frmWelic = (FormWelic)Activator.CreateInstance(type);
        //                                        if (frmWelic.Name.Equals(formName))
        //                                        {
        //                                            PreencherPropriedades(frmWelic, propriedades, valores);
        //                                            frmWelic.ShowDialog();
        //                                        }
        //                                        break;
        //                                    case "UseFul.Forms.Welic.FormCadastro":
        //                                        FormCadastro frmCadastro = (FormCadastro)Activator.CreateInstance(type);
        //                                        if (frmCadastro.Name.Equals(formName))
        //                                        {
        //                                            PreencherPropriedades(frmCadastro, propriedades, valores);
        //                                            frmCadastro.ShowDialog();
        //                                        }
        //                                        break;
        //                                    //case "UseFul.Forms.Welic.FormRelatorioCompleto":
        //                                    //    FormRelatorioCompleto frmRelatorioCompleto = (FormRelatorioCompleto)Activator.CreateInstance(type);
        //                                    //    if (frmRelatorioCompleto.Name.Equals(formName))
        //                                    //    {
        //                                    //        PreencherPropriedades(frmRelatorioCompleto, propriedades, valores);
        //                                    //        frmRelatorioCompleto.ShowDialog();
        //                                    //    }
        //                                    //    break;
        //                                    case "UseFul.Forms.Welic.FormBusca":
        //                                        FormBuscaPaginacao frmBusca = (FormBuscaPaginacao)Activator.CreateInstance(type);
        //                                        if (frmBusca.Name.Equals(formName))
        //                                        {
        //                                            PreencherPropriedades(frmBusca, propriedades, valores);
        //                                            frmBusca.ShowDialog();
        //                                        }
        //                                        break;
        //                                    case "UseFul.Forms.Welic.FormConsulta":
        //                                        FormConsulta frmConsulta = (FormConsulta)Activator.CreateInstance(type);
        //                                        if (frmConsulta.Name.Equals(formName))
        //                                        {
        //                                            PreencherPropriedades(frmConsulta, propriedades, valores);
        //                                            frmConsulta.ShowDialog();
        //                                        }
        //                                        break;
        //                                    case "UseFul.Forms.Welic.FormAssistenteCadastro":
        //                                        FormAssistenteCadastro frmAssistenteCadastro = (FormAssistenteCadastro)Activator.CreateInstance(type);
        //                                        if (frmAssistenteCadastro.Name.Equals(formName))
        //                                        {
        //                                            PreencherPropriedades(frmAssistenteCadastro, propriedades, valores);
        //                                            frmAssistenteCadastro.ShowDialog();
        //                                        }
        //                                        break;
        //                                }
        //                            }
        //                            catch (Exception)
        //                            {
        //                                //os erros de formulários com construtores que possuem parâmetros cairão aqui e serão ignorados
        //                            }
        //                        }
        //                    }
        //                    #endregion

        //                    sql.Clear();
        //                    sql.Append(@"
        //                    DELETE FROM seg.parametros_temporarios pt 
        //                     WHERE pt.sistema = " + Globals.Sistema + @"
        //                       AND pt.usuario = " + Globals.Usuario + @"
        //                       AND pt.projeto = '" + projectName + @"'
        //                       AND pt.formulario = '" + formName + "'");
        //                    new Classes.Dal.Conexao(Globals.GetStringConnection(), 2).ExecuteNonQuery(sql.ToString());
        //                }

        //                Environment.Exit(-1);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Ocorreu um erro: " + ex.Message + "\nPor favor, entre em contato com a DTI", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            Environment.Exit(-1);
        //        }
        //    }
        //}



        private void PreencherPropriedades(FormWelic frm, List<string> propriedades, List<string> valores)
        {
            try
            {
                for (int i = 0; i < propriedades.Count; i++)
                {
                    frm.SetValorPropriedade(frm, propriedades[i], valores[i]);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro durante a passagem de parâmetros para o formulário solicitado. Por favor, entre em contato com a DTI.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
        }

        //Seleciona todo o texto de um controle.
        private void SelectMaskedTextBoxWelic_Enter(object sender, System.EventArgs e)
        {
            // Executa o método de forma assíncrona - pois o MaskedTextBox já executa um
            // select no evento "Enter" do foco, que acaba desfazendo a seleção.
            this.BeginInvoke((MethodInvoker)delegate()
            {
                if (sender is UpDownBase)
                {
                    ((UpDownBase)sender).Select(0, ((UpDownBase)sender).Text.Length);
                }
                else if (sender is MaskedTextBoxWelic)
                {
                    ((MaskedTextBoxWelic)sender).SelectAll();
                }
            });
        }

        //Seleciona todo o texto de um controle.
        private void SelectMaskedTextBoxDataWelic_Enter(object sender, System.EventArgs e)
        {
            // Executa o método de forma assíncrona - pois o MaskedTextBox já executa um
            // select no evento "Enter" do foco, que acaba desfazendo a seleção.
            this.BeginInvoke((MethodInvoker)delegate()
            {
                if (sender is UpDownBase)
                {
                    ((UpDownBase)sender).Select(0, ((UpDownBase)sender).Text.Length);
                }
                else if (sender is MaskedTextBoxDataWelic)
                {
                    ((MaskedTextBoxDataWelic)sender).SelectAll();
                }
            });
        }

        //Associa o evento "SelectText_Enter" a cada um dos campos com texto
        private void DelegateEnterFocusMaskedTextBoxWelic(Control ctrl)
        {
            if ((ctrl is UpDownBase) || (ctrl is MaskedTextBoxWelic))
            {
                ctrl.Enter += SelectMaskedTextBoxWelic_Enter;
                return;
            }

            // Chamada recursiva para associar o evento a todos os controles da interface
            foreach (Control ctrlChild in ctrl.Controls)
            {
                this.DelegateEnterFocusMaskedTextBoxWelic(ctrlChild);
            }
        }

        //Associa o evento "SelectText_Enter" a cada um dos campos com texto
        private void DelegateEnterFocusMaskedTextBoxDataWelic(Control ctrl)
        {
            if ((ctrl is UpDownBase) || (ctrl is MaskedTextBoxDataWelic))
            {
                ctrl.Enter += SelectMaskedTextBoxDataWelic_Enter;
                return;
            }

            // Chamada recursiva para associar o evento a todos os controles da interface
            foreach (Control ctrlChild in ctrl.Controls)
            {
                this.DelegateEnterFocusMaskedTextBoxDataWelic(ctrlChild);
            }
        }

        //Quanto é MDI não pode fechar o formulario direto
        private void FechaFormulario()
        {
            this.Close();
        }


        protected void LimpaCampos(Control.ControlCollection pControles)
        {
            foreach (Control ctrl in pControles)
            {
                LimpaCampos(ctrl);
                LimpaCampos(ctrl.Controls);
            }
        }
        protected void LimpaCamposNaoChave(Control.ControlCollection pControles)
        {
            foreach (Control ctrl in pControles)
            {
                if (!EChave(ctrl))
                    LimpaCampos(ctrl);
                LimpaCamposNaoChave(ctrl.Controls);
            }
        }
        protected void LimpaCamposBloqueiaAutoIncremento(Control.ControlCollection pControles)
        {
            foreach (Control ctrl in pControles)
            {
                if (EAutoIncremento(ctrl))
                    BloqueiaCampo(ctrl);
                else
                    LiberaCampo(ctrl);
                LimpaCampos(ctrl);
                LimpaCamposBloqueiaAutoIncremento(ctrl.Controls);
            }
        }
        protected void LiberaChaveBloqueiaCampos(Control.ControlCollection pControles)
        {
            foreach (Control ctrl in pControles)
            {
                if (EChave(ctrl))
                    LiberaCampo(ctrl);
                else
                {
                    BloqueiaCampo(ctrl);
                }
                LiberaChaveBloqueiaCampos(ctrl.Controls);
            }
        }
        protected bool ValidaCamposObrigatorios(Control.ControlCollection pControles)
        {
            foreach (Control ctrl in pControles)
            {
                if (EObrigatorio(ctrl) && ENullOuVazio(ctrl))
                    return false;
                if (!ValidaCamposObrigatorios(ctrl.Controls))
                    return false;
            }
            return true;
        }
        protected void BloqueiaChaves(Control.ControlCollection pControles)
        {
            foreach (Control ctrl in pControles)
            {
                if (EChave(ctrl))
                    BloqueiaCampo(ctrl);
                BloqueiaChaves(ctrl.Controls);
            }
        }
        protected void BloqueiaChaveLiberaCampos(Control.ControlCollection pControles)
        {
            foreach (Control ctrl in pControles)
            {
                if (EChave(ctrl))
                    BloqueiaCampo(ctrl);
                else
                    LiberaCampo(ctrl);
                BloqueiaChaveLiberaCampos(ctrl.Controls);
            }
        }
        protected void LimpaCampos(Control pControle)
        {
            if (pControle is TextBoxWelic)
            {
                if (((TextBoxWelic)(pControle)).LimpaCampo)
                    ((TextBoxWelic)(pControle)).Clear();
                return;
            }
            if (pControle is MaskedTextBoxWelic)
            {
                if (((MaskedTextBoxWelic)(pControle)).LimpaCampo)
                    ((MaskedTextBoxWelic)(pControle)).Clear();
                return;
            }
            if (pControle is MaskedTextBoxDataWelic)
            {
                if (((MaskedTextBoxDataWelic)(pControle)).LimpaCampo)
                    ((MaskedTextBoxDataWelic)(pControle)).Clear();
                return;
            }
            if (pControle is RadioButtonWelic)
            {
                if (((RadioButtonWelic)(pControle)).LimpaCampo)
                    ((RadioButtonWelic)(pControle)).Checked = false;
                return;
            }
            if (pControle is DataGridViewWelic)
            {
                if (((DataGridViewWelic)(pControle)).LimpaCampo)
                {
                    DataTable dt = new DataTable();
                    if (((DataGridViewWelic)(pControle)).DataSource != null)
                    {
                        if (((DataGridViewWelic)(pControle)).DataSource.GetType() == typeof(BindingSource))
                        {
                            BindingSource bs = new BindingSource();
                            var source = bs.DataSource;
                            while (source is BindingSource)
                            {
                                source = ((BindingSource) source).DataSource;
                            }

                            if (source is DataTable)
                            {
                                dt = (DataTable) source; /*((BindingSource) ((DataGridViewWelic) (pControle)).DataSource)*/
                                    //.DataSource;
                                if (dt == null) return;
                                if (dt.Rows.Count > 0)
                                {
                                    dt.Clear();
                                    bs.DataSource = dt;
                                    ((DataGridViewWelic) (pControle)).DataSource = bs;
                                }
                            }
                        }
                        else
                        {
                            dt = (DataTable)((DataGridViewWelic)(pControle)).DataSource;
                            if (dt != null)
                            {
                                if (dt.Rows.Count > 0)
                                {
                                    dt.Clear();
                                    ((DataGridViewWelic)(pControle)).DataSource = dt;
                                }
                            }
                        }
                    }
                }
                return;
            }
            if (pControle is CheckBoxWelic)
            {
                if (((CheckBoxWelic)(pControle)).LimpaCampo)
                    ((CheckBoxWelic)(pControle)).Checked = false;
                return;
            }
            if (pControle is ComboBoxWelic)
            {
                if (((ComboBoxWelic)(pControle)).LimpaCampo)
                {
                    DataTable dt = new DataTable();
                    dt = (DataTable)((ComboBoxWelic)(pControle)).DataSource;
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            dt.Clear();
                            ((ComboBoxWelic)(pControle)).DataSource = dt;
                        }
                    }
                    else
                    {
                        ((ComboBoxWelic)(pControle)).DataSource = null;
                        ((ComboBoxWelic)(pControle)).Items.Clear();
                    }
                    ((ComboBoxWelic)(pControle)).Text = string.Empty;
                }
                return;
            }
            if (pControle is DateTimePickerWelic)
            {
                if (((DateTimePickerWelic)(pControle)).LimpaCampo)
                    ((DateTimePickerWelic)(pControle)).Value = DateTime.Now;
                return;
            }
            if (pControle is ListBoxWelic)
            {
                if (((ListBoxWelic)(pControle)).LimpaCampo)
                {
                    ((ListBoxWelic)(pControle)).DataSource = null;
                    ((ListBoxWelic)(pControle)).Items.Clear();
                }
                return;
            }
            //if (pControle is ListaCampos1)
            //{
            //    ((ListaCampos1)pControle).listGeral.Items.Clear();
            //}
            if (pControle.HasChildren)
                LimpaCampos(pControle.Controls);
        }
        protected void BloqueiaCampo(Control pControle)
        {
            if (pControle is TextBoxWelic)
            {
                ((TextBoxWelic)(pControle)).Enabled = false;
                return;
            }
            if (pControle is MaskedTextBoxWelic)
            {
                ((MaskedTextBoxWelic)(pControle)).Enabled = false;
                return;
            }
            if (pControle is MaskedTextBoxDataWelic)
            {
                ((MaskedTextBoxDataWelic)(pControle)).Enabled = false;
                return;
            }
            if (pControle is CheckBoxWelic)
            {
                ((CheckBoxWelic)(pControle)).Enabled = false;
                return;
            }
            if (pControle is ComboBoxWelic)
            {
                ((ComboBoxWelic)(pControle)).Enabled = false;
                return;
            }
            if (pControle is DateTimePickerWelic)
            {
                ((DateTimePickerWelic)(pControle)).Enabled = false;
                return;
            }
            if (pControle is ListBoxWelic)
            {
                ((ListBoxWelic)(pControle)).Enabled = false;
                return;
            }
            if (pControle is GroupBoxWelic)
            {
                ((GroupBoxWelic)(pControle)).Enabled = false;
                return;
            }
            if (pControle is RadioButtonWelic)
            {
                ((RadioButtonWelic)(pControle)).Enabled = false;
                return;
            }
        }
        protected void LiberaCampo(Control pControle)
        {
            if (pControle is TextBoxWelic)
            {
                ((TextBoxWelic)(pControle)).Enabled = true;
                return;
            }
            if (pControle is MaskedTextBoxWelic)
            {
                ((MaskedTextBoxWelic)(pControle)).Enabled = true;
                return;
            }
            if (pControle is MaskedTextBoxDataWelic)
            {
                ((MaskedTextBoxDataWelic)(pControle)).Enabled = true;
                return;
            }
            if (pControle is DataGridViewWelic)
            {
                ((DataGridViewWelic)(pControle)).Enabled = true;
                return;
            }
            if (pControle is CheckBoxWelic)
            {
                ((CheckBoxWelic)(pControle)).Enabled = true;
                return;
            }
            if (pControle is ComboBoxWelic)
            {
                ((ComboBoxWelic)(pControle)).Enabled = true;
                return;
            }
            if (pControle is DateTimePickerWelic)
            {
                ((DateTimePickerWelic)(pControle)).Enabled = true;
                return;
            }
            if (pControle is ListBoxWelic)
            {
                ((ListBoxWelic)(pControle)).Enabled = true;
                return;
            }
            if (pControle is GroupBoxWelic)
            {
                ((GroupBoxWelic)(pControle)).Enabled = true;
                return;
            }
            if (pControle is RadioButtonWelic)
            {
                ((RadioButtonWelic)(pControle)).Enabled = true;
                return;
            }
        }

        protected bool EAutoIncremento(Control pControle)
        {
            if (pControle is TextBoxWelic)
            {
                if (((TextBoxWelic)(pControle)).TipoCampo == TextBoxWelic.CTipoCampo.ChaveAutoIncremento)
                    return true;
                else
                    return false;
            }
            if (pControle is MaskedTextBoxWelic)
            {
                if (((MaskedTextBoxWelic)(pControle)).TipoCampo == MaskedTextBoxWelic.CTipoCampo.ChaveAutoIncremento)
                    return true;
                else
                    return false;
            }
            if (pControle is MaskedTextBoxDataWelic)
            {
                if (((MaskedTextBoxDataWelic)(pControle)).TipoCampo == MaskedTextBoxDataWelic.CTipoCampo.ChaveAutoIncremento)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        protected bool EChave(Control pControle)
        {
            if (pControle is TextBoxWelic)
            {
                if (((TextBoxWelic)(pControle)).TipoCampo == TextBoxWelic.CTipoCampo.ChaveAutoIncremento || ((TextBoxWelic)(pControle)).TipoCampo == TextBoxWelic.CTipoCampo.Chave)
                    return true;
                else
                    return false;
            }
            if (pControle is MaskedTextBoxWelic)
            {
                if (((MaskedTextBoxWelic)(pControle)).TipoCampo == MaskedTextBoxWelic.CTipoCampo.ChaveAutoIncremento || ((MaskedTextBoxWelic)(pControle)).TipoCampo == MaskedTextBoxWelic.CTipoCampo.Chave)
                    return true;
                else
                    return false;
            }
            if (pControle is MaskedTextBoxDataWelic)
            {
                if (((MaskedTextBoxDataWelic)(pControle)).TipoCampo == MaskedTextBoxDataWelic.CTipoCampo.ChaveAutoIncremento || ((MaskedTextBoxDataWelic)(pControle)).TipoCampo == MaskedTextBoxDataWelic.CTipoCampo.Chave)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        protected bool EObrigatorio(Control pControle)
        {
            if (pControle is TextBoxWelic)
            {
                if (AcaoFormulario == CAcaoFormulario.Novo)
                {
                    if (((TextBoxWelic)(pControle)).TipoCampo == TextBoxWelic.CTipoCampo.Chave || ((TextBoxWelic)(pControle)).TipoCampo == TextBoxWelic.CTipoCampo.Obrigatorio)
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (((TextBoxWelic)(pControle)).TipoCampo != TextBoxWelic.CTipoCampo.Normal)
                        return true;
                    else
                        return false;
                }
            }
            if (pControle is MaskedTextBoxWelic)
            {
                if (AcaoFormulario == CAcaoFormulario.Novo)
                {
                    if (((MaskedTextBoxWelic)(pControle)).TipoCampo == MaskedTextBoxWelic.CTipoCampo.Chave || ((MaskedTextBoxWelic)(pControle)).TipoCampo == MaskedTextBoxWelic.CTipoCampo.Obrigatorio)
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (((MaskedTextBoxWelic)(pControle)).TipoCampo != MaskedTextBoxWelic.CTipoCampo.Normal)
                        return true;
                    else
                        return false;
                }
            }
            if (pControle is MaskedTextBoxDataWelic)
            {
                if (AcaoFormulario == CAcaoFormulario.Novo)
                {
                    if (((MaskedTextBoxDataWelic)(pControle)).TipoCampo == MaskedTextBoxDataWelic.CTipoCampo.Chave || ((MaskedTextBoxDataWelic)(pControle)).TipoCampo == MaskedTextBoxDataWelic.CTipoCampo.Obrigatorio)
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (((MaskedTextBoxDataWelic)(pControle)).TipoCampo != MaskedTextBoxDataWelic.CTipoCampo.Normal)
                        return true;
                    else
                        return false;
                }
            }
            else
                return false;
        }
        protected bool ENullOuVazio(Control pControle)
        {
            if (pControle is TextBoxWelic)
            {
                if (string.IsNullOrEmpty(((TextBoxWelic)pControle).Text.ToString()))
                    return true;
                else
                    return false;
            }
            if (pControle is MaskedTextBoxWelic)
            {
                if (!((MaskedTextBoxWelic)pControle).MaskFull)
                    return true;
                else
                    return false;
            }
            if (pControle is MaskedTextBoxDataWelic)
            {
                if ((string.IsNullOrEmpty(((MaskedTextBoxDataWelic)pControle).Text.ToString())) || (!((MaskedTextBoxDataWelic)pControle).MaskFull))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public static string nomePrograma;

        public static void MensagemSistema(string nomePrograma_)
        {
            nomePrograma = nomePrograma_;
        }

        private const string WMCLOSE = "WmClose";

        public static bool FecharFormulario()
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
            if (FecharFormulario() == true)
                return;

            MessageBox.Show("Registro não encontrado", "Validação registro não encontrado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txt.Text = "";
            txt.Focus();
        }
        public static void RegistroNaoEncontrado(MaskedTextBoxWelic txt)
        {
            if (FecharFormulario() == true)
                return;

            MessageBox.Show("Registro não encontrado", "Validação registro não encontrado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txt.Text = "";
            txt.Focus();
        }

        public static bool MensagemCampoVazio(MaskedTextBoxWelic txt, string mensagem)
        {
            if (FecharFormulario() == true)
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
            if (FecharFormulario() == true)
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
            if (FecharFormulario() == true)
                return false;

            if (string.IsNullOrEmpty(txt.Text))
            {
                MessageBox.Show(mensagem, "Validação campo vazio.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Método para exibir uma mensagem que desaparece automaticamente na tela.
        /// Essa mensagem começa a desaparecer em 2 segundos, ficando gradativamente mais transparente, ate desaparecer por completo.
        /// Durante o processo de desaparecimento, caso o usuário passe o mouse por cima da mensagem, o processo é cancelado e retomado quando o cursor do mouse sai da mensagem.
        /// </summary>
        /// <param name="msg">Mensagem a ser exibida</param>
        /// <param name="icone">Imagem que será exibida ao lado da mensagem. A classe SystemIcons possui diversas opções. </param>
        /// <param name="backColor">Cor de fundo da tela da mensagem</param>
        /// <param name="foreColor">Cor do texto da mensagem</param>
        /// <param name="fonteMensagem">Fonte a ser aplicada no texto da mensagem</param>
        protected void Mensagem(string msg, Icon icone = null, Color? backColor = null, Color? foreColor = null, Font fonteMensagem = null)
        {
            FormMensagem f = new FormMensagem(msg);
            f.icone = icone;
            f.backColor = backColor;
            f.foreColor = foreColor;
            f.FonteMensagem = fonteMensagem;
            f.Show();
        }

        static List<Control> txts = new List<Control>();
        private void BuscarTextBoxs(Control.ControlCollection pControles)
        {
            foreach (Control ctrl in pControles)
            {
                BuscarTextBoxs(ctrl);
                BuscarTextBoxs(ctrl.Controls);
            }
        }
        private void BuscarTextBoxs(Control pControle)
        {
            if (pControle is TextBoxWelic)
            {
                if (((TextBoxWelic)pControle).InformacaoToolTipCaminho != null &&
                    !string.IsNullOrEmpty(((TextBoxWelic)pControle).InformacaoToolTipCaminho.Trim()) //&&
                    //((TextBoxWelic)pControle).InformacaoToolTipDescricao != null &&
                    //!string.IsNullOrEmpty(((TextBoxWelic)pControle).InformacaoToolTipDescricao.Trim())
                    )
                {
                    txts.Add(pControle);
                }
            }
        }

        //TODO: REvisar para TOltip
        //public void PreencherMensagensToolTips()
        //{
        //    BuscarTextBoxs(this.Controls);

        //    foreach (Control item in txts)
        //    {
        //        string[] campos = ((TextBoxWelic)item).InformacaoToolTipCaminho.Split('.');

        //        StringBuilder sql = new StringBuilder();
        //        sql.Append(@"
        //        SELECT c.comments
        //          FROM sys.all_col_comments c
        //         WHERE upper(c.owner) = upper('" + campos[0] + @"')
        //           AND upper(c.table_name) = upper('" + campos[1] + @"')
        //           AND upper(c.column_name) = upper('" + campos[2] + "')");

        //        Classes.Dal.Conexao dal = new Classes.Dal.Conexao(Globals.GetStringConnection(), 2);
        //        DataTable dtDados = dal.ExecuteQuery(sql.ToString());

        //        ((TextBoxWelic)item).InformacaoToolTipDescricao = dtDados.Rows[0][0].ToString();
        //    }
        //}

        private static int CompareTabIndex(Control c1, Control c2)
        {
            return c1.TabIndex.CompareTo(c2.TabIndex);
        }

        /// <summary>
        /// Método para preencher automaticamente os campos do formulário. Serão preenchidos todos os campos que 
        /// possuírem a propriedade NomeCampoDadosDataTable informada. Essa propriedade deve conter o respectivo 
        /// nome da coluna na DataTable,
        /// </summary>
        public void PreencherCampos(Control.ControlCollection controls, DataTable dtDados)
        {
            if (dtDados.Rows.Count > 0)
            {
                List<Control> list = new List<Control>();
                foreach (Control item in controls)
                {
                    list.Add(item);
                }
                list.Sort(new Comparison<Control>(CompareTabIndex));

                foreach (Control ctrl in list)
                {
                    try
                    {
                        //TextBox
                        if (ctrl is TextBoxWelic && !string.IsNullOrEmpty(((TextBoxWelic)ctrl).NomeCampoDadosDataTable))
                        {
                            ((TextBoxWelic)ctrl).Text = dtDados.Rows[0][((TextBoxWelic)ctrl).NomeCampoDadosDataTable].ToString();
                        }

                        //NumericUpDown
                        if (ctrl is NumericUpDownWelic && !string.IsNullOrEmpty(((NumericUpDownWelic)ctrl).NomeCampoDadosDataTable))
                        {
                            ((NumericUpDownWelic)ctrl).Value = Decimal.Parse(dtDados.Rows[0][((NumericUpDownWelic)ctrl).NomeCampoDadosDataTable].ToString());
                        }

                        //MaskedTextBox
                        if (ctrl is MaskedTextBoxWelic && !string.IsNullOrEmpty(((MaskedTextBoxWelic)ctrl).NomeCampoDadosDataTable))
                        {
                            ((MaskedTextBoxWelic)ctrl).Text = dtDados.Rows[0][((MaskedTextBoxWelic)ctrl).NomeCampoDadosDataTable].ToString();
                        }

                        //DateTimePicker
                        if (ctrl is DateTimePickerWelic && !string.IsNullOrEmpty(((DateTimePickerWelic)ctrl).NomeCampoDadosDataTable))
                        {
                            ((DateTimePickerWelic)ctrl).Text = dtDados.Rows[0][((DateTimePickerWelic)ctrl).NomeCampoDadosDataTable].ToString();
                        }

                        //TextBoxData
                        if (ctrl is MaskedTextBoxDataWelic && !string.IsNullOrEmpty(((MaskedTextBoxDataWelic)ctrl).NomeCampoDadosDataTable))
                        {
                            ((MaskedTextBoxDataWelic)ctrl).Text = dtDados.Rows[0][((MaskedTextBoxDataWelic)ctrl).NomeCampoDadosDataTable.ToString()].ToString();
                        }

                        //CheckBox
                        if (ctrl is CheckBoxWelic && !string.IsNullOrEmpty(((CheckBoxWelic)ctrl).NomeCampoDadosDataTable))
                        {
                            ((CheckBoxWelic)ctrl).Checked = (dtDados.Rows[0][((CheckBoxWelic)ctrl).NomeCampoDadosDataTable.ToString()].ToString().Trim().Equals("1") ? true : false);
                        }

                        //TextBoxTelefone
                        if (ctrl is MaskedTextBoxFoneWelic && !string.IsNullOrEmpty(((MaskedTextBoxFoneWelic)ctrl).NomeCampoDadosDataTable))
                        {
                            ((MaskedTextBoxFoneWelic)ctrl).Text = dtDados.Rows[0][((MaskedTextBoxFoneWelic)ctrl).NomeCampoDadosDataTable.ToString()].ToString();
                        }

                        //ComboBox
                        if (ctrl is ComboBoxWelic && !string.IsNullOrEmpty(((ComboBoxWelic)ctrl).NomeCampoDadosDataTable))
                        {
                            ((ComboBoxWelic)ctrl).SelectedItem = dtDados.Rows[0][((ComboBoxWelic)ctrl).NomeCampoDadosDataTable.ToString()].ToString();
                        }

                        //RadioButton
                        if (ctrl is RadioButtonWelic)
                        {
                            ((RadioButtonWelic)ctrl).Checked = (dtDados.Rows[0][((RadioButtonWelic)ctrl).NomeCampoDadosDataTable.ToString()].ToString().Equals(((RadioButtonWelic)ctrl).ValorNomeCampoDadosDataTable.ToString()) ? true : false);
                        }
                    }
                    catch (Exception)
                    {
                    }

                    //Se for um Container, executa a função novamente, passando os controles que existem dentro do container
                    if (ctrl.HasChildren)
                    {
                        PreencherCampos(ctrl.Controls, dtDados);
                    }
                }
            }
        }        

        public List<System.Reflection.PropertyInfo> GetPropriedades()
        {
            Type myType = this.GetType();
            IList<System.Reflection.PropertyInfo> props = new List<System.Reflection.PropertyInfo>(myType.GetProperties());

            List<System.Reflection.PropertyInfo> propriedades = new List<System.Reflection.PropertyInfo>();

            foreach (System.Reflection.PropertyInfo prop in props)
            {
                //object propValue = prop.GetValue(base.frmBaseCadastroPadrao, null);
                if (prop.DeclaringType == myType)
                {
                    propriedades.Add(prop);

                }
            }

            return propriedades;
        }
        public System.Reflection.PropertyInfo GetPropriedades(string nomeDaPropriedade)
        {
            List<System.Reflection.PropertyInfo> props = GetPropriedades();

            System.Reflection.PropertyInfo p = null;

            foreach (System.Reflection.PropertyInfo item in props)
            {
                if (item.Name.ToLower().Equals(nomeDaPropriedade.ToLower()))
                {
                    p = item;
                    break;
                }
            }

            return p;
        }
        public void SetValorPropriedade(FormWelic frm, string nomeDaPropriedade, object valor)
        {
            System.Reflection.PropertyInfo prop = GetPropriedades(nomeDaPropriedade);

            prop.SetValue(frm, valor, null);
        }
        public object GetValorPropriedade(FormWelic frm, string nomeDaPropriedade)
        {
            System.Reflection.PropertyInfo prop = GetPropriedades(nomeDaPropriedade);

            object valor = prop.GetValue(frm, null);

            return valor;
        }

        private void FormWelic_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Linha abaixo é para não deixar o formulário maximizado caso o usuário feche pelo X
            //Principal problema detectado foi nos relatórios que tem o estado maximizado quando 
            //em modo de visualização de impressao
            this.WindowState = FormWindowState.Normal;
        }

        public enum _TipoPermissaoCodigoSeguranca { Read, Insert, Delete, Update, ApenasVisualizar };
        public bool UsrTemPermissao(_TipoPermissaoCodigoSeguranca tipo)
        {
            return UsrTemPermissao(tipo, this.IdProgram);
        }
        public bool UsrTemPermissao(_TipoPermissaoCodigoSeguranca tipo, string program)
        {
            if (program.Trim().Equals(""))
            {
                return true;
            }
            else
            {


                HttpResponseMessage response =
                    ClienteApi.Instance.RequisicaoGet($"permission/getbyUser/{Globals.Usuario}/{program}");
                var returnResposta =
                    ClienteApi.Instance.ObterResposta<PermissionDto>(response);                              

                bool retorno = false;
                if (tipo == _TipoPermissaoCodigoSeguranca.Read)
                    retorno = returnResposta.Read;
                else if (tipo == _TipoPermissaoCodigoSeguranca.Insert)
                    retorno = returnResposta.Insert;
                else if (tipo == _TipoPermissaoCodigoSeguranca.Delete)
                    retorno = returnResposta.Delete;
                else if (tipo == _TipoPermissaoCodigoSeguranca.Update)
                    retorno = returnResposta.Update;
                else if (tipo == _TipoPermissaoCodigoSeguranca.ApenasVisualizar)
                    retorno = (returnResposta.Read &&
                               returnResposta.Insert == false &&
                               returnResposta.Delete == false &&
                               returnResposta.Update == false);

                return retorno;
            }
        }


        //Utilizar Filtros Anteriores
        private string informacoesArquivoTxt { get; set; }
        public bool comandoExecutado = false;
        public bool atribuirFiltros = false;
        public void atribuirFiltrosAnteriores()//Relatorio
        {
            atribuirFiltros = true;
            InserirLinhasArquivoCampos();
        }
        
        public void CriarAlterarArquivoRelatorioFiltrosAnteriores(int pTipo) //Relatorio
        {
            //CRIANDO PASTA SE NAO EXISTIR
            string folder = @"C:\Temp\";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            //{} = INICIO E FIM DO RELATORIO
            //() = VALORES DE CADA CAMPO


            FileInfo arquivo = new FileInfo(@"C:\Temp\RelatorioUltimosFiltrosVer2.txt");
            string informacaoAntiga = "";

            //VERIFICANDO SE O ARQUIVO EXISTE
            if (arquivo.Exists)
            {
                informacoesArquivoTxt += "\n{@#Inicio Relatorio: " + this.ProductName + "." + this.Name;
                informacoesArquivoTxt += System.Environment.NewLine;

                System.IO.StreamReader lerArquivo = new System.IO.StreamReader(@"C:\Temp\RelatorioUltimosFiltrosVer2.txt");
                string linhaTxt = "";

                PercorrerObjetos(this.Controls, pTipo);
                informacoesArquivoTxt += "Fim Relatorio: " + this.ProductName + "." + this.Name + "#@}" + System.Environment.NewLine;
                while ((linhaTxt = lerArquivo.ReadLine()) != null)
                {
                    if (linhaTxt.Contains("{@#Inicio Relatorio: " + this.ProductName + "." + this.Name))
                    {
                        while (!(linhaTxt = lerArquivo.ReadLine()).Contains("Fim Relatorio: " + this.ProductName + "." + this.Name + "#@}")) { }
                    }
                    else
                    {
                        if (linhaTxt.Length > 0)
                        {
                            if (linhaTxt.Contains("{@#Inicio Relatorio: "))
                            {
                                informacaoAntiga += linhaTxt;
                            }
                            else if (linhaTxt.Contains("Fim Relatorio: ") && linhaTxt.Substring(linhaTxt.Length - 3).Equals("#@}"))
                            {
                                informacaoAntiga += System.Environment.NewLine + linhaTxt + System.Environment.NewLine + System.Environment.NewLine;
                            }
                            else
                            {
                                informacaoAntiga += System.Environment.NewLine + linhaTxt;
                            }
                        }
                    }
                }
                if (!string.IsNullOrEmpty(informacaoAntiga))
                    informacaoAntiga += informacoesArquivoTxt;
                else
                    informacaoAntiga = informacoesArquivoTxt;

                lerArquivo.Dispose();

                System.IO.File.WriteAllText(@"C:\Temp\RelatorioUltimosFiltrosVer2.txt", informacaoAntiga);
                informacoesArquivoTxt = "";
            }
            else
            {
                arquivo.Create().Close();
                CriarAlterarArquivoRelatorioFiltrosAnteriores(pTipo);
            }

        }
        
        public void CriarAlterarArquivoRelatorioFiltrosAnteriores(int pTipo, Control.ControlCollection controls) //Outros
        {
            //CRIANDO PASTA SE NAO EXISTIR
            string folder = @"C:\Temp\";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            //{} = INICIO E FIM DO RELATORIO
            //() = VALORES DE CADA CAMPO


            FileInfo arquivo = new FileInfo(@"C:\Temp\RelatorioUltimosFiltrosVer2.txt");
            string informacaoAntiga = "";

            //VERIFICANDO SE O ARQUIVO EXISTE
            if (arquivo.Exists)
            {
                informacoesArquivoTxt += "\n{@#Inicio Relatorio: " + this.ProductName + "." + this.Name;
                informacoesArquivoTxt += System.Environment.NewLine;

                System.IO.StreamReader lerArquivo = new System.IO.StreamReader(@"C:\Temp\RelatorioUltimosFiltrosVer2.txt");
                string linhaTxt = "";

                PercorrerObjetos(controls, pTipo);
                informacoesArquivoTxt += "Fim Relatorio: " + this.ProductName + "." + this.Name + "#@}" + System.Environment.NewLine;
                while ((linhaTxt = lerArquivo.ReadLine()) != null)
                {
                    if (linhaTxt.Contains("{@#Inicio Relatorio: " + this.ProductName + "." + this.Name))
                    {
                        while (!(linhaTxt = lerArquivo.ReadLine()).Contains("Fim Relatorio: " + this.ProductName + "." + this.Name + "#@}")) { }
                    }
                    else
                    {
                        if (linhaTxt.Length > 0)
                        {
                            if (linhaTxt.Contains("{@#Inicio Relatorio: "))
                            {
                                informacaoAntiga += linhaTxt;
                            }
                            else if (linhaTxt.Contains("Fim Relatorio: ") && linhaTxt.Substring(linhaTxt.Length - 3).Equals("#@}"))
                            {
                                informacaoAntiga += System.Environment.NewLine + linhaTxt + System.Environment.NewLine + System.Environment.NewLine;
                            }
                            else
                            {
                                informacaoAntiga += System.Environment.NewLine + linhaTxt;
                            }
                        }
                    }
                }
                if (!string.IsNullOrEmpty(informacaoAntiga))
                    informacaoAntiga += informacoesArquivoTxt;
                else
                    informacaoAntiga = informacoesArquivoTxt;

                lerArquivo.Dispose();

                System.IO.File.WriteAllText(@"C:\Temp\RelatorioUltimosFiltrosVer2.txt", informacaoAntiga);
                informacoesArquivoTxt = "";
            }
            else
            {
                arquivo.Create().Close();
                CriarAlterarArquivoRelatorioFiltrosAnteriores(pTipo);
            }

        }
        private void InserirLinhasArquivoCampos()//Relatorio
        {
            //CRIANDO PASTA SE NAO EXISTIR
            string folder = @"C:\Temp\";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }


            FileInfo arquivoAntigo = new FileInfo(@"C:\Temp\RelatorioUltimosFiltros.txt");
            if (arquivoAntigo.Exists)
            {
                arquivoAntigo.Delete();
            }

            FileInfo arquivo = new FileInfo(@"C:\Temp\RelatorioUltimosFiltrosVer2.txt");
            if (arquivo.Exists)
            {
                System.IO.StreamReader lerArquivo = new System.IO.StreamReader(@"C:\Temp\RelatorioUltimosFiltrosVer2.txt");
                string linhaTxt = "";

                while ((linhaTxt = lerArquivo.ReadLine()) != null)
                {
                    if (linhaTxt.Equals("{@#Inicio Relatorio: " + this.ProductName + "." + this.Name))
                    {
                        while (!(linhaTxt = lerArquivo.ReadLine()).Equals("Fim Relatorio: " + this.ProductName + "." + this.Name + "#@}"))
                        {
                            PercorrerObjetosLinha(this.Controls, linhaTxt);
                        }
                    }
                }
                lerArquivo.Dispose();
            }
        }        

        private void PercorrerObjetos(Control.ControlCollection pControles, int pTipo)//PERCORRE OS COMPONENTES DA TELA E DEPOIS PEGA OS VALORES E ALTERA O TXT
        {
            foreach (Control ctrl in pControles)
            {
                InserirInformacoesVariavel(ctrl, pTipo);
                PercorrerObjetos(ctrl.Controls, pTipo);
            }
        }
        private void InserirInformacoesVariavel(Control pControle, int pTipo)//pTipo = 1 - Relatorio; 2 - Extrator;  INSERI O VALOR NA VARIAVEL USADA NO TXT
        {
            string teste = pControle.Name;
            if (pControle is TextBoxWelic && pTipo != 2)// && !camposArquivoTxt.Contains(pControle.Name + " (" + pControle.Text + ")"))
            {
                if (!string.IsNullOrEmpty(pControle.Text))
                {
                    informacoesArquivoTxt += pControle.Name + " (@#" + pControle.Text + "#@)";
                    informacoesArquivoTxt += System.Environment.NewLine;
                }
                return;
            }
            if (pControle is MaskedTextBoxWelic)// && !camposArquivoTxt.Contains(pControle.Name + " (" + pControle.Text + ")"))
            {
                if (!string.IsNullOrEmpty(pControle.Text.Replace("/", "").Trim()))
                {
                    informacoesArquivoTxt += pControle.Name + " (@#" + pControle.Text + "#@)";
                    informacoesArquivoTxt += System.Environment.NewLine;
                }
                return;
            }
            if (pControle is MaskedTextBoxDataWelic)// && !camposArquivoTxt.Contains(pControle.Name + " (" + pControle.Text + ")"))
            {
                if (!string.IsNullOrEmpty(pControle.Text.Replace("/", "").Trim()))
                {
                    informacoesArquivoTxt += pControle.Name + " (@#" + pControle.Text + "#@)";
                    informacoesArquivoTxt += System.Environment.NewLine;
                }
                return;
            }
            if (pControle is RadioButtonWelic)// && !camposArquivoTxt.Contains(pControle.Name + " (" + ((RadioButtonWelic)(pControle)).Checked + ")"))
            {
                if (((RadioButtonWelic)(pControle)).Checked)
                {
                    informacoesArquivoTxt += pControle.Name + " (@#" + ((RadioButtonWelic)(pControle)).Checked + "#@)";
                    informacoesArquivoTxt += System.Environment.NewLine;
                }
                return;
            }
            if (pControle is DataGridViewWelic)
            {
                DataTable dt = new DataTable();
                if (((DataGridViewWelic)(pControle)).DataSource != null)
                {
                    if (((DataGridViewWelic)(pControle)).DataSource.GetType() == typeof(BindingSource))
                    {
                        BindingSource bs = new BindingSource();
                        dt = (DataTable)((BindingSource)((DataGridViewWelic)(pControle)).DataSource).DataSource;
                    }
                    else
                    {
                        dt = (DataTable)((DataGridViewWelic)(pControle)).DataSource;
                    }

                    if (dt.Rows.Count > 0)
                    {
                        string aux;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            aux = "";
                            //NOME GRID {INDICDE DA COLUNA} ([COLUNA1][COLUNA2][COLUNAN])
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                aux += "{@#" + dt.Columns[j].ToString() + "#@}[@#" + dt.Rows[i][j].ToString() + "#@]";
                            }
                            informacoesArquivoTxt += pControle.Name + " (@#" + aux + "#@)" + System.Environment.NewLine;
                        }
                    }
                }
                return;
            }
            if (pControle is CheckBoxWelic)// && !camposArquivoTxt.Contains(pControle.Name + " (" + ((CheckBoxWelic)(pControle)).Checked + ")"))
            {
                informacoesArquivoTxt += pControle.Name + " (@#" + ((CheckBoxWelic)(pControle)).Checked + "#@)";
                informacoesArquivoTxt += System.Environment.NewLine;

                //if (((CheckBoxWelic)(pControle)).Checked)
                //{
                //    informacoesArquivoTxt += pControle.Name + " (@#" + ((CheckBoxWelic)(pControle)).Checked + "#@)";
                //    informacoesArquivoTxt += System.Environment.NewLine;
                //}
                return;
            }
            if (pControle is ComboBoxWelic)// && !camposArquivoTxt.Contains(pControle.Name + " (" + ((ComboBoxWelic)(pControle)).SelectedIndex + ")"))
            {
                if (((ComboBoxWelic)(pControle)).SelectedIndex != -1)
                {
                    informacoesArquivoTxt += pControle.Name + " (@#" + ((ComboBoxWelic)(pControle)).SelectedIndex + "#@)";
                    informacoesArquivoTxt += System.Environment.NewLine;
                }
                return;
            }
            if (pControle is DateTimePickerWelic)// && !camposArquivoTxt.Contains(pControle.Name + " (" + pControle.Text + ")"))
            {
                if (!string.IsNullOrEmpty(pControle.Text) && (!((DateTimePickerWelic)(pControle)).CustomFormat.Equals("__/__/____")))
                {
                    informacoesArquivoTxt += pControle.Name + " (@#" + pControle.Text + "#@)";
                    informacoesArquivoTxt += System.Environment.NewLine;
                }
                return;
            }
            if (pControle is NumericUpDownWelic)
            {
                if (!string.IsNullOrEmpty(((NumericUpDownWelic)pControle).Value.ToString()))
                {
                    informacoesArquivoTxt += pControle.Name + " (@#" + ((NumericUpDownWelic)pControle).Value.ToString() + "#@)";
                    informacoesArquivoTxt += System.Environment.NewLine;
                }
            }
            //if (pControle is ListBoxWelic)
            //{
            //    if (((ListBoxWelic)(pControle)).LimpaCampo)
            //    {
            //        //((ListBoxWelic)(pControle)).DataSource = null;
            //        //((ListBoxWelic)(pControle)).Items.Clear();
            //        campostxt += pControle.Name + " (" + pControle.Text + ")";
            //        campostxt += System.Environment.NewLine;
            //    }
            //    return;
            //}
        }
        private void PercorrerObjetosLinha(Control.ControlCollection pControle, string pLinhaTxt)//PERCORRE OS COMPONENTES DA TELA E DEPOIS INSERI OS VALORES
        {
            foreach (Control ctrl in pControle)
            {
                PercorrerObjetosInserindoValores(ctrl, pLinhaTxt);
                PercorrerObjetosLinha(ctrl.Controls, pLinhaTxt);
            }
        }
        private void PercorrerObjetosInserindoValores(Control pControle, string pLinhaTxt)//PERCORRE O TXT E INSERI OS VALORES NOS CAMPOS DA TELA
        {
            if (!(pLinhaTxt.Equals("{@#Inicio Relatorio: " + this.Name) && pLinhaTxt.Equals("Fim Relatorio: " + this.Name + "#@}")) && !string.IsNullOrEmpty(pLinhaTxt))
            {
                string teste = pControle.Name;
                string nomeObject = pLinhaTxt.Substring(0, pLinhaTxt.IndexOf(" "));
                string valorObject = pLinhaTxt.Substring(pLinhaTxt.IndexOf("(@#") + 3, pLinhaTxt.IndexOf("#@)") - pLinhaTxt.IndexOf("(@#") - 3);

                if (pControle is TextBoxWelic)
                {
                    if (((TextBoxWelic)(pControle)).Name.Equals(nomeObject))
                    {
                        ((TextBoxWelic)(pControle)).Text = valorObject;
                    }
                    return;
                }
                if (pControle is MaskedTextBoxWelic)
                {
                    if (((MaskedTextBoxWelic)(pControle)).Name.Equals(nomeObject))
                    {
                        ((MaskedTextBoxWelic)(pControle)).Text = valorObject;
                    }
                    return;
                }
                if (pControle is MaskedTextBoxDataWelic)
                {
                    if (((MaskedTextBoxDataWelic)(pControle)).Name.Equals(nomeObject))
                    {
                        ((MaskedTextBoxDataWelic)(pControle)).Text = valorObject;
                    }
                    return;
                }
                if (pControle is RadioButtonWelic)
                {
                    if (((RadioButtonWelic)(pControle)).Name.Equals(nomeObject))
                    {
                        ((RadioButtonWelic)(pControle)).Checked = bool.Parse(valorObject);
                    }
                    return;
                }
                if (pControle is DataGridViewWelic)
                {
                    if (((DataGridViewWelic)(pControle)).Name.Equals(nomeObject))
                    {
                        DataTable dtGrid = (DataTable)((DataGridViewWelic)(pControle)).DataSource;
                        DataRow dtRow = null;

                        if (dtGrid != null)
                        {
                            dtRow = dtGrid.NewRow();
                            //Quantidade de Colunas
                            for (int i = 0; i < 99; i++)
                            {
                                string nomeColuna = dtGrid.Columns[i].ToString();
                                dtRow[nomeColuna] = pLinhaTxt.Substring(pLinhaTxt.IndexOf("[@#") + 3, pLinhaTxt.IndexOf("#@]") - pLinhaTxt.IndexOf("[@#") - 3);
                                pLinhaTxt = pLinhaTxt.Substring(pLinhaTxt.IndexOf("#@]") + 3);

                                if (pLinhaTxt.Equals("#@)"))
                                    break;
                            }
                        }
                        else
                        {
                            dtGrid = new DataTable();

                            string[] nomeColuna = new string[999];
                            string[] valorColuna = new string[999];
                            //Quantidade de Colunas
                            for (int i = 0; i < 99; i++)
                            {
                                nomeColuna[i] = pLinhaTxt.Substring(pLinhaTxt.IndexOf("{@#") + 3, pLinhaTxt.IndexOf("#@}") - pLinhaTxt.IndexOf("{@#") - 3);
                                dtGrid.Columns.Add(nomeColuna[i].ToString());
                                valorColuna[i] = pLinhaTxt.Substring(pLinhaTxt.IndexOf("[@#") + 3, pLinhaTxt.IndexOf("#@]") - pLinhaTxt.IndexOf("[@#") - 3);

                                pLinhaTxt = pLinhaTxt.Substring(pLinhaTxt.IndexOf("#@]") + 3);

                                if (pLinhaTxt.Equals("#@)"))
                                    break;
                            }

                            dtRow = dtGrid.NewRow();
                            for (int j = 0; valorColuna[j] != null; j++)
                            {
                                dtRow[nomeColuna[j]] = valorColuna[j];
                            }
                        }

                        dtGrid.Rows.Add(dtRow);
                        ((DataGridView)(pControle)).DataSource = dtGrid;

                    }
                    return;
                }
                if (pControle is CheckBoxWelic)
                {
                    if (((CheckBoxWelic)(pControle)).Name.Equals(nomeObject))
                    {
                        ((CheckBoxWelic)(pControle)).Checked = bool.Parse(valorObject);
                    }
                    return;
                }
                if (pControle is ComboBoxWelic)
                {
                    if (((ComboBoxWelic)(pControle)).Name.Equals(nomeObject))
                    {
                        if (((ComboBoxWelic)(pControle)).Items.Count > 0)
                        {
                            ((ComboBoxWelic)(pControle)).SelectedIndex = int.Parse(valorObject);
                        }
                    }
                    return;
                }
                if (pControle is DateTimePickerWelic)
                {
                    if (((DateTimePickerWelic)(pControle)).Name.Equals(nomeObject))
                    {
                        //if (valorObject != null && !valorObject.ToString().Equals(""))
                        //{
                        //    ((DateTimePickerWelic)(pControle)).Format = DateTimePickerFormat.Short;
                        //    ((DateTimePickerWelic)(pControle)).CustomFormat = "";
                        //    ((DateTimePickerWelic)(pControle)).Value = DateTime.Parse(valorObject.ToString());
                        //}
                        //else
                        //{
                        //    ((DateTimePickerWelic)(pControle)).Format = DateTimePickerFormat.Custom;
                        //    ((DateTimePickerWelic)(pControle)).CustomFormat = "__/__/____";
                        //}
                    }
                    return;
                }
                if (pControle is NumericUpDownWelic)
                {
                    if (((NumericUpDownWelic)(pControle)).Name.Equals(nomeObject))
                    {
                        ((NumericUpDownWelic)(pControle)).Value = int.Parse(valorObject);
                    }
                }
                //if (pControle is ListBoxWelic)
                //{
                //    if (((ListBoxWelic)(pControle)).LimpaCampo)
                //    {
                //        //((ListBoxWelic)(pControle)).DataSource = null;
                //        //((ListBoxWelic)(pControle)).Items.Clear();
                //        campostxt += pControle.Name + " (" + pControle.Text + ")";
                //        campostxt += System.Environment.NewLine;
                //    }
                //    return;
                //}
            }
        }
    }
}