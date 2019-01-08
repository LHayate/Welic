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
    public class EstacionamentoVagasMap: Entity
    {
        [Key, Column(Order = 1)]
        public int IdEstacionamento { get; set; }
        [Key, Column(Order = 2)]
        public int TipoVaga { get; set; }
        public int Quantidade { get; set; }
        [Key, Column(Order = 3)]
        public int TipoVeiculo { get; set; }

        [ForeignKey("IdEstacionamento")]
        public EstacionamentoMap Estacionamento { get; set; }
    }
}
