using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseFul.Uteis;
using Welic.Dominio.Models.Departamento.Map;
using Welic.Infra.Context;

namespace UseFul.ClientApi.Dtos
{
    public class DepartamentoDto: BaseDto<DepartamentoDto>
    {
        public int IdDepartamento { get; set; }
        public string Descricao { get; set; }
        public int IdEmpresa { get; set; }
        public EmpresaDto EmpresaDto { get; set; }


        public DepartamentoDto() 
        {
           
        }

        public DepartamentoDto ConsultaDepartamentoPorId(int idDepartamento)
        {
            var departamento =
                Adaptador.AdaptadorGeneric<DepartamentoMap,DepartamentoDto>(Context.Departamento.FirstOrDefault(d => d.IdDepartamento == idDepartamento));
            if (departamento == null)
            {
                throw CustomErro.Erro("Departamento não encontrado pelo código informado.");
            }

            return departamento;
        }

        public List<DepartamentoDto> ConsultaDepartamentos()
        {
            return Adaptador.AdaptadorGeneric<DepartamentoMap, DepartamentoDto>(Context.Departamento.OrderBy(d => d.Descricao).ToList());
        }

        public int BuscaCodigoDepartamentoPorDescricao(string descricao)
        {
            var departamentoEncontrado =
                Context.Departamento.FirstOrDefault(d => d.Descricao == descricao);
            if (departamentoEncontrado != null)
            {
                return departamentoEncontrado.IdDepartamento;
            }
            throw CustomErro.Erro("Departamento não encontrado pela descrição.");
        }
    }
}
