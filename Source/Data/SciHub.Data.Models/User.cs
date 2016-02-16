namespace SciHub.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Data.Common.Models;
    using Enumerators;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SciHub.Common.Constants;
    using SciHub.Common.Constants.Models;

    public class User : IdentityUser, IAuditInfo, IDeletableEntity 
    {
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

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}