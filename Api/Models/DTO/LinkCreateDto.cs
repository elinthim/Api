using System.ComponentModel.DataAnnotations;

namespace Api.Models.DTO
{
    public class LinkCreateDto
    {
        [Required]
        public string Url { get; set; }


        [Required]
        public int IntrestId { get; set; }
    }
}
