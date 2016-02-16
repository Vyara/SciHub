namespace SciHub.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Data.Common.Models;
    using Book;
    using Enumerators;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Movie;
    using SciHub.Common.Constants;
    using SciHub.Common.Constants.Models;
    using ShortStory;
    using TvShow;

    public class User : IdentityUser, IAuditInfo, IDeletableEntity
    {
        private ICollection<ShortStory.ShortStory> shortStories;

        private ICollection<MovieComment> movieComments;
        private ICollection<BookComment> bookComments;
        private ICollection<ShortStoryComment> shortStoryComments;
        private ICollection<TvShowComment> tvShowComments;

        private ICollection<MovieRating> movieRatings;
        private ICollection<BookRating> bookRatings;
        private ICollection<ShortStoryRating> shortStoryRatings;
        private ICollection<TvShowRating> tvShowRatings;


        public User()
        {
            this.CreatedOn = DateTime.Now;

            this.shortStories = new HashSet<ShortStory.ShortStory>();

            this.movieComments = new HashSet<MovieComment>();
            this.bookComments = new HashSet<BookComment>();
            this.shortStoryComments = new HashSet<ShortStoryComment>();
            this.tvShowComments = new HashSet<TvShowComment>();

            this.movieRatings = new HashSet<MovieRating>();
            this.bookRatings = new HashSet<BookRating>();
            this.shortStoryRatings = new HashSet<ShortStoryRating>();
            this.tvShowRatings = new HashSet<TvShowRating>();
        }

        [Required]
        [MinLength(UserModelConstants.FirstNameMinLength)]
        [MaxLength(UserModelConstants.FirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(UserModelConstants.LastNameMinLength)]
        [MaxLength(UserModelConstants.LastNameMaxLength)]
        public string LastName { get; set; }

        [RegularExpression(DataModelConstants.UrlValiadtion)]
        public string Avatar { get; set; }

        public DateTime? BirthDate { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [MaxLength(UserModelConstants.AboutMaxLength)]
        public string About { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsHidden { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<ShortStory.ShortStory> ShortStories
        {
            get { return this.shortStories; }
            set { this.shortStories = value; }
        }

        public virtual ICollection<MovieComment> MovieComments
        {
            get { return this.movieComments; }
            set { this.movieComments = value; }
        }

        public virtual ICollection<BookComment> BookComments
        {
            get { return this.bookComments; }
            set { this.bookComments = value; }
        }

        public virtual ICollection<ShortStoryComment> ShortStoryComments
        {
            get { return this.shortStoryComments; }
            set { this.shortStoryComments = value; }
        }

        public virtual ICollection<TvShowComment> TvShowComments
        {
            get { return this.tvShowComments; }
            set { this.tvShowComments = value; }
        }

        public virtual ICollection<MovieRating> MovieRatings
        {
            get { return this.movieRatings; }
            set { this.movieRatings = value; }
        }

        public virtual ICollection<BookRating> BookRatings
        {
            get { return this.bookRatings; }
            set { this.bookRatings = value; }
        }

        public virtual ICollection<ShortStoryRating> ShortStoryRatings
        {
            get { return this.shortStoryRatings; }
            set { this.shortStoryRatings = value; }
        }

        public virtual ICollection<TvShowRating> TvShowRatings
        {
            get { return this.tvShowRatings; }
            set { this.tvShowRatings = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}