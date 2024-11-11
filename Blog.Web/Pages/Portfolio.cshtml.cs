using Blog.Web.Database;
using Blog.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Web.Pages;

public class PortfolioModel : PageModel, ISettings
{
    private readonly BlogDbContext _dbContext;
    
    public Settings Settings { get; set; } = new();
    
    public PortfolioModel(BlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void OnGet()
    {
        Settings = _dbContext.Settings.First();
    }
}