using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseFul.ClientApi.Dtos
{
    public class EstacionamentoDto
    {
        public int IdEstacionamento { get; set; }
        public string Descricao { get; set; }
        public bool ValidaVencimento { get; set; }
        public int TipoIdentificacao { get; set; }
        public int Relacao { get; set; }
    }
}
