using System.Web.Mvc;

namespace SciHub.Web.Areas.TvShow
{
    public class TvShowAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TvShow";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TvShow_default",
                "TvShow/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "SciHub.Web.Areas.TvShow.Controllers" });
        }
    }
}