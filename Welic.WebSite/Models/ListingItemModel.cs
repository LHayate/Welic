using System;
using System.Collections.Generic;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace WebApi.Models
{
    public class ListingItemModel
    {
        public List<Listing> ListingsOther { get; set; }

        public Listing ListingCurrent { get; set; }

        public string UrlPicture { get; set; }

        public List<PictureModel> Pictures { get; set; }

        public List<DateTime> DatesBooked { get; set; }

        public ApplicationUser User { get; set; }

        public List<ListingReview> ListingReviews { get; set; }
    }
}