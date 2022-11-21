using Blog.Web.Database;
using Microsoft.AspNetCore.Components;

namespace Blog.Web.Pages.Admin;

public partial class Settings
{
    private Models.Settings _model = new();

    [Inject]
    public BlogDbContext BlogDbContext { get; set; } = null!;

    [Inject]
    public ILogger<Settings> Logger { get; set; } = null!;

    protected override void OnInitialized()
    {
        _model = BlogDbContext.Settings.First();
    }

    private void SaveChanges()
    {
        try
        {
            BlogDbContext.Settings.Update(_model);
            BlogDbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Failed to update settings");
        }
    }
}