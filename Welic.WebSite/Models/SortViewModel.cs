﻿using Welic.Dominio.Enumerables;

namespace WebApi.Models
{
    public class SortViewModel
    {
        public SortViewModel()
        {
            PageSize = (int)Enum_EstateSortPageSize.Page20;
            PageNumber = 1;
        }

        public int SortBy { get; set; }

        public int SortCriteriaId { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public Enum_SortView SortView { get; set; }
    }
}
