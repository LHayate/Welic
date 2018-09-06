using System;
using Welic.Dominio.TiposDados;

namespace Welic.Dominio.Utilitarios.Comandos
{
    public class ComandoMesAno
    {
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int Numero { get; set; }
        public string TextoMesAno { get; set; }

        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }

        public static ComandoMesAno Mapear(MesAno mesAno)
        {
            return new ComandoMesAno
            {
                Ano = mesAno.Ano,
                DataInicial = mesAno.DataInicial,
                Mes = mesAno.Mes,
                DataFinal = mesAno.DataFinal,
                Numero = mesAno.Numero,
                TextoMesAno = mesAno.TextoMesAno
            };
        }
    }
}