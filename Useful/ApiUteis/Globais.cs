using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace UseFul.ClientApi
{
    public static class Globals
    {
        private static string _login = string.Empty;
        private static string _usuario, _nickName;
        private static string _nomeUsuario; 
        private static string _conexao;
        private static DateTime _sysdate;
        private static string _programa;        
        public static int Sistema { get; set; }
        public static string TituloSistema { get; set; }
        public static string ServerName { get; set; }
        /// <summary>
        /// Flag para utilizar ou não os direcionais para alterar páginas no relatório completo
        /// </summary>
        public static bool _UtilizarDirecionaisRel { get; set; }
        /// <summary>
        /// Flag para utilizar ou não as teclas de atalhos no relatório
        /// </summary>
        public static bool _UtilizarAtalhosRel { get; set; }
               
        public static List<Seguranca> listaSeguranca;

        public static string Senha
        {
            get => _login;
            set => _login = value;
        }

        public static string Usuario
        {
            get => _usuario;
            set => _usuario = value;
        }
        private static string _idUser;

        public static string IdUser
        {
            get { return _idUser; }
            set { _idUser = value; }
        }


        public static string NomeUsuario
        {
            get { return _nomeUsuario; }
            set { _nomeUsuario = value; }
        }

        public static string Conexao
        {
            get => _conexao;
            set => _conexao = value;
        }

        public static DateTime Sysdate
        {
            get => RetornaSysdate();
            set => _sysdate = value;
        }

        private static DateTime RetornaSysdate()
        {
            return DateTime.Now;
        }

        public static string Programa
        {
            get => _programa;
            set => _programa = value;
        }

        public static string UsuarioCarteira
        {
            get => _nickName;
            set => _nickName = value;
        }

        public static string NickName { get; set; }
    }
}
