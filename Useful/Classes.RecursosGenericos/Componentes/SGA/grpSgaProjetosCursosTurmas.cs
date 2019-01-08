using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Uniube;
using System.Data.OracleClient;
using Classes.Dal;
using Classes.Entity;

namespace Classes.RecursosGenericos.Componentes.SGA
{
    public partial class grpProjetosCursosTurmas : UserControlUniube
    {
        public grpProjetosCursosTurmas()
        {
            InitializeComponent();
        }

        private void grpProjetosCursosTurmas_Load(object sender, EventArgs e)
        {

        }

        private void txtCurso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3 &&
                !txtCurso.ReadOnly)
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(@"
                SELECT c.curso,
                       trim(c.descricao) AS descricao,
                       ct.descricao AS tipo,
                       decode(c.ativo,
                                1,
                                'SIM',
                                'NÃO') AS ativo
                  FROM sga.cursos c
                  JOIN sga.cursos_tipos ct ON (ct.curso_tipo = c.tipo)
                 WHERE c.tipo IN (3, 4)
                 ORDER BY c.curso");

                FormBusca fb = new FormBusca(sql.ToString(), new List<OracleParameter>(), true, "Busca por Cursos de Pós Graduação e Extensão", "descricao", "", "Nenhum Curso encontrado", true);
                fb.ShowDialog();

                if (fb.retorno != null)
                {
                    txtCurso.Text = fb.retorno["curso"].ToString();
                    txtPolo.Focus();
                }
            }
        }
        private void txtCurso_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCurso.Text))
            {
                DataTable dtDados = BLL.BuscarSgaCursos(txtCurso.Text);

                if (dtDados.Rows.Count == 1)
                {
                    //implementação da mesma regra utilizada no KeyDown
                    if (new string[] { "3", "4" }.Contains(dtDados.Rows[0]["tipo"].ToString()))
                    {
                        txtCursoDesc.Text = dtDados.Rows[0]["descricao"].ToString();
                    }
                    else
                    {
                        txtCurso.Text = "";
                        txtCursoDesc.Text = "";
                    }
                }
                else
                {
                    txtCurso.Text = "";
                    txtCursoDesc.Text = "";
                }
            }
            else
            {
                txtCurso.Text = "";
                txtCursoDesc.Text = "";
            }

            txtPolo_Leave(txtPolo, null);
            txtTurma_Leave(txtTurma, null);
            txtEtapa_Leave(txtEtapa, null);
        }

        private void txtPolo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3 &&
                !((TextBoxUniube)(sender)).ReadOnly &&
                ((this.ControlarIntegridade && !txtCurso.Text.Trim().Equals("")) || !this.ControlarIntegridade))
            {
                StringBuilder sql = new StringBuilder();
                string msgNaoEncontrado = "Nenhum registro encontrado.";
                if (AcaoParentForm != FormUniube.CAcaoFormulario.Novo)
                {
                    string auxWhere = "";
                    if (this.ControlarIntegridade)
                        auxWhere = "WHERE pct.curso = " + txtCurso.Text;

                    sql.Append(@"
                    SELECT DISTINCT pct.polo,
                                    p.descricao, pa.razao_social AS parceiro
                      FROM sga.projetos_cursos_turmas pct
                      JOIN sga.polos p ON (p.polo = pct.polo)
                      LEFT JOIN sga.parceiros pa ON (pa.parceiro = p.parceiro)
                     " + auxWhere + @"
                     ORDER BY pct.polo");
                    msgNaoEncontrado = @"Nenhum Polo encontrado para a condição informada. " + Environment.NewLine + auxWhere.Replace("cdc.", "").Replace("WHERE", "").Replace("AND", "").Trim().ToUpper();
                }
                else
                {
                    sql.Append(@"
                    SELECT DISTINCT p.polo,
                                    p.descricao, 
                                    pa.razao_social AS parceiro
                      FROM sga.polos p
                      LEFT JOIN sga.parceiros pa ON (pa.parceiro = p.parceiro)
                     WHERE nvl(p.presencial, 0) = 1
                       AND nvl(p.ativo, 0) = 1
                     ORDER BY p.polo");
                }

                FormBusca fb = new FormBusca(sql.ToString(), new List<OracleParameter>(), true, "Busca por Polos", "descricao", "", msgNaoEncontrado, true);
                fb.ShowDialog();

                if (fb.retorno != null)
                {
                    txtPolo.Text = fb.retorno["polo"].ToString();

                    if (txtPoloDesc != null)
                    {
                        txtPoloDesc.Text = fb.retorno["descricao"].ToString();
                    }
                    txtTurma.Focus();
                }
            }
        }
        private void txtPolo_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPolo.Text.Trim()) &&
                ((this.ControlarIntegridade && !txtCurso.Text.Trim().Equals("")) || !this.ControlarIntegridade))
            {
                StringBuilder sql = new StringBuilder();
                if (((FormUniube)this.ParentForm).AcaoFormulario != FormUniube.CAcaoFormulario.Novo)
                {
                    string auxWhere = "";
                    if (this.ControlarIntegridade)
                        auxWhere = @"WHERE pct.curso = " + txtCurso.Text + @"
                                       AND pct.polo = " + txtPolo.Text;
                    else
                        auxWhere = @"WHERE pct.polo = " + txtPolo.Text;

                    
                    sql.Append(@"
                    SELECT DISTINCT pct.polo,
                                    p.descricao
                      FROM sga.projetos_cursos_turmas pct
                      JOIN sga.polos p ON (p.polo = pct.polo)
                     " + auxWhere);
                }
                else
                {
                    sql.Append(@"
                    SELECT DISTINCT p.polo,
                                    p.descricao
                      FROM sga.polos p
                     WHERE p.polo = " + txtPolo.Text);
                }
                
                                
                DataTable dtDados = new Conexao(Globals.GetStringConnection(), 2).ExecuteQuery(sql.ToString());

                if (dtDados.Rows.Count == 1)
                {
                    txtPoloDesc.Text = dtDados.Rows[0]["descricao"].ToString();
                }
                else
                {
                    txtPolo.Text = "";
                    txtPoloDesc.Text = "";
                }
            }
            else
            {
                txtPolo.Text = "";
                txtPoloDesc.Text = "";
            }

            txtTurma_Leave(txtTurma, null);
            txtEtapa_Leave(txtEtapa, null);
        }

        private void txtTurma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3 &&
                !((TextBoxUniube)(sender)).ReadOnly &&
                ((this.ControlarIntegridade &&
                !txtCurso.Text.Trim().Equals("") &&
                !txtPolo.Text.Trim().Equals("")) || !this.ControlarIntegridade))
            {
                StringBuilder sql = new StringBuilder();
                string auxWhere = "";
                if (this.ControlarIntegridade)
                    auxWhere = @"WHERE pct.curso = " + txtCurso.Text + @"
                                       AND pct.polo = " + txtPolo.Text;

                sql.Append(@"
                SELECT DISTINCT pct.turma
                  FROM sga.projetos_cursos_turmas pct
                 " + auxWhere + @"
                 ORDER BY pct.turma");

                string msgNaoEncontrado = @"Nenhuma Turma encontrada para a condição informada. " + Environment.NewLine + auxWhere.Replace("cdc.", "").Replace("WHERE", "").Replace("AND", "").Trim().ToUpper();

                FormBusca fb = new FormBusca(sql.ToString(), new List<OracleParameter>(), true, "Busca por Trumas", "turma", "", msgNaoEncontrado, true);
                fb.ShowDialog();
                                                                
                if (fb.retorno != null)
                {
                    txtTurma.Text = fb.retorno["turma"].ToString();
                    txtEtapa.Focus();
                }
            }
        }
        private void txtTurma_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTurma.Text.Trim()) &&
                ((this.ControlarIntegridade &&
                !txtCurso.Text.Trim().Equals("") &&
                !txtPolo.Text.Trim().Equals("")) || !this.ControlarIntegridade))
            {
                StringBuilder sql = new StringBuilder();

                string auxWhere = "";
                if (((FormUniube)this.ParentForm).AcaoFormulario != FormUniube.CAcaoFormulario.Novo)
                {
                    if (this.ControlarIntegridade)
                        auxWhere = @"WHERE pct.curso = " + txtCurso.Text + @"
                                       AND pct.polo = " + txtPolo.Text + @"
                                       AND pct.turma = " + txtTurma.Text;
                    else
                        auxWhere = @"WHERE pct.turma = " + txtTurma.Text;

                    sql.Append(@"
                    SELECT DISTINCT pct.turma
                      FROM sga.projetos_cursos_turmas pct
                     " + auxWhere);

                    DataTable dtDados = new Conexao(Globals.GetStringConnection(), 2).ExecuteQuery(sql.ToString());

                    if (dtDados.Rows.Count == 1)
                    {
                        //se existe, não faz nada
                    }
                    else
                    {
                        txtTurma.Text = "";
                    }
                }
                else
                {
                    //Se estiver criando um novo registro, deixa informar a turma que quiser
                }                                
            }
            else
            {
                txtTurma.Text = "";
            }

            txtEtapa_Leave(txtEtapa, null);
        }

        private void txtEtapa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3 &&
                !((TextBoxUniube)(sender)).ReadOnly &&
                ((this.ControlarIntegridade &&
                !txtCurso.Text.Trim().Equals("") &&
                !txtPolo.Text.Trim().Equals("") &&
                !txtTurma.Text.Trim().Equals("")) || !this.ControlarIntegridade))
            {
                StringBuilder sql = new StringBuilder();
                string auxWhere = "";
                if (this.ControlarIntegridade)
                    auxWhere = @"WHERE pct.curso = " + txtCurso.Text + @"
                                   AND pct.polo = " + txtPolo.Text + @"
                                   AND pct.turma = " + txtTurma.Text;

                sql.Append(@"
                SELECT DISTINCT pct.etapa
                  FROM sga.projetos_cursos_turmas pct
                 " + auxWhere + @"
                 ORDER BY pct.etapa");

                string msgNaoEncontrado = @"Nenhuma Etapa encontrada para a condição informada. " + Environment.NewLine + auxWhere.Replace("cdc.", "").Replace("WHERE", "").Replace("AND", "").Trim().ToUpper();

                FormBusca fb = new FormBusca(sql.ToString(), new List<OracleParameter>(), true, "Busca por Etapas", "etapa", "", msgNaoEncontrado, true);
                fb.ShowDialog();

                if (fb.retorno != null)
                {
                    txtEtapa.Text = fb.retorno["etapa"].ToString();
                    txtCurso.Focus();
                }
            }
        }
        private void txtEtapa_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEtapa.Text.Trim()) &&
                ((this.ControlarIntegridade &&
                !txtCurso.Text.Trim().Equals("") &&
                !txtPolo.Text.Trim().Equals("") &&
                !txtTurma.Text.Trim().Equals("")) || !this.ControlarIntegridade))
            {
                StringBuilder sql = new StringBuilder();

                string auxWhere = "";
                if (((FormUniube)this.ParentForm).AcaoFormulario != FormUniube.CAcaoFormulario.Novo)
                {
                    if (this.ControlarIntegridade)
                        auxWhere = @"WHERE pct.curso = " + txtCurso.Text + @"
                                       AND pct.polo = " + txtPolo.Text + @"
                                       AND pct.turma = " + txtTurma.Text + @"
                                       AND pct.etapa = " + txtEtapa.Text;
                    else
                        auxWhere = @"WHERE pct.etapa = " + txtEtapa.Text;

                    sql.Append(@"
                    SELECT DISTINCT pct.etapa
                      FROM sga.projetos_cursos_turmas pct
                     " + auxWhere);

                    DataTable dtDados = new Conexao(Globals.GetStringConnection(), 2).ExecuteQuery(sql.ToString());

                    if (dtDados.Rows.Count == 1)
                    {
                        //se existe, não faz nada
                    }
                    else
                    {
                        txtEtapa.Text = "";
                    }
                }
                else
                {
                    //Se estiver criando um novo registro, deixa informar a turma que quiser
                }         
            }
            else
            {
                txtEtapa.Text = "";
            }
        }

        private void txtCurso_TextChanged(object sender, EventArgs e)
        {
            if (txtCurso.Text.Trim().Equals(""))
            {
                txtCursoDesc.Text = "";
                txtPolo.Text = "";
                txtPoloDesc.Text = "";
                txtTurma.Text = "";
                txtEtapa.Text = "";
            }
            else if (!txtCurso.Text.Trim().Equals("") && !txtCurso.Focused)
            {
                //Essa verificação serve para quando o valor do TextBox for definido através do método de 
                //preenchimento automático dos campos utilizando o Assistente de Cadastros
                txtCurso_Leave(sender, e);
            }
        }
        private void txtPolo_TextChanged(object sender, EventArgs e)
        {
            if (txtPolo.Text.Trim().Equals(""))
            {
                txtPoloDesc.Text = "";
                txtTurma.Text = "";
                txtEtapa.Text = "";
            }
            else if (!txtPolo.Text.Trim().Equals("") && !txtPolo.Focused)
            {
                //Essa verificação serve para quando o valor do TextBox for definido através do método de 
                //preenchimento automático dos campos utilizando o Assistente de Cadastros
                txtPolo_Leave(sender, e);
            }
        }
        private void txtTurma_TextChanged(object sender, EventArgs e)
        {
            if (txtTurma.Text.Trim().Equals(""))
            {
                txtEtapa.Text = "";
            }
        }

    }
}
