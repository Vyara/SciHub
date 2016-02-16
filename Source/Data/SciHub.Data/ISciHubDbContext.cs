namespace SciHub.Data
{
    using System.Data.Entity;
    using Models;
    using Models.Book;
    using Models.Common;
    using Models.Movie;
    using Models.ShortStory;
    using Models.TvShow;

    public interface ISciHubDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Actor> Actors { get; set; }

        IDbSet<Director> Directors { get; set; }

        IDbSet<Tag> Tags { get; set; }

        IDbSet<ShortStory> ShortStories { get; set; }

        IDbSet<ShortStoryComment> ShortStoryComments { get; set; }

        IDbSet<ShortStoryRating> ShortStoryRatings { get; set; }

        IDbSet<Book> Books { get; set; }

        IDbSet<BookAuthor> BookAuthors { get; set; }

        IDbSet<BookComment> BookComments { get; set; }

        IDbSet<BookCover> BookCovers { get; set; }

        IDbSet<BookRating> BookRatings { get; set; }

        IDbSet<Movie> Movies { get; set; }

        IDbSet<MovieComment> MovieComments { get; set; }

        IDbSet<MoviePoster> MoviePosters { get; set; }

        IDbSet<MovieRating> MovieRatings { get; set; }

        IDbSet<MovieStudio> MovieStudios { get; set; }

        IDbSet<TvShow> TvShows { get; set; }

        IDbSet<TvShowChannel> TvShowChannels { get; set; }

        IDbSet<TvShowComment> TvShowComments { get; set; }

        IDbSet<TvShowPoster> TvShowPosters { get; set; }

        IDbSet<TvShowRating> TvShowRatings { get; set; }

    }
}
