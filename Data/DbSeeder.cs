using Microsoft.AspNetCore.Identity;
using customer_wellness_project.Models;
using Microsoft.EntityFrameworkCore;

namespace customer_wellness_project.Data
{
    public static class DbSeeder
    {
        public static async Task SeedDataAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // 1. Seed the Admin User
            if (!await userManager.Users.AnyAsync())
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "schen@wellnessops.com",
                    Email = "schen@wellnessops.com",
                    FirstName = "Sarah",
                    LastName = "Chen",
                    JobTitle = "Administrator",
                    EmailConfirmed = true // Skips the email verification requirement for testing
                };
                
                // This automatically hashes the password before saving to Azure SQL
                await userManager.CreateAsync(adminUser, "Melaleuca2026!");
            }

            // 2. Seed the Inventory Products
            if (!await context.Products.AnyAsync())
            {
                context.Products.AddRange(
                    new Product { Name = "Insulin Humalog", SKU = "MED-001", Category = "Pharmacy", StockQuantity = 2, MinimumThreshold = 10 },
                    new Product { Name = "Nitrate Strips", SKU = "MED-002", Category = "Pharmacy", StockQuantity = 12, MinimumThreshold = 20 },
                    new Product { Name = "Surgical Masks", SKU = "PPE-001", Category = "Supplies", StockQuantity = 4, MinimumThreshold = 50 }
                );
                await context.SaveChangesAsync();
            }

            // 3. Seed an Open Support Ticket
            if (!await context.Tickets.AnyAsync())
            {
                var firstProduct = await context.Products.FirstOrDefaultAsync();
                var firstUser = await userManager.Users.FirstOrDefaultAsync();

                context.Tickets.Add(new Ticket
                {
                    Title = "Emergency Room Equipment Maintenance",
                    Description = "Routine check required for life support systems in Wing B.",
                    Priority = "Urgent",
                    Status = "Open",
                    ProductId = firstProduct?.Id,
                    AssignedUserId = firstUser?.Id
                });
                await context.SaveChangesAsync();
            }
        }
    }
}
