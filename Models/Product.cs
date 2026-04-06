using System.ComponentModel.DataAnnotations;

namespace customer_wellness_project.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        public string Category { get; set; } = string.Empty;
        
        public int StockQuantity { get; set; }
        
        public int MinimumThreshold { get; set; } // Triggers the "Low Stock" warning
    }
}
