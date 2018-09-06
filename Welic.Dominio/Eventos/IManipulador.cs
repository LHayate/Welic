using System;
using System.Collections.Generic;
using Welic.Dominio.Eventos.Contratos;

namespace Welic.Dominio.Eventos
{
    public interface IManipulador<T> : IDisposable where T : IEventoDominio
    {
        void Manipular(T args);
        IEnumerable<T> Notificar();
        bool PossuiNotificacoes();
    }
}