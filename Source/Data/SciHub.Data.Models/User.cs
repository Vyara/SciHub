namespace SciHub.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Common.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Enumerators;
    using SciHub.Common.Constants;

    public class User : IdentityUser, IAuditInfo, IDeletableEntity 
    {
        [Required]
        [MinLength(DataModelConstants.UserFirstNameMinLength)]
        [MaxLength(DataModelConstants.UserFirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(DataModelConstants.UserLastNameMinLength)]
        [MaxLength(DataModelConstants.UserLastNameMaxLength)]
        public string LastName { get; set; }

        [RegularExpression(DataModelConstants.UrlValiadtion)]
        public string Avatar { get; set; }

        public DateTime? BirthDate { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [MaxLength(DataModelConstants.UserAboutMaxLength)]
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