using System.ComponentModel.DataAnnotations;

namespace MovieTracker.API.Movies
{
    public class Movie
    {
        [Key]
        public required Guid Id { get; init; }
        [MaxLength(255)]

        public required string Title { get; set; }

        public required int YearOfRelease { get; set; }
    }
}
