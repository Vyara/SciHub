using SciHub.Data.Models.Common;

namespace SciHub.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SciHub.Data.Models.Movie;
    using SciHub.Data.Models.TvShow;

    public interface IActorsService
    {
        IQueryable<Actor> GetAll();
    }
}
