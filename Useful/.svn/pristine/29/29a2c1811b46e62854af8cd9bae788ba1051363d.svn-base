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
    public partial class grpCustosDiretosCursos : UserControlUniube
    {

        public grpCustosDiretosCursos()
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
            txtItem_Leave(txtItem, null);
            txtCusto_Leave(txtCusto, null);
            txtUnidade_Leave(txtUnidade, null);
        }

        private void txtPolo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3 &&
                !((TextBoxUniube)(sender)).ReadOnly &&
                ((this.ControlarIntegridade && !txtCurso.Text.Trim().Equals("")) || !this.ControlarIntegridade))
            {
                StringBuilder sql = new StringBuilder();
                string msgNaoEncontrado = "Nenhum registro encontrado.";
                if (((FormUniube)this.ParentForm).AcaoFormulario != FormUniube.CAcaoFormulario.Novo)
                {
                    string auxWhere = "";
                    if (this.ControlarIntegridade)
                        auxWhere = "WHERE cdc.curso = " + txtCurso.Text;

                    sql.Append(@"
                    SELECT DISTINCT cdc.polo,
                                    p.descricao, 
                                    pa.razao_social AS parceiro
                      FROM sga.Custos_Diretos_cursos cdc
                      JOIN sga.polos p ON (p.polo = cdc.polo)
                      LEFT JOIN sga.parceiros pa ON (pa.parceiro = p.parceiro)
                     " + auxWhere + @"
                     ORDER BY cdc.polo");
                    msgNaoEncontrado = @"Nenhum Polo encontrado para a condição informada. " + Environment.NewLine + auxWhere.Replace("cdc.", "").Replace("WHERE", "").Replace("AND", "").Trim().ToUpper();
                }
                else
                {
                    sql.Append(@"
                    SELECT DISTINCT pct.polo,
                                    p.descricao, 
                                    pa.razao_social AS parceiro
                      FROM sga.projetos_cursos_turmas pct
                      JOIN sga.polos p ON (p.polo = pct.polo)
                      LEFT JOIN sga.parceiros pa ON (pa.parceiro = p.parceiro)
                     ORDER BY pct.polo");
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
                        auxWhere = @"WHERE cdc.curso = " + txtCurso.Text + @"
                                       AND cdc.polo = " + txtPolo.Text;
                    else
                        auxWhere = @"WHERE cdc.polo = " + txtPolo.Text;

                    sql.Append(@"
                    SELECT DISTINCT cdc.polo,
                                    p.descricao
                      FROM sga.Custos_Diretos_cursos cdc
                      JOIN sga.polos p ON (p.polo = cdc.polo)
                     " + auxWhere);
                }
                else
                {
                    sql.Append(@"
                    SELECT DISTINCT pct.polo,
                                    p.descricao
                      FROM sga.projetos_cursos_turmas pct
                      JOIN sga.polos p ON (p.polo = pct.polo)
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
            txtItem_Leave(txtItem, null);
            txtCusto_Leave(txtCusto, null);
            txtUnidade_Leave(txtUnidade, null);
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
                string msgNaoEncontrado = "Nenhum registro encontrado.";

                string auxWhere = "";
                if (((FormUniube)this.ParentForm).AcaoFormulario != FormUniube.CAcaoFormulario.Novo)
                {
                    if (this.ControlarIntegridade)
                        auxWhere = @"WHERE cdc.curso = " + txtCurso.Text + @"
                                       AND cdc.polo = " + txtPolo.Text;
                    sql.Append(@"
                    SELECT DISTINCT cdc.turma
                      FROM sga.Custos_Diretos_cursos cdc
                     " + auxWhere + @"
                     ORDER BY cdc.turma");
                }
                else
                {
                    if (this.ControlarIntegridade)
                        auxWhere = @"WHERE pct.curso = " + txtCurso.Text + @"
                                       AND pct.polo = " + txtPolo.Text;
                    sql.Append(@"
                    SELECT DISTINCT pct.turma
                      FROM sga.projetos_cursos_turmas pct
                     " + auxWhere + @"
                     ORDER BY pct.turma");
                }

                msgNaoEncontrado = @"Nenhuma Turma encontrada para: " + Environment.NewLine + auxWhere.Replace("cdc.", "").Replace("WHERE", "").Replace("AND", "").Trim().ToUpper();

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
                string auxWhere = "";
                StringBuilder sql = new StringBuilder();
                if (((FormUniube)this.ParentForm).AcaoFormulario != FormUniube.CAcaoFormulario.Novo)
                {
                    if (this.ControlarIntegridade)
                        auxWhere = @"WHERE cdc.curso = " + txtCurso.Text + @"
                                       AND cdc.polo = " + txtPolo.Text + @"
                                       AND cdc.turma = " + txtTurma.Text;
                    else
                        auxWhere = @"WHERE cdc.turma = " + txtTurma.Text;

                    sql.Append(@"
                    SELECT DISTINCT cdc.turma
                      FROM sga.Custos_Diretos_cursos cdc
                     " + auxWhere);
                }
                else
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
                }

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
                txtTurma.Text = "";
            }

            txtEtapa_Leave(txtEtapa, null);
            txtItem_Leave(txtItem, null);
            txtCusto_Leave(txtCusto, null);
            txtUnidade_Leave(txtUnidade, null);
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
                string msgNaoEncontrado = "Nenhum registro encontrado.";
                string auxWhere = "";
                if (((FormUniube)this.ParentForm).AcaoFormulario != FormUniube.CAcaoFormulario.Novo)
                {

                    if (this.ControlarIntegridade)
                        auxWhere = @"WHERE cdc.curso = " + txtCurso.Text + @"
                                       AND cdc.polo = " + txtPolo.Text + @"
                                       AND cdc.turma = " + txtTurma.Text;

                    sql.Append(@"
                    SELECT DISTINCT cdc.etapa
                      FROM sga.Custos_Diretos_cursos cdc
                     " + auxWhere + @"
                     ORDER BY cdc.etapa");

                    msgNaoEncontrado = @"Nenhuma Etapa encontrada para: " + Environment.NewLine + auxWhere.Replace("cdc.", "").Replace("WHERE", "").Replace("AND", "").Trim().ToUpper();
                }
                else
                {
                    if (this.ControlarIntegridade)
                        auxWhere = @" WHERE pct.curso = " + txtCurso.Text + @"
                                        AND pct.polo = " + txtPolo.Text + @"
                                        AND pct.turma = " + txtTurma.Text;
                    sql.Append(@"
                    SELECT DISTINCT pct.etapa
                      FROM sga.projetos_cursos_turmas pct
                     " + auxWhere + @"
                     ORDER BY pct.etapa");
                }

                FormBusca fb = new FormBusca(sql.ToString(), new List<OracleParameter>(), true, "Busca por Etapas", "etapa", "", msgNaoEncontrado, true);
                fb.ShowDialog();

                if (fb.retorno != null)
                {
                    txtEtapa.Text = fb.retorno["etapa"].ToString();
                    txtItem.Focus();
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
                string auxWhere = "";
                StringBuilder sql = new StringBuilder();
                if (((FormUniube)this.ParentForm).AcaoFormulario != FormUniube.CAcaoFormulario.Novo)
                {
                    if (this.ControlarIntegridade)
                        auxWhere = @"WHERE cdc.curso = " + txtCurso.Text + @"
                                       AND cdc.polo = " + txtPolo.Text + @"
                                       AND cdc.turma = " + txtTurma.Text + @"
                                       AND cdc.etapa = " + txtEtapa.Text;
                    else
                        auxWhere = @"WHERE cdc.etapa = " + txtEtapa.Text;

                    sql.Append(@"
                    SELECT DISTINCT cdc.etapa
                      FROM sga.Custos_Diretos_cursos cdc
                     " + auxWhere);
                }
                else
                {
                    if (this.ControlarIntegridade)
                        auxWhere = @"WHERE pct.curso = " + txtCurso.Text + @"
                                       AND pct.polo = " + txtPolo.Text + @"
                                       AND pct.turma = " + txtTurma.Text + @"
                                       AND pct.etapa = " + txtEtapa.Text;

                    sql.Append(@"
                    SELECT DISTINCT pct.etapa
                      FROM sga.projetos_cursos_turmas pct
                     " + auxWhere);
                }

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
                txtEtapa.Text = "";
            }

            txtItem_Leave(txtItem, null);
            txtCusto_Leave(txtCusto, null);
            txtUnidade_Leave(txtUnidade, null);
        }

        private void txtItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3 &&
                !((TextBoxUniube)(sender)).ReadOnly &&
                ((this.ControlarIntegridade &&
                !txtCurso.Text.Trim().Equals("") &&
                !txtPolo.Text.Trim().Equals("") &&
                !txtTurma.Text.Trim().Equals("") &&
                !txtEtapa.Text.Trim().Equals("")) || !this.ControlarIntegridade))
            {
                StringBuilder sql = new StringBuilder();
                string auxWhere = "";
                string msgNaoEncontrado = "Nenhum registro encontrado.";
                if (((FormUniube)this.ParentForm).AcaoFormulario != FormUniube.CAcaoFormulario.Novo)
                {
                    if (this.ControlarIntegridade)
                        auxWhere += @"
                         WHERE cdc.curso = " + txtCurso.Text + @"
                           AND cdc.polo = " + txtPolo.Text + @"
                           AND cdc.turma = " + txtTurma.Text + @"
                           AND cdc.etapa = " + txtEtapa.Text + @"";

                    sql.Append(@"
                    SELECT DISTINCT cdc.item,
                                    icd.descricao
                      FROM sga.Custos_Diretos_cursos cdc
                      JOIN sga.itens_custos_diretos icd ON (icd.item = cdc.item)
                     " + auxWhere + @"
                     ORDER BY cdc.item");
                    msgNaoEncontrado = @"Nenhuma Turma encontrada para: " + Environment.NewLine + auxWhere.Replace("cdc.", "").Replace("WHERE", "").Replace("AND", "").Trim().ToUpper();
                }
                else
                {
                    sql.Append(@"
                    SELECT icd.item,
                           icd.descricao
                      FROM sga.itens_custos_diretos icd
                     ORDER BY icd.item");
                }

                FormBusca fb = new FormBusca(sql.ToString(), new List<OracleParameter>(), true, "Busca por Itens", "descricao", "", msgNaoEncontrado, true);
                fb.ShowDialog();

                if (fb.retorno != null)
                {
                    txtItem.Text = fb.retorno["item"].ToString();
                    txtCusto.Focus();
                }
            }
        }
        private void txtItem_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtItem.Text.Trim()) &&
                ((this.ControlarIntegridade &&
                !txtCurso.Text.Trim().Equals("") &&
                !txtPolo.Text.Trim().Equals("") &&
                !txtTurma.Text.Trim().Equals("") &&
                !txtEtapa.Text.Trim().Equals("")) || !this.ControlarIntegridade))
            {
                string auxWhere = "";
                StringBuilder sql = new StringBuilder();
                if (((FormUniube)this.ParentForm).AcaoFormulario != FormUniube.CAcaoFormulario.Novo)
                {
                    if (this.ControlarIntegridade)
                        auxWhere = @"WHERE cdc.curso = " + txtCurso.Text + @"
                                       AND cdc.polo = " + txtPolo.Text + @"
                                       AND cdc.turma = " + txtTurma.Text + @"
                                       AND cdc.etapa = " + txtEtapa.Text + @"
                                       AND cdc.item = " + txtItem.Text;
                    else
                        auxWhere = @"WHERE cdc.item = " + txtItem.Text;

                    sql.Append(@"
                    SELECT DISTINCT cdc.item,
                                    icd.descricao
                      FROM sga.Custos_Diretos_cursos cdc
                      JOIN sga.itens_custos_diretos icd ON (icd.item = cdc.item)
                     " + auxWhere);
                }
                else
                {
                    sql.Append(@"
                    SELECT icd.item,
                           icd.descricao
                      FROM sga.itens_custos_diretos icd
                     WHERE icd.item = " + txtItem.Text + @"
                     ORDER BY icd.item");
                }

                DataTable dtDados = new Conexao(Globals.GetStringConnection(), 2).ExecuteQuery(sql.ToString());

                if (dtDados.Rows.Count == 1)
                {
                    txtItemDesc.Text = dtDados.Rows[0]["descricao"].ToString();
                }
                else
                {
                    txtItem.Text = "";
                    txtItemDesc.Text = "";
                }
            }
            else
            {
                txtItem.Text = "";
                txtItemDesc.Text = "";
            }

            txtCusto_Leave(txtCusto, null);
            txtUnidade_Leave(txtUnidade, null);
        }

        private void txtCusto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3 &&
                !((TextBoxUniube)sender).ReadOnly &&
                ((this.ControlarIntegridade &&
                !txtCurso.Text.Trim().Equals("") &&
                !txtPolo.Text.Trim().Equals("") &&
                !txtTurma.Text.Trim().Equals("") &&
                !txtEtapa.Text.Trim().Equals("") &&
                !txtItem.Text.Trim().Equals("")) || !this.ControlarIntegridade))
            {
                StringBuilder sql = new StringBuilder();
                string auxWhere = "";
                string msgNaoEncontrado = "Nenhum registro encontrado.";
                if (((FormUniube)this.ParentForm).AcaoFormulario != FormUniube.CAcaoFormulario.Novo)
                {
                    if (this.ControlarIntegridade)
                        auxWhere = @"
                         WHERE cdc.curso = " + txtCurso.Text + @"
                           AND cdc.polo = " + txtPolo.Text + @"
                           AND cdc.turma = " + txtTurma.Text + @"
                           AND cdc.etapa = " + txtEtapa.Text + @"
                           AND cdc.item = " + txtItem.Text;

                    sql.Append(@"
                    SELECT DISTINCT cdc.custo,
                                    icd.descricao
                      FROM sga.Custos_Diretos_cursos cdc
                      JOIN sga.custos_diretos cd ON (cd.custo = cdc.custo)
                     " + auxWhere + @"
                     ORDER BY cdc.custo");
                }
                else
                {
                    sql.Append(@"
                    SELECT DISTINCT cd.custo,
                                    TRIM(cd.descricao) AS descricao
                      FROM sga.custos_diretos cd
                    ORDER BY cd.custo");
                }

                msgNaoEncontrado = @"Nenhum Custo encontrado para a condição informada. " + Environment.NewLine + auxWhere.Replace("cdc.", "").Replace("WHERE", "").Replace("AND", "").Trim().ToUpper();

                FormBusca fb = new FormBusca(sql.ToString(), new List<OracleParameter>(), true, "Busca por Custos Diretos", "descricao", "", msgNaoEncontrado);
                fb.ShowDialog();

                if (fb.retorno != null)
                {
                    txtCusto.Text = fb.retorno["custo"].ToString();
                    txtUnidade.Focus();
                }
            }
        }
        private void txtCusto_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCusto.Text.Trim()) &&
                ((this.ControlarIntegridade && 
                !txtCurso.Text.Trim().Equals("") &&
                !txtPolo.Text.Trim().Equals("") &&
                !txtTurma.Text.Trim().Equals("") &&
                !txtEtapa.Text.Trim().Equals("") &&
                !txtItem.Text.Trim().Equals("")) || !this.ControlarIntegridade))
            {
                string auxWhere = "";
                StringBuilder sql = new StringBuilder();
                if (((FormUniube)this.ParentForm).AcaoFormulario != FormUniube.CAcaoFormulario.Novo)
                {
                    if (this.ControlarIntegridade)
                        auxWhere = @" WHERE cdc.curso = " + txtCurso.Text + @"
                                        AND cdc.polo = " + txtPolo.Text + @"
                                        AND cdc.turma = " + txtTurma.Text + @"
                                        AND cdc.etapa = " + txtEtapa.Text + @"
                                        AND cdc.item = " + txtItem.Text + @"
                                        AND cdc.custo = " + txtCusto.Text;
                    else
                        auxWhere = @" WHERE cdc.custo = " + txtCusto.Text;

                    sql.Append(@"
                    SELECT DISTINCT cdc.custo,
                                    cd.descricao
                      FROM sga.Custos_Diretos_cursos cdc
                      JOIN sga.Custos_Diretos cd ON (cd.custo = cdc.custo)
                    " + auxWhere);
                }
                else
                {
                    sql.Append(@"
                    SELECT cd.custo,
                           cd.descricao
                      FROM sga.custos_diretos cd
                     WHERE cd.custo = " + txtCusto.Text);
                }

                DataTable dtDados = new Conexao(Globals.GetStringConnection(), 2).ExecuteQuery(sql.ToString());

                if (dtDados.Rows.Count == 1)
                {
                    txtCustoDesc.Text = dtDados.Rows[0]["descricao"].ToString();
                }
                else
                {
                    txtCusto.Text = "";
                    txtCustoDesc.Text = "";
                }
            }
            else
            {
                txtCusto.Text = "";
                txtCustoDesc.Text = "";
            }

            txtUnidade_Leave(txtUnidade, null);
        }

        private void txtUnidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3 &&
                !((TextBoxUniube)sender).ReadOnly &&
                ((this.ControlarIntegridade && 
                !txtCurso.Text.Trim().Equals("") &&
                !txtPolo.Text.Trim().Equals("") &&
                !txtTurma.Text.Trim().Equals("") &&
                !txtEtapa.Text.Trim().Equals("") &&
                !txtItem.Text.Trim().Equals("") &&
                !txtCusto.Text.Trim().Equals("")) || !this.ControlarIntegridade))
            {
                StringBuilder sql = new StringBuilder();
                string auxWhere = "";
                string msgNaoEncontrado = "Nenhum registro encontrado.";
                if (((FormUniube)this.ParentForm).AcaoFormulario != FormUniube.CAcaoFormulario.Novo)
                {
                    if (this.ControlarIntegridade)
                        auxWhere += @"
                         WHERE cdc.curso = " + txtCurso.Text + @"
                           AND cdc.polo = " + txtPolo.Text + @"
                           AND cdc.turma = " + txtTurma.Text + @"
                           AND cdc.etapa = " + txtEtapa.Text + @"
                           AND cdc.item = " + txtItem.Text + @"
                           AND cdc.custo = " + txtCusto.Text;

                    sql.Append(@"
                    SELECT DISTINCT cdc.unidade,
                                    trim(ucd.descricao) AS descricao
                      FROM sga.Custos_Diretos_cursos cdc
                      JOIN sga.unidades_custos_diretos ucd ON (ucd.unidade = cdc.unidade)
                     " + auxWhere + @"
                     ORDER BY cdc.unidade");
                    msgNaoEncontrado = @"Nenhum Custo encontrado para a condição informada. " + Environment.NewLine + auxWhere.Replace("cdc.", "").Replace("WHERE", "").Replace("AND", "").Trim().ToUpper();

                }
                else
                {
                    sql.Append(@"
                    SELECT ucd.unidade,
                           trim(ucd.descricao) AS descricao
                      FROM sga.unidades_custos_diretos ucd
                     ORDER BY ucd.unidade");
                }

                FormBusca fb = new FormBusca(sql.ToString(), new List<OracleParameter>(), true, "Busca por Custos Diretos", "descricao", "", msgNaoEncontrado);
                fb.ShowDialog();

                if (fb.retorno != null)
                {
                    txtUnidade.Text = fb.retorno["unidade"].ToString();
                    txtCurso.Focus();
                }
            }
        }
        private void txtUnidade_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUnidade.Text.Trim()) &&
                ((this.ControlarIntegridade &&
                !txtCurso.Text.Trim().Equals("") &&
                !txtPolo.Text.Trim().Equals("") &&
                !txtTurma.Text.Trim().Equals("") &&
                !txtEtapa.Text.Trim().Equals("") &&
                !txtItem.Text.Trim().Equals("") &&
                !txtCusto.Text.Trim().Equals("")) || !this.ControlarIntegridade))
            {
                string auxWhere = "";
                StringBuilder sql = new StringBuilder();
                if (((FormUniube)this.ParentForm).AcaoFormulario != FormUniube.CAcaoFormulario.Novo)
                {
                    if (this.ControlarIntegridade)
                        auxWhere = @" 
                                     WHERE cdc.curso = " + txtCurso.Text + @"
                                       AND cdc.polo = " + txtPolo.Text + @"
                                       AND cdc.turma = " + txtTurma.Text + @"
                                       AND cdc.etapa = " + txtEtapa.Text + @"
                                       AND cdc.item = " + txtItem.Text + @"
                                       AND cdc.custo = " + txtCusto.Text + @"
                                       AND cdc.unidade = " + txtUnidade.Text;
                    else
                        auxWhere = "WHERE cdc.unidade = " + txtUnidade.Text;

                    sql.Append(@"
                    SELECT DISTINCT cdc.unidade,
                                    ucd.descricao
                      FROM sga.Custos_Diretos_cursos cdc
                      JOIN sga.unidades_custos_diretos ucd ON (ucd.unidade = cdc.unidade)
                     " + auxWhere);
                }
                else
                {
                    sql.Append(@"
                    SELECT ucd.unidade,
                           ucd.descricao
                      FROM sga.unidades_custos_diretos ucd
                     WHERE ucd.unidade = " + txtUnidade.Text + @"
                     ORDER BY ucd.unidade");
                }

                DataTable dtDados = new Conexao(Globals.GetStringConnection(), 2).ExecuteQuery(sql.ToString());

                if (dtDados.Rows.Count == 1)
                {
                    txtUnidadeDesc.Text = dtDados.Rows[0]["descricao"].ToString();
                }
                else
                {
                    txtUnidade.Text = "";
                    txtUnidadeDesc.Text = "";
                }
            }
            else
            {
                txtUnidade.Text = "";
                txtUnidadeDesc.Text = "";
            }
        }

        private void txtCurso_TextChanged(object sender, EventArgs e)
        {
            if (((TextBoxUniube)(sender)).Text.Trim().Equals(""))
            {
                txtCursoDesc.Text = "";
                txtPolo.Text = "";
                txtPoloDesc.Text = "";
                txtTurma.Text = "";
                txtEtapa.Text = "";
                txtItem.Text = "";
                txtItemDesc.Text = "";
                txtCusto.Text = "";
                txtCustoDesc.Text = "";
                txtUnidade.Text = "";
                txtUnidadeDesc.Text = "";
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
            if (((TextBoxUniube)(sender)).Text.Trim().Equals(""))
            {
                txtPoloDesc.Text = "";
                txtTurma.Text = "";
                txtEtapa.Text = "";
                txtItem.Text = "";
                txtItemDesc.Text = "";
                txtCusto.Text = "";
                txtCustoDesc.Text = "";
                txtUnidade.Text = "";
                txtUnidadeDesc.Text = "";
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
            if (((TextBoxUniube)(sender)).Text.Trim().Equals(""))
            {
                txtEtapa.Text = "";
                txtItem.Text = "";
                txtItemDesc.Text = "";
                txtCusto.Text = "";
                txtCustoDesc.Text = "";
                txtUnidade.Text = "";
                txtUnidadeDesc.Text = "";
            }
            else if (!txtTurma.Text.Trim().Equals("") && !txtTurma.Focused)
            {
                //Essa verificação serve para quando o valor do TextBox for definido através do método de 
                //preenchimento automático dos campos utilizando o Assistente de Cadastros
                txtTurma_Leave(sender, e);
            }
        }
        private void txtEtapa_TextChanged(object sender, EventArgs e)
        {
            if (((TextBoxUniube)(sender)).Text.Trim().Equals(""))
            {
                txtItem.Text = "";
                txtItemDesc.Text = "";
                txtCusto.Text = "";
                txtCustoDesc.Text = "";
                txtUnidade.Text = "";
                txtUnidadeDesc.Text = "";
            }
            else if (!txtEtapa.Text.Trim().Equals("") && !txtEtapa.Focused)
            {
                //Essa verificação serve para quando o valor do TextBox for definido através do método de 
                //preenchimento automático dos campos utilizando o Assistente de Cadastros
                txtEtapa_Leave(sender, e);
            }
        }
        private void txtItem_TextChanged(object sender, EventArgs e)
        {
            if (((TextBoxUniube)(sender)).Text.Trim().Equals(""))
            {
                txtItemDesc.Text = "";
                txtCusto.Text = "";
                txtCustoDesc.Text = "";
                txtUnidade.Text = "";
                txtUnidadeDesc.Text = "";
            }
            else if (!txtItem.Text.Trim().Equals("") && !txtItem.Focused)
            {
                //Essa verificação serve para quando o valor do TextBox for definido através do método de 
                //preenchimento automático dos campos utilizando o Assistente de Cadastros
                txtItem_Leave(sender, e);
            }
        }
        private void txtCusto_TextChanged(object sender, EventArgs e)
        {
            if (((TextBoxUniube)(sender)).Text.Trim().Equals(""))
            {
                txtCusto.Text = "";
                txtCustoDesc.Text = "";
                txtUnidade.Text = "";
                txtUnidadeDesc.Text = "";
            }
            else if (!txtCusto.Text.Trim().Equals("") && !txtCusto.Focused)
            {
                //Essa verificação serve para quando o valor do TextBox for definido através do método de 
                //preenchimento automático dos campos utilizando o Assistente de Cadastros
                txtCusto_Leave(sender, e);
            }
        }
        private void txtUnidade_TextChanged(object sender, EventArgs e)
        {
            if (((TextBoxUniube)(sender)).Text.Trim().Equals(""))
            {
                txtUnidade.Text = "";
                txtUnidadeDesc.Text = "";
            }
            else if (!txtUnidade.Text.Trim().Equals("") && !txtUnidade.Focused)
            {
                //Essa verificação serve para quando o valor do TextBox for definido através do método de 
                //preenchimento automático dos campos utilizando o Assistente de Cadastros
                txtUnidade_Leave(sender, e);
            }
        }
    
    }
}
