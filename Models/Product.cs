using System.Collections.Generic;

namespace customer_wellness_project.Models
{
    public class Product
    {
        public int Id { get; set; } // Primary Key
        
        public string Name { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        
        public int StockQuantity { get; set; }
        public int MinimumThreshold { get; set; } 
        
        // Navigation Property: One product can have many related support tickets
        public ICollection<Ticket>? Tickets { get; set; } 
    }
}
