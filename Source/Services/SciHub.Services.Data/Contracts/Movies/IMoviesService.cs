﻿using SciHub.Services.Data.DataTransferObjects;

namespace SciHub.Services.Data.Contracts.Movies
{
    using System.Linq;
    using SciHub.Data.Models.Movie;

    public interface IMoviesService
    {
        IQueryable<Movie> GetTop(int count);

        IQueryable<Movie> GetAll();

        PagedMoviesDto GetAllWithPaging(int page, int itemsPerPage, string order, string criteria);

        Movie GetById(int id);

        void Rate(int movieId, float value, string userId);

    }
}
