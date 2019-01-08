using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Classes.Uteis
{
    public static class Diversos
    {
        public static void FiltrarColunas(DataTable dt, string colunasFiltragem)
        {
            if (colunasFiltragem != null && !colunasFiltragem.ToString().Trim().Equals(""))
            {
                colunasFiltragem = colunasFiltragem.Replace("\r", "").Replace("\n", "").ToUpper();
                string[] auxColunas = colunasFiltragem.Split(',');

                List<string> colunasDt = new List<string>();
                int qtdColunas = dt.Columns.Count;
                for (int i = 0; i < qtdColunas; i++)
                {
                    colunasDt.Add(dt.Columns[i].ColumnName.ToUpper());
                }

                List<string> nomesOriginais = new List<string>();
                List<string> nomesNovos = new List<string>();

                foreach (string item in auxColunas)
                {
                    string coluna = item;
                    if (coluna.Contains(" AS "))
                    {
                        string nomeOriginal = coluna.Substring(0, coluna.IndexOf(" AS ")).Replace(" ", "");
                        string nomeNovo = coluna.Substring(coluna.IndexOf(" AS ") + 4, coluna.Length - coluna.IndexOf(" AS ") - 4).Replace(" ", "");

                        if (!nomeOriginal.Trim().Equals("") && !nomeNovo.Trim().Equals(""))
                        {
                            nomesOriginais.Add(nomeOriginal);
                            nomesNovos.Add(nomeNovo);
                        }

                        coluna = nomeOriginal;
                    }

                    coluna = coluna.Replace(" ", "");

                    if (!colunasDt.Contains(coluna))
                    {
                        throw new Exception("Erro em FiltrarColunas(): " + Environment.NewLine + "Coluna '" + coluna.ToLower() + "' não encontrada.");
                    }
                    colunasDt.Remove(coluna);
                }

                foreach (string item in colunasDt)
                {
                    dt.Columns.Remove(item);
                }

                for (int i = 0; i < nomesOriginais.Count(); i++)
                {
                    dt.Columns[nomesOriginais[i]].ColumnName = nomesNovos[i];
                }
            }
        }
        public static void RenomearColunas(DataTable dt, string[] nomesColunasOriginais, string[] novosNomes)
        {
            if (nomesColunasOriginais.Count() != novosNomes.Count())
            {
                throw new Exception("Erro em RenomearColunas()" + Environment.NewLine + "Número de argumentos em 'nomesColunasOriginais' é diferente do número de argumentos em 'novosNomes'.");
            }
            else
            {
                for (int i = 0; i < nomesColunasOriginais.Count(); i++)
                {
                    dt.Columns[nomesColunasOriginais[i]].ColumnName = novosNomes[i];
                }
            }
        }

        /// <summary>
        /// Método que recebe um vetor numerico e monta cada valor no formato "(0, 1, 2, 3)", deixando-os pronto para serem utilizados numa clausula where do tipo WHERE STATUS IN (0, 1, 2, 3)
        /// </summary>
        public static string MontarList(List<object> parametros)
        {
            string resultado = "";
            if (parametros.Count > 0)
            {
                for (int i = 0; i < parametros.Count; i++)
                {
                    resultado += "'" + parametros[i] + "'";
                    if (i < parametros.Count - 1)
                    {
                        resultado += ", ";
                    }
                }
            }

            resultado = "(" + resultado + ")";

            return resultado;
        }
        public static string MontarList(List<int> parametros)
        {
            string resultado = "";
            if (parametros.Count > 0)
            {
                for (int i = 0; i < parametros.Count; i++)
                {
                    resultado += parametros[i];
                    if (i < parametros.Count - 1)
                    {
                        resultado += ", ";
                    }
                }
            }

            resultado = "(" + resultado + ")";

            return resultado;
        }
        public static string MontarList(object[] parametros)
        {
            string resultado = "";
            if (parametros.Length > 0)
            {
                for (int i = 0; i < parametros.Length; i++)
                {
                    resultado += parametros[i];
                    if (i < parametros.Length - 1)
                    {
                        resultado += ", ";
                    }
                }
            }

            resultado = "(" + resultado + ")";

            return resultado;
        }

        public static DataTable ConverteGridEmDataTable(System.Windows.Forms.DataGridView dgv)
        {
            DataTable dt = new DataTable();

            foreach (System.Windows.Forms.DataGridViewColumn coluna in dgv.Columns)
                if (!string.IsNullOrEmpty(coluna.DataPropertyName.ToString()))
                    dt.Columns.Add(coluna.DataPropertyName.ToString(), typeof(string));

            return dt;
        }
    }
}
