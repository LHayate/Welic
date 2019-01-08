using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes.Uteis
{
    public static class ComparaString
    {
        /// <summary>
        /// Verifica se a primeira expressão é 70% semelhante à segunda expressão
        /// Data de criação: 06/11/2015
        /// </summary>
        /// <param name="expressaoComparar">Expressão que será comparada com a outra</param>
        /// <param name="expressaoModelo">Expressão que servirá de comparação</param>
        /// <returns></returns>
        public static bool StringsSemelhantes(string expressaoComparar, string expressaoModelo)
        {
            return StringsSemelhantes(expressaoComparar, expressaoModelo, 70);
        }

        /// <summary>
        /// Verifica se a primeira expressão é semelhante à segunda expressão de acordo com uma porcentagem de semelhança
        /// Data de criação: 06/11/2015
        /// </summary>
        /// <param name="expressaoComparar">Expressão que será comparada com a outra</param>
        /// <param name="expressaoModelo">Expressão que servirá de comparação</param>
        /// <param name="porcentagemSemelhanca">Percentual (%) que será utilizado para determinar se as expressções são semelhantes ou não</param>
        /// <returns></returns>
        public static bool StringsSemelhantes(string expressaoComparar, string expressaoModelo, int porcentagemSemelhanca)
        {
            int modificacoes = VerificarSimilaridade(expressaoComparar, expressaoModelo);

            return (1 - (double.Parse(modificacoes.ToString()) / expressaoComparar.Length)) * 100 >= porcentagemSemelhanca;
        }

        /// <summary>
        /// Compara as 2 expressões e retorna quantas modificações serão necessárias na primeira expressão para que ela fique igual a segunda expressão
        /// Data de criação: 06/11/2015
        /// Baseado em: http://pt.stackoverflow.com/questions/10405/como-verificar-semelhan%C3%A7a-entre-strings
        /// </summary>
        /// <param name="expressaoComparar">Expressão que será comparada com a outra</param>
        /// <param name="expressaoModelo">Expressão que servirá de comparação</param>
        /// <returns></returns>
        public static int VerificarSimilaridade(string expressaoComparar, string expressaoModelo)
        {
            int tam1 = expressaoComparar.Length;
            int tam2 = expressaoModelo.Length;
            int[,] verif = new int[tam1 + 1, tam2 + 1];

            // Se uma das palavras tiver coprimento igual a zero, é necessária uma modificação do tamanho da outra:
            if (tam1 == 0)
                return tam2;

            if (tam2 == 0)
                return tam1;

            // Atribuir ordem numérica resultante das palavras ao vetor de modo, respectivamente, "vertical" e "horizontal":
            int i = 0;
            while (i <= tam1)
                verif[i, 0] = i++;

            int j = 0;
            while (j <= tam2)
                verif[0, j] = j++;

            // Verificação:
            for (int x = 1; x <= tam1; x++)
            {
                for (int z = 1; z <= tam2; z++)
                {
                    // Definindo custos de modificação (deleção, inserção e substituição):
                    int custo = (expressaoModelo[z - 1] == expressaoComparar[x - 1]) ? 0 : 1;

                    verif[x, z] = Math.Min(
                                           Math.Min(verif[x - 1, z] + 1, verif[x, z - 1] + 1),
                                           verif[x - 1, z - 1] + custo);
                }
            }

            return verif[tam1, tam2];
        }
    }
}
