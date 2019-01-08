using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Windows.Forms.Uniube;
using System.Data;
using Classes.Dal;
using Classes.Entity;


namespace Classes.RecursosGenericos
{
    public static class EventosGenericos
    {

        public static void txtCustoDireto_KeyDown(KeyEventArgs e, TextBox txtCusto, TextBox txtDescricao)
        {
            if (e.KeyCode == Keys.F3 && !txtCusto.ReadOnly)
            {
                StringBuilder sql = new StringBuilder();

                sql.Append(@"
                SELECT cd.custo,
                       cd.descricao
                  FROM sga.custos_diretos cd
                 ORDER BY custo");

                FormBusca fb = new FormBusca(sql.ToString(), new List<OracleParameter>(), true, "Busca por Custos Diretos", "descricao", "", "Nenhum Registro Encontrado");
                fb.ShowDialog();

                if (fb.retorno != null)
                {
                    txtCusto.Text = fb.retorno["custo"].ToString();
                    txtCustoDireto_Leave(e, txtCusto, txtDescricao);
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                txtCustoDireto_Leave(e, txtCusto, txtDescricao);
            }
        }
        public static void txtCustoDireto_Leave(EventArgs e, TextBox txtCusto, TextBox txtDescricao)
        {
            if (!txtCusto.Text.Trim().Equals(""))
            {
                DataTable dt = BLL.BuscarSgaCustosDiretos(txtCusto.Text);

                if (dt.Rows.Count == 1)
                {
                    txtDescricao.Text = dt.Rows[0]["descricao"].ToString();
                }
                else
                {
                    txtCusto.Text = "";
                    txtDescricao.Text = "";
                }
            }
            else
            {
                txtCusto.Text = "";
                txtDescricao.Text = "";
            }
        }

        public static void txtItemCustoDireto_KeyDown(KeyEventArgs e, TextBox txtItem, TextBox txtDescricao)
        {
            if (e.KeyCode == Keys.F3 && !txtItem.ReadOnly)
            {
                StringBuilder sql = new StringBuilder();

                sql.Append(@"
                SELECT icd.item, icd.descricao
                  FROM sga.Itens_Custos_Diretos icd
                 ORDER BY item");

                FormBusca fb = new FormBusca(sql.ToString(), new List<OracleParameter>(), true, "Busca por Itens de Custos Diretos", "descricao", "", "Nenhum Registro Encontrado");
                fb.ShowDialog();

                if (fb.retorno != null)
                {
                    txtItem.Text = fb.retorno["item"].ToString();
                    txtItemCustoDireto_Leave(e, txtItem, txtDescricao);
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                txtItemCustoDireto_Leave(e, txtItem, txtDescricao);
            }
        }
        public static void txtItemCustoDireto_Leave(EventArgs e, TextBox txtItem, TextBox txtDescricao)
        {
            if (!txtItem.Text.Trim().Equals(""))
            {
                DataTable dt = BLL.BuscarSgaItensCustosDiretos(txtItem.Text);

                if (dt.Rows.Count == 1)
                {
                    txtDescricao.Text = dt.Rows[0]["descricao"].ToString();
                }
                else
                {
                    txtItem.Text = "";
                    txtDescricao.Text = "";
                }
            }
            else
            {
                txtItem.Text = "";
                txtDescricao.Text = "";
            }
        }

        public static void txtUnidadeCustoDireto_KeyDown(KeyEventArgs e, TextBox txtUnidade, TextBox txtDescricao)
        {
            if (e.KeyCode == Keys.F3 && !txtUnidade.ReadOnly)
            {
                StringBuilder sql = new StringBuilder();

                sql.Append(@"
                 SELECT ucd.unidade, ucd.descricao
                   FROM sga.Unidades_Custos_Diretos ucd
               ORDER BY unidade");

                FormBusca fb = new FormBusca(sql.ToString(), new List<OracleParameter>(), true, "Busca por Unidades de Custos Diretos", "descricao", "", "Nenhum Registro Encontrado");
                fb.ShowDialog();

                if (fb.retorno != null)
                {
                    txtUnidade.Text = fb.retorno["unidade"].ToString();
                    txtUnidadeCustoDireto_Leave(e, txtUnidade, txtDescricao);
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                txtUnidadeCustoDireto_Leave(e, txtUnidade, txtDescricao);
            }
        }
        public static void txtUnidadeCustoDireto_Leave(EventArgs e, TextBox txtUnidade, TextBox txtDescricao)
        {
            if (!txtUnidade.Text.Trim().Equals(""))
            {
                DataTable dt = BLL.BuscarSgaUnidadesCustosDiretos(txtUnidade.Text);

                if (dt.Rows.Count == 1)
                {
                    txtDescricao.Text = dt.Rows[0]["descricao"].ToString();
                }
                else
                {
                    txtUnidade.Text = "";
                    txtDescricao.Text = "";
                }
            }
            else
            {
                txtUnidade.Text = "";
                txtDescricao.Text = "";
            }
        }

        public static void txtPolo_KeyDown(KeyEventArgs e, TextBox txtPolo, TextBox txtPoloDesc = null)
        {
            if (e.KeyCode == Keys.F3 && !txtPolo.ReadOnly)
            {
                StringBuilder sql = new StringBuilder();

                string auxWhere = " WHERE nvl(p.presencial, 0) = 1";


                sql.Append(@"SELECT p.polo, p.descricao 
                               FROM sga.polos p 
                                " + auxWhere + @"
                              ORDER BY p.polo");

                FormBusca fb = new FormBusca(sql.ToString(), new List<OracleParameter>(), true, "Busca por Polos", "descricao", "", "Nenhum Registro Encontrado", true);
                fb.ShowDialog();

                if (fb.retorno != null)
                {
                    txtPolo.Text = fb.retorno["polo"].ToString();

                    if (txtPoloDesc != null)
                    {
                        txtPoloDesc.Text = fb.retorno["descricao"].ToString();
                    }
                }
            }
        }
        public static void txtPolo_Leave(EventArgs e, TextBox txtPolo, TextBox txtPoloDesc)
        {
            if (!string.IsNullOrEmpty(txtPolo.Text.Trim()))
            {
                DataTable dtDados = BLL.BuscarSgaPolos(txtPolo.Text);

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
        }

        public static void txtNucleo_KeyDown(KeyEventArgs e, object polo, TextBox txtNucleo, TextBox txtNucleoDesc = null)
        {
            if (e.KeyCode == Keys.F3 && !txtNucleo.ReadOnly)
            {
                StringBuilder sql = new StringBuilder();

                sql.Append(@"SELECT n.nucleo, n.descricao FROM sga.nucleos n WHERE n.polo = " + polo + " ORDER BY n.nucleo");

                FormBusca fb = new FormBusca(sql.ToString(), new List<OracleParameter>(), true, "Busca por Núcleos", "descricao", "", "Nenhum Registro Encontrado", true);
                fb.ShowDialog();

                if (fb.retorno != null)
                {
                    txtNucleo.Text = fb.retorno["nucleo"].ToString();
                    txtNucleo_Leave(e, polo, txtNucleo, txtNucleoDesc);
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                txtNucleo_Leave(e, polo, txtNucleo, txtNucleoDesc);
            }
        }
        public static void txtNucleo_Leave(EventArgs e, object polo, TextBox txtNucleo, TextBox txtNucleoDesc)
        {
            if (!string.IsNullOrEmpty(polo.ToString().Trim()) && !string.IsNullOrEmpty(txtNucleo.Text.Trim()))
            {
                DataTable dtDados = BLL.BuscarSgaNucleos(polo, txtNucleo.Text);

                if (dtDados.Rows.Count == 1)
                {
                    txtNucleoDesc.Text = dtDados.Rows[0]["descricao"].ToString();
                }
                else
                {
                    txtNucleo.Text = "";
                    txtNucleoDesc.Text = "";
                }
            }
            else
            {
                txtNucleo.Text = "";
                txtNucleoDesc.Text = "";
            }
        }

        public static void txtCurso_KeyDown(KeyEventArgs e, TextBox txtCurso, TextBox txtCursoDesc = null, bool apenasAtivos = false)
        {
            if (e.KeyCode == Keys.F3 && !txtCurso.ReadOnly)
            {
                string auxWhere = " WHERE c.tipo IN (3, 4) ";

                if (apenasAtivos)
                    auxWhere += " AND c.ativo = 1";

                StringBuilder sql = new StringBuilder();
                sql.Append(@"
                SELECT c.curso,
                       c.desc_psel AS descricao,
                       ct.descricao AS tipo,
                       decode(c.ativo,
                                1,
                                'SIM',
                                'NÃO') AS ativo
                  FROM sga.cursos c
                  JOIN sga.cursos_tipos ct ON (ct.curso_tipo = c.tipo)
                 " + auxWhere + @"
                 ORDER BY c.curso");

                FormBusca fb = new FormBusca(sql.ToString(), new List<OracleParameter>(), true, "Busca por Cursos Ativos", "descricao", "", "Nenhum Registro Encontrado", true);
                fb.ShowDialog();

                if (fb.retorno != null)
                {
                    txtCurso.Text = fb.retorno["curso"].ToString();
                    txtCurso_Leave(e, txtCurso, txtCursoDesc);
                    SendKeys.Send("{TAB}");
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                txtCurso_Leave(e, txtCurso, txtCursoDesc, apenasAtivos);
            }
        }
        public static void txtCurso_Leave(EventArgs e, TextBox txtCurso, TextBox txtCursoDesc, bool apenasAtivos = false)
        {
            if (!string.IsNullOrEmpty(txtCurso.Text))
            {
                DataTable dtDados = BLL.BuscarSgaCursos(txtCurso.Text);

                if (dtDados.Rows.Count == 1)
                {
                    //implementação da mesma regra utilizada no KeyDown
                    if (new string[] { "3", "4" }.Contains(dtDados.Rows[0]["tipo"].ToString()))
                    {
                        if (apenasAtivos)
                        {
                            if (dtDados.Rows[0]["ativo"].ToString().Equals("1"))
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
                            txtCursoDesc.Text = dtDados.Rows[0]["descricao"].ToString();
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
            }
            else
            {
                txtCurso.Text = "";
                txtCursoDesc.Text = "";
            }
        }

        public static void txtTurmaProjetosCursos_KeyDown(KeyEventArgs e, TextBox txtTurma, object curso, object polo)
        {
            if (e.KeyCode == Keys.F3 && !txtTurma.ReadOnly)
            {
                if (curso != null && polo != null && !curso.ToString().Equals("") && !polo.ToString().Equals(""))
                {
                    StringBuilder sql = new StringBuilder();

                    sql.Append(@"
                    SELECT DISTINCT turma
                      FROM sga.Projetos_Cursos_Turmas
                     WHERE curso = " + curso + @"
                       AND polo = " + polo + @"
                     ORDER BY turma");

                    FormBusca fb = new FormBusca(sql.ToString(), new List<OracleParameter>(), true, "Busca por Turmas", "turma", "", "Nenhum Registro Encontrado", true);
                    fb.ShowDialog();

                    if (fb.retorno != null)
                    {
                        txtTurma.Text = fb.retorno["turma"].ToString();
                    }
                }
            }
        }
        public static void txtTurmaProjetosCursos_Leave(EventArgs e, TextBoxUniube txtTurma, string p, string p_2)
        {

        }

        public static void txtEtapaProjetosCursos_KeyDown(KeyEventArgs e, TextBox txtEtapa, object curso, object polo, object turma)
        {
            if (e.KeyCode == Keys.F3 && !txtEtapa.ReadOnly)
            {
                if (curso != null && polo != null && turma != null && !curso.ToString().Equals("") && !polo.ToString().Equals("") && !turma.ToString().Equals(""))
                {
                    StringBuilder sql = new StringBuilder();

                    sql.Append(@"
                    SELECT DISTINCT etapa
                      FROM sga.Projetos_Cursos_Turmas
                     WHERE curso = " + curso + @"
                       AND polo = " + polo + @"
                       AND turma = " + turma + @"
                     ORDER BY etapa");

                    FormBusca fb = new FormBusca(sql.ToString(), new List<OracleParameter>(), true, "Busca por Etapas", "etapa", "", "Nenhum Registro Encontrado", true);
                    fb.ShowDialog();

                    if (fb.retorno != null)
                    {
                        txtEtapa.Text = fb.retorno["etapa"].ToString();
                    }
                }
            }
        }
        public static void txtEtapaProjetosCursos_Leave(KeyEventArgs e, TextBox txtEtapa, object curso, object polo, object turma)
        {

        }

        public static void txtCoordenador_KeyDown(KeyEventArgs e, TextBox txtCoordenador, TextBox txtCoordenadorD = null)
        {
            if (e.KeyCode == Keys.F3 && !txtCoordenador.ReadOnly)
            {
                StringBuilder sql = new StringBuilder();

                sql.Append(@"
                SELECT d.matricula as coordenador,
                       d.colaborador as nome
                  FROM sga.docentes d
                 WHERE nvl(ativo,0) = 1
                 ORDER BY d.colaborador");

                FormBusca fb = new FormBusca(sql.ToString(), new List<OracleParameter>(), true, "Busca por Coordenadores", "coordenador", "", "Nenhum Registro Encontrado", true);
                fb.ShowDialog();

                if (fb.retorno != null)
                {
                    txtCoordenador.Text = fb.retorno["coordenador"].ToString();
                    txtCoordenador_Leave(e, txtCoordenador, txtCoordenadorD);
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                txtCoordenador_Leave(e, txtCoordenador, txtCoordenadorD);
            }
        }
        public static void txtCoordenador_Leave(EventArgs e, TextBox txtCoordenador, TextBox txtCoordenadorD)
        {
            if (!string.IsNullOrEmpty(txtCoordenador.Text))
            {
                DataTable dtDados = BLL.BuscarSgaDocentes(txtCoordenador.Text);

                if (dtDados.Rows.Count == 1)
                {
                    txtCoordenadorD.Text = dtDados.Rows[0]["nome"].ToString();
                }
                else
                {
                    txtCoordenador.Text = "";
                    txtCoordenadorD.Text = "";
                }
            }
            else
            {
                txtCoordenador.Text = "";
                txtCoordenadorD.Text = "";
            }
        }


    }
}

