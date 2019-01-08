using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Client.Map;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Estacionamento.Map
{
    public class SolicitacoesVagasMap : Entity
    {
        [Key]
        public int IdSolicitacao { get; set; }
        public int IdPessoa { get; set; }
        public int IdVeiculo { get; set; }
        public DateTime DtSolicitacao { get; set; }
        public string IdUser { get; set; }
        public DateTime DtInicio { get; set; }
        public bool Ativo { get; set; }
        public int Situacao { get; set; }
        public DateTime DtCancel { get; set; }
        public string UserCancel { get; set; }

        [ForeignKey("IdUser")]
        public AspNetUser AspNetUserCadastro { get; set; }
        [ForeignKey("UserCancel")]
        public AspNetUser AspNetUserCancel { get; set; }
        [ForeignKey("IdPessoa")]
        public PessoaMap PessoaMap { get; set; }
        [ForeignKey("IdVeiculo")]
        public VeiculosMap Veiculos { get; set; }
    }
}
