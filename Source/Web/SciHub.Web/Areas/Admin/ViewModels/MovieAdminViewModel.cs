namespace SciHub.Web.Areas.Admin.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using SciHub.Common.Constants.Models;
    using SciHub.Data.Models.Common;
    using SciHub.Data.Models.Movie;
    using SciHub.Web.Infrastructure.Mapping;


    public class MovieAdminViewModel : IMapFrom<Movie>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(MovieModelConstants.TitleMinLength)]
        [MaxLength(MovieModelConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [Range(MovieModelConstants.YearMinValue, MovieModelConstants.YearMaxValue)]
        public int Year { get; set; }

        [MinLength(MovieModelConstants.SummaryMinLength)]
        [MaxLength(MovieModelConstants.SummaryMaxLength)]
        [DataType(DataType.MultilineText)]
        public string Summary { get; set; }

        public int DirectorId { get; set; }

        public int PosterId { get; set; }

        public int StudioId { get; set; }


        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}