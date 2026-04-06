using Microsoft.EntityFrameworkCore;
using customer_wellness_project.Models;

namespace customer_wellness_project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial inventory data (matching the dashboard UI)
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Insulin Humalog", Category = "Medication", StockQuantity = 2, MinimumThreshold = 10 },
                new Product { Id = 2, Name = "Nitrate Strips", Category = "Diagnostics", StockQuantity = 12, MinimumThreshold = 50 },
                new Product { Id = 3, Name = "Surgical Masks", Category = "PPE", StockQuantity = 4, MinimumThreshold = 20 },
                new Product { Id = 4, Name = "Nitrile Gloves", Category = "PPE", StockQuantity = 150, MinimumThreshold = 50 },
                new Product { Id = 5, Name = "Saline Solution", Category = "Medication", StockQuantity = 8, MinimumThreshold = 15 }
            );

            // Seed initial ticket data
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { Id = 1, Title = "Lab results upload failure", Description = "Lab results for Patient #8829 failed to upload to portal", Status = "Resolved", CreatedAt = DateTime.Parse("2026-03-30T15:00:00") },
                new Ticket { Id = 2, Title = "Emergency room equipment maintenance", Description = "Ventilator unit #3 requires scheduled maintenance", Status = "Urgent", CreatedAt = DateTime.Parse("2026-03-30T14:00:00") },
                new Ticket { Id = 3, Title = "Pharmacy inventory discrepancy", Description = "Physical count doesn't match system for insulin stock", Status = "Open", CreatedAt = DateTime.Parse("2026-03-30T13:30:00") },
                new Ticket { Id = 4, Title = "Patient portal access issue", Description = "Multiple patients reporting login failures on mobile", Status = "Open", CreatedAt = DateTime.Parse("2026-03-30T12:00:00") },
                new Ticket { Id = 5, Title = "Blood pressure monitor calibration", Description = "Ward B monitors showing inconsistent readings", Status = "Open", CreatedAt = DateTime.Parse("2026-03-30T11:00:00") },
                new Ticket { Id = 6, Title = "Nurse call system malfunction", Description = "Room 204 call button unresponsive", Status = "Urgent", CreatedAt = DateTime.Parse("2026-03-30T10:30:00") },
                new Ticket { Id = 7, Title = "EHR system slow response", Description = "Electronic health records taking >10s to load", Status = "Open", CreatedAt = DateTime.Parse("2026-03-30T10:00:00") },
                new Ticket { Id = 8, Title = "Sterilization unit error", Description = "Autoclave unit showing E-04 error code", Status = "Open", CreatedAt = DateTime.Parse("2026-03-30T09:30:00") },
                new Ticket { Id = 9, Title = "Wheelchair shortage Ward C", Description = "Only 2 wheelchairs available for 12-bed ward", Status = "Open", CreatedAt = DateTime.Parse("2026-03-30T09:00:00") },
                new Ticket { Id = 10, Title = "Temperature control Lab 3", Description = "Lab refrigerator temp drifting above safe range", Status = "Urgent", CreatedAt = DateTime.Parse("2026-03-30T08:30:00") },
                new Ticket { Id = 11, Title = "Shift scheduling conflict", Description = "Double booking for night shift radiology", Status = "Open", CreatedAt = DateTime.Parse("2026-03-29T16:00:00") },
                new Ticket { Id = 12, Title = "MRI room ventilation", Description = "Ventilation fan noise in MRI suite", Status = "Open", CreatedAt = DateTime.Parse("2026-03-29T14:00:00") },
                new Ticket { Id = 13, Title = "Medication expiry alert", Description = "Batch of amoxicillin expiring within 30 days", Status = "Open", CreatedAt = DateTime.Parse("2026-03-29T11:00:00") },
                new Ticket { Id = 14, Title = "Network printer offline", Description = "Ward A nursing station printer not responding", Status = "Open", CreatedAt = DateTime.Parse("2026-03-29T09:00:00") }
            );
        }
    }
}
