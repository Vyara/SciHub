namespace SciHub.Web.ViewModels.Account
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models.Enumerators;
    using Common.Constants;
    using Common.Constants.Models;

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
        [StringLength(UserModelConstants.FirstNameMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = UserModelConstants.FirstNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [StringLength(UserModelConstants.LastNameMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = UserModelConstants.LastNameMinLength)]
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
        [StringLength(UserModelConstants.AboutMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.")]
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