using Blog.Web.Database;
using Blog.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Web.Pages;

public class Resume : PageModel, ISettings
{
    private readonly BlogDbContext _context;

    public Resume(BlogDbContext context)
    {
        _context = context;
    }
    
    public void OnGet()
    {
        Settings = _context.Settings.First();
    }

    public Settings Settings { get; set; } = null!;
}