using System.ComponentModel.DataAnnotations;

namespace EfCodeFirstCore.Models
{
    public class Manager : Employee
    {
        [Required]
        public string workPhone { get; set; }
    }
}
