
using Microsoft.EntityFrameworkCore;
using MovieTracker.API.Database;

namespace MovieTracker.API.Movies
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _dbContext;

        public MovieService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Movie> Create(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            var movies = await _dbContext.Movies.ToListAsync();
            return movies;
        }

        public Task<Movie?> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> Update(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
