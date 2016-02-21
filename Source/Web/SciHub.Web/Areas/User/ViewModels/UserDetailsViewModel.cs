namespace SciHub.Web.Areas.User.ViewModels
{
    using Data.Models;
    using Infrastructure.Mapping;


    public class UserDetailsViewModel : IMapFrom<User>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Avatar { get; set; }

        public string About { get; set; }

    }
}