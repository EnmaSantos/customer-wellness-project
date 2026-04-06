using System.ComponentModel.DataAnnotations;

namespace customer_wellness_project.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        public string Status { get; set; } = "Open"; // Open, Urgent, Resolved
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
