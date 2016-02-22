namespace SciHub.Web.Areas.ShortStory.ViewModels.ShortStories
{
    using System.Collections.Generic;
    using SciHub.Web.Areas.ShortStory.ViewModels.ShortStories;

    public class ShortStoriesPageableListViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int AllItemsCount { get; set; }

        public IEnumerable<AllShortStoriesShortStoryViewModel> ShortStories { get; set; }
    }
}