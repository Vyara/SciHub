namespace SciHub.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using SciHub.Data.Common.Repositories;
    using SciHub.Data.Models.Common;
    using SciHub.Data.Models.Movie;
    using SciHub.Data.Models.TvShow;

    public class ActorsService : IActorsService
    {
        private readonly IDbRepository<Actor> actors;

        public ActorsService(IDbRepository<Actor> actors)
        {
            this.actors = actors;
        }

        public IQueryable<Actor> GetAll()
        {
            return this.actors.All()
                .OrderByDescending(m => m.CreatedOn);
        }

        public ICollection<TvShow> GetActorTvShows(int actorId)
        {
            var tvShows = this.actors.GetById(actorId).TvShows;
            return tvShows;
        }
    }
}
