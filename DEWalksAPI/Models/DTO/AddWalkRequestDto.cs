using System.ComponentModel.DataAnnotations;

namespace DEWalksAPI.Models.DTO
{
    public class AddWalkRequestDto
    {
        [Required(ErrorMessage = "Name is required!")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters!")]
        [MaxLength(50, ErrorMessage = "Name can't be more than 50 characters!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required!")]
        [MinLength(10, ErrorMessage = "Description must be at least 10 characters!")]
        [MaxLength(500, ErrorMessage = "Description can't be more than 500 characters!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Length is required!")]
        [Range(0.1, 1000, ErrorMessage = "Length must be between 0.1 and 1000 km!")]
        public double LengthInKm { get; set; }

        [Url(ErrorMessage = "Invalid URL format!")]
        public string? WalkImageUrl { get; set; }

        [Required(ErrorMessage = "DifficultyId is required!")]
        public Guid DifficultyId { get; set; }

        [Required(ErrorMessage = "RegionId is required!")]
        public Guid RegionId { get; set; }
    }
}
