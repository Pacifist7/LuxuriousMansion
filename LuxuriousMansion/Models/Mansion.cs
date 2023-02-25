using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuxuriousMansion.Models
{
    public class Mansion
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        [Display(Name="Posted Date")]
        public DateTime? CreatedDate { get; set; }
    }
}
