using System.Web.Mvc;

namespace SciHub.Web.Areas.ShortStory
{
    public class ShortStoryAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ShortStory";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ShortStory_default",
                "ShortStory/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "SciHub.Web.Areas.ShortStory.Controllers" }
            );
        }
    }
}