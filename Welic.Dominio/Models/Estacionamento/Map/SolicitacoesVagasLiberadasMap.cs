using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Estacionamento.Map
{
    public class SolicitacoesVagasLiberadasMap: Entity
    {
        [Key]
        public int Vaga { get; set; }
        public int? IdEstacionamento { get; set; }
        public int? IdVeiculo { get; set; }
        public int? Manha { get; set; }
        public int? Tarde { get; set; }
        public int? Noite { get; set; }
        public string IdUser { get; set; }
        public DateTime DtValidade { get; set; }
        public DateTime DtLiberacao { get; set; }
        public int? Situacao { get; set; }
        public string IdUserSuspensao { get; set; }
        public DateTime DtSuspensao { get; set; }
        public DateTime DtCancel { get; set; }
        public string IdUserCancel { get; set; }
        public string Justificativa { get; set; }
        public int? Motivo { get; set; }
        public int? DescricaoVaga { get; set; }
        public int? TipoIdentificacao { get; set; }

        [ForeignKey("IdUser")]
        public AspNetUser AspNetUser { get; set; }
        [ForeignKey("IdUserCancel")]
        public AspNetUser NetUserCancel { get; set; }
        [ForeignKey("IdUserSuspensao")]
        public AspNetUser NetUserSuspensao { get; set; }
        [ForeignKey("IdEstacionamento")]
        public EstacionamentoMap EstacionamentoMap { get; set; }
        [ForeignKey("IdVeiculo")]
        public VeiculosMap VeiculosMap { get; set; }



    }
}
