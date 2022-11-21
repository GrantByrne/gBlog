using Blog.Web.Database;
using Microsoft.AspNetCore.Components;

namespace Blog.Web.Pages.Admin;

public partial class Dashboard
{
    private int _postCount;

    [Inject]
    public BlogDbContext DbContext { get; set; } = null!;
    
    protected override void OnInitialized()
    {
        _postCount = DbContext.Posts.Count();
    }
}