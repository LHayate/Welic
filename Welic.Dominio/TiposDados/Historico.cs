using System;

namespace Welic.Dominio.TiposDados
{
    public class Historico
    {
        public string CriadoPor { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public string ModificadoPor { get; private set; }
        public DateTime? ModificadoEm { get; private set; }
        public string AprovadoPor { get; private set; }
        public DateTime? AprovadoEm { get; private set; }
        public string ReprovadoPor { get; private set; }
        public string MotivoReprovacao { get; set; }
        public DateTime? ReprovadoEm { get; private set; }
        public string CanceladoPor { get; private set; }
        public string MotivoCancelamento { get; set; }
        public DateTime? CanceladoEm { get; private set; }

        public void DefinirHistoricoCompleto(string criadoPor, DateTime criadoEm, string modificadoPor,
            DateTime? modificadoEm, string aprovadoPor, DateTime? aprovadoEm, string reprovadoPor,
            string motivoReprovacao, DateTime? reprovadoEm, string canceladoPor, string motivoCancelamento,
            DateTime? canceladoEm)
        {
            CriadoPor = criadoPor;
            CriadoEm = criadoEm;
            ModificadoPor = modificadoPor;
            ModificadoEm = modificadoEm;
            AprovadoPor = aprovadoPor;
            AprovadoEm = aprovadoEm;
            ReprovadoPor = reprovadoPor;
            MotivoReprovacao = motivoReprovacao;
            ReprovadoEm = reprovadoEm;
            CanceladoPor = canceladoPor;
            MotivoCancelamento = motivoCancelamento;
            CanceladoEm = canceladoEm;
        }

        public Historico(string criadoPor)
        {
            CriadoPor = criadoPor;
            CriadoEm = DateTime.Now;
        }

        public void DefinirAprovacao(string autorizadoPor)
        {
            AprovadoPor = autorizadoPor;
            AprovadoEm = DateTime.Now;
        }

        public void DefinirModificacao(string modificadoPor)
        {
            ModificadoPor = modificadoPor;
            ModificadoEm = DateTime.Now;
        }

        public void DefinirCriadoEm(DateTime criadoEm)
        {
            CriadoEm = criadoEm;
        }

        public void DefinirReprovacao(string reprovadoPor, string motivoReprovacao)
        {
            ReprovadoPor = reprovadoPor;
            ReprovadoEm = DateTime.Now;
            MotivoReprovacao = motivoReprovacao;
        }

        public void DefinirCancelamento(string canceladoPor, string motivoCancelamento)
        {
            CanceladoPor = canceladoPor;
            CanceladoEm = DateTime.Now;
            MotivoCancelamento = motivoCancelamento;
        }
    }
}