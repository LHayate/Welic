using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes.Uteis
{
    public class ExecutaveisFoxPro
    {
        private readonly string _caminhoRede;
        private readonly string _caminhoLocal;

        public static readonly ExecutaveisFoxPro ALMOXARIFADO = new ExecutaveisFoxPro(@"s:\suprimentos\almoxarifado.exe", @"c:\sistemas\almoxarifado.exe");
        public static readonly ExecutaveisFoxPro COMPRAS = new ExecutaveisFoxPro(@"s:\suprimentos\compras.exe", @"c:\sistemas\compras.exe");
        public static readonly ExecutaveisFoxPro RCI_AVALIADOR = new ExecutaveisFoxPro(@"s:\suprimentos\reprografia.exe", @"c:\sistemas\reprografia.exe");
        public static readonly ExecutaveisFoxPro RMS_ADMINISTRATIVO = new ExecutaveisFoxPro(@"s:\suprimentos\rms_adm.exe", @"c:\sistemas\rms_adm.exe");
        public static readonly ExecutaveisFoxPro RMS_APROVADOR = new ExecutaveisFoxPro(@"s:\suprimentos\rms_apro.exe", @"c:\sistemas\rms_apro.exe");
        public static readonly ExecutaveisFoxPro RMS_ATENDIMENTO = new ExecutaveisFoxPro(@"s:\suprimentos\rms_atend.exe", @"c:\sistemas\rms_atend.exe");
        public static readonly ExecutaveisFoxPro RMS_AVALIADOR = new ExecutaveisFoxPro(@"s:\suprimentos\rms_atend_filtro.exe", @"c:\sistemas\rms_atend_filtro.exe");
        public static readonly ExecutaveisFoxPro RMS_MATERIAIS = new ExecutaveisFoxPro(@"s:\suprimentos\rms_mat.exe", @"c:\sistemas\rms_mat.exe");
        public static readonly ExecutaveisFoxPro RMS_REQUISITANTE = new ExecutaveisFoxPro(@"s:\suprimentos\rms_req.exe", @"c:\sistemas\rms_req.exe");
        public static readonly ExecutaveisFoxPro SAD_APROVADOR = new ExecutaveisFoxPro(@"s:\sad\sad_aprov.exe", @"c:\sistemas\sad_aprov.exe");
        public static readonly ExecutaveisFoxPro SAD_CONTABILIDADE = new ExecutaveisFoxPro(@"s:\sad\sad_contabilidade.exe", @"c:\sistemas\sad_contabilidade.exe");
        public static readonly ExecutaveisFoxPro SAD_DEPTO_PESSOAL = new ExecutaveisFoxPro(@"s:\sad\sad_dp.exe", @"c:\sistemas\sad_dp.exe");
        public static readonly ExecutaveisFoxPro SAD_SOLICITANTE = new ExecutaveisFoxPro(@"s:\sad\sad_solicitante.exe", @"c:\sistemas\sad_solicitante.exe");
        public static readonly ExecutaveisFoxPro SGA_POS_GRADUACAO_EXTENSAO = new ExecutaveisFoxPro(@"s:\sga\pos_graduacao.exe", @"c:\sistemas\pos_graduacao.exe");
        public static readonly ExecutaveisFoxPro SGA_CONTROLE_PONTO = new ExecutaveisFoxPro(@"s:\sga\controle_ponto.exe", @"c:\sistemas\controle_ponto.exe");
        public static readonly ExecutaveisFoxPro ROTEIROS_EAD = new ExecutaveisFoxPro(@"s:\sga\ead.exe", @"c:\sistemas\ead.exe");
        public static readonly ExecutaveisFoxPro TELEMARKETING = new ExecutaveisFoxPro(@"s:\SGA\telemarketing.exe", @"c:\sistemas\telemarketing.exe");
        public static readonly ExecutaveisFoxPro SGA_FINANCEIRO = new ExecutaveisFoxPro(@"s:\SGA\sga_financeiro.exe", @"C:\sistemas\sga_financeiro.exe");
        public static readonly ExecutaveisFoxPro BANCO_HORAS = new ExecutaveisFoxPro(@"s:\bhoras\bhoras9.exe", @"c:\sistemas\bhoras9.exe");
        public static readonly ExecutaveisFoxPro ADMINISTRAR_ACESSO = new ExecutaveisFoxPro(@"s:\suprimentos\seguranca.exe", @"c:\sistemas\seguranca.exe");
        public static readonly ExecutaveisFoxPro SGA_COM_CENTRAL_MATERIAIS_EAD = new ExecutaveisFoxPro(@"s:\sga\ead_livros.exe", @"c:\sistemas\ead_livros.exe");
        public static readonly ExecutaveisFoxPro SGV_ADMINISTRATIVO = new ExecutaveisFoxPro(@"s:\hvu\administrativo_sgv.exe", @"c:\sistemas\administrativo_sgv.exe");
        public static readonly ExecutaveisFoxPro SGV_AMBULATORIO = new ExecutaveisFoxPro(@"s:\hvu\ambulatorio_sgv.exe", @"c:\sistemas\ambulatorio_sgv.exe");
        public static readonly ExecutaveisFoxPro SGV_CIRURGICO = new ExecutaveisFoxPro(@"s:\hvu\cirurgico_sgv.exe", @"c:\sistemas\cirurgico_sgv.exe");
        public static readonly ExecutaveisFoxPro SGV_FARMACIA = new ExecutaveisFoxPro(@"s:\hvu\farmacia_sgv.exe", @"c:\sistemas\farmacia_sgv.exe");
        public static readonly ExecutaveisFoxPro SGV_FINANCEIRO = new ExecutaveisFoxPro(@"s:\hvu\financeiro_sgv.exe", @"c:\sistemas\financeiro_sgv.exe");
        public static readonly ExecutaveisFoxPro SGV_INTERNACAO = new ExecutaveisFoxPro(@"s:\hvu\internacao_sgv.exe", @"c:\sistemas\internacao_sgv.exe");
        public static readonly ExecutaveisFoxPro SGV_LABORATORIO = new ExecutaveisFoxPro(@"s:\hvu\laboratorio_sgv.exe", @"c:\sistemas\laboratorio_sgv.exe");
        public static readonly ExecutaveisFoxPro SGV_LMVP = new ExecutaveisFoxPro(@"s:\hvu\lmvp_sgv.exe", @"c:\sistemas\lmvp_sgv.exe");
        public static readonly ExecutaveisFoxPro SGV_PATOLOGIA = new ExecutaveisFoxPro(@"s:\hvu\patologia_sgv.exe", @"c:\sistemas\patologia_sgv.exe");
        public static readonly ExecutaveisFoxPro SGV_RECEPCAO = new ExecutaveisFoxPro(@"s:\hvu\recepcao_sgv.exe", @"c:\sistemas\recepcao_sgv.exe");
        public static readonly ExecutaveisFoxPro APLICATIVO_APOIO_GEM = new ExecutaveisFoxPro(@"s:\aplicativo\aplicativo_apoio_gem.exe", @"c:\sistemas\aplicativo_apoio_gem.exe");
        public static readonly ExecutaveisFoxPro RMS_GESTAO_SERVICOS = new ExecutaveisFoxPro(@"s:\suprimentos\rms_gestao_servicos.exe", @"c:\sistemas\rms_gestao_servicos.exe");
        public static readonly ExecutaveisFoxPro BANCO_HORAS_CARGAS = new ExecutaveisFoxPro(@"s:\bhoras\carga\bhoras_cargas.exe", @"c:\sistemas\bhoras_cargas.exe");
        public static readonly ExecutaveisFoxPro ACADEMICO = new ExecutaveisFoxPro(@"S:\SGA\academico.exe", @"C:\sistemas\academico.exe");

        private ExecutaveisFoxPro(string caminhoRede, string caminhoLocal)
        {
            this._caminhoRede = caminhoRede;
            this._caminhoLocal = caminhoLocal;
        }

        public string getCaminhoRede()
        {
            return this._caminhoRede;
        }

        public string getCaminhoLocal()
        {
            return this._caminhoLocal;
        }
    }
}
