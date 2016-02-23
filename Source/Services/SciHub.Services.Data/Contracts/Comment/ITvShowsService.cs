namespace SciHub.Services.Data.Contracts.Comment
{
    using System.Collections.Generic;
    using System.Linq;
    using SciHub.Data.Models.TvShow;
    using SciHub.Services.Data.DataTransferObjects;

    public interface ITvShowsService
    {
        IQueryable<TvShow> GetTop(int count);

        IQueryable<TvShow> GetAll();

        PagedTvShowsDto GetAllWithPaging(int page, int itemsPerPage, string order, string criteria);

        TvShow GetById(int id);

        void Rate(int tvShowId, float value, string userId);

        ICollection<TvShow> GetActorShows(int actorId);

        ICollection<TvShow> GetTagShows(int tagId);

        ICollection<TvShow> GetChannelShows(int studioId);

    }
}
