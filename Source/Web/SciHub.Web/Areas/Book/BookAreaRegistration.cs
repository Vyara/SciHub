namespace SciHub.Web.Areas.Book
{
    using System.Web.Mvc;

    public class BookAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Book";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Book_default",
                "Book/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "SciHub.Web.Areas.Book.Controllers" });
        }
    }
}