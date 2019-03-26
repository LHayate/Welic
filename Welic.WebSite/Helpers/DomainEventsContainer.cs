using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Welic.Dominio.Eventos;

namespace WebApi.Helpers
{
    public class DomainEventsContainer : IContainer
    {
        private readonly IDependencyResolver _resolver;

        public DomainEventsContainer(IDependencyResolver resolver)
        {
            _resolver = resolver;
        }

        public object ObterServico(Type serviceType)
        {
            return _resolver.GetService(serviceType);
        }

        public T ObterServico<T>()
        {
            return (T)_resolver.GetService(typeof(T));
        }

        public IEnumerable<object> ObterServicos(Type serviceType)
        {
            return _resolver.GetServices(serviceType);
        }

        public IEnumerable<T> ObterServicos<T>()
        {
            return (IEnumerable<T>)_resolver.GetServices(typeof(T));
        }
    }
}