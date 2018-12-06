using System.Collections.Generic;
using Welic.Dominio;
using Welic.Dominio.Models.News.Maps;
using Welic.Dominio.Models.News.Services;
using Welic.Dominio.Patterns.Repository.Pattern.Infrastructure;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Servicos.News
{
    public class ServiceNews : Service<NewsMap>, IServiceNews
    {
        public ServiceNews(IRepositoryAsync<NewsMap> repository) 
            : base(repository)
        {
        }
    }
}
