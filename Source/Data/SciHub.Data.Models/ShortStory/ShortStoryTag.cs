namespace SciHub.Data.Models.ShortStory
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using SciHub.Common.Constants;


    public class ShortStoryTag : BaseModel<int>
    {
        [Required]
        [MinLength(DataModelConstants.ShortStoryTagMinLength)]
        [MaxLength(DataModelConstants.ShortStoryTagMaxLength)]
        public string Value { get; set; }
    }
}
