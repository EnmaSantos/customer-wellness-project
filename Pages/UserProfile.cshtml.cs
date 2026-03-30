using Microsoft.AspNetCore.Mvc.RazorPages;

namespace customer_wellness_project.Pages;

public class UserProfileModel : PageModel
{
    private readonly ILogger<UserProfileModel> _logger;

    public UserProfileModel(ILogger<UserProfileModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}
