using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseFul.ClientApi.Dtos
{
    public class EstacionamentoVagaDto
    {
        public int IdEstacionamento { get; set; }
        public int TipoVaga { get; set; }
        public int Quantidade { get; set; }
        public int TipoVeiculo { get; set; }
    }
}
