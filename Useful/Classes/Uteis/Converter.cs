using System;

namespace UseFul.Uteis
{
    public static class Converter
    {
        public static string ToExtenso(decimal valor)
        {
            if (valor <= 0 | valor >= 1000000000000000)
            {
                return "Valor não suportado pelo sistema.";
            }
            string strValor = valor.ToString("000000000000000.00");
            string valorPorExtenso = string.Empty;

            for (int i = 0; i <= 15; i += 3)
            {
                valorPorExtenso += EscrevaParte(Convert.ToDecimal(strValor.Substring(i, 3)));
                if (i == 0 & valorPorExtenso != string.Empty)
                {
                    switch (Convert.ToInt32(strValor.Substring(0, 3)))
                    {
                        case 1:
                            valorPorExtenso += " TRILHÃO" +
                                               (Convert.ToDecimal(strValor.Substring(3, 12)) > 0
                                                   ? " E "
                                                   : string.Empty);
                            break;
                        default:
                            if (Convert.ToInt32(strValor.Substring(0, 3)) > 1)
                            {
                                valorPorExtenso += " TRILHÕES" +
                                                   (Convert.ToDecimal(strValor.Substring(3, 12)) > 0
                                                       ? " E "
                                                       : string.Empty);
                            }
                            break;
                    }
                }
                else if (i == 3 & valorPorExtenso != string.Empty)
                {
                    switch (Convert.ToInt32(strValor.Substring(3, 3)))
                    {
                        case 1:
                            valorPorExtenso += " BILHÃO" +
                                               (Convert.ToDecimal(strValor.Substring(6, 9)) > 0
                                                   ? " E "
                                                   : string.Empty);
                            break;
                        default:
                            if (Convert.ToInt32(strValor.Substring(3, 3)) > 1)
                            {
                                valorPorExtenso += " BILHÕES" +
                                                   (Convert.ToDecimal(strValor.Substring(6, 9)) > 0
                                                       ? " E "
                                                       : string.Empty);
                            }
                            break;
                    }
                }
                else if (i == 6 & valorPorExtenso != string.Empty)
                {
                    if (Convert.ToInt32(strValor.Substring(6, 3)) == 1)
                    {
                        valorPorExtenso += " MILHÃO" +
                                           (Convert.ToDecimal(strValor.Substring(9, 6)) > 0
                                               ? " E "
                                               : string.Empty);
                    }
                    else if (Convert.ToInt32(strValor.Substring(6, 3)) > 1)
                    {
                        valorPorExtenso += " MILHÕES" +
                                           (Convert.ToDecimal(strValor.Substring(9, 6)) > 0
                                               ? " E "
                                               : string.Empty);
                    }
                }
                else if (i == 9 & valorPorExtenso != string.Empty)
                {
                    if (Convert.ToInt32(strValor.Substring(9, 3)) > 0)
                    {
                        valorPorExtenso += " MIL" +
                                           (Convert.ToDecimal(strValor.Substring(12, 3)) > 0
                                               ? " E "
                                               : string.Empty);
                    }
                }

                if (i == 12)
                {
                    if (valorPorExtenso.Length > 8)
                    {
                        if (valorPorExtenso.Substring(valorPorExtenso.Length - 6, 6) == "BILHÃO" |
                            valorPorExtenso.Substring(valorPorExtenso.Length - 6, 6) == "MILHÃO")
                        {
                            valorPorExtenso += " DE";
                        }
                        else if (valorPorExtenso.Substring(valorPorExtenso.Length - 7, 7) == "BILHÕES" |
                                 valorPorExtenso.Substring(valorPorExtenso.Length - 7, 7) == "MILHÕES" |
                                 valorPorExtenso.Substring(valorPorExtenso.Length - 8, 7) == "TRILHÕES")
                        {
                            valorPorExtenso += " DE";
                        }
                        else if (valorPorExtenso.Substring(valorPorExtenso.Length - 8, 8) == "TRILHÕES")
                        {
                            valorPorExtenso += " DE";
                        }
                    }

                    switch (Convert.ToInt64(strValor.Substring(0, 15)))
                    {
                        case 1:
                            valorPorExtenso += " REAL";
                            break;
                        default:
                            if (Convert.ToInt64(strValor.Substring(0, 15)) > 1)
                            {
                                valorPorExtenso += " REAIS";
                            }
                            break;
                    }

                    if (Convert.ToInt32(strValor.Substring(16, 2)) > 0 && valorPorExtenso != string.Empty)
                    {
                        valorPorExtenso += " E ";
                    }
                }

                if (i == 15)
                {
                    if (Convert.ToInt32(strValor.Substring(16, 2)) == 1)
                    {
                        valorPorExtenso += " CENTAVO";
                    }
                    else if (Convert.ToInt32(strValor.Substring(16, 2)) > 1)
                    {
                        valorPorExtenso += " CENTAVOS";
                    }
                }
            }
            return valorPorExtenso;
        }

        private static string EscrevaParte(decimal valor)
        {
            if (valor <= 0)
            {
                return string.Empty;
            }
            string montagem = string.Empty;
            if (valor > 0 & valor < 1)
            {
                valor *= 100;
            }
            string strValor = valor.ToString("000");
            int centena = Convert.ToInt32(strValor.Substring(0, 1));
            int dezena = Convert.ToInt32(strValor.Substring(1, 1));
            int unidade = Convert.ToInt32(strValor.Substring(2, 1));

            switch (centena)
            {
                case 1:
                    montagem += dezena + unidade == 0 ? "CEM" : "CENTO";
                    break;
                case 2:
                    montagem += "DUZENTOS";
                    break;
                case 3:
                    montagem += "TREZENTOS";
                    break;
                case 4:
                    montagem += "QUATROCENTOS";
                    break;
                case 5:
                    montagem += "QUINHENTOS";
                    break;
                case 6:
                    montagem += "SEISCENTOS";
                    break;
                case 7:
                    montagem += "SETECENTOS";
                    break;
                case 8:
                    montagem += "OITOCENTOS";
                    break;
                case 9:
                    montagem += "NOVECENTOS";
                    break;
            }

            switch (dezena)
            {
                case 1:
                    switch (unidade)
                    {
                        case 0:
                            montagem += (centena > 0 ? " E " : string.Empty) + "DEZ";
                            break;
                        case 1:
                            montagem += (centena > 0 ? " E " : string.Empty) + "ONZE";
                            break;
                        case 2:
                            montagem += (centena > 0 ? " E " : string.Empty) + "DOZE";
                            break;
                        case 3:
                            montagem += (centena > 0 ? " E " : string.Empty) + "TREZE";
                            break;
                        case 4:
                            montagem += (centena > 0 ? " E " : string.Empty) + "QUATORZE";
                            break;
                        case 5:
                            montagem += (centena > 0 ? " E " : string.Empty) + "QUINZE";
                            break;
                        case 6:
                            montagem += (centena > 0 ? " E " : string.Empty) + "DEZESSEIS";
                            break;
                        case 7:
                            montagem += (centena > 0 ? " E " : string.Empty) + "DEZESSETE";
                            break;
                        case 8:
                            montagem += (centena > 0 ? " E " : string.Empty) + "DEZOITO";
                            break;
                        case 9:
                            montagem += (centena > 0 ? " E " : string.Empty) + "DEZENOVE";
                            break;
                    }
                    break;
                case 2:
                    montagem += (centena > 0 ? " E " : string.Empty) + "VINTE";
                    break;
                case 3:
                    montagem += (centena > 0 ? " E " : string.Empty) + "TRINTA";
                    break;
                case 4:
                    montagem += (centena > 0 ? " E " : string.Empty) + "QUARENTA";
                    break;
                case 5:
                    montagem += (centena > 0 ? " E " : string.Empty) + "CINQUENTA";
                    break;
                case 6:
                    montagem += (centena > 0 ? " E " : string.Empty) + "SESSENTA";
                    break;
                case 7:
                    montagem += (centena > 0 ? " E " : string.Empty) + "SETENTA";
                    break;
                case 8:
                    montagem += (centena > 0 ? " E " : string.Empty) + "OITENTA";
                    break;
                case 9:
                    montagem += (centena > 0 ? " E " : string.Empty) + "NOVENTA";
                    break;
            }

            if (strValor.Substring(1, 1) != "1" & unidade != 0 & montagem != string.Empty)
            {
                montagem += " E ";
            }

            if (strValor.Substring(1, 1) != "1")
            {
                switch (unidade)
                {
                    case 1:
                        montagem += "UM";
                        break;
                    case 2:
                        montagem += "DOIS";
                        break;
                    case 3:
                        montagem += "TRÊS";
                        break;
                    case 4:
                        montagem += "QUATRO";
                        break;
                    case 5:
                        montagem += "CINCO";
                        break;
                    case 6:
                        montagem += "SEIS";
                        break;
                    case 7:
                        montagem += "SETE";
                        break;
                    case 8:
                        montagem += "OITO";
                        break;
                    case 9:
                        montagem += "NOVE";
                        break;
                }
            }
            return montagem;
        }
    }
}