namespace SciHub.Data.Models.ShortStory
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using SciHub.Common.Constants.Models;

    public class ShortStoryTag : BaseModel<int>
    {
        [Required]
        [MinLength(ShortStoryModelConstants.TagMinLength)]
        [MaxLength(ShortStoryModelConstants.TagMaxLength)]
        public string Name { get; set; }
    }
}
