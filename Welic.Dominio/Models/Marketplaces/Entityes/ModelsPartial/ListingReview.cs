using System;
using System.ComponentModel.DataAnnotations;

namespace Welic.Dominio.Models.Marketplaces.Entityes
{
    [MetadataType(typeof(ListingReviewMetaData))]
    public partial class ListingReview
    {
        public string RatingClass
        {
            get
            {
                return "s" + Math.Round(Rating * 2);
            }
        }        
    }

    public class ListingReviewMetaData
    {        
    }
}
