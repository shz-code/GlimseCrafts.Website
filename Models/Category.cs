using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
//using System.Diagnostics.CodeAnalysis;

namespace GlimseCrafts.Website.Models
{
    public class Category
    {
        [Key]
        [DisplayName("Serial")]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Created {  get; set; }
    }
}
