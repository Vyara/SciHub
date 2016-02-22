namespace SciHub.Services.Data.DataTransferObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SciHub.Data.Models.ShortStory;

    public class PagedShortStoryDto
    {
        public int TotalPages { get; set; }

        public int AllItemsCount { get; set; }

        public IQueryable<ShortStory> ShortStories { get; set; }
    }
}
