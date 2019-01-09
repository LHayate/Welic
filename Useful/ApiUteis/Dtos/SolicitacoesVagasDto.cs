using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseFul.ClientApi.Dtos
{
    public class SolicitacoesVagasDto
    {
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
    }
}
