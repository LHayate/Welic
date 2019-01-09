using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseFul.ClientApi.Dtos
{
    public class SolicitacoesEstacionamentoDto : BaseDto<SolicitacoesEstacionamentoDto>
    {
        public int Solicitacao { get; set; }
        public int Estacionamento { get; set; }
        public int? TipoVaga { get; set; }
        public bool Manha { get; set; }
        public bool Tarde { get; set; }
        public bool Noite { get; set; }
        public int? Situacao { get; set; }
        public long? Vaga { get; set; }
    }
}
