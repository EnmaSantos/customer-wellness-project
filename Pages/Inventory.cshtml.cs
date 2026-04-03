using Microsoft.AspNetCore.Mvc.RazorPages;
using customer_wellness_project.Data;
using customer_wellness_project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace customer_wellness_project.Pages;

public class InventoryModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public InventoryModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Product> Products { get; set; } = new List<Product>();

    public async Task OnGetAsync()
    {
        Products = await _context.Products.OrderBy(p => p.Name).ToListAsync();
    }
}
