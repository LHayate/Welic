using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Classes.Dal;
using System.Data;

namespace Classes.Entity
{
    public class Seguranca
    {
        private int _usuario;
        public int Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        private string _programa;
        public string Programa
        {
            get { return _programa; }
            set { _programa = value; }
        }

        private bool _qualquer;
        public bool Qualquer
        {
            get { return _qualquer; }
            set { _qualquer = value; }
        }

        private bool _visualizar;
        public bool Visualizar
        {
            get { return _visualizar; }
            set { _visualizar = value; }
        }

        private bool _incluir;
        public bool Incluir
        {
            get { return _incluir; }
            set { _incluir = value; }
        }

        private bool _alterar;
        public bool Alterar
        {
            get { return _alterar; }
            set { _alterar = value; }
        }

        private bool _excluir;
        public bool Excluir
        {
            get { return _excluir; }
            set { _excluir = value; }
        }

        private bool _ativo;
        public bool Ativo
        {
            get { return _ativo; }
            set { _ativo = value; }
        }

        /// <summary>
        /// Lista de Permissões do Usuario
        /// </summary>
        /// <param name="usuario">Código do Usuário</param>
        /// <returns>Lista de Permissões</returns>
        public List<Seguranca> BuscaPermissoes(int usuario)
        {
            DataTable dt = new DataTable();
            Conexao dal = new Conexao(Globals.GetStringConnection(), 2);
            StringBuilder sql = new StringBuilder();
            Seguranca seg = new Seguranca();
            List<Seguranca> lseg = new List<Seguranca>();

            dal.AddParam("Usuario", usuario);

            sql.Append("SELECT USUARIO, ");
            sql.Append("       PROGRAMA, ");
            sql.Append("       PERMISSAO_QUALQUER, ");
            sql.Append("       PERMISSAO_VISUALIZAR, ");
            sql.Append("       PERMISSAO_INCLUIR, ");
            sql.Append("       PERMISSAO_ALTERAR, ");
            sql.Append("       PERMISSAO_EXCLUIR, ");
            sql.Append("       ATIVO ");
            sql.Append("  FROM SEG.VW_PERMISSOES VW ");
            sql.Append(" WHERE VW.USUARIO = :Usuario ");

            dt = dal.ExecuteQuery(sql.ToString());
            foreach (DataRow dr in dt.Rows)
            {
                seg = new Seguranca();

                seg.Usuario = int.Parse(dr["USUARIO"].ToString());
                seg.Programa = dr["PROGRAMA"].ToString();
                seg.Qualquer = (dr["PERMISSAO_QUALQUER"].ToString() == "1") ? true : false;
                seg.Visualizar = (dr["PERMISSAO_VISUALIZAR"].ToString() == "1") ? true : false;
                seg.Incluir = (dr["PERMISSAO_INCLUIR"].ToString() == "1") ? true : false;
                seg.Alterar = (dr["PERMISSAO_ALTERAR"].ToString() == "1") ? true : false;
                seg.Excluir = (dr["PERMISSAO_EXCLUIR"].ToString() == "1") ? true : false;
                seg.Ativo = (dr["ATIVO"].ToString() == "1") ? true : false;

                lseg.Add(seg);
            }

            return lseg;
        }

        /// <summary>
        /// Permissão do Usuario no Programa
        /// </summary>
        /// <param name="usuario">Código do Usuário</param>
        /// <param name="programa">Código do Programa</param>
        /// <returns>Permissão no Programa</returns>
        public Seguranca BuscaPermissoes(int usuario, string programa)
        {
            DataTable dt = new DataTable();
            Conexao dal = new Conexao(Globals.GetStringConnection(), 2);
            StringBuilder sql = new StringBuilder();
            Seguranca seg = new Seguranca();

            dal.AddParam("Usuario", usuario);
            dal.AddParam("Programa", programa);

            sql.Append("SELECT USUARIO, ");
            sql.Append("       PROGRAMA, ");
            sql.Append("       PERMISSAO_QUALQUER, ");
            sql.Append("       PERMISSAO_VISUALIZAR, ");
            sql.Append("       PERMISSAO_INCLUIR, ");
            sql.Append("       PERMISSAO_ALTERAR, ");
            sql.Append("       PERMISSAO_EXCLUIR, ");
            sql.Append("       ATIVO ");
            sql.Append("  FROM SEG.VW_PERMISSOES VW ");
            sql.Append(" WHERE VW.USUARIO = :Usuario ");
            sql.Append("   AND VW.PROGRAMA = :Programa ");

            dt = dal.ExecuteQuery(sql.ToString());

            if (dt.Rows.Count > 0)
            {
                seg.Usuario = int.Parse(dt.Rows[0]["USUARIO"].ToString());
                seg.Programa = dt.Rows[0]["PROGRAMA"].ToString();
                seg.Qualquer = (dt.Rows[0]["PERMISSAO_QUALQUER"].ToString() == "1") ? true : false;
                seg.Visualizar = (dt.Rows[0]["PERMISSAO_VISUALIZAR"].ToString() == "1") ? true : false;
                seg.Incluir = (dt.Rows[0]["PERMISSAO_INCLUIR"].ToString() == "1") ? true : false;
                seg.Alterar = (dt.Rows[0]["PERMISSAO_ALTERAR"].ToString() == "1") ? true : false;
                seg.Excluir = (dt.Rows[0]["PERMISSAO_EXCLUIR"].ToString() == "1") ? true : false;
                seg.Ativo = (dt.Rows[0]["ATIVO"].ToString() == "1") ? true : false;
            }

            return seg;
        }

        /// <summary>
        /// Autentica o Usuario
        /// </summary>
        /// <returns>Retorna o código do usuario e o nome</returns>
        public static bool BuscaAutenticacaoUsuario(int matricula, string senha, string banco)
        {
            Globals.Conexao = banco;
            Globals.Usuario = matricula;
            Globals.Login = senha;

            Conexao dal = new Conexao(Globals.GetStringConnection(), 2);

            if (dal.TestaConexao())
            {
                DataTable dt = new DataTable();
                dt = Seguranca.BuscaUsuarios(Globals.Usuario);
                if (dt.Rows.Count > 0)
                {
                    Globals.NomeUsuario = dt.Rows[0]["NOME"].ToString();
                    Globals.UsuarioCarteira = int.Parse(dt.Rows[0]["CARTEIRA"].ToString());
                }

                //Lista de Permissão por Usuario.
                Seguranca seg = new Seguranca();
                Globals.listaSeguranca = seg.BuscaPermissoes(Globals.Usuario);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Metodo que busca os dados do usuário
        /// </summary>
        /// <param name="usuario">Matricula do usuário</param>
        /// <returns>Retorna um DataTable com os dados do usuário</returns>
        public static DataTable BuscaUsuarios(int usuario)
        {
            Conexao dal = new Conexao(Globals.GetStringConnection(), 2);
            StringBuilder sql = new StringBuilder();
            dal.AddParam("Usuario", usuario);

            sql.Append(" SELECT USUARIO, NOME, EMAIL, CPF, SITUACAO, MASTER, POLO, CARTEIRA ");
            sql.Append(" FROM SEG.USUARIOS WHERE USUARIO = :Usuario");

            return dal.ExecuteQuery(sql.ToString());
        }

    }
}

