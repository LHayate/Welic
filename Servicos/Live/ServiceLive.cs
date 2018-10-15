using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio;
using Welic.Dominio.Models.Lives.Adapters;
using Welic.Dominio.Models.Lives.Dtos;
using Welic.Dominio.Models.Lives.Maps;
using Welic.Dominio.Models.Lives.Repositoryes;
using Welic.Dominio.Models.Lives.Services;

namespace Servicos.Live
{
    public class ServiceLive : Servico, IServiceLive
    {
        private readonly IRepositoryLive _repositoryLive;
        private readonly IUnidadeTrabalho _unidadeTrabalho;

        public ServiceLive(IRepositoryLive repositoryLive, IUnidadeTrabalho unidadeTrabalho) : base(unidadeTrabalho)
        {
            _repositoryLive = repositoryLive;
            _unidadeTrabalho = unidadeTrabalho;
        }

        public LiveDto Save(LiveDto liveMap)
        {
            var liveEncontrada = _repositoryLive.GetById(liveMap.Id);

            if (liveEncontrada != null)
            {
                liveEncontrada.Id = liveMap.Id;
                liveEncontrada.Title = liveMap.Title;
                liveEncontrada.Print = liveMap.Print;
                liveEncontrada.Themes = liveMap.Themes;
                liveEncontrada.UrlDestino = liveMap.UrlDestino;
                liveEncontrada.Prince = liveMap.Prince;
                liveEncontrada.Description = liveMap.Description;
                liveEncontrada.Chat = liveMap.Chat;                
            }
            else
            {
                liveEncontrada = new LiveMap
                {
                    Id = liveMap.Id,
                    Title = liveMap.Title,
                    Print = liveMap.Print,
                    Themes = liveMap.Themes,
                    UrlDestino = liveMap.UrlDestino,
                    Prince = liveMap.Prince,
                    Description = liveMap.Description,
                    Chat = liveMap.Chat
                };
            }

            _repositoryLive.Save(liveEncontrada);

            if (!Commit())
            {
                return null;
            }

            return GetById(liveEncontrada.Id);
        }

        public void Delet(int id)
        {
            _repositoryLive.Delet(id);
        }

        public LiveDto GetById(int id)
        {
            return  AdapterLive.ConverterMapParaDto(_repositoryLive.GetById(id));
        }

        public ObservableCollection<LiveDto> GetListLive()
        {
            return AdapterLive.ConverterMapParaDto(_repositoryLive.GetListLive());
        }

        public ObservableCollection<LiveDto> GetSearchListLive(string text)
        {
            return AdapterLive.ConverterMapParaDto(_repositoryLive.GetSearchListLive(text));
        }
    }
}
