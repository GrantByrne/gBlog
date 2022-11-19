using Blog.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Database;

public class BlogDbContext : DbContext
{
    public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
    {
    }

    public DbSet<Post> Posts { get; set; } = null!;
}

