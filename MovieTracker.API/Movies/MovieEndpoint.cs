namespace MovieTracker.API.Movies
{
    public static class MovieEndpoint
    {
        public static void MapMovieEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("movies");

            group.MapGet("/", async (IMovieService movieService) =>
            {
                return await movieService.GetAll();
            });

            group.MapGet("/{id:guid}", async (IMovieService movieService, Guid id) =>
            {
                var matchingMovie = await movieService.GetById(id);
                if (matchingMovie is null)
                {
                    return Results.NotFound($"Could not find a movie with id {id}");
                }

                return Results.Ok(matchingMovie);
            });

            group.MapPost("/", async (IMovieService movieService, AddMovieRequest request) =>
            {
                // This eventually needs to use a mapper or something less hard-coded
                var movie = new Movie
                {
                    Id = Guid.NewGuid(),
                    Title = request.Title,
                    YearOfRelease = request.YearOfRelease
                };

                var result = await movieService.Create(movie);
                return result;
            });

            //group.MapPost("/", (Movie movie) =>
            //{
            //    movies.Add((Movie)movie);
            //});

            //group.MapPut("/{id:guid}", (Guid id, Movie request) =>
            //{
            //    var existingMovie = movies.Find(movie => movie.Id == id);
            //    if (existingMovie is null)
            //    {
            //        return Results.NotFound(); // Handle the case where the movie does not exist
            //    }

            //    // Update properties
            //    existingMovie.Title = request.Title;
            //    existingMovie.YearOfRelease = request.YearOfRelease;

            //    return Results.Ok(existingMovie); // Optionally return the updated movie
            //});
        }
    }
}