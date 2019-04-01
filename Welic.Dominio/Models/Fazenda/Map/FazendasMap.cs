using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Dominio.Models.Fazenda.Map
{
    public class FazendasMap : Entity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string IE { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Tel { get; set; }
        public string PontoReferencia { get; set; }

        public string IdUser { get; set; }
        [ForeignKey("IdUser")]
        public AspNetUser AspNetUser { get; set; }



        public FazendasMap()
        {
            
        }
    }
}
