using Microsoft.AspNetCore.Mvc.RazorPages;
using customer_wellness_project.Data;
using customer_wellness_project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace customer_wellness_project.Pages;

public class TicketsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public TicketsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Ticket> Tickets { get; set; } = new List<Ticket>();

    public async Task OnGetAsync()
    {
        Tickets = await _context.Tickets
            .Include(t => t.Product)
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync();
    }
}
