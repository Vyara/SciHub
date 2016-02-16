namespace SciHub.Data.Models.Book
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using SciHub.Common.Constants.Models;

    public class BookTag : BaseModel<int>
    {
        [Required]
        [MinLength(BookModelConstants.TagMinLength)]
        [MaxLength(BookModelConstants.TagMaxLength)]
        public string Name { get; set; }
    }
}
