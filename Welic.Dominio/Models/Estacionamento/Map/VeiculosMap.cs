using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Client.Map;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Estacionamento.Map
{
    public class VeiculosMap : Entity
    {
        public int IdVeiculo { get; set; }
        public int Tipo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public int IdPessoa { get; set; }
        public string Chassi { get; set; }
        public string CNH { get; set; }
        public string Categoria { get; set; }
        public DateTime ExpedicaoCnh { get; set; }
        public DateTime VencimentoCnh { get; set; }


        [ForeignKey("IdPessoa")]
        public PessoaMap PessoaMap { get; set; }

        public ICollection<SolicitacoesVagasLiberadasMap> SolicitacoesVagasLiberadas { get; set; }
    }
}
