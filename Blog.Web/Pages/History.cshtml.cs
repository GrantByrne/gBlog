using Blog.Web.Database;
using Blog.Web.Models;
using Blog.Web.Models.Posts;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Web.Pages;

public class History : PageModel, ISettings
{
    private const int PageSize = 10;
    
    private readonly BlogDbContext _context;

    public History(BlogDbContext context)
    {
        _context = context;
        
        Settings = _context.Settings.First();
    }

    public void OnGet(int number)
    {
        PageNumber = number;
        
        var postsQuery = _context.Posts
            .Where(p => p.Status == PostStatus.Published)
            .OrderByDescending(p => p.Published);

        Posts = postsQuery
            .Skip((number - 1) * PageSize)
            .Take(PageSize)
            .ToArray();

        var totalPages = (int)Math.Ceiling((double)postsQuery.Count() / PageSize);
        
        ShowOlder = PageNumber < totalPages;
    }

    public int PageNumber { get; set; }

    public bool ShowOlder { get; set; }

    public bool ShowNewer => PageNumber > 1;

    public Settings Settings { get; set; }

    public IEnumerable<Post> Posts { get; set; } = Array.Empty<Post>();
}