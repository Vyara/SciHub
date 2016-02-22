namespace SciHub.Services.Data.Contracts
{
    using System.Linq;
    using SciHub.Data.Models;

    public interface IUsersService
    {
        IQueryable<User> GetAll();

        IQueryable<User> GetAllWithDeleted();

        User GetById(string id);

        User GetUser(string name);

        User Add(User user);

        void Delete(User user);

        IQueryable<User> Update(User user);

    }
}
