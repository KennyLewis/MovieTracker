namespace MovieTracker.API.Movies
{
    public static class MovieEndpoint
    {
        public static void MapMovieEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("movies");

            var movies = new List<Movie>();
            movies.Add(new Movie { Id = Guid.NewGuid(), Title = "The Lion King", YearOfRelease = 1994 });
            movies.Add(new Movie { Id = Guid.NewGuid(), Title = "Rocky", YearOfRelease = 1976 });

            group.MapGet("/", () =>
            {
                return movies.OrderBy(x => x.YearOfRelease);
            });

            group.MapPost("/", (Movie movie) =>
            {
                movies.Add((Movie)movie);
            });
        }
    }
}