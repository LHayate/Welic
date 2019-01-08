using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseFul.ClientApi.Dtos
{
    public class PessoaDto
    {
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimeto { get; set; }
        public int? Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public string Naturalidade { get; set; }
        public string Nacionalidade { get; set; }

        public string Identidade { get; set; }
        public DateTime DataExpedicao { get; set; }
        public string OrgaoExpeditor { get; set; }
        public int? UfExpeditor { get; set; }
        public long Cpf { get; set; }
        public string TituloEleitor { get; set; }
        public int? Zona { get; set; }
        public int? Secao { get; set; }

        public string Endereco { get; set; }
        public string Numero { get; set; }
        public int? Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }

        public string Telefone { get; set; }
        public string TelComercial { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string EmailCorporativo { get; set; }
    }
}
