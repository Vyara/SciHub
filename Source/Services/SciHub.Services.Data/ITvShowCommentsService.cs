namespace SciHub.Services.Data
{
    using System.Linq;
    using SciHub.Data.Models.TvShow;

    public interface ITvShowCommentsService
    {
        IQueryable<TvShowComment> GetAll();

        IQueryable<TvShowComment> GetAllByTvShowId(int showId, int? size);

        TvShowComment GetById(int id);

        TvShowComment Add(string content, int showId, string userId);

        void Update(string content, int id);

        void Delete(int id);
    }
}
