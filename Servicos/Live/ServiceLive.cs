using System.Collections.ObjectModel;
using Welic.Dominio;
using Welic.Dominio.Models.Lives.Adapters;
using Welic.Dominio.Models.Lives.Dtos;
using Welic.Dominio.Models.Lives.Maps;
using Welic.Dominio.Models.Lives.Repositoryes;
using Welic.Dominio.Models.Lives.Services;
using Welic.Dominio.Models.Users.Mapeamentos;

namespace Servicos.Live
{
    public class ServiceLive : Servico, IServiceLive
    {
        private readonly IRepositoryLive _repositoryLive;        
        public ServiceLive(IRepositoryLive repositoryLive, IUnidadeTrabalho unidadeTrabalho) : base(unidadeTrabalho)
        {
            _repositoryLive = repositoryLive;            
        }

        public LiveDto Save(LiveDto liveDto)
        {
            var liveEncontrada = _repositoryLive.GetById(liveDto.Id);

            if (liveEncontrada != null)
            {
                liveEncontrada.Id = liveDto.Id;
                liveEncontrada.Title = liveDto.Title;
                liveEncontrada.Print = liveDto.Print;
                liveEncontrada.Themes = liveDto.Themes;
                liveEncontrada.UrlDestino = liveDto.UrlDestino;
                liveEncontrada.Prince = liveDto.Prince;
                liveEncontrada.Description = liveDto.Description;
                liveEncontrada.Chat = liveDto.Chat;

                if (liveDto.Author == null)
                    throw new System.Exception("É obrigatório o autor");

                liveEncontrada.Author = new AspNetUser
                {
                    Id = liveDto.Author.UserId.ToString(),
                    Email = liveDto.Author.Email
                };                 
            }
            else
            {
                liveEncontrada = new LiveMap
                {
                    Id = liveDto.Id,
                    Title = liveDto.Title,
                    Print = liveDto.Print,
                    Themes = liveDto.Themes,
                    UrlDestino = liveDto.UrlDestino,
                    Prince = liveDto.Prince,
                    Description = liveDto.Description,
                    Chat = liveDto.Chat
                };

                if (liveDto.Author == null)
                    throw  new System.Exception("É obrigatório o autor");
               
                liveEncontrada.Author = new AspNetUser
                {
                    Id = liveDto.Author.UserId.ToString(),
                    Email = liveDto.Author.Email
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
