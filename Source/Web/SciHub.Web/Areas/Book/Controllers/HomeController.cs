namespace SciHub.Web.Areas.Book.Controllers
{
    using System.Web.Mvc;
    using Web.Controllers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}