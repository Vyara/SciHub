using SciHub.Services.Data.Contracts;

namespace SciHub.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SciHub.Data.Common.Repositories;
    using DataTransferObjects;
    using SciHub.Data.Models.Common;
    using SciHub.Data.Models.TvShow;

    public class TvShowsService : ITvShowsService
    {
        private readonly IDbRepository<TvShow> shows;
        private readonly IDbRepository<Actor> actors;
        private readonly IDbRepository<Tag> tags;
        private readonly IDbRepository<TvShowChannel> channels;

        public TvShowsService(IDbRepository<TvShow> shows, IDbRepository<Actor> actors, IDbRepository<Tag> tags, IDbRepository<TvShowChannel> channels)
        {
            this.shows = shows;
            this.actors = actors;
            this.tags = tags;
            this.channels = channels;
        }

        public IQueryable<TvShow> GetTop(int count)
        {
            var shows = this.shows.All()
                .OrderByDescending(m => (m.Ratings.Sum(r => r.Value) / m.Ratings.Count()))
                .ThenBy(m => m.CreatedOn)
                .Take(count);
            return shows;
        }

        public IQueryable<TvShow> GetAll()
        {
            return this.shows.All()
                .OrderByDescending(m => m.CreatedOn);
        }

        public PagedTvShowsDto GetAllWithPaging(int page, int itemsPerPage, string order, string criteria)
        {
            var allItemsCount = this.shows.All().Count();
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)itemsPerPage);
            var itemsToSkip = (page - 1) * itemsPerPage;

            var allShows = this.shows.All();

            if (!string.IsNullOrEmpty(criteria))
            {
                allShows = allShows.Where(x => x.Title.Contains(criteria) || x.Summary.Contains(criteria));
            }

            if (order == "newest")
            {
                allShows = allShows.OrderByDescending(x => x.CreatedOn);
            }
            else if (order == "top")
            {
                allShows = allShows.OrderByDescending(m => ((float)m.Ratings.Sum(r => r.Value) / m.Ratings.Count()));
            }

            allShows = allShows
                     .Skip(itemsToSkip)
                     .Take(itemsPerPage);

            var dto = new PagedTvShowsDto
            {
                AllItemsCount = allItemsCount,
                TvShows = allShows,
                TotalPages = totalPages
            };

            return dto;
        }

        public void Rate(int showId, float value, string userId)
        {
            var tvShow = this.shows.GetById(showId);

            if (tvShow != null)
            {
                tvShow.Ratings.Add(new TvShowRating()
                {
                    Value = value,
                    UserId = userId
                });
            }

            this.shows.SaveChanges();
        }

        public TvShow GetById(int id)
        {
            var show = this.shows.GetById(id);
            return show;
        }

        public ICollection<TvShow> GetActorShows(int actorId)
        {
            var shows = this.actors.GetById(actorId).TvShows;
            return shows;
        }

        public ICollection<TvShow> GetTagShows(int tagId)
        {
            var shows = this.tags.GetById(tagId).TvShows;
            return shows;
        }

        public ICollection<TvShow> GetChannelShows(int studioId)
        {
            var shows = this.channels.GetById(studioId).TvShows;
            return shows;
        }

    }
}

