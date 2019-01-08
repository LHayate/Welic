using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Data.OracleClient;
using Classes.Dal;
using Classes.Entity;

namespace Classes.Uteis
{
    public static class CriaArquivoBlob
    {
        /// <summary>
        /// Lê um campo BLOB no banco e recria o arquivo na máquina do usuário
        /// </summary>
        /// <param name="usuario">Usuário logado no sistema</param>
        /// <param name="senha">Senha do usuário logado no sistema</param>
        /// <param name="banco">Banco ao qual o programa vai conectar</param>
        /// <param name="sql">O comando responsável por retornar o BLOB (execução Scalar)</param>
        /// <param name="nomeArquivo">O caminho completo do arquivo a ser gerado COM a extensão</param>
        /// <returns>Retorna uma string com o caminho onde foi gerado o arquivo</returns>
        public static string RetornaCaminhoArquivo(string sql, string nomeArquivo)
        {
            Conexao dal = new Conexao(Globals.GetStringConnection(), 2); // abrindo a conexão com o banco

            DataTable dtDados = dal.ExecuteQuery(sql);

            return RetornaCaminhoArquivo(dtDados.Rows[0][0], nomeArquivo);
        }

        public static string RetornaCaminhoArquivo(object campoDados, string nomeArquivo)
        {
            if (File.Exists(nomeArquivo))
            {
                File.Delete(nomeArquivo);
            }

            FileStream FS = new FileStream(nomeArquivo, FileMode.Create, FileAccess.ReadWrite, FileShare.Delete);
            if (!string.IsNullOrEmpty(campoDados.ToString()))
            {
                byte[] arquivo = (byte[])campoDados;

                FS.Write(arquivo, 0, arquivo.Length);
                FS.Flush(true);
                FS.Close();
                FS = null;

                return nomeArquivo;
            }
            else
            {
                return "";
            }
        }
    }
}
