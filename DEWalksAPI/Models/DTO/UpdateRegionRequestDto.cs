using System.ComponentModel.DataAnnotations;

namespace DEWalksAPI.Models.DTO
{
    public class UpdateRegionRequestDto
    {
        [Required(ErrorMessage = "Code is required!")]
        [MinLength(2, ErrorMessage = "Code must be at least 2 characters!")]
        [MaxLength(10, ErrorMessage = "Code can't be more than 10 characters!")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters!")]
        [MaxLength(50, ErrorMessage = "Name can't be more than 50 characters!")]
        public string Name { get; set; }

        [Url(ErrorMessage = "Invalid URL format!")]
        public string? RegionImageUrl { get; set; }
    }
}
