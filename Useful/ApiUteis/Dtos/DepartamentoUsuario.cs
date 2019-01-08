using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Infra.Context;

namespace UseFul.ClientApi.Dtos
{
    public class DepartamentoUsuario: BaseDto<DepartamentoUsuario>
    {
        public int IdDepartamento { get; set; }
        public string UserId { get; set; }
    

        public DepartamentoUsuario() 
        {
            
        }
    }
}
