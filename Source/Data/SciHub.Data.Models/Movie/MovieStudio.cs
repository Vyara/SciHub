namespace SciHub.Data.Models.Movie
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data.Common.Models;
    using SciHub.Common.Constants.Models;

    public class MovieStudio : BaseModel<int>
    {
        private ICollection<Movie> movies;

        public MovieStudio()
        {
            this.movies = new HashSet<Movie>();
        }

        [Required]
        [MinLength(MovieModelConstants.StudioNameMinLenght)]
        [MaxLength(MovieModelConstants.StudioNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies
        {
            get { return this.movies; }
            set { this.movies = value; }
        }
    }
}
