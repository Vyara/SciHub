namespace SciHub.Web.Areas.Movie
{
    using System.Web.Mvc;

    public class MovieAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Movie";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Movie_default",
                "Movie/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "SciHub.Web.Areas.Movie.Controllers" });
        }
    }
}