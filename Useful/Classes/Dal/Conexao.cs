using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Windows.Forms;
using System.Text;
using System.Web;
using System.Configuration;

/// <summary>
/// Classe para conexão com o Banco de Dados
/// </summary>
namespace Classes.Dal
{
    public class Conexao
    {
        OracleConnection _conn;
        OracleCommand _cmd;
        //OracleTransaction _trans;

        int _totalLinhas, _tipoConexao;
        string _sql;

        /// <summary>
        /// Total de linhas afetadas na execução da SQL
        /// </summary>
        public int TotalLinhas
        {
            get { return _totalLinhas; }
            set { _totalLinhas = value; }
        }

        /// <summary>
        /// Tipo de conexão [1: Web, 2: WinForms, 3: Console]
        /// </summary>
        public int TipoConexao
        {
            get { return _tipoConexao; }
            set { _tipoConexao = value; }
        }

        /// <summary>
        /// Instrução SQL
        /// </summary>
        public string SQL
        {
            get { return _sql; }
            set { _sql = value; }
        }

        /// <summary>
        /// Contrutor da Classe padrão, faz a conexão sem precisar passar paramentro da connection string
        /// </summary>
        public Conexao()
        {
            _conn = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings[HttpContext.Current.Session["conexao"].ToString()].ConnectionString.Replace("USUARIO", HttpContext.Current.Session["usuario"].ToString()).Replace("SENHA", HttpContext.Current.Session["senha"].ToString()));
            _cmd = new OracleCommand();
            _cmd.Connection = this._conn;
            TotalLinhas = 0;
            TipoConexao = 1;
            this.Open();
        }

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="connStr">ConnectionString para conexão com o Banco de Dados</param>
        /// <param name="tipo">Tipo de conexão [1: Web, 2: WinForms, 3: Console]</param>
        public Conexao(String connStr, int tipo)
        {
            _conn = new OracleConnection(connStr);
            _cmd = new OracleCommand();
            _cmd.Connection = _conn;
            TipoConexao = tipo;
        }

        /// <summary>
        /// Testa a conexão com o Banco de Dados
        /// </summary>
        /// <returns>Retorna TRUE se conseguir conectar e FALSE se não conseguir</returns>
        public bool TestaConexao()
        {
            bool resposta = false;

            try
            {
                _conn.Open();
                _conn.Close();
                resposta = true;
            }
            catch (OracleException)
            {
                resposta = false;
            }

            return resposta;
        }

        /// <summary>
        /// Abre conexão com o Banco de Dados
        /// </summary>
        private void Open()
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                {
                    _conn.Open();
                    //_trans = _conn.BeginTransaction();
                    //_cmd.Transaction = _trans;
                }
            }
            catch (OracleException e)
            {

                this.TrataErro(e);
            }
        }

        /// <summary>
        /// Fecha conexão com o Banco de Dados
        /// </summary>
        private void Close()
        {
            try
            {
                _cmd.Parameters.Clear();
                //_trans.Commit();
                _conn.Close();
            }
            catch (OracleException e)
            {
                this.TrataErro(e);
            }
        }

        /// <summary>
        /// Tratamento de erros retornados pelo Banco de Dados
        /// </summary>
        /// <param name="e">Exceção retornada pelo Banco de Dados</param>
        private void TrataErro(OracleException e)
        {
            int codErro = 0;

            #region Gravar erro no LOG

            //OracleConnection _connErro = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=acad-scan.Welic.br)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=acad)(SERVER=DEDICATED)));User Id=perfil;Password=pe_#_mstr_yoda;");
            OracleConnection _connErro = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=acad-scan.Welic.br)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=acad)(SERVER=DEDICATED)));User Id=perweb;Password=#-_Uni+vER9%8Z;");
            OracleCommand _cmdErro = new OracleCommand();
            OracleParameter op = null;
            StringBuilder parametros = new StringBuilder();

            try
            {
                if (this.TipoConexao != 2)
                {
                    _connErro.Open();

                    _cmdErro.Connection = _connErro;

                    _cmdErro.CommandText = "INSERT INTO logdb.log_erros (data, usuario, codigo, mensagem, stack_trace, ip, sql, parametros) VALUES (sysdate, :usuario, :cod, :mensagem, :stack, :ip, :sql, :param)";
                    _cmdErro.CommandType = CommandType.Text;

                    if (System.Web.HttpContext.Current.Session["usuario"] != null)
                    {
                        _cmdErro.Parameters.Add(new OracleParameter("usuario", System.Web.HttpContext.Current.Session["usuario"]));
                    }
                    else
                    {
                        _cmdErro.Parameters.Add(new OracleParameter("usuario", System.Web.HttpContext.Current.Session["usuario_erro"]));
                    }
                    _cmdErro.Parameters.Add(new OracleParameter("cod", e.Code));
                    _cmdErro.Parameters.Add(new OracleParameter("mensagem", e.Message));
                    _cmdErro.Parameters.Add(new OracleParameter("stack", e.StackTrace));
                    _cmdErro.Parameters.Add(new OracleParameter("ip", System.Web.HttpContext.Current.Request.UserHostAddress));
                    if (String.IsNullOrEmpty(_cmd.CommandText))
                    {
                        op = new OracleParameter("sql", OracleLob.Null);
                    }
                    else
                    {
                        op = new OracleParameter("sql", _cmd.CommandText);
                    }
                    op.OracleType = OracleType.Clob;
                    _cmdErro.Parameters.Add(op);

                    foreach (OracleParameter p in _cmd.Parameters)
                    {
                        parametros.Append(p.ParameterName);
                        parametros.Append(" = ");
                        parametros.Append(p.Value);
                        parametros.AppendLine(";");
                    }

                    if (parametros.Length.Equals(0))
                    {
                        op = new OracleParameter("param", "SEM PARÂMETROS");
                    }
                    else
                    {
                        op = new OracleParameter("param", parametros.ToString());
                    }
                    op.OracleType = OracleType.Clob;
                    _cmdErro.Parameters.Add(op);

                    _cmdErro.ExecuteNonQuery();

                    _cmdErro.Parameters.Clear();

                    _cmdErro.CommandText = "SELECT logdb.seq_log_erros.currval AS CODIGO FROM logdb.log_erros ";
                    codErro = Int32.Parse(_cmdErro.ExecuteOracleScalar().ToString());

                    _connErro.Close();
                }
            }
            catch (OracleException erro)
            {
                throw erro;
            }
            #endregion
            string msgErro2 = e.Message;
            if (e.InnerException != null)
                msgErro2 = e.InnerException.ToString();
            
            String msgErro = "Ocorreu um erro de Banco de Dados.\n\nCódigo do Erro: " + codErro.ToString() + "\nMessage: " + e.Message;
            if (e.InnerException != null)
                msgErro += "\nInner Exeption: " + e.InnerException.Message;
            msgErro += "\nPor favor, entre em contato com o responsável pelo sistema.";

            switch (this.TipoConexao)
            {
                case 1:
                    // Código de erro do Oracle para Usuário ou Senha incorretos ou Conta Bloqueada
                    if (e.Code == 01017 || e.Code == 28000)
                    {
                        String url = System.Web.HttpContext.Current.Request.RawUrl;

                        if (e.Code == 01017)
                        {
                            System.Web.HttpContext.Current.Session.Add("erro", "1");
                        }
                        else
                        {
                            System.Web.HttpContext.Current.Session.Add("erro", "3");
                        }
                        System.Web.HttpContext.Current.Response.Redirect(url);
                        System.Web.HttpContext.Current.Response.End();
                    }
                    else if (e.Code == 20500 || e.Code == 28007)
                    {
                        throw e;
                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Olá! mensagem no ajax!!!!!');", true); 
                        //"<script type='text/javascript'>alert('" + msgErro.Replace('\n', ' ') + "');</script>" + msgErro.Replace("\n", "<br />")
                        //System.Web.HttpContext.Current.Response.Redirect("/" + System.Web.HttpContext.Current.Request.Url.Segments[1] + "Erro/?msg="+msgErro.Replace("\n","§"));
                        System.Web.HttpContext.Current.Response.Redirect("http://sis.Welic.br/Erro/?cod=" + codErro.ToString());
                        System.Web.HttpContext.Current.Response.End();
                    }
                    break;
                case 2:
                    throw e;
                case 3:
                    Console.WriteLine(msgErro);
                    break;
                default:
                    throw e;
            }

        }

        /// <summary>
        /// Executa SQL's que não retornam valor [INSERT, UPDATE, DELETE e SET]
        /// </summary>
        public void ExecuteNonQuery()
        {
            this.ExecuteNonQuery(this.SQL, CommandType.Text);
        }

        /// <summary>
        /// Executa SQL's que não retornam valor [INSERT, UPDATE, DELETE e SET]
        /// </summary>
        /// <param name="sql">Instrução SQL para execução no Banco de Dados</param>
        public void ExecuteNonQuery(String sql)
        {
            this.ExecuteNonQuery(sql, CommandType.Text);
        }

        /// <summary>
        /// Executa SQL's que não retornam valor [INSERT, UPDATE, DELETE e SET]
        /// </summary>
        /// <param name="tipo">Tipo de Comando (StoredProcedure, TableDirect ou Text)</param>
        public void ExecuteNonQuery(CommandType tipo)
        {
            this.ExecuteNonQuery(this.SQL, tipo);
        }

        /// <summary>
        /// Executa SQL's que não retornam valor [INSERT, UPDATE, DELETE e SET]
        /// </summary>
        /// <param name="sql">Instrução SQL para execução no Banco de Dados</param>
        /// <param name="tipo">Tipo de Comando (StoredProcedure, TableDirect ou Text)</param>
        public void ExecuteNonQuery(String sql, CommandType tipo)
        {
            _cmd.CommandText = sql;
            _cmd.CommandType = tipo;

            try
            {
                this.Open();
                _cmd.ExecuteNonQuery();
            }
            catch (OracleException e)
            {
                //System.Windows.Forms.MessageBox.Show(e.Message.ToString());
                //this.TrataErro(e);
                throw e;
            }
            catch (Exception e)
            {
                //System.Windows.Forms.MessageBox.Show(e.Message.ToString());
                throw e;
            }
            finally
            {
                this.Close();
            }
        }
        /// <summary>
        /// Executa SQL's de procedures e retornam valor [INSERT, UPDATE, DELETE e SET]
        /// </summary>
        /// <param name="sql">Instrução SQL para execução no Banco de Dados</param>
        /// <param name="tipo">Tipo de Comando (StoredProcedure, TableDirect ou Text)</param>
        public string ExecuteNonQueryProcedure(String sql, CommandType tipo)
        {
            _cmd.CommandText = sql;
            _cmd.CommandType = tipo;
            string retorno;

            try
            {
                this.Open();
                _cmd.ExecuteNonQuery();
                retorno = _cmd.Parameters["Retorno"].Value.ToString();
            }
            catch (OracleException e)
            {
                //System.Windows.Forms.MessageBox.Show(e.Message.ToString());
                retorno = string.Empty;
                throw e;
            }
            catch (Exception e)
            {
                //System.Windows.Forms.MessageBox.Show(e.Message.ToString());
                retorno = string.Empty;
                throw e;
            }
            finally
            {
                this.Close();
            }
            return retorno;
        }

        /// <summary>
        /// Executa SQL's de consulta que retornam um único valor [Exemplo: SELECT count(*) FROM tabela]
        /// </summary>
        /// <returns>Retorna um Object com o resultado da consulta</returns>
        public Object ExecuteScalarQuery()
        {
            return this.ExecuteScalarQuery(this.SQL, CommandType.Text);
        }

        /// <summary>
        /// Executa SQL's de consulta que retornam um único valor [Exemplo: SELECT count(*) FROM tabela]
        /// </summary>
        /// <param name="sql">Instrução SQL para execução no Banco de Dados</param>
        /// <returns>Retorna um Object com o resultado da consulta</returns>
        public Object ExecuteScalarQuery(String sql)
        {
            return this.ExecuteScalarQuery(sql, CommandType.Text);
        }

        /// <summary>
        /// Executa SQL's de consulta que retornam um único valor [Exemplo: SELECT count(*) FROM tabela]
        /// </summary>
        /// <param name="tipo">Tipo de Comando (StoredProcedure, TableDirect ou Text)</param>
        /// <returns>Retorna um Object com o resultado da consulta</returns>
        public Object ExecuteScalarQuery(CommandType tipo)
        {
            return this.ExecuteScalarQuery(this.SQL, tipo);
        }

        /// <summary>
        /// Executa SQL's de consulta que retornam um único valor [Exemplo: SELECT count(*) FROM tabela]
        /// </summary>
        /// <param name="sql">Instrução SQL para execução no Banco de Dados</param>
        /// <param name="tipo">Tipo de Comando (StoredProcedure, TableDirect ou Text)</param>
        /// <returns>Retorna um Object com o resultado da consulta</returns>
        public Object ExecuteScalarQuery(String sql, CommandType tipo)
        {
            Object resultado = null;
            _cmd.CommandText = sql;
            _cmd.CommandType = tipo;

            try
            {
                this.Open();
                resultado = _cmd.ExecuteOracleScalar();
            }
            catch (OracleException e)
            {
                this.TrataErro(e);
            }
            finally
            {
                this.Close();
            }
            return resultado;
        }

        /// <summary>
        /// Executa SQL's de consulta [SELECT]
        /// </summary>
        /// <returns>Retorna um DataTable com o resultado da consulta</returns>
        public DataTable ExecuteQuery()
        {
            return this.ExecuteQuery(this.SQL, CommandType.Text);
        }

        /// <summary>
        /// Executa SQL's de consulta [SELECT]
        /// </summary>
        /// <param name="sql">Instrução SQL para execução no Banco de Dados</param>
        /// <returns>Retorna um DataTable com o resultado da consulta</returns>
        public DataTable ExecuteQuery(String sql)
        {
            return this.ExecuteQuery(sql, CommandType.Text);
        }

        /// <summary>
        /// Executa SQL's de consulta [SELECT]
        /// </summary>
        /// <param name="tipo">Tipo de Comando (StoredProcedure, TableDirect ou Text)</param>
        /// <returns>Retorna um DataTable com o resultado da consulta</returns>
        public DataTable ExecuteQuery(CommandType tipo)
        {
            return this.ExecuteQuery(this.SQL, tipo);
        }

        /// <summary>
        /// Executa SQL's de consulta [SELECT]
        /// </summary>
        /// <param name="sql">Instrução SQL para execução no Banco de Dados</param>
        /// <param name="tipo">Tipo de Comando (StoredProcedure, TableDirect ou Text)</param>
        /// <returns>Retorna um DataTable com o resultado da consulta</returns>
        public DataTable ExecuteQuery(String sql, CommandType tipo)
        {
            DataTable dt = new DataTable();

            _cmd.CommandText = sql;
            _cmd.CommandType = tipo;

            try
            {
                this.Open();

                OracleDataAdapter oda = new OracleDataAdapter(_cmd);
                oda.Fill(dt);
                TotalLinhas = dt.Rows.Count;
            }
            catch (OracleException e)
            {
                this.TrataErro(e);
            }
            finally
            {
                this.Close();
            }
            return dt;
        }

        /// <summary>
        /// Executa SQL's de consulta [SELECT]
        /// </summary>
        /// <returns>Retorna uma List de Hashtable com o resultado da consulta</returns>
        public List<Hashtable> ExecuteListQuery()
        {
            return this.ExecuteListQuery(this.SQL, CommandType.Text);
        }

        /// <summary>
        /// Executa SQL's de consulta [SELECT]
        /// </summary>
        /// <param name="sql">Instrução SQL para execução no Banco de Dados</param>
        /// <returns>Retorna uma List de Hashtable com o resultado da consulta</returns>
        public List<Hashtable> ExecuteListQuery(String sql)
        {
            return this.ExecuteListQuery(sql, CommandType.Text);
        }

        /// <summary>
        /// Executa SQL's de consulta [SELECT]
        /// </summary>
        /// <param name="tipo">Tipo de Comando (StoredProcedure, TableDirect ou Text)</param>
        /// <returns>Retorna uma List de Hashtable com o resultado da consulta</returns>
        public List<Hashtable> ExecuteListQuery(CommandType tipo)
        {
            return this.ExecuteListQuery(this.SQL, tipo);
        }

        /// <summary>
        /// Executa SQL's de consulta [SELECT]
        /// </summary>
        /// <param name="sql">Instrução SQL para execução no Banco de Dados</param>
        /// <param name="tipo">Tipo de Comando (StoredProcedure, TableDirect ou Text)</param>
        /// <returns>Retorna uma List de Hashtable com o resultado da consulta</returns>
        public List<Hashtable> ExecuteListQuery(String sql, CommandType tipo)
        {
            OracleDataReader dr = null;

            Hashtable ht = null;
            List<Hashtable> lista = new List<Hashtable>();

            _cmd.CommandText = sql;
            _cmd.CommandType = tipo;

            try
            {
                this.Open();
                dr = _cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    ht = new Hashtable(dr.FieldCount);

                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        ht.Add(dr.GetName(i).ToLower(), dr[i]);
                    }
                    lista.Add(ht);
                }
                TotalLinhas = lista.Count;
            }
            catch (OracleException e)
            {
                this.TrataErro(e);
            }
            finally
            {
                this.Close();
            }
            return lista;
        }

        /// <summary>
        /// Adiciona um parâmetro na instrução SQL que será executada
        /// </summary>
        /// <param name="paramNome">Nome do parâmetro</param>
        /// <param name="paramValor">Valor do parâmetro</param>
        [Obsolete]
        public void NovoParametro(String paramNome, Object paramValor)
        {
            this.AddParam(paramNome, paramValor);
        }

        /// <summary>
        /// Adiciona um parâmetro na instrução SQL que será executada
        /// </summary>
        /// <param name="paramNome">Nome do parâmetro</param>
        /// <param name="paramValor">Valor do parâmetro</param>
        public void AddParam(String paramNome, Object paramValor)
        {
            AddParam(paramNome, paramValor, ParameterDirection.Input, null);

        }

        public void AddParam(String paramNome, Object paramValor, ParameterDirection direction)
        {
            OracleParameter oParam = new OracleParameter(paramNome, paramValor);
            oParam.Direction = direction;
            _cmd.Parameters.Add(oParam);

        }

        public void AddParam(String paramNome, Object paramValor, ParameterDirection direction, int? size)
        {
            OracleParameter oParam;
            if (size == null)
                oParam = new OracleParameter(paramNome, paramValor);
            else
            {
                int x = int.Parse(size.ToString());
                OracleType TipoCampo = (OracleType)paramValor;
                oParam = new OracleParameter(paramNome, TipoCampo, x);
            }
            oParam.Direction = direction;
            _cmd.Parameters.Add(oParam);
        }

        public void ClearParams()
        {
            _cmd.Parameters.Clear();
        }
        /// <summary>
        /// Converte um DataTable em um Lista de Hashtable
        /// </summary>
        /// <param name="dt">DataTable que será convertido</param>
        /// <returns>Retorna a Lista de Hashtable convertida</returns>
        public List<Hashtable> ConverterDataTable(DataTable dt)
        {
            Hashtable ht = null;
            List<Hashtable> lista = new List<Hashtable>();

            foreach (DataRow item in dt.Rows)
            {
                ht = new Hashtable(dt.Columns.Count);

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ht.Add(item.Table.Columns[i].ToString().ToLower(), item[i].ToString());
                }
                lista.Add(ht);
            }

            return lista;
        }

        public void AbreTransacao()
        {

            try
            {

                this.Open();
            }

            catch (Exception ex)
            {
                throw ex;
            }



            //inicia uma transação local

            OracleTransaction transacao = _conn.BeginTransaction();

            //Alista o command na transação atual.

            OracleCommand comando = _conn.CreateCommand();

            comando.Transaction = transacao;

            try
            {
                //define os comandos SQL para icluir dados na tabela Transportadoras do banco de dados Northwind.mdb 

                comando.CommandText = "Insert into Transportadoras (CódigoDaTransportadora,NomeDaEmpresa,Telefone) VALUES (4, 'JcmSoft','(055)-658-55')";

                comando.ExecuteNonQuery();

                comando.CommandText = "Insert into Transportadoras (CódigoDaTransportadora,NomeDaEmpresa,Telefone) VALUES (5, 'Macorati','(061)-123-54')";

                comando.ExecuteNonQuery();

                //efetua o commit - consolida as inclusções

                transacao.Commit();
            }
            catch (Exception ex)
            {

                try
                {
                    //cancela a transacao - rollback

                    transacao.Rollback();
                }
                catch (OracleException ex1)
                {

                    if (transacao.Connection != null)
                    {
                        System.Windows.Forms.MessageBox.Show("Uma exceção do tipo " + ex1.GetType().ToString() + " foi encontrada durante a tentativa de cancelar a transação RollBack.");
                    }

                }

                System.Windows.Forms.MessageBox.Show("Uma exceção do tipo " + ex.GetType().ToString() + " foi encontrada durante durante a inclusão de dados Transações.");

                System.Windows.Forms.MessageBox.Show("Nenhum registro foi incluido na fonte de dados RollBack.");
            }
            finally
            {
                //fecha a conexao com a fonte de dados
                _conn.Close();

            }

        }
    }
}