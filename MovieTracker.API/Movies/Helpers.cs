using MovieTracker.API.Movies;

namespace MovieTracker.Data.Models
{
    public static class Helpers
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
