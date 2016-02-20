using SciHub.Data.Models.Movie;
namespace SciHub.Services.Web.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMoviesService
    {
        IQueryable<Movie> GetTop(int count);

        Movie GetById(int id);

        IQueryable<Movie> GetAll();
    }
}
