using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using UseFul.ClientApi;
using UseFul.ClientApi.Dtos;
using UseFul.Forms.Welic;
using UseFul.Uteis;
using UseFul.Uteis.UI;

namespace Welic.WinForm
{
    public partial class FrmLogin : FormWelic
    {
        private readonly ConfiguracaoApi _configuracaoApi;
        public FrmLogin()
        {
            InitializeComponent();
            _configuracaoApi = new ConfiguracaoApi();
            _configuracaoApi.Configurar();
            Program.MainForm.DefinirApi(_configuracaoApi.ObterClientApiPadraoNaoAutenticado());
        }

        private void CarregarDadosDoUltimoAcesso()
        {
            try
            {
                const string path = @"SOFTWARE\Solution\Welic\";
                RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(path);
                if (registryKey != null)
                {
                    //if (registryKey.GetValue("Empresa_Padrao") != null)
                    //{
                    //    DropDownListEmpresa.SelectedValue = registryKey.GetValue("Empresa_Padrao");
                    //}

                    if (registryKey.GetValue("Usuario_Padrao") != null)
                    {
                        txtUsuario.Text = registryKey.GetValue("Usuario_Padrao").ToString();
                        txtSenha.Select();
                    }

                    registryKey.Close();
                }
            }
            catch (Exception exception)
            {
                AppLogging.LogException("Erro carregar o registro", exception, LogType.Error);
            }
        }

        private void Login()
        {
            try
            {
                StartWaitCursor();
                AutenticacaoApi();
                Seguranca.BuscaAutenticacaoUsuario(txtUsuario.Text, txtSenha.Text);
                CarregarSistema();
            }
            catch (CustomException exception)
            {
                ProcessMessage(exception.Message, MessageType.Error);                
            }
            catch (Exception exception)
            {
                ProcessMessage(exception.Message, MessageType.Error);
                AppLogging.LogException("Erro ao Efetuar o Login.", exception, LogType.Error);                
            }
            StopWaitCursor();
        }

        private void AutenticacaoApi()
        {
            _configuracaoApi.Autenticar(txtUsuario.Text.Trim(), txtSenha.Text);


            if (CboEmpresa.SelectedItem is EmpresaDto empresaSelecionada)
            {

                HttpResponseMessage response = ClienteApi.Instance.RequisicaoGet($"Empresas/ValidaEmpresa/{txtUsuario.Text}/{empresaSelecionada.IdEmpresa}");

                bool retorno = ClienteApi.Instance.ObterResposta<bool>(response);

                if (retorno)
                {
                    ConfigurarOAcesso(_configuracaoApi.Usuario);
                }
                else
                {
                    throw CustomErro.Erro("Usuário não tem permissão de acesso a empresa selecionada.");
                }
            }

        }

        private void GravarNoRegistroOsDadosDoUltimoAcesso()
        {
            try
            {
                const string path = @"SOFTWARE\Solutions\Welic\";
                RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(path);

                if (registryKey != null)
                {
                    registryKey.SetValue("Usuario_Padrao", txtUsuario.Text);
                    registryKey.SetValue("Empresa_Padrao", CboEmpresa.SelectedValue);
                    registryKey.Close();
                }
            }
            catch (Exception exception)
            {
                AppLogging.LogException("Erro Registro", exception, LogType.Error);
            }
        }

        private void CarregarSistema()
        {
            Program.MainForm.EmpresaLogin =
                CboEmpresa.SelectedItem as EmpresaDto;           

            DialogResult = DialogResult.OK;
            Program.MainForm.Show();
        }

        private void ConfigurarOAcesso(string usuario)
        {
            Program.MainForm.UsuarioLogin =
                UserDto.Instance.ConsultaUsuarioPorEmail(usuario);

            GravarNoRegistroOsDadosDoUltimoAcesso();
        }

        private void CarregarEmpresa()
        {
            StartWaitCursor();
            try
            {

                HttpResponseMessage response = ClienteApi.Instance.RequisicaoGet("empresas/get");

                BindingComboEmpresa.DataSource = ClienteApi.Instance.ObterResposta<List<EmpresaDto>>(response);
            }
            catch (CustomException Exception)
            {
                ProcessMessage(Exception.Message, MessageType.Error);
            }
            catch (Exception exception)
            {
                ProcessMessage(exception.Message, MessageType.Error);
                
            }
            StopWaitCursor();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btEntrar_Click(object sender, EventArgs e)
        {

            Login();
            //if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtSenha.Text))
            //    MessageBox.Show("Usuário ou senha não preenchido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //else
            //{
            //    try
            //    {
            //        string banco = string.Empty;
            //        if (File.Exists(@"K:/cert_sis.omt"))
            //        {
            //            FormLoginDesenvolvedor fLoginDes = new FormLoginDesenvolvedor();
            //            fLoginDes.ShowDialog();
            //            banco = fLoginDes.Banco;
            //        }
            //        else
            //            banco = "ACAD";
            
            //        else
            //        {                           
            //            this.Dispose();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Falha ao tentar conectar ao banco.\nMotivo:" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void btFechar_MouseEnter(object sender, EventArgs e)
        {
            btFechar.Visible = true;
            btFechar.Focus();
        }

        private void btFecharRed_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btFecharRed_MouseLeave(object sender, EventArgs e)
        {
            btFechar.Visible = false;
        }

        private void btEntra_Click(object sender, EventArgs e)
        {
            btEntrar_Click(btEntrar, e);
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            try
            {
                //lblVersion.Text = $@"Versão - {Application.VersaoSistema}";

                //DefinirConexao();
                CarregarEmpresa();
                CarregarDadosDoUltimoAcesso();
#if (DEBUG)
                txtUsuario.Text = ConfigurationManager.AppSettings["Usuario-Padrao"];
                txtSenha.Text = ConfigurationManager.AppSettings["Senha-Padrao"];
                btEntrar.PerformLayout();
#endif


            }
            catch (CustomException Exception)
            {
                ProcessMessage(Exception.Message, MessageType.Error);
            }
            catch (Exception exception)
            {
                ProcessMessage(exception.Message, MessageType.Error);
                AppLogging.LogException("Erro ao Efetuar o Login.", exception, LogType.Error);
            }

            //Autenticacao a = new Autenticacao();
            //if (a.AutenticaTemporiaUsuario())
            //    this.Close();
        }

    }
}
