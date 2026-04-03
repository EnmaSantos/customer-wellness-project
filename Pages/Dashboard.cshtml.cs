using Microsoft.AspNetCore.Mvc.RazorPages;
using customer_wellness_project.Data;
using customer_wellness_project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace customer_wellness_project.Pages;

public class DashboardModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DashboardModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public int OpenTicketsCount { get; set; }
    public int ResolutionRatePercentage { get; set; }
    public IList<Product> LowStockProducts { get; set; } = new List<Product>();
    public IList<Ticket> RecentTickets { get; set; } = new List<Ticket>();

    public async Task OnGetAsync()
    {
        OpenTicketsCount = await _context.Tickets.CountAsync(t => t.Status == "Open");
        
        var totalTickets = await _context.Tickets.CountAsync();
        var resolvedTickets = await _context.Tickets.CountAsync(t => t.Status == "Resolved");
        
        ResolutionRatePercentage = totalTickets > 0 ? (int)((double)resolvedTickets / totalTickets * 100) : 100;

        LowStockProducts = await _context.Products
            .Where(p => p.StockQuantity < p.MinimumThreshold)
            .Take(3)
            .ToListAsync();

        RecentTickets = await _context.Tickets
            .OrderByDescending(t => t.CreatedAt)
            .Take(4)
            .ToListAsync();
    }
}
