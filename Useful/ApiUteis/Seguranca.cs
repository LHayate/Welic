using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using UseFul.ClientApi.Dtos;

namespace UseFul.ClientApi
{
    public class Seguranca
    {
        private string _idUser;
        public string IdUser
        {
            get { return _idUser; }
            set { _idUser = value; }
        }

        private string _idPrograma;
        public string IdProgram
        {
            get { return _idPrograma; }
            set { _idPrograma = value; }
        }

        private bool _all;
        public bool All
        {
            get { return _all; }
            set { _all = value; }
        }

        private bool _read;
        public bool Read
        {
            get { return _read; }
            set { _read = value; }
        }

        private bool _insert;
        public bool Insert
        {
            get { return _insert; }
            set { _insert = value; }
        }

        private bool _Update;
        public bool Update
        {
            get { return _Update; }
            set { _Update = value; }
        }

        private bool _delete;
        public bool Delete
        {
            get { return _delete; }
            set { _delete = value; }
        }

        private bool _active;
        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }



        /// <summary>
        /// Lista de Permissões do Usuario
        /// </summary>
        /// <param name="usuario">Código do Usuário</param>
        /// <returns>Lista de Permissões</returns>
        public List<Seguranca> BuscaPermissoes(string usuario)
        {

            HttpResponseMessage response =
                ClienteApi.Instance.RequisicaoGet($"permission/GetByUser/{usuario}");
            var retorno =
                ClienteApi.Instance.ObterResposta<List<Seguranca>>(response);
           
            return retorno;
        }

        /// <summary>
        /// Permissão do Usuario no Programa
        /// </summary>
        /// <param name="usuario">Código do Usuário</param>
        /// <param name="programa">Código do Programa</param>
        /// <returns>Permissão no Programa</returns>
        public Seguranca BuscaPermissoes(string usuario, string programa)
        {
            Task<HttpResponseMessage> response =
                ClienteApi.Instance.RequisicaoGetAsync($"permission/getbyuserprogram/{usuario}/{programa}");
            Task<Seguranca> retorno =
                ClienteApi.Instance.ObterRespostaAsync<Seguranca>(response.Result);           

            return retorno.Result;
        }

       

        /// <summary>
        /// Metodo que busca os dados do usuário
        /// </summary>
        /// <param name="usuario">Matricula do usuário</param>
        /// <returns>Retorna um DataTable com os dados do usuário</returns>
        public static UserDto BuscaUsuarios(string usuario)
        {
            HttpResponseMessage response =
                ClienteApi.Instance.RequisicaoGet($"User/getbyEmail?Email={usuario}");
            UserDto retorno =
                ClienteApi.Instance.ObterResposta<UserDto>(response);

            return retorno;
        }

        public static bool BuscaAutenticacaoUsuario(string matricula, string senha)
        {            
            Globals.Usuario = matricula;
            Globals.Senha = senha;
            
            var retornoUser = Seguranca.BuscaUsuarios(Globals.Usuario);
            if (retornoUser != null)
            {
                Globals.NomeUsuario = retornoUser.FirstName;
                Globals.NickName = retornoUser.NickName;
                Globals.IdUser = retornoUser.Id;
            }
            Globals.listaSeguranca = new Seguranca().BuscaPermissoes(Globals.IdUser);
            return true;
        }        


        #region Segurança
        public void TrataPermissaoMenu(MenuStrip Menu, bool TornarInvisivel)
        {
            for (int i = 0; i <= int.Parse(Menu.Items.Count.ToString()) - 1; i++)
            {
                int _sub_Items_Habilitados = -1;
                try
                {
                    ToolStripMenuItem A = (ToolStripMenuItem)Menu.Items[i];
                    if (int.Parse(A.DropDownItems.Count.ToString()) > 0)
                    {
                        _sub_Items_Habilitados = 0;
                        _sub_Items_Habilitados = TrataPermissaoMenuItem((ToolStripMenuItem)Menu.Items[i], TornarInvisivel);
                    }

                    string _tag = "";

                    if (Menu.Items[i].Tag != null)
                    {
                        _tag = Menu.Items[i].Tag.ToString();
                    }

                    if (ValidaOpcaoMenu(_tag) == true)
                    {
                        if (_sub_Items_Habilitados == 0)
                        {
                            if (TornarInvisivel)
                            {
                                Menu.Items[i].Enabled = false;
                                Menu.Items[i].Visible = false;
                            }
                        }
                    }
                    else
                    {
                        if (TornarInvisivel) { Menu.Items[i].Visible = false; }
                        //    Menu.Items[i].Enabled = false;
                        if (TornarInvisivel) { Menu.Items[i].Enabled = false; }
                        Menu.Items[i].Enabled = false;
                    }
                }
                catch { }
            }
        }

        public Int32 TrataPermissaoMenuItem(ToolStripMenuItem MenuItem, bool TornarInvisivel)
        {
            int _Items_Habilitados = 0;
            for (int i = 0; i <= int.Parse(MenuItem.DropDownItems.Count.ToString()) - 1; i++)
            {
                string TESTE = MenuItem.DropDownItems[i].Text;
                if (((MenuItem.DropDownItems[i] is ToolStripSeparator) == false) ) //&(MenuItem.DropDownItems[i].Visible == true)
                {
                    //Verifica Nivel Inferior
                    int _sub_Items_Habilitados = -1;
                    try
                    {
                        ToolStripMenuItem A = (ToolStripMenuItem)MenuItem.DropDownItems[i];
                        if (int.Parse(A.DropDownItems.Count.ToString()) > 0)
                        {
                            _sub_Items_Habilitados = 0;
                            _sub_Items_Habilitados += TrataPermissaoMenuItem((ToolStripMenuItem)MenuItem.DropDownItems[i], TornarInvisivel);
                        }
                    }
                    catch { }

                    try
                    {
                        string _tag = "";

                        if (MenuItem.DropDownItems[i].Tag != null)
                        {
                            _tag = ((string)(MenuItem.DropDownItems[i].Tag)).ToString();
                        }

                        if (ValidaOpcaoMenu(_tag) == true)
                        {
                            if (_sub_Items_Habilitados != 0)
                            {
                                /*Mantem Habilitados os itens habilitados visualmente*/
                                _Items_Habilitados++;
                            }
                            else
                            {
                                if (TornarInvisivel)
                                {
                                    MenuItem.DropDownItems[i].Enabled = false;
                                    MenuItem.DropDownItems[i].Visible = false;
                                }
                            }
                        }
                        else
                        {
                            if (TornarInvisivel) { MenuItem.DropDownItems[i].Visible = false; }
                            //MenuItem.DropDownItems[i].Enabled = false;
                            if (TornarInvisivel) { MenuItem.DropDownItems[i].Enabled = false; }
                            MenuItem.DropDownItems[i].Enabled = false;
                        }
                    }
                    catch { }
                }
            }

            //REMOVER SEPARADORES EM EXCESSO SE A OPÇÃO FOR TORNAR INVISIVEL
            if (TornarInvisivel == true)
            {
                Int32 Ultimo_Separador = -2;
                Int32 Ultima_Opcao = -1;
                for (int i = 0; i <= int.Parse(MenuItem.DropDownItems.Count.ToString()) - 1; i++)
                {
                    if (((MenuItem.DropDownItems[i] is ToolStripSeparator) == false) && (MenuItem.DropDownItems[i].Enabled == true))
                        Ultima_Opcao = i;
                    if ((MenuItem.DropDownItems[i] is ToolStripSeparator) == true)
                    {
                        if ((Ultima_Opcao == -1) || (Ultimo_Separador >= Ultima_Opcao))
                        {
                            MenuItem.DropDownItems[i].Visible = false;
                            MenuItem.DropDownItems[i].Enabled = false;
                        }                           
                        else Ultimo_Separador = i;
                    }
                }

                if (Ultimo_Separador >= Ultima_Opcao)
                {
                    MenuItem.DropDownItems[Ultimo_Separador].Visible = false;
                    MenuItem.DropDownItems[Ultimo_Separador].Enabled = false;
                }
                   
            } //FIM REMOÇÃO DE SEPARADORES EM EXCESSO

            return _Items_Habilitados;
        }

        private bool ValidaOpcaoMenu(string Tag)
        {
            try
            {
                if (string.IsNullOrEmpty(Tag))
                    return true;

                Seguranca s = new Seguranca(); //CLASSES.ENTITY
                string codPrograma = Tag; //SETA O CÓDIGO DO PROGRAMA

                s = Globals.listaSeguranca.FirstOrDefault(a => a.IdProgram == codPrograma);



                if (s == null)  //Retorna se o TAG não foi encontrado em programas
                    return false;

                return s.All; //Retorna se o usuário possui alguma permissao 



            }
            catch { return false; }
        }
        #endregion

    }
}

