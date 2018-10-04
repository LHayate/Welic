using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Eventos;

namespace Registrators
{
    public class ManipuladorNotificacaoDominio : IManipulador<NotificacaoDominio>
    {
        private List<NotificacaoDominio> _notifications;

        public ManipuladorNotificacaoDominio()
        {
            _notifications = new List<NotificacaoDominio>();
        }

        public void Manipular(NotificacaoDominio args)
        {
            _notifications.Add(args);
        }

        public IEnumerable<NotificacaoDominio> Notificar()
        {
            return ObterValor();
        }

        private List<NotificacaoDominio> ObterValor()
        {
            return _notifications;
        }

        public bool PossuiNotificacoes()
        {
            return ObterValor().Count > 0;
        }

        public void Dispose()
        {
            _notifications = new List<NotificacaoDominio>();
        }
    }
}
