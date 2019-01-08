using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseFul.ClientApi.Dtos
{
    public class MenuDto
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string IconMenu { get; set; }

        public string Descricao => $"{Nivel}-{Title}";

        public int? MenuDadId { get; set; }

        public string Action { get; set; }
        public string Controller { get; set; }                

        public string Nivel { get; set; }
    }
}
