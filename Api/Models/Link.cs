using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Link
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LinkId { get; set; }
        public string Url { get; set; }
        [ForeignKey("Intrest")]
        public int FK_IntrestId { get; set; }
        public Intrest Intrest { get; set; }
    }
}
