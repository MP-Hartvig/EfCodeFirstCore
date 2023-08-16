using System.ComponentModel.DataAnnotations;

namespace EfCodeFirstCore.Models
{
    public abstract class Employee
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string firstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string lastName { get; set; }

        [Required]
        [MaxLength(255)]
        public string streetName { get; set; }

        [Required]
        public int streetNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string privatePhone { get; set; }

        [Required]
        public Department department { get; set; }
    }
}
