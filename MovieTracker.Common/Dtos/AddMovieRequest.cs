using System.ComponentModel.DataAnnotations;

namespace MovieTracker.Core.Dtos
{
    public class AddMovieRequest
    {
        [MaxLength(255)]
        public required string Title { get; set; }
        public required int YearOfRelease { get; set; }
    }
}
