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
