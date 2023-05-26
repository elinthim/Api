using System.ComponentModel.DataAnnotations;

namespace Api.Models.DTO
{
    public class PersonCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
    }
}
