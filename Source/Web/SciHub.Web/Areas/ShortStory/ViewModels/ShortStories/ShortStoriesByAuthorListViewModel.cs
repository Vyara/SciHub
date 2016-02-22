namespace SciHub.Web.Areas.ShortStory.ViewModels.ShortStories
{
    using System.Collections.Generic;
    using Data.Models.ShortStory;

    public class ShortStoriesByAuthorListViewModel
    {
        public IEnumerable<ShortStory> ShortStories { get; set; }
    }
}