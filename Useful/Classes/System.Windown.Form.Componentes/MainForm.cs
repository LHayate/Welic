using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;
using UseFul.ClientApi;
using UseFul.ClientApi.Dtos;
using UseFul.Uteis;
using UseFul.Uteis.UI;

namespace UseFul.Forms.Welic
{
    public partial class MainForm : FormWelic
    {
        public MainForm()
        {
            InitializeComponent();
            StopWaitCursor();
        }

        public UserDto UsuarioLogin { get; set; }
        public EmpresaDto EmpresaLogin { get; set; }

        public void UpdateLoggedUser()
        {
            UsuarioLogin = UserDto.Instance.ConsultaUsuarioPorIdUsuario(UsuarioLogin.Id);
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            PersonalizarFormulario();
            //ConfigurarMenu();
            ChecarVersaoSistema();
        }

        private void ChecarVersaoSistema()
        {
#if (!DEBUG)

            Timer timerUpdater = new Timer
            {
                Interval = 2 * 60 * 1000,
                SynchronizingObject = this
            };

            timerUpdater.Elapsed += delegate
            {
                string autoUpdateUrl = ConfigurationManager.AppSettings.Get("AutoUpdateUrl");
                AutoUpdater.Start(autoUpdateUrl);
            };
            timerUpdater.Start();

            if (SGCApplication.MainForm.UsuarioLogin.VersaoSistema != SGCApplication.VersaoSistema)
            {
                new SobreForm().ShowDialog();
            }

            Task<HttpResponseMessage> requisicaoRegistrarAtividade = ClienteApi.Instance.RequisicaoPostAsync(
                "usuarios/registrar-atividade",
                new ComandoRegistroAtividadeUsuario
                {
                    VersaoSistema = SGCApplication.VersaoSistema,
                    NomeDispositivo = Environment.MachineName
                });
#endif
        }

        private void ConfigurarMenu()
        {
            ObterMenuPrincipal();           
        }

        private void PersonalizarFormulario()
        {
            Text = $@"ERP - {EmpresaLogin.RazaoSocial}";
            lblUser.Text = UsuarioLogin.NickName;
            ConfigureStatusBar();
        }
        

        public void DefinirApi(HttpClient client)
        {
            ClienteApi.Instance.DefinirClienteApi(client);
        }

        private void ObterMenuPrincipal()
        {
            try
            {
                HttpResponseMessage response = ClienteApi.Instance.RequisicaoPost("Menu/GetMenuByUser",
                    UsuarioLogin);
                List<MenuDto> retorno =
                    ClienteApi.Instance.ObterResposta<List<MenuDto>>(response);

                //MenuBindingSource.DataSource = retorno;

                //radTreeViewMenu.ExpandAll();
            }
            catch (CustomException exception)
            {
                ProcessMessage(exception.Message, MessageType.Error);
            }
            catch (Exception exception)
            {
                ProcessException(exception);
            }
        }

        private void ConfigureStatusBar()
        {
            try
            {
                //radLabelElementServidor.Text = ConnectionStringUtil.Instance.ServerName;
                //radLabelElementBancoDeDados.Text = ConnectionStringUtil.Instance.DataBaseName;
                //radLabelElementUsuario.Text = string.IsNullOrWhiteSpace(UsuarioLogin.Id)
                //    ? "Não definido"
                //    : UsuarioLogin.Usuario;
                //radLabelElementLogadoEm.Text = DateTime.Now.ToString("dd/MM/yy HH:mm:ss");
                //radLabelElementVersao.Text = SGCApplication.VersaoSistema;
            }
            catch (Exception exception)
            {
                ProcessMessage(exception.Message, MessageType.Error);
                AppLogging.LogException("Erro ao efetuar o login.", exception, LogType.Error);
            }
        }

        private void linkLblChangeUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ProcessDialog("Deseja trocar de Usuário ?", MessageBoxButtons.YesNo) == Result.Yes)
            {
                Application.Restart();
            }
        }

        private void AbrirLogSistema()
        {
            try
            {
                AppLogging.OpenLogFolder();
            }
            catch (Exception exception)
            {
                AppLogging.LogException(exception.Message, exception, LogType.Error);
                ProcessMessage("Erro ao abrir a pasta de logs do sistema.", MessageType.Error);
            }
        }

        private void linkLblClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ProcessDialog("Deseja finalizar o Sistema ?", MessageBoxButtons.YesNo) == Result.Yes)
            {
                Application.Exit();
            }
        }        

        private void MainFormFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }        

        private void linkLabelAtualizarMenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ObterMenuPrincipal();
        }
    }
}
