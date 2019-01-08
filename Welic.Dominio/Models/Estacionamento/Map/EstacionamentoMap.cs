using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Estacionamento.Map
{
    public class EstacionamentoMap: Entity
    {
        public int IdEstacionamento { get; set; }
        public string Descricao { get; set; }
        public bool ValidaVencimento { get; set; }
        public int TipoIdentificacao { get; set; }
        public int Relacao { get; set; }

        public virtual ICollection<EstacionamentoVagasMap> EstacionamentoVagas { get; set; }
        public ICollection<SolicitacoesEstacionamentoMap> SolicitacoesEstacionamento { get; set; }
        public ICollection<SolicitacoesVagasLiberadasMap> SolicitacoesVagasLiberadas { get; set; }
    }
}
