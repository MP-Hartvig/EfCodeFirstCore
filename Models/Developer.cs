using System.ComponentModel.DataAnnotations;

namespace EfCodeFirstCore.Models
{
    public class Developer : Employee
    {
        [Required]
        public string primaryProgrammingLanguage { get; set; }
    }
}
