namespace SciHub.Web.Areas.Admin.ViewModels
{
    using System;
    using SciHub.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;
    using SciHub.Common.Constants;
    using SciHub.Common.Constants.Models;
    using SciHub.Data.Models.Enumerators;
    using Data.Models;

    public class UserAdminViewModel : IMapFrom<User>
    {
        [Required]
        public string Id { get; set; }

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
    }
}