using System.ComponentModel.DataAnnotations;

namespace DEWalksAPI.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        public string Code { get; set; }
        [Required]
        [MinLength(3,ErrorMessage = "Name must be at least 3 characters!")]
        [MaxLength(15,ErrorMessage = "Name can't be more than 15 characters!")]
        public string Name { get; set; }
        public string RegionImageUrl { get; set; }
    }
}
