using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace customer_wellness_project.Pages;

public class SignUpModel : PageModel
{
    private readonly ILogger<SignUpModel> _logger;

    [BindProperty]
    public string FullName { get; set; } = string.Empty;

    [BindProperty]
    public string Specialty { get; set; } = string.Empty;

    [BindProperty]
    public string NpiNumber { get; set; } = string.Empty;

    [BindProperty]
    public string LicenseState { get; set; } = string.Empty;

    [BindProperty]
    public string Email { get; set; } = string.Empty;

    public List<string> Specialties { get; } = new()
    {
        "Cardiology",
        "Internal Medicine",
        "Physical Therapy",
        "Neurology",
        "Endocrinology"
    };

    public SignUpModel(ILogger<SignUpModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // TODO: Implement registration logic
        _logger.LogInformation("Registration attempt for: {FullName}, Specialty: {Specialty}", FullName, Specialty);

        return RedirectToPage("/Login");
    }
}
