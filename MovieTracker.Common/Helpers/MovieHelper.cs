using MovieTracker.Core.Dtos;
using MovieTracker.Data.Models;

namespace MovieTracker.Core.Helpers
{
    public static class MovieHelper
    {
        public static Movie MapToMovie(this AddMovieRequest request)
        {
            return new Movie
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                YearOfRelease = request.YearOfRelease
            };
        }

        public static Movie MapToMovie(this UpdateMovieRequest request, Guid id)
        {
            return new Movie
            {
                Id = id,
                Title = request.Title,
                YearOfRelease = request.YearOfRelease
            };
        }
    }
}
