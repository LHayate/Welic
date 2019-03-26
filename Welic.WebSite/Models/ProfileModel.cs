using System.Collections.Generic;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace WebApi.Models
{
    public class ProfileModel
    {
        public List<ListingItemModel> Listings { get; set; }

        public ApplicationUser User { get; set; }

        public List<ListingReview> ListingReviews { get; set; }
    }
}