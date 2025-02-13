﻿using MovieTracker.Data.Models;

namespace MovieTracker.API.Services
{
    public interface IMovieService
    {
        Task<Movie> Create(Movie movie);
        Task<Movie?> GetById(Guid id);
        Task<IEnumerable<Movie>> GetAll();
        Task<Movie> Update(Movie movie);
        Task<bool> DeleteById(Guid id);
    }
}
