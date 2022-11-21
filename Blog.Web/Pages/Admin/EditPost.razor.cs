using Blog.Web.Database;
using Blog.Web.Models;
using Blog.Web.Models.Posts;
using Microsoft.AspNetCore.Components;

namespace Blog.Web.Pages.Admin;

public partial class EditPost
{
    private Post _post = new()
    {
        Created = DateTime.Now
    };

    [Inject]
    public BlogDbContext DbContext { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    public ILogger<EditPost> Logger { get; set; } = null!;
    
    [Parameter]
    public long PostId { get; set; }

    protected override void OnInitialized()
    {
        if (PostId != 0)
        {
            var post = DbContext.Posts.First(p => p.Id == PostId);
            _post = post;
        }
    }

    public void Save()
    {
        try
        {
            
            DbContext.Posts.Update(_post);
            DbContext.SaveChanges();

            NavigationManager.NavigateTo("/admin/posts");
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Failed to update post {PostId}", PostId);
        }
    }
}