using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace OutFit.CoreBusiness
{
    public class Product
    {
        [Key]
        public  int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public int Type { get; set; }
        public string? Description { get; set; }
        public string? brand { get; set; }

        [Required]
        [Range(0, int.MaxValue,ErrorMessage ="Quantity Must be greater Than 0")]
        public int Quantity { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Price Must be greater or eqal to 0")]
        public decimal Price { get; set; }

        [Required]
        public string Size { get; set; }
        public string? Colour { get; set; }


        public string ProductImageUrl { get; set; } = string.Empty;
        public DateTime DateAdded { get; set; } = System.DateTime.UtcNow;
        public DateTime? LastUpdatedOn { get; set; }
        public string? LastUpdatedBy { get; set; }

    }
}