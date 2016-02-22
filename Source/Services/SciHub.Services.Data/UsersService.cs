namespace SciHub.Services.Data
{
    using System.Linq;
    using SciHub.Data;
    using SciHub.Data.Models;
    using SciHub.Data.Models.Movie;
    using SciHub.Services.Data.Contracts;
    using SciHub.Data.Common.Repositories;
    using Common.Constants;
    public class UsersService : IUsersService
    {
        private readonly IDbRepository<User> users;

        public UsersService(IDbRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }


        public IQueryable<User> GetAllWithDeleted()
        {
            return this.users.AllWithDeleted();
        }


        public User GetById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            return this.users.GetById(id);
        }

        

        public User GetUser(string userName)
        {
            var user = this.users.All().FirstOrDefault(x => x.UserName == userName);
            return user;
        }

        public User Add(User user)
        {

            this.users.Add(user);
            this.users.SaveChanges();
            return user;
        }

        public void Delete(User user)
        {
            this.users.Delete(user);
            this.users.SaveChanges();
        }

        public IQueryable<User> Update(User user)
        {
            this.users.Update(user);
            this.users.SaveChanges();

            return this.users.All().Where(u => u.Id == user.Id);
        }
    }
}
