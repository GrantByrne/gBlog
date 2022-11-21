using Blog.Web.Database;
using Blog.Web.Models.Posts;
using Microsoft.AspNetCore.Components;

namespace Blog.Web.Pages.Admin;

public partial class CreatePost
{
    private readonly Post _post = new()
    {
        Created = DateTime.Now,
        Status = PostStatus.Published,
        Published = DateTime.Now
    };

    [Inject]
    public BlogDbContext DbContext { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [Inject] 
    public ILogger<CreatePost> Logger { get; set; } = null!;

    public void Save()
    {
        try
        {
            _post.Created = DateTime.Now;

            DbContext.Posts.Add(_post);
            DbContext.SaveChanges();

            NavigationManager.NavigateTo("/admin/posts");
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error saving post");
        }
    }
}