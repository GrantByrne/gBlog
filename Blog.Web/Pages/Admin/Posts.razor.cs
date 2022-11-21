using Blog.Web.Database;
using Blog.Web.Models;
using Blog.Web.Models.Posts;
using Microsoft.AspNetCore.Components;

namespace Blog.Web.Pages.Admin;

public partial class Posts
{
    private List<Post> PostItems { get; set; } = new();
    private int Page { get; set; } = 1;
    private int PageSize { get; set; } = 10;
    private int TotalCount { get; set; } = 0;
    
    [Inject]
    public BlogDbContext DbContext { get; set; } = null!;
    
    [Inject]
    public ILogger<Posts> Logger { get; set; } = null!;

    protected override void OnInitialized()
    {
        Reload();
    }

    private void Newer()
    {
        Page--;
        Reload();
    }

    private void Older()
    {
        Page++;
        Reload();
    }

    private void Reload()
    {
        TotalCount = DbContext.Posts.Count();

        PostItems = DbContext.Posts
            .OrderByDescending(p => p.Created)
            .Skip((Page - 1) * PageSize)
            .Take(PageSize)
            .ToList();
    }

    private bool DisplayNewer => Page > 1;
    private bool DisplayOlder => Page < PageCount;
    private int PageCount => (int)Math.Ceiling((double)TotalCount / PageSize);

    private void Delete(Post post)
    {
        try
        {
            DbContext.Posts.Remove(post);
            DbContext.SaveChanges();
            Reload();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error deleting post");
        }
    }
}