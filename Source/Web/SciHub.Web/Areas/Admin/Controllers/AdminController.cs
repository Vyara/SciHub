﻿namespace SciHub.Web.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class AdminController : BaseAdminController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}