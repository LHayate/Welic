using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes.Uteis
{
    public class ValidacaoData
    {
        public static string VerificaData(string Data)
        {
            string retorno = "";
            string mes = Data;
            string dia = Data;
            string ano = Data;
            dia = dia.Substring(0, 2);
            mes = mes.Substring(3, 2);
            ano = ano.Substring(6, 4);
            int day = Convert.ToInt32(dia);
            int month = Convert.ToInt32(mes);
            int year = Convert.ToInt32(ano);

            if (day > 31 || day < 1 || month < 1 || month > 12)
            {
                retorno = "Data invalida. Favor verificar o valor digitado";
            }
            else
            {
                if ((month == 02))
                {
                    if (day >= 29)
                    {
                        if (year % 4 == 0 && day == 29)
                        {
                            retorno = "";
                        }
                        else
                        {
                            retorno = "O mês de Fevereiro so tem 28 ou 29 dias";
                        }
                    }
                }

                if ((month == 04))
                {
                    if (day > 30)
                    {
                        retorno = "O mês de Abril so tem 30 dias";
                    }
                    else
                    {
                        retorno = "";
                    }
                }

                if ((month == 06))
                {
                    if (day > 30)
                    {
                        retorno = "O mês de Junho so tem 30 dias";
                    }
                    else
                    {
                        retorno = "";
                    }
                }

                if ((month == 09))
                {
                    if (day > 30)
                    {
                        retorno = "O mês de Setembro so tem 30 dias";
                    }
                    else
                    {
                        retorno = "";
                    }
                }

                if ((month == 11))
                {
                    if (day > 30)
                    {
                        retorno = "O mês de Novembro so tem 30 dias";
                    }
                    else
                    {
                        retorno = "";
                    }
                }
            }

            return retorno;
        }
    }
}
