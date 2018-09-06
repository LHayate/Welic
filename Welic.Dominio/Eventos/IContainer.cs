using System;
using System.Collections.Generic;

namespace Welic.Dominio.Eventos
{
    public interface IContainer
    {
        T ObterServico<T>();
        object ObterServico(Type serviceType);
        IEnumerable<T> ObterServicos<T>();
        IEnumerable<object> ObterServicos(Type serviceType);
    }
}