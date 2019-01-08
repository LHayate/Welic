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
                new UfBrasil("AP", "Amap�"),
                new UfBrasil("AM", "Amazonas"),
                new UfBrasil("BA", "Bahia"),
                new UfBrasil("CE", "Cear�"),
                new UfBrasil("DF", "Distrito Federal"),
                new UfBrasil("ES", "Esp�rito Santo"),
                new UfBrasil("GO", "Goi�s"),
                new UfBrasil("MA", "Maranh�o"),
                new UfBrasil("MT", "Mato Grosso"),
                new UfBrasil("MS", "Mato Grosso do Sul"),
                new UfBrasil("MG", "Minas Gerais"),
                new UfBrasil("PA", "Par�"),
                new UfBrasil("PB", "Para�ba"),
                new UfBrasil("PR", "Paran�"),
                new UfBrasil("PE", "Pernambuco"),
                new UfBrasil("PI", "Piau�"),
                new UfBrasil("RR", "Roraima"),
                new UfBrasil("RO", "Rond�nia"),
                new UfBrasil("RJ", "Rio de Janeiro"),
                new UfBrasil("RN", "Rio Grande do Norte"),
                new UfBrasil("RS", "Rio Grande do Sul"),
                new UfBrasil("SC", "Santa Catarina"),
                new UfBrasil("SP", "S�o Paulo"),
                new UfBrasil("SE", "Sergipe"),
                new UfBrasil("TO", "Tocantins")
            };
        }
    }
}