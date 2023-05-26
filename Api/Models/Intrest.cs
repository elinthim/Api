using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Intrest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IntrestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [ForeignKey("Person")]
        public int FK_PersonId { get; set; }
        public Person Person { get; set; }
    }
}
