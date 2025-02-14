using MovieTracker.API.Services;
using MovieTracker.Core.Dtos;
using MovieTracker.Core.Helpers;

namespace MovieTracker.API.Endpoints
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
                var movie = request.MapToMovie();

                var result = await movieService.Create(movie);
                return result;
            });

            group.MapPut("/{id:guid}", async (IMovieService movieService, Guid id, UpdateMovieRequest request) =>
            {
                var existingMovie = request.MapToMovie(id);
                await movieService.Update(existingMovie);

                return Results.Ok(existingMovie);
            });

            group.MapDelete("/{id:guid}", async (IMovieService movieService, Guid id) =>
            {
                var movieDeleted = await movieService.DeleteById(id);
                return movieDeleted ? Results.Ok() : Results.NotFound();
            });
        }
    }
}