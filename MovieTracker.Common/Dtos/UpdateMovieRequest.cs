using System.ComponentModel.DataAnnotations;

namespace MovieTracker.Core.Dtos
{
    public class UpdateMovieRequest
    {
        [MaxLength(255)]
        public required string Title { get; init; }

        public required int YearOfRelease { get; init; }
    }
}
