using System;

namespace Welic.Dominio.TiposDados
{
    public class DataCalendario
    {
        public DateTime? Valor { get; private set; }
        public string Texto => PrepararTextoData();
        public string Periodo => PrepararMesAno();

        private string PrepararMesAno()
        {
            if (Valor != null && Valor != DateTime.MinValue)
            {
                return new MesAno(Valor.Value.Month, Valor.Value.Year).ToString();
            }
            return "NÃO DEFINIDO";
        }

        private string PrepararTextoData()
        {
            return Valor == null || Valor.Value == DateTime.MinValue
                ? string.Empty
                : Valor.Value.ToString("dd/MM/yyyy");
        }

        public DataCalendario(DateTime? valor)
        {
            Valor = valor;
        }
    }
}