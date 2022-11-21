using Blog.Web.Database;
using Microsoft.AspNetCore.Components;

namespace Blog.Web.Pages.Shared.Admin;

public partial class AdminHeader
{
    private string _blogName = string.Empty;
    
    [Inject]
    public BlogDbContext DbContext { get; set; } = null!;
    
    protected override void OnInitialized()
    {
        _blogName = DbContext.Settings.First().BlogName;
    }
}