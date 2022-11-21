using Blog.Web.Database;
using Blog.Web.Models;
using Blog.Web.Models.Posts;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Web.Pages;

public class Entry : PageModel, ISettings
{
    private readonly BlogDbContext _dbContext;

    public Entry(BlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Post Post { get; set; } = null!;

    public int Id { get; set; }

    public void OnGet(int id)
    {
        Settings = _dbContext.Settings.First();
        
        Id = id;
        
        var entry = _dbContext.Posts
            .First(e => e.Id == id);

        Post = entry;
    }

    public Settings Settings { get; set; } = null!;
}