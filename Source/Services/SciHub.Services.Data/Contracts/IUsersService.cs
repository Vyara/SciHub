namespace SciHub.Services.Data.Contracts
{
    using SciHub.Data.Models;

    public interface IUsersService
    {
        User GetUser(string name);
    }
}
