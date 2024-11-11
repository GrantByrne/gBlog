using Blog.Web.Database;
using Blog.Web.Models;
using Blog.Web.Models.Posts;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Web.Pages;

public class BlogModel : PageModel, ISettings
{
    private readonly ILogger<IndexModel> _logger;
    private readonly BlogDbContext _blogDbContext;

    public IEnumerable<Post> Posts { get; set; } = Array.Empty<Post>();

    public Settings Settings { get; set; } = new();

    public bool DisplayPreviousLink { get; set; }

    public BlogModel(
        ILogger<IndexModel> logger,
        BlogDbContext blogDbContext)
    {
        _logger = logger;
        _blogDbContext = blogDbContext;
    }

    public void OnGet()
    {
        var postQuery = _blogDbContext.Posts
            .OrderByDescending(p => p.Published)
            .Where(p => p.Status == PostStatus.Published);

        Posts = postQuery
            .Take(Settings.PageSize)
            .ToList();

        Settings = _blogDbContext.Settings
            .First();
        
        DisplayPreviousLink = postQuery.Count() > Settings.PageSize;
    }
}