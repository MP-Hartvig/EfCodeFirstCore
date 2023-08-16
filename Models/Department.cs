using System.ComponentModel.DataAnnotations;

namespace EfCodeFirstCore.Models
{
    public class Department
    {
        [Key]
        [Required]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public Location location { get; set; }
    }
}
