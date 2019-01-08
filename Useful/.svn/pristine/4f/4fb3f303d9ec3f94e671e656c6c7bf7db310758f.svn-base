using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Classes.Dal;
using System.Configuration;
using Classes.Entity.Properties;
using System.Data.Entity;
using System.Data.EntityClient;
using System.IO;
using System.Text.RegularExpressions;

namespace Classes.Entity
{
    public static class Globals
    {
        private static string _login = string.Empty;
        private static int _usuario, _usuarioCarteira;
        private static string _nomeUsuario;
        private static string _conexao;
        private static DateTime _sysdate;
        private static string _programa;
        public enum CBanco { Acad, ACADDR, Gem, Hvu, Mv };
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


        public static string GetConectionString(string initStringConection, string endStringConection, string caminho = "")
        {
            ServerName = initStringConection;

            if (string.IsNullOrEmpty(caminho))
                caminho = GetPathToTNSNamesFile();

            TextReader leitor = new StreamReader(caminho);
            string stringConexao = "", linha;

            do
            {
                linha = leitor.ReadLine();
                if (linha.Contains(initStringConection))
                {
                    string aux = linha;
                    aux = aux.Replace(initStringConection, "");
                    do
                    {
                        stringConexao += aux;
                        aux = leitor.ReadLine();
                    } while (!aux.Contains(endStringConection));
                    linha = null;
                }
            } while (linha != null);

            leitor.Close();
            return stringConexao;
        }

        /// <summary>
        /// Gets TNSNames file path from system path
        /// </summary>
        /// <returns>TNSNames.ora file path</returns>
        private static string GetPathToTNSNamesFile()
        {
            string systemPath = Environment.GetEnvironmentVariable("Path");
            Regex reg = new Regex("[a-zA-Z]:\\\\[a-zA-Z0-9\\\\]*(oracle|app)[a-zA-Z0-9_.\\\\]*(?=bin)");
            MatchCollection col = reg.Matches(systemPath);

            string subpath = "network\\ADMIN\\tnsnames.ora";
            foreach (Match match in col)
            {
                string path = match.ToString() + subpath;
                if (File.Exists(path))
                    return path;
            }
            return string.Empty;
        }

        public static string GetStringConnection()
        {
            string stringConnection = string.Empty;
            if (Globals.Conexao == "ACAD_TESTE")
                stringConnection = "Data Source" + GetConectionString("DBTESTE.WORLD", "#FIMDBTESTE#") + ";User Id=" + Globals.Usuario.ToString() + ";Password=" + Globals.Login;
            else if (Globals.Conexao == "MVPRD")
                stringConnection = "Data Source" + GetConectionString("MVPRD.WORLD", "#FIMMVPRD#") + ";User Id=" + Globals.Usuario.ToString() + ";Password=" + Globals.Login;
            else if (Globals.Conexao == "MVSML")
                stringConnection = "Data Source" + GetConectionString("MVSML.WORLD", "#FIMMVSML#") + ";User Id=" + Globals.Usuario.ToString() + ";Password=" + Globals.Login;
            else if (Globals.Conexao == "MVTRN")
                stringConnection = "Data Source" + GetConectionString("MVTRN.WORLD", "#FIMMVTRN#") + ";User Id=" + Globals.Usuario.ToString() + ";Password=" + Globals.Login;
            else if (Globals.Conexao == "ACADDR")
                stringConnection = "Data Source" + GetConectionString("ACADDR.WORLD", "#FIMACADDR#") + ";User Id=" + Globals.Usuario.ToString() + ";Password=" + Globals.Login;
            else
                stringConnection = "Data Source" + GetConectionString("ACAD.WORLD", "#FIMACAD#") + ";User Id=" + Globals.Usuario.ToString() + ";Password=" + Globals.Login;
            return stringConnection;
        }

        public static string GetStringConnection(string pConexao, string pUsuario, string pLogin)
        {
            string stringConnection = string.Empty;
            if (pConexao == "ACAD_TESTE")
                stringConnection = "Data Source" + GetConectionString("DBTESTE.WORLD", "#FIMDBTESTE#") + ";User Id=" + pUsuario + ";Password=" + pLogin;
            else if (pConexao == "MVPRD")
                stringConnection = "Data Source" + GetConectionString("MVPRD.WORLD", "#FIMMVPRD#") + ";User Id=" + pUsuario + ";Password=" + pLogin;
            else if (pConexao == "MVSML")
                stringConnection = "Data Source" + GetConectionString("MVSML.WORLD", "#FIMMVSML#") + ";User Id=" + pUsuario + ";Password=" + pLogin;
            else if (pConexao == "MVTRN")
                stringConnection = "Data Source" + GetConectionString("MVTRN.WORLD", "#FIMMVTRN#") + ";User Id=" + pUsuario + ";Password=" + pLogin;
            else if (Globals.Conexao == "ACADDR")
                stringConnection = "Data Source" + GetConectionString("ACADDR.WORLD", "#FIMACADDR#") + ";User Id=" + pUsuario + ";Password=" + Globals.Login;
            else
                stringConnection = "Data Source" + GetConectionString("ACAD.WORLD", "#FIMACAD#") + ";User Id=" + pUsuario + ";Password=" + pLogin;
            return stringConnection;
        }

        public static string GetStringConnection(CBanco pBanco)
        {
            string stringConnection = string.Empty;

            if (pBanco == CBanco.Acad)
            {
                stringConnection = GetStringConnection();
            }
            else if (pBanco == CBanco.ACADDR)
            {
                stringConnection = "Data Source" + GetConectionString("ACADDR.WORLD", "#FIMACADDR#") + ";User Id=" + Globals.Usuario.ToString() + ";Password=" + Globals.Login;
            }
            else if (pBanco == CBanco.Gem)
            {
                if (Globals.Conexao == "ACAD_TESTE")
                    stringConnection = "Data Source" + GetConectionString("DBTESTE.WORLD", "#FIMDBTESTE#") + ";User Id=obvius;Password=test_obvius";
                else
                    stringConnection = "Data Source" + GetConectionString("ACAD.WORLD", "#FIMACAD#") + ";User Id=obvius;Password=K57JANAY#3";
            }
            else if (pBanco == CBanco.Hvu)
            {
                if (Globals.Conexao == "ACAD_TESTE")
                    stringConnection = GetStringConnection();
                else
                    stringConnection = "Data Source" + GetConectionString("PHVU.WORLD", "#FIMPHVU#") + ";User Id=" + Globals.Usuario.ToString() + ";Password=" + Globals.Login;
            }
            else if (pBanco == CBanco.Mv)
            {
                if (Globals.Conexao == "MVPRD")
                    stringConnection = "Data Source" + GetConectionString("MVPRD.WORLD", "#FIMMVPRD#") + ";User Id=" + Globals.Usuario.ToString() + ";Password=" + Globals.Login;
                else if (Globals.Conexao == "MVSML")
                    stringConnection = "Data Source" + GetConectionString("MVSML.WORLD", "#FIMMVSML#") + ";User Id=" + Globals.Usuario.ToString() + ";Password=" + Globals.Login;
                else if (Globals.Conexao == "MVTRN")
                    stringConnection = "Data Source" + GetConectionString("MVTRN.WORLD", "#FIMMVTRN#") + ";User Id=" + Globals.Usuario.ToString() + ";Password=" + Globals.Login;
            }

            return stringConnection;
        }

        public static EntityConnectionStringBuilder GetStringConnectionEntity(string Metadata)
        {
            return GetStringConnectionEntity(Metadata, CBanco.Acad);
        }

        public static EntityConnectionStringBuilder GetStringConnectionEntity(string Metadata, CBanco pBanco)
        {
            EntityConnectionStringBuilder connStrBuild = new EntityConnectionStringBuilder();
            connStrBuild.Metadata = Metadata;
            connStrBuild.Provider = "Devart.Data.Oracle";
            connStrBuild.ProviderConnectionString = GetStringConnection(pBanco);
            return connStrBuild;
        }

        public static List<Seguranca> listaSeguranca;

        public static string Login
        {
            get { return Globals._login; }
            set { Globals._login = value; }
        }

        public static int Usuario
        {
            get { return Globals._usuario; }
            set { Globals._usuario = value; }
        }

        public static string NomeUsuario
        {
            get { return Globals._nomeUsuario; }
            set { Globals._nomeUsuario = value; }
        }

        public static string Conexao
        {
            get { return Globals._conexao; }
            set { Globals._conexao = value; }
        }

        public static DateTime Sysdate
        {
            get { return RetornaSysdate(); }
            set { Globals._sysdate = value; }
        }

        private static DateTime RetornaSysdate()
        {
            Conexao dal = new Conexao(GetStringConnection(), 2);
            StringBuilder sql = new StringBuilder();

            sql.Append(" SELECT SYSDATE AS DATAHORA FROM DUAL ");

            DataTable dt = new DataTable();
            dt = dal.ExecuteQuery(sql.ToString());

            if (dt.Rows.Count > 0)
            {
                return DateTime.Parse(dt.Rows[0]["DATAHORA"].ToString());
            }
            else
            {
                return new DateTime();
            }
        }

        public static string Programa
        {
            get { return Globals._programa; }
            set { Globals._programa = value; }
        }

        public static int UsuarioCarteira
        {
            get { return Globals._usuarioCarteira; }
            set { Globals._usuarioCarteira = value; }
        }
    }
}
