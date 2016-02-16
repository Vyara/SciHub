namespace SciHub.Web.ViewModels.Account
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using Data.Models.Enumerators;

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "First name")]
        [StringLength(DataModelConstants.UserFirstNameMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = DataModelConstants.UserFirstNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [StringLength(DataModelConstants.UserLastNameMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = DataModelConstants.UserLastNameMinLength)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Avatar")]
        [RegularExpression(DataModelConstants.UrlValiadtion)]
        public string Avatar { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [RegularExpression(DataModelConstants.UrlValiadtion)]
        public DateTime? BirthDate { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "About")]
        [StringLength(DataModelConstants.UserAboutMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string About { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}