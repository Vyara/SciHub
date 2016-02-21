namespace SciHub.Web.Areas.Movie.ViewModels.Movies
{
    using SciHub.Data.Models.Movie;
    using SciHub.Web.Infrastructure.Mapping;

    public class MovieStudioViewModel : IMapFrom<MovieStudio>
    {
        public string Id { get; set; }

        public string Name { get; set; }

    }
}