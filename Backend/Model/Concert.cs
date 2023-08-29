using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Model
{
    public class Concert
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Musisi { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Description { get; set;} = string.Empty;
        public string Venue { get; set; } = string.Empty;
        public string Date { get; set; }
        public Category Category { get; set; }
    }
}
