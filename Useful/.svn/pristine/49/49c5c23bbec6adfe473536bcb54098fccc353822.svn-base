using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Classes.Dal;
using Classes.Entity;

namespace Classes.RecursosGenericos
{
    public class BLL
    {
        public static string GetModelSGA()
        {
            return "res://*/ModelSGA.csdl|res://*/ModelSGA.ssdl|res://*/ModelSGA.msl";
        }

        #region SGA
        public static DataTable BuscarSgaCustosDiretos(object custo)
        {
            DataTable dtRetorno = new DataTable();

            string auxWhere = " WHERE cd.custo IS NOT NULL ";

            if (custo != null && !string.IsNullOrEmpty(custo.ToString().Trim()))
            {
                auxWhere += " AND cd.custo = " + custo;
            }

            StringBuilder sql = new StringBuilder();
            sql.Append(@"
            SELECT cd.custo, trim(cd.descricao) as descricao
              FROM sga.custos_diretos cd
            " + auxWhere + @"
             ORDER BY custo");

            dtRetorno = new Conexao(Globals.GetStringConnection(), 2).ExecuteQuery(sql.ToString());

            return dtRetorno;
        }
        public static DataTable BuscarSgaUnidadesCustosDiretos(object unidade)
        {
            DataTable dtRetorno = new DataTable();

            string auxWhere = " WHERE ucd.unidade IS NOT NULL ";

            if (unidade != null && !string.IsNullOrEmpty(unidade.ToString().Trim()))
            {
                auxWhere += " AND ucd.unidade = " + unidade;
            }

            StringBuilder sql = new StringBuilder();
            sql.Append(@"
            SELECT ucd.*
              FROM sga.unidades_custos_diretos ucd
            " + auxWhere + @"
             ORDER BY unidade");

            dtRetorno = new Conexao(Globals.GetStringConnection(), 2).ExecuteQuery(sql.ToString());

            return dtRetorno;
        }
        public static DataTable BuscarSgaItensCustosDiretos(object item)
        {
            DataTable dtRetorno = new DataTable();

            string auxWhere = " WHERE icd.item IS NOT NULL ";

            if (item != null && !string.IsNullOrEmpty(item.ToString().Trim()))
            {
                auxWhere += " AND icd.item = " + item;
            }

            StringBuilder sql = new StringBuilder();
            sql.Append(@"
            SELECT icd.*
              FROM sga.itens_custos_diretos icd
            " + auxWhere + @"
             ORDER BY item");

            dtRetorno = new Conexao(Globals.GetStringConnection(), 2).ExecuteQuery(sql.ToString());

            return dtRetorno;
        }
        public static DataTable BuscarSgaAreasConcentracoesCursos(object area)
        {
            DataTable dtRetorno = new DataTable();

            string auxWhere = " WHERE a.area IS NOT NULL ";

            if (area != null && !string.IsNullOrEmpty(area.ToString().Trim()))
            {
                auxWhere += " AND a.area = " + area;
            }

            StringBuilder sql = new StringBuilder();
            sql.Append(@"
            SELECT a.area, trim(a.descricao) AS descricao
              FROM sga.areas a
            " + auxWhere + @"
             ORDER BY area");

            dtRetorno = new Conexao(Globals.GetStringConnection(), 2).ExecuteQuery(sql.ToString());

            return dtRetorno;
        }
        public static DataTable BuscarSgaDocentes(object matricula)
        {
            DataTable dtRetorno = new DataTable();

            string auxWhere = " WHERE d.matricula IS NOT NULL ";

            if (matricula != null && !string.IsNullOrEmpty(matricula.ToString().Trim()))
            {
                auxWhere += " AND a.matricula = " + matricula;
            }

            StringBuilder sql = new StringBuilder();
            sql.Append(@"
            SELECT d.origem,
                   d.matricula,
                   d.colaborador AS nome,
                   d.dt_admissao,
                   d.dt_demissao,
                   d.categoria,
                   d.dt_nascimento,
                   d.foneres,
                   d.celular,
                   d.naturalidade,
                   d.endereco,
                   d.complemento,
                   d.numero,
                   d.cep,
                   d.bairro,
                   d.nm_cidade,
                   d.sexo,
                   d.email,
                   d.download,
                   d.cpf,
                   d.rg,
                   d.rg_dt_emissao,         
                   d.rg_orgao_exp,
                   d.rg_uf_exp,
                   d.eleitor,
                   d.zona,
                   d.secao,
                   d.ctps,
                   d.uf_ctps,
                   d.pis,
                   d.escolaridade,
                   d.ds_escolaridade,
                   d.estado_civil,
                   d.ds_estado_civil,
                   d.ds_cargo  AS cargo_desc,
                   d.centro_custo,
                   d.centro_custo_3,
                   d.no_campus,
                   d.curso,
                   d.ativo,
                   d.cnpq1,
                   d.cnpq2,
                   d.ficticio,
                   d.email_corporativo,
                   d.nacionalidade,
                   d.pais_origem,
                   d.licenciado,
                   d.lic_dt_inicial,
                   d.lic_dt_final
              FROM sga.docentes d
            " + auxWhere + @"
             ORDER BY d.matricula");

            dtRetorno = new Conexao(Globals.GetStringConnection(), 2).ExecuteQuery(sql.ToString());

            return dtRetorno;
        }

        public static DataTable BuscarSgaConceitos(object conceito)
        {
            DataTable dtRetorno = new DataTable();

            string auxWhere = " WHERE c.conceito IS NOT NULL ";

            if (conceito != null && !string.IsNullOrEmpty(conceito.ToString().Trim()))
            {
                auxWhere += " AND c.conceito = " + conceito;
            }

            StringBuilder sql = new StringBuilder();
            sql.Append(@"
            SELECT c.conceito, c.descricao
              FROM sga.conceitos c
            " + auxWhere + @"
             ORDER BY conceito");

            dtRetorno = new Conexao(Globals.GetStringConnection(), 2).ExecuteQuery(sql.ToString());

            return dtRetorno;
        }
        public static DataTable BuscarSgaResponsabilidades(object responsabilidade)
        {
            DataTable dtRetorno = new DataTable();

            string auxWhere = " WHERE r.responsabilidade IS NOT NULL ";

            if (responsabilidade != null && !string.IsNullOrEmpty(responsabilidade.ToString().Trim()))
            {
                auxWhere += " AND r.responsabilidade = " + responsabilidade;
            }

            StringBuilder sql = new StringBuilder();
            sql.Append(@"
            SELECT r.responsabilidade, r.descricao
              FROM sga.responsabilidades r
            " + auxWhere + @"
             ORDER BY responsabilidade");

            dtRetorno = new Conexao(Globals.GetStringConnection(), 2).ExecuteQuery(sql.ToString());

            return dtRetorno;
        }
        public static DataTable BuscarSgaCargosResponsabilidades(object cargo)
        {
            DataTable dtRetorno = new DataTable();

            string auxWhere = " WHERE cr.cargo IS NOT NULL ";

            if (cargo != null && !string.IsNullOrEmpty(cargo.ToString().Trim()))
            {
                auxWhere += " AND cr.cargo = " + cargo;
            }

            StringBuilder sql = new StringBuilder();
            sql.Append(@"
            SELECT cr.cargo, cr.descricao, cr.tipo, decode(cr.tipo, 1, 'REITORIA', 2, 'DIRETORIA', '[INDEFINIDO]') AS tipo_desc
              FROM sga.cargos_responsabilidades cr
            " + auxWhere + @"
             ORDER BY cargo");

            dtRetorno = new Conexao(Globals.GetStringConnection(), 2).ExecuteQuery(sql.ToString());

            return dtRetorno;
        }
        public static DataTable BuscarSgaPolos(object polo = null)
        {
            //Implementado em 29/01/2013 por Junior Carvalho Brolini

            DataTable dtRetorno = new DataTable();
            Conexao dal = new Conexao(Globals.GetStringConnection(), 2);
            StringBuilder sql = new StringBuilder();

            string auxWhere = " WHERE nvl(p.presencial, 0) = 1";
            if (polo != null && !string.IsNullOrEmpty(polo.ToString().Trim()))
            {
                auxWhere += " AND p.polo = " + polo;
            }

            sql.Append(@"
            SELECT DISTINCT p.polo,
                   p.descricao,
                   p.cidade,
                   p.parceiro,
                   p.status,
                   p.presencial,
                   p.ativo,
                   p.desc_reduzida,
                   p.repasse_data,
                   p.repasse_percentual,
                   p.pos
              FROM sga.polos p
             " + auxWhere);

            dtRetorno = dal.ExecuteQuery(sql.ToString());

            return dtRetorno;
        }
        public static DataTable BuscarSgaNucleos(object polo = null, object nucleo = null)
        {
            //Implementado em 29/01/2013 por Junior Carvalho Brolini

            DataTable dtRetorno = new DataTable();
            Conexao dal = new Conexao(Globals.GetStringConnection(), 2);
            StringBuilder sql = new StringBuilder();

            string auxWhere = " WHERE p.polo IS NOT NULL";
            if (polo != null && !string.IsNullOrEmpty(polo.ToString().Trim()))
            {
                auxWhere += " AND p.polo = " + polo;
            }
            if (nucleo != null && !string.IsNullOrEmpty(nucleo.ToString().Trim()))
            {
                auxWhere += " AND n.nucleo = " + nucleo;
            }

            sql.Append(@"
            SELECT DISTINCT n.polo,
                   n.nucleo,
                   n.cidade,
                   n.status,
                   n.parceiro,
                   n.descricao,
                   n.observacao,
                   n.formulario1,
                   n.formulario13,
                   n.contrato_social,
                   n.alvara,
                   n.certidao_negativa,
                   n.identidade,
                   n.cpf_doc,
                   n.estrutura,
                   n.doc_estrutura,
                   n.minuta,
                   n.anexo1,
                   n.anexo2,
                   n.formalizacao,
                   n.observacao_doc,
                   n.formulario1r,
                   n.anexo3,
                   n.planilha,
                   n.centro_custo,
                   n.curso_contabil,
                   n.logradouro,
                   n.numero,
                   n.complemento,
                   n.bairro,
                   n.cep,
                   n.telefone,
                   n.celular,
                   n.email,
                   n.ativo,
                   n.desc_reduzida,
                   n.contato,
                   n.nucleo_externo,
                   n.repasse_data,
                   n.repasse_percentual,
                   n.pos,
                   n.bloqueio_ava,
                   n.inep,
                   n.qt_dias_entrega,
                   n.supervisor,
                   n.seq_nucleo,
                   n.campus_estacionamento
              FROM sga.polos p
              JOIN sga.nucleos n ON (n.polo = p.polo)
             " + auxWhere);

            dtRetorno = dal.ExecuteQuery(sql.ToString());

            return dtRetorno;
        }
        public static DataTable BuscarSgaCursos(object curso)
        {
            Conexao dal = new Conexao(Globals.GetStringConnection(), 2);

            StringBuilder sql = new StringBuilder();
            sql.Append(@"
            SELECT c.curso,
                   c.descricao,
                   c.nome_reduzido,
                   c.responsavel,
                   c.ativo,
                   c.tipo,
                   c.cod_enade,
                   c.area,
                   c.modalidade,
                   c.curso_tipo,
                   c.curso_unificado,
                   c.diretor,
                   c.secretaria,
                   c.centro_custo,
                   c.curso_contabil,
                   c.desc_psel,
                   c.email,
                   c.perfil,
                   c.area_site,
                   c.tipo_contabilizacao_esp,
                   c.virtual,
                   c.enade_licenciatura,
                   c.enade_diploma,
                   c.curso_externo,
                   c.semestre_aberto,
                   c.telefone,
                   c.descritivo,
                   c.perfil_egresso,
                   c.situacao_legal,
                   c.momentos_presenciais,
                   c.avaliacao_aprendizagem,
                   c.atividades_complementares,
                   c.estagio_supervisionado,
                   c.materiais_estudos,
                   c.inicio_funcionamento,
                   c.ch_min_matricula,
                   c.ch_max_matricula,
                   c.companhia_contabil,
                   c.curso_bi,
                   c.tipo_virtual,
                   c.curso_biblioteca,
                   c.turno,
                   c.bonus,
                   c.pts_portfolio_acqa,
                   c.titulacao_minima,
                   c.prateleira,
                   c.pontualidade_especial
              FROM sga.cursos c
             WHERE c.curso = " + curso);

            DataTable dtRetorno = dal.ExecuteQuery(sql.ToString());

            return dtRetorno;
        }

        public static DataTable BuscarSgaProjetosCursosTurmas(object polo, object curso, object turma, object etapa)
        {
            Conexao dal = new Conexao(Globals.GetStringConnection(), 2);
            StringBuilder sql = new StringBuilder();

            string auxWhere = "WHERE pct.polo IS NOT NULL";
            if (polo != null && !polo.ToString().Trim().Equals(""))
                auxWhere += " AND pct.polo = " + polo;
            if (curso != null && !curso.ToString().Trim().Equals(""))
                auxWhere += " AND pct.curso = " + curso;
            if (turma != null && !turma.ToString().Trim().Equals(""))
                auxWhere += " AND pct.turma = " + turma;
            if (etapa != null && !etapa.ToString().Trim().Equals(""))
                auxWhere += " AND pct.etapa = " + etapa;

            sql.Append(@"
            SELECT pct.curso,
                   trim(c.descricao)       AS curso_desc,
                   c.curso_contabil  AS centro_curso,
                   pct.polo,
                   trim(p.descricao)       AS polo_desc,
                   pct.turma,
                   pct.descricao,
                   pct.realizacao,
                   pct.duracao,
                   pct.participantes,
                   pct.coordenador,
                   trim(d.colaborador)     AS coordenador_nome,
                   pct.carga_horaria,
                   pct.dt_inicio,
                   pct.etapa
              FROM sga.projetos_cursos_turmas pct
              JOIN sga.cursos c ON (c.curso = pct.curso)
              JOIN sga.polos p ON (p.polo = pct.polo)
              LEFT JOIN sga.docentes d ON (d.matricula = pct.coordenador)
              " + auxWhere + @"
             ORDER BY pct.curso, pct.polo, pct.turma, pct.etapa");

            DataTable dt = dal.ExecuteQuery(sql.ToString());

            return dt;
        }
        public static DataTable BuscarSgaCustosDiretosCursos(object curso,
                                                  object polo,
                                                  object turma,
                                                  object custo,
                                                  object item,
                                                  object unidade,
                                                  object etapa,
                                                  object tc,
                                                  object classificacao,
                                                  object quantidadeInicial,
                                                  object quantidadeFinal,
                                                  object valorUnitarioInicial,
                                                  object valorUnitarioFinal,
                                                  object percentualInicial,
                                                  object percentualFinal)
        {
            DataTable dtRetorno = new DataTable();

            string auxWhere = " WHERE cdc.curso IS NOT NULL ";

            if (curso != null && !curso.ToString().Equals(""))
                auxWhere += " AND cdc.curso = " + curso;
            if (polo != null && !polo.ToString().Equals(""))
                auxWhere += " AND cdc.polo = " + polo;
            if (turma != null && !turma.ToString().Equals(""))
                auxWhere += " AND cdc.turma = " + turma;
            if (custo != null && !custo.ToString().Equals(""))
                auxWhere += " AND cdc.custo = " + custo;
            if (item != null && !item.ToString().Equals(""))
                auxWhere += " AND cdc.item = " + item;
            if (unidade != null && !unidade.ToString().Equals(""))
                auxWhere += " AND cdc.unidade = " + unidade;
            if (etapa != null && !etapa.ToString().Equals(""))
                auxWhere += " AND cdc.etapa = " + etapa;
            if (tc != null && !tc.ToString().Equals(""))
                auxWhere += " AND cdc.tc = " + tc;
            if (classificacao != null && !classificacao.ToString().Equals(""))
                auxWhere += " AND cdc.classificacao = " + classificacao;

            if (quantidadeInicial != null && !quantidadeInicial.ToString().Equals(""))
                auxWhere += " AND cdc.qtde >= " + quantidadeInicial;
            if (quantidadeFinal != null && !quantidadeFinal.ToString().Equals(""))
                auxWhere += " AND cdc.qtde <= " + quantidadeFinal;

            if (valorUnitarioInicial != null && !valorUnitarioInicial.ToString().Equals(""))
                auxWhere += " AND cdc.vl_unitario >= " + valorUnitarioInicial;
            if (valorUnitarioFinal != null && !valorUnitarioFinal.ToString().Equals(""))
                auxWhere += " AND cdc.vl_unitario <= " + valorUnitarioFinal;

            if (percentualInicial != null && !percentualInicial.ToString().Equals(""))
                auxWhere += " AND cdc.percentual >= " + percentualInicial;
            if (percentualFinal != null && !percentualFinal.ToString().Equals(""))
                auxWhere += " AND cdc.percentual <= " + percentualFinal;



            StringBuilder sql = new StringBuilder();
            sql.Append(@"
            SELECT cdc.polo,
                   TRIM(c.descricao) AS curso_desc,
                   cdc.curso,
                   TRIM(p.descricao) AS polo_desc,
                   cdc.turma,
                   cdc.custo,
                   trim( cd.descricao) AS custo_desc,
                   cdc.item,
                   trim(idc.descricao) AS item_desc,
                   cdc.unidade,
                   trim(ucd.descricao) AS unidade_desc,
                   cdc.qtde,
                   cdc.vl_unitario,
                   nvl(cdc.qtde,0) * nvl(cdc.vl_unitario,0) AS vl_total,                   
                   cdc.classificacao,               
                   decode(cdc.classificacao, 1, 'FIXO', 2, 'VARIÁVEL', '[INDEFINIDO]') AS classificacao_desc,
                   cdc.tc,
                   cdc.percentual,
                   cdc.etapa,
                   cdc.carga_horaria
              FROM sga.custos_diretos_cursos cdc
              JOIN sga.cursos c ON (c.curso = cdc.curso)
              JOIN sga.polos p ON (p.polo = cdc.polo)
              JOIN sga.Custos_Diretos cd ON (cd.custo = cdc.custo)
              JOIN sga.itens_custos_diretos idc ON (idc.item = cdc.item)
              JOIN sga.Unidades_Custos_Diretos ucd ON (ucd.unidade = cdc.unidade)
            " + auxWhere + @"
             ORDER BY cdc.curso");

            dtRetorno = new Conexao(Globals.GetStringConnection(), 2).ExecuteQuery(sql.ToString());

            return dtRetorno;

        }
        public static DataTable BuscarSgaPropostasPrecos(object curso, object polo, object turma, object custo, object item, object etapa)
        {
            DataTable dtRetorno = new DataTable();

            string auxWhere = " WHERE ppc.curso IS NOT NULL ";

            if (curso != null && !curso.ToString().Equals(""))
                auxWhere += " AND ppc.curso = " + curso;
            if (polo != null && !polo.ToString().Equals(""))
                auxWhere += " AND ppc.polo = " + polo;
            if (turma != null && !turma.ToString().Equals(""))
                auxWhere += " AND ppc.turma = " + turma;
            if (custo != null && !custo.ToString().Equals(""))
                auxWhere += " AND ppc.custo = " + custo;
            if (item != null && !item.ToString().Equals(""))
                auxWhere += " AND ppc.item = " + item;
            if (etapa != null && !etapa.ToString().Equals(""))
                auxWhere += " AND ppc.etapa = " + etapa;


            StringBuilder sql = new StringBuilder();
            sql.Append(@"
            SELECT ppc.curso,
                   TRIM(c.descricao) AS curso_desc,
                   ppc.polo,
                   TRIM(p.descricao) AS polo_desc,
                   ppc.turma,
                   ppc.etapa,
                   ppc.custo,
                   TRIM(cc.descricao) AS custo_desc,
                   ppc.item,
                   TRIM(itc.descricao) AS item_desc,
                   --ppc.qt_alunos,
                   ppc.valor_mes,
                   ppc.parcelas
              FROM sga.propostas_precos_cursos ppc
              JOIN sga.cursos c ON (c.curso = ppc.curso)
              JOIN sga.polos p ON (p.polo = ppc.polo)
              JOIN sga.custos_diretos cc ON (cc.custo = ppc.custo)
              JOIN sga.Itens_Custos_Diretos itc ON (itc.item = ppc.item)
            " + auxWhere + @"
             ORDER BY ppc.curso, ppc.polo, ppc.turma, ppc.etapa, ppc.custo, ppc.item");

            dtRetorno = new Conexao(Globals.GetStringConnection(), 2).ExecuteQuery(sql.ToString());

            return dtRetorno;

        }


        #endregion
    }
}
