using System;
using System.Collections.Generic;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace Welic.Dominio.ViewModels
{
    public class Statistics
    {
        public int UserCount { get; set; }

        public int TransactionCount { get; set; }

        public int OrderCount { get; set; }

        public int ListingCount { get; set; }

        public List<CategoryStat> CategoryStats { get; set; }

        public Dictionary<DateTime, int> ItemsCountDictionary { get; set; }
    }
}
