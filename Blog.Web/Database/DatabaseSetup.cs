using Blog.Web.Models;
using Blog.Web.Models.Posts;

namespace Blog.Web.Database;

public static class DatabaseSetupExtensions
{
    public static void EnsureDatabaseSetup(this WebApplication app)
    {
        if (app == null)
        {
            throw new ArgumentNullException(nameof(app));
        }

        using var scope = app.Services.CreateAsyncScope();

        var context = scope.ServiceProvider.GetService<BlogDbContext>();

        if (context == null)
        {
            throw new Exception("Unable to resolve BlogDbContext");
        }

        if (!context.Database.EnsureCreated())
            return;

        CreateFirstPost(context);
        SetDefaultSettings(context);

        context.SaveChanges();
    }

    private static void SetDefaultSettings(BlogDbContext context)
    {
        var settings = new Settings();

        settings.BlogName = "Grant Byrne";
        settings.Tagline = "Coder, Cyclist, Runner, Swimmer, and Rock Climber";
        settings.PageSize = 10;
        
        context.Settings.Add(settings);
    }

    private static void CreateFirstPost(BlogDbContext context)
    {
        var post = new Post();

        post.Title = "Hello World";
        post.Content = "This is the first post of the great blog. I hope you enjoy it.";
        post.Created = DateTime.Now;
        post.Published = DateTime.Today;
        post.Status = PostStatus.Published;

        context.Posts.Add(post);
    }
}