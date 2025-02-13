
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
        public async Task<Movie> Create(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync();

            return movie;
        }

        public Task<bool> DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await _dbContext.Movies.ToListAsync();
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
