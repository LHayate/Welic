﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Marketplaces.Entityes;
using Welic.Dominio.Models.Marketplaces.Services;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Services.MarketPlace
{
    public class CustomFieldListingService : Service<ListingMeta>, ICustomFieldListingService
    {
        public CustomFieldListingService(IRepositoryAsync<ListingMeta> repository)
            : base(repository)
        {
        }
    }
}
