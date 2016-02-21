using SciHub.Data.Common.Repositories;

namespace SciHub.Services.Data
{
    using System.Linq;
    using SciHub.Data;
    using SciHub.Data.Models;
    using SciHub.Data.Models.Movie;
    using SciHub.Services.Data.Contracts;

    public class UsersService : IUsersService
    {
        private readonly IDbRepository<User> users;

        public UsersService(IDbRepository<User> users)
        {
            this.users = users;
        }

        public User GetUser(string userName)
        {
            var user = this.users.All().FirstOrDefault(x => x.UserName == userName);
            return user;
        }


    }
}
