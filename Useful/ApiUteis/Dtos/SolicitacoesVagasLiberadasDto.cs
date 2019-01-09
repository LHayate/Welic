using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseFul.ClientApi.Dtos
{
    public class SolicitacoesVagasLiberadasDto
    {
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
    }
}
