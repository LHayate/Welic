using System;
using Welic.Dominio.Eventos.Contratos;

namespace Welic.Dominio.Eventos
{
    public class NotificacaoDominio : IEventoDominio
    {
        public string Chave { get; private set; }
        public string Valor { get; private set; }
        public DateTime Data { get; }

        public NotificacaoDominio(string chave, string valor)
        {
            Chave = chave;
            Valor = valor;
            Data = DateTime.Now;
        }

        public DateTime Date { get; }
    }
}