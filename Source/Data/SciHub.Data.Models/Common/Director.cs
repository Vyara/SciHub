namespace SciHub.Data.Models.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data.Common.Models;
    using Movie;
    using SciHub.Common.Constants;


    public class Director : BaseModel<int>
    {
        private ICollection<Movie> movies;

        public Director()
        {
            this.movies = new HashSet<Movie>();
        }

        [Required]
        [MinLength(DataModelConstants.DirectorFirstNameMinLength)]
        [MaxLength(DataModelConstants.DirectorFirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(DataModelConstants.DirectorLastNameMinLength)]
        [MaxLength(DataModelConstants.DirectorLastNameMaxLength)]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public virtual ICollection<Movie> Movies
        {
            get { return this.movies; }
            set { this.movies = value; }
        }
    }
}
