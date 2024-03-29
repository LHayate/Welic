﻿using System.Linq;
using GridMvc;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace WebApi.Models.Grids
{
    public class ContentPagesGrid : Grid<ContentPage>
    {
        public ContentPagesGrid(IQueryable<ContentPage> contentPage)
            : base(contentPage)
        {
        }
    }
}