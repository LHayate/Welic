﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApi.API.Controllers
{
    public class MarketplaceController : Controller
    {
        // GET: Marketplace
        public ActionResult Index()
        {
            return View();
        }
    }
}