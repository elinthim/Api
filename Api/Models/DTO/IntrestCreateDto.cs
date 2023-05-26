using System.ComponentModel.DataAnnotations;

namespace Api.Models.DTO
{
    public class IntrestCreateDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int PersonId { get; set; }
    }
}
