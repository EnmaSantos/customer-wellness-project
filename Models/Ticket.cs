using System;

namespace customer_wellness_project.Models
{
    public class Ticket
    {
        public int Id { get; set; } // Primary Key
        
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "Open"; // Open, In Progress, Resolved
        public string Priority { get; set; } = "Normal"; // Low, Normal, Urgent
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ResolvedAt { get; set; }

        // Foreign Key to the Product (Nullable, because a ticket might just be a general question)
        public int? ProductId { get; set; }
        public Product? Product { get; set; }

        // Foreign Key to the User (Employee assigned to the ticket)
        public string? AssignedUserId { get; set; }
        public ApplicationUser? AssignedUser { get; set; }
    }
}
