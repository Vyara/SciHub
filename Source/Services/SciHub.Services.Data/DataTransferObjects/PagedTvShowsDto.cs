namespace SciHub.Services.Data.DataTransferObjects
{
    using System.Linq;
    using SciHub.Data.Models.TvShow;

    public class PagedTvShowsDto
    {
        public int TotalPages { get; set; }

        public int AllItemsCount { get; set; }

        public IQueryable<TvShow> TvShows { get; set; }
    }
}

