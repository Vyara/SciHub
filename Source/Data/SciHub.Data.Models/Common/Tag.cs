namespace SciHub.Data.Models.Common
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Book;
    using Data.Common.Models;
    using Movie;
    using SciHub.Common.Constants;
    using ShortStory;


    public class Tag : BaseModel<int>
    {
        private ICollection<Movie> movies;
        private ICollection<Book> books;
        private ICollection<ShortStory> shortStories;

        public Tag()
        {
            this.movies = new HashSet<Movie>();
            this.books = new HashSet<Book>();
            this.shortStories = new HashSet<ShortStory>();
        }

        [Required]
        [MinLength(DataModelConstants.TagMinLength)]
        [MaxLength(DataModelConstants.TagMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies
        {
            get { return this.movies; }
            set { this.movies = value; }
        }

        public virtual ICollection<Book> Books
        {
            get { return this.books; }
            set { this.books = value; }
        }

        public virtual ICollection<ShortStory> ShortStories
        {
            get { return this.shortStories; }
            set { this.shortStories = value; }
        }
    }
}
