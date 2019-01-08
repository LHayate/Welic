using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Data.OracleClient;
//using Classes.Entity;
using System.Text.RegularExpressions;

namespace Classes.Interface.VFP
{
    public class CriaArquivoBlob: System.EnterpriseServices.ServicedComponent
    {
        public CriaArquivoBlob()
        { }

        /// <summary>
        /// Lê um campo BLOB no banco e recria o arquivo na máquina do usuário
        /// </summary>
        /// <param name="usuario">Usuário logado no sistema</param>
        /// <param name="senha">Senha do usuário logado no sistema</param>
        /// <param name="banco">Banco ao qual o programa vai conectar</param>
        /// <param name="sql">O comando responsável por retornar o BLOB (execução Scalar)</param>
        /// <param name="nomeArquivo">O nome do arquivo a ser gerado COM a extensão</param>
        /// <returns>Retorna uma string com o caminho onde foi gerado o arquivo</returns>
        public string RetornaCaminhoArquivo(int usuario, string senha, string banco, string sql, string nomeArquivo)
        {
            OracleConnection conexao = GeraConexao(usuario, senha, banco);
            OracleCommand comando = new OracleCommand(sql, conexao);

            DataTable dtImagem = new DataTable();

            OracleDataAdapter oda = new OracleDataAdapter(comando);
            oda.Fill(dtImagem);

            string caminho = @"C:\sistemas\" + nomeArquivo;

            if (File.Exists(caminho))
            {
                File.Delete(caminho);
            }

            FileStream FS = new FileStream(caminho, FileMode.Create, FileAccess.ReadWrite, FileShare.Delete);
            if (!string.IsNullOrEmpty(dtImagem.Rows[0][0].ToString()))
            {
                byte[] imagem = (byte[])dtImagem.Rows[0][0];

                FS.Write(imagem, 0, imagem.Length);
                FS.Flush(true);
                FS.Close();
                FS = null;

                return caminho;
            }
            else
            {
                return "";
            }
        }

        private OracleConnection GeraConexao(int usuario, string senha, string banco)
        {
            string stringConnection = StringConnection(banco, usuario.ToString(), senha);
            
            OracleConnection conexao = new OracleConnection(stringConnection);
            conexao.Open();
            return conexao;
        }

        private string StringConnection(string banco, string usuario, string login)
        {
            string stringConnection = string.Empty;
            //if (Globals.Conexao == "ACAD_TESTE")
            //    stringConnection = "Data Source" + Globals.GetConectionString("DBTESTE.WORLD", "#FIMDBTESTE#") + ";User Id=" + usuario + ";Password=" + login;
            //else if (Globals.Conexao == "MVPRD")
            //    stringConnection = "Data Source" + Globals.GetConectionString("MVPRD.WORLD", "#FIMMVPRD#") + ";User Id=" + usuario + ";Password=" + login;
            //else if (Globals.Conexao == "MVSML")
            //    stringConnection = "Data Source" + Globals.GetConectionString("MVSML.WORLD", "#FIMMVSML#") + ";User Id=" + usuario + ";Password=" + login;
            //else if (Globals.Conexao == "MVTRN")
            //    stringConnection = "Data Source" + Globals.GetConectionString("MVTRN.WORLD", "#FIMMVTRN#") + ";User Id=" + usuario + ";Password=" + login;
            //else
            //    stringConnection = "Data Source" + Globals.GetConectionString("ACAD.WORLD", "#FIMACAD#") + ";User Id=" + usuario + ";Password=" + login;

            if (banco == "ACAD_TESTE")
                stringConnection = "Data Source" + GetConectionString("DBTESTE.WORLD", "#FIMDBTESTE#") + ";User Id=" + usuario + ";Password=" + login;
            else if (banco == "MVPRD")
                stringConnection = "Data Source" + GetConectionString("MVPRD.WORLD", "#FIMMVPRD#") + ";User Id=" + usuario + ";Password=" + login;
            else if (banco == "MVSML")
                stringConnection = "Data Source" + GetConectionString("MVSML.WORLD", "#FIMMVSML#") + ";User Id=" + usuario + ";Password=" + login;
            else if (banco == "MVTRN")
                stringConnection = "Data Source" + GetConectionString("MVTRN.WORLD", "#FIMMVTRN#") + ";User Id=" + usuario + ";Password=" + login;
            else
                stringConnection = "Data Source" + GetConectionString("ACAD.WORLD", "#FIMACAD#") + ";User Id=" + usuario + ";Password=" + login;
            return stringConnection;

        }

        public bool GravaArquivoBlob(int usuario, string senha, string banco, string sql, string arquivo)
        { 
            // converter o arquivo em byte[]
            FileStream fs = new FileStream(@arquivo, FileMode.Open, FileAccess.Read);
            byte[] arquivoVetorizado = new byte[fs.Length];
            fs.Read(arquivoVetorizado, 0, (int)fs.Length);

            // gerar conexão
            OracleConnection conexao = GeraConexao(usuario, senha, banco);

            // executar comando
            OracleCommand comando = new OracleCommand(sql, conexao);
            comando.Parameters.Add(new OracleParameter("arquivo",arquivoVetorizado));
            comando.ExecuteNonQuery();

            return true;

        }

        public string GetConectionString(string initStringConection, string endStringConection, string caminho = "")
        {
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
        private string GetPathToTNSNamesFile()
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
    }
}
