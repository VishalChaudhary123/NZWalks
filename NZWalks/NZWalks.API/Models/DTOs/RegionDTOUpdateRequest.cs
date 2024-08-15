using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTOs
{
    public class RegionDTOUpdateRequest
    {
        [Required(ErrorMessage = "Code cannot be blank.")]
        [MinLength(3, ErrorMessage = "Minimun length of the code should be 3.")]
        [MaxLength(3, ErrorMessage = "Maximum length of the code should be 3.")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Name cannot be blank.")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
