
using System.ComponentModel.DataAnnotations;
namespace Students.Models
{
    public class Mark
    {
        public int Id { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public int Value { get; set; }
    }
}
