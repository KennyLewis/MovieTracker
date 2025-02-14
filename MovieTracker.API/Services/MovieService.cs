
using Microsoft.EntityFrameworkCore;
using MovieTracker.API.Context;
using MovieTracker.Data.Models;

namespace MovieTracker.API.Services
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _dbContext;

        public MovieService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Movie> Create(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync();

            return movie;
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var result = await _dbContext.Movies.Where(movie => movie.Id == id).ExecuteDeleteAsync();
            return result > 0;
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            var movies = await _dbContext.Movies.ToListAsync();
            return movies.OrderBy(movie => movie.YearOfRelease).ThenBy(movie => movie.Title);
        }

        public async Task<Movie?> GetById(Guid id)
        {
            return await _dbContext.Movies.FindAsync(id);
        }

        public async Task<Movie> Update(Movie movie)
        {
            _dbContext.Movies.Update(movie);
            var result = await _dbContext.SaveChangesAsync();

            // We'll eventually want to make sure the result is valid instead of just returning the same movie object
            return movie;
        }
    }
}
