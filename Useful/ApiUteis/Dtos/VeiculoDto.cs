using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseFul.ClientApi.Dtos
{
    public class VeiculoDto
    {
        public int IdVeiculo { get; set; }
        public int Tipo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public int IdPessoa { get; set; }
        public string Chassi { get; set; }
    }
}
