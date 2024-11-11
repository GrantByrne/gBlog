using Blog.Web.Database;
using Blog.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Web.Pages;

public class IndexModel : PageModel, ISettings
{
    private readonly BlogDbContext _dbContext;
    
    public Settings Settings { get; set; } = new();
    
    public IndexModel(BlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void OnGet()
    {
        Settings = _dbContext.Settings.First();
    }
}