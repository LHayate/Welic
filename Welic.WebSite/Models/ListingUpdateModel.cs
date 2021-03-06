﻿using System.Collections.Generic;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace WebApi.Models
{
    public class ListingUpdateModel
    {
        public ListingUpdateModel()
        {            
            Categories = new List<Category>();
            Users = new List<ApplicationUser>();
            Pictures = new List<PictureModel>();
            CustomFields = new CustomFieldListingModel();
        }

        public int CategoryID { get; set; }

        public int ListingTypeID { get; set; }

        public string UserID { get; set; }

        public Listing ListingItem { get; set; }

        public List<Category> Categories { get; set; }

        public List<ListingType> ListingTypes { get; set; }

        public List<ApplicationUser> Users { get; set; }

        public List<PictureModel> Pictures { get; set; }

        public CustomFieldListingModel CustomFields { get; set; }
    }
}
