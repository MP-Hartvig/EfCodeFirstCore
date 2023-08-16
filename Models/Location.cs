using System.ComponentModel.DataAnnotations;

namespace EfCodeFirstCore.Models
{
    public class Location
    {
        [Key]
        [Required]
        public int id { get; set; }

        [Required]
        public string city { get; set; }
    }
}
