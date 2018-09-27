

using Welic.Dominio;
using Welic.Dominio.Eventos;

namespace Servicos
{
    public class Servico : IServico
    {
        private readonly IUnidadeTrabalho _unidadeTrabalho;
        private readonly IManipulador<NotificacaoDominio> _notificacoes;

        protected Servico(IUnidadeTrabalho unidadeTrabalho)
        {
            _unidadeTrabalho = unidadeTrabalho;
            //_notificacoes = EventoDominio.Container.ObterServico<IManipulador<NotificacaoDominio>>();
        }      

        public void Rollback(string valor)
        {
            //EventoDominio.Disparar(new NotificacaoDominio("Erro", valor));
            _unidadeTrabalho.Rollback();
        }

        public void Rollback()
        {
            _unidadeTrabalho.Rollback();
        }

        public bool Valido()
        {
            //TODO: Implementar Validações
            return true; //!_notificacoes.PossuiNotificacoes();
        }

        public void BeginTran()
        {
            _unidadeTrabalho.BeginTran();
        }

        public bool Commit()
        {
            //if (_notificacoes.PossuiNotificacoes())
            //{
            //    return false;
            //}

            try
            {
                _unidadeTrabalho.Commit();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
           
        }
    }
}
