using System.ComponentModel.DataAnnotations;

namespace SciHub.Web.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}