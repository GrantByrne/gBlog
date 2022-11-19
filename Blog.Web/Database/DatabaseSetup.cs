using Blog.Web.Models;

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

        var post = new Post();

        post.Title = "Hello World";
        post.Content = "This is the first post of the great blog. I hope you enjoy it.";
        post.Created = DateTime.Now;

        context.Posts.Add(post);

        context.SaveChanges();
    }
}