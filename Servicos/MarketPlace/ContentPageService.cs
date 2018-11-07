﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Marketplaces.Entityes;
using Welic.Dominio.Models.Marketplaces.Services;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Servicos.MarketPlace
{
    public class ContentPageService : Service<ContentPage>, IContentPageService
    {
        public ContentPageService(IRepositoryAsync<ContentPage> repository)
            : base(repository)
        {
        }
    }
}