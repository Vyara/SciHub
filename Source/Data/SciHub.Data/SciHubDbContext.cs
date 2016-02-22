namespace SciHub.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Common.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.Book;
    using Models.Common;
    using Models.Movie;
    using Models.ShortStory;
    using Models.TvShow;

    public class SciHubDbContext : IdentityDbContext<User>, ISciHubDbContext
    {
        public SciHubDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Actor> Actors { get; set; }

        public virtual IDbSet<BookAuthor> BookAuthors { get; set; }

        public virtual IDbSet<BookComment> BookComments { get; set; }

        public virtual IDbSet<BookCover> BookCovers { get; set; }

        public virtual IDbSet<BookRating> BookRatings { get; set; }

        public virtual IDbSet<Book> Books { get; set; }

        public virtual IDbSet<Director> Directors { get; set; }

        public virtual IDbSet<MovieComment> MovieComments { get; set; }


        public virtual IDbSet<MoviePoster> MoviePosters { get; set; }

        public virtual IDbSet<MovieRating> MovieRatings { get; set; }

        public virtual IDbSet<Movie> Movies { get; set; }

        public virtual IDbSet<MovieStudio> MovieStudios { get; set; }

        public virtual IDbSet<ShortStory> ShortStories { get; set; }

        public virtual IDbSet<ShortStoryComment> ShortStoryComments { get; set; }

        public virtual IDbSet<ShortStoryRating> ShortStoryRatings { get; set; }

        public virtual IDbSet<Tag> Tags { get; set; }

        public virtual IDbSet<TvShowChannel> TvShowChannels { get; set; }


        public virtual IDbSet<TvShowComment> TvShowComments { get; set; }

        public virtual IDbSet<TvShowPoster> TvShowPosters { get; set; }

        public virtual IDbSet<TvShowRating> TvShowRatings { get; set; }

        public virtual IDbSet<TvShow> TvShows { get; set; }


        public static SciHubDbContext Create()
        {
            return new SciHubDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Movie>()
                .HasMany(x => x.Comments)
                .WithRequired(x => x.Movie)
                .WillCascadeOnDelete(true);

            modelBuilder
                .Entity<Book>()
                .HasMany(x => x.Comments)
               .WithRequired(x => x.Book)
                .WillCascadeOnDelete(true);

            modelBuilder
                .Entity<TvShow>()
                .HasMany(x => x.Comments)
                .WithRequired(x => x.TvShow)
                .WillCascadeOnDelete(true);

            modelBuilder
                .Entity<ShortStory>()
                .HasMany(x => x.Comments)
                .WithRequired(x => x.ShortStory)
                .WillCascadeOnDelete(true);


            base.OnModelCreating(modelBuilder);
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}