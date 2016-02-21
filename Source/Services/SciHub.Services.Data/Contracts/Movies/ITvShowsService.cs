using SciHub.Data.Models.TvShow;
using SciHub.Services.Data.DataTransferObjects;

namespace SciHub.Services.Data.Contracts.Movies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
