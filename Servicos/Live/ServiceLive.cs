using Welic.Dominio.Models.Lives.Maps;
using Welic.Dominio.Models.Lives.Services;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Servicos.Live
{

    public class ServiceLive : Service<LiveMap>, IServiceLive
    {

        public ServiceLive(IRepositoryAsync<LiveMap> repository) : base(repository)
        {
        }




        // private readonly IRepositoryLive _repositoryLive;        


        //public LiveDto Save(LiveDto liveDto)
        //{
        //    var liveEncontrada = _repositoryLive.GetById(liveDto.Id);

        //    if (liveEncontrada != null)
        //    {
        //        liveEncontrada.Id = liveDto.Id;
        //        liveEncontrada.Title = liveDto.Title;
        //        liveEncontrada.Print = liveDto.Print;
        //        liveEncontrada.Themes = liveDto.Themes;
        //        liveEncontrada.UrlDestino = liveDto.UrlDestino;
        //        liveEncontrada.Prince = liveDto.Prince;
        //        liveEncontrada.Description = liveDto.Description;
        //        liveEncontrada.Chat = liveDto.Chat;
        //        liveEncontrada.ObjectState = ObjectState.Modified;

        //        if (liveDto.Author == null)
        //            throw new Exception("É obrigatório o autor");

        //        //liveEncontrada.Author = new AspNetUser
        //        //{
        //        //    Id = liveDto.Author.Id.ToString(),
        //        //    Email = liveDto.Author.Email
        //        //};                 
        //    }
        //    else
        //    {
        //        liveEncontrada = new LiveMap
        //        {
        //            Id = liveDto.Id,
        //            Title = liveDto.Title,
        //            Print = liveDto.Print,
        //            Themes = liveDto.Themes,
        //            UrlDestino = liveDto.UrlDestino,
        //            Prince = liveDto.Prince,
        //            Description = liveDto.Description,
        //            Chat = liveDto.Chat,
        //            ObjectState = ObjectState.Added,
        //        };

        //        if (liveDto.Author == null)
        //            throw  new Exception("É obrigatório o autor");

        //        //liveEncontrada.Author = new AspNetUser
        //        //{
        //        //    Id = liveDto.Author.Id,
        //        //    Email = liveDto.Author.Email
        //        //};                    

        //    }

        //    _repositoryLive.Save(liveEncontrada);           

        //    return GetById(liveEncontrada.Id);
        //}

        //public void Delet(int id)
        //{
        //    _repositoryLive.Delet(id);
        //}

        //public LiveDto GetById(int id)
        //{
        //    return  AdapterLive.ConverterMapParaDto(_repositoryLive.GetById(id));
        //}

        //public ObservableCollection<LiveDto> GetListLive()
        //{
        //    return AdapterLive.ConverterMapParaDto(_repositoryLive.GetListLive());
        //}

        //public ObservableCollection<LiveDto> GetListByCourse(int id)
        //{
        //    return AdapterLive.ConverterMapParaDto(_repositoryLive.GetListByCourse(id));
        //}

        //public ObservableCollection<LiveDto> GetSearchListLive(string text)
        //{
        //    return AdapterLive.ConverterMapParaDto(_repositoryLive.GetSearchListLive(text));
        //}

    }
}
