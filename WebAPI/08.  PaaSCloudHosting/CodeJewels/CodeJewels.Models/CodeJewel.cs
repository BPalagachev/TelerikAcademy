using System.ComponentModel.DataAnnotations;

namespace CodeJewels.Models
{
    public class CodeJewel
    {
        public CodeJewel()
        {
            this.Rating = 10;
        }

        public int Id { get; set; }

        [Required]
        public string AuthorMail { get; set; }

        public int Rating { get; set; }

        [Required]
        public string SourceCode { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
