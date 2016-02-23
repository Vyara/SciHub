namespace SciHub.Web.Controllers
{
    using System.Web.Mvc;

    public class ChatController : BaseController
    {
        public ActionResult Chat()
        {
            return this.View();
        }
    }
}