using System.Collections.Generic;

namespace UseFul.Uteis
{
    public class UfBrasil
    {
        public UfBrasil(string sigla, string nome)
        {
            Sigla = sigla;
            Nome = nome;
        }

        public string Sigla { get; private set; }
        public string Nome { get; private set; }

        public static List<UfBrasil> ConsultaEstados()
        {
            return new List<UfBrasil>
            {
                new UfBrasil("AC", "Acre"),
                new UfBrasil("AL", "Alagoas"),
                new UfBrasil("AP", "Amapá"),
                new UfBrasil("AM", "Amazonas"),
                new UfBrasil("BA", "Bahia"),
                new UfBrasil("CE", "Ceará"),
                new UfBrasil("DF", "Distrito Federal"),
                new UfBrasil("ES", "Espírito Santo"),
                new UfBrasil("GO", "Goiás"),
                new UfBrasil("MA", "Maranhão"),
                new UfBrasil("MT", "Mato Grosso"),
                new UfBrasil("MS", "Mato Grosso do Sul"),
                new UfBrasil("MG", "Minas Gerais"),
                new UfBrasil("PA", "Pará"),
                new UfBrasil("PB", "Paraíba"),
                new UfBrasil("PR", "Paraná"),
                new UfBrasil("PE", "Pernambuco"),
                new UfBrasil("PI", "Piauí"),
                new UfBrasil("RR", "Roraima"),
                new UfBrasil("RO", "Rondônia"),
                new UfBrasil("RJ", "Rio de Janeiro"),
                new UfBrasil("RN", "Rio Grande do Norte"),
                new UfBrasil("RS", "Rio Grande do Sul"),
                new UfBrasil("SC", "Santa Catarina"),
                new UfBrasil("SP", "São Paulo"),
                new UfBrasil("SE", "Sergipe"),
                new UfBrasil("TO", "Tocantins")
            };
        }
    }
}