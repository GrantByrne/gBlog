using Blog.Web.Database;
using Blog.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly BlogDbContext _blogDbContext;

    public IEnumerable<Post> Posts { get; set; } = Array.Empty<Post>();

    public IndexModel(
        ILogger<IndexModel> logger,
        BlogDbContext blogDbContext)
    {
        _logger = logger;
        _blogDbContext = blogDbContext;
    }

    public void OnGet()
    {
        Posts = _blogDbContext.Posts
            .OrderByDescending(p => p.Created)
            .Take(10)
            .ToList();
    }
}