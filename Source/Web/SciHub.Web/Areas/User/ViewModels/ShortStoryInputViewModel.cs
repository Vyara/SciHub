using SciHub.Data.Models.Common;

namespace SciHub.Web.Areas.User.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using SciHub.Common.Constants.Models;
    using SciHub.Web.Infrastructure.Mapping;
    using SciHub.Web.ViewModels.Tags;
    using Data.Models.ShortStory;

    public class ShortStoryInputViewModel : IMapTo<ShortStory>
    {
        [Required]
        [MinLength(ShortStoryModelConstants.TitleMinLength)]
        [MaxLength(ShortStoryModelConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(ShortStoryModelConstants.ContentMinLength)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public IEnumerable<TagViewModel> Tags { get; set; }

        public IEnumerable<int> TagIds { get; set; }
    }
}