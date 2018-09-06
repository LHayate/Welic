using System;
using System.Collections.Generic;
using System.Linq;
using Welic.Dominio.TiposDados.Escopos;

namespace Welic.Dominio.TiposDados
{
    public class MesAno
    {
        public int Mes { get; }
        public int Ano { get; }
        public int Numero => Convert.ToInt32(Mes.ToString() + Ano);
        public string TextoMesAno => $"{Mes}/{Ano}";

        public MesAno(int mes, int ano)
        {
            Mes = mes;
            Ano = ano;
        }

        public DateTime DataInicial => new DateTime(Ano, Mes, 1);
        public DateTime DataFinal => DataInicial.AddMonths(1).AddDays(-1);

        public bool Validar()
        {
            return this.ValidarNovoMesAno();
        }

        public static bool DatasEstaoNoMesmoPeriodo(List<DateTime> datas)
        {
            return datas.Min().Month == datas.Max().Month && datas.Min().Year == datas.Max().Year;
        }

        public override string ToString()
        {
            return $"{Mes}/{Ano}";
        }
    }
}