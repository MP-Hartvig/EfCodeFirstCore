using System.ComponentModel.DataAnnotations;

namespace EfCodeFirstCore.Models
{
    public class Computer
    {
        [Key]
        [Required]
        public int id { get; set; }

        [Required]
        public string serialNumber { get; set; }

        [Required]
        public Employee employee { get; set; }
    }
}
