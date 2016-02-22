namespace SciHub.Web.Areas.ShortStory.ViewModels.ShortStories
{
    using System.Collections.Generic;

    public class TopShortStoryListViewModel
    {
        public IEnumerable<TopShortStoryIndexViewModel> ShortStories { get; set; }
    }
}