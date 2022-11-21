using Blog.Web.Database;
using Blog.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Web.Pages;

public class AboutMe : PageModel, ISettings
{
    private readonly BlogDbContext _dbContext;

    public AboutMe(BlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void OnGet()
    {
        Settings = _dbContext.Settings.First();
    }

    public Settings Settings { get; set; } = null!;
}