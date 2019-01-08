using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Estacionamento.Map
{
    public class SolicitacoesEstacionamentoMap : Entity
    {
        [Key]
        public int Solicitacao  { get; set; }
        public int Estacionamento { get; set; }
        public int? TipoVaga { get; set; }
        public bool Manha { get; set; }
        public bool Tarde { get; set; }
        public bool Noite { get; set; }
        public int? Situacao { get; set; }
        public long? Vaga { get; set; }

        [ForeignKey("Estacionamento")]
        public EstacionamentoMap EstacionamentoMap { get; set; }
    }
}
