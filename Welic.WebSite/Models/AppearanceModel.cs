﻿using System.Web;

namespace WebApi.Models
{
    public class AppearanceModel
    {
        public int ID { get; set; }

        public string MainColor { get; set; }

        public string SecondColor { get; set; }

        public string LogoUrl { get; set; }

        public string CoverPhotoUrl { get; set; }

        public string FaviconUrl { get; set; }

        public HttpPostedFileBase Logo { get; set; }

        public HttpPostedFileBase CoverPhoto { get; set; }

        public HttpPostedFileBase Favicon { get; set; }
    }
}