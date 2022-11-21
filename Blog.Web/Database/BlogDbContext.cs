using Blog.Web.Models;
using Blog.Web.Models.Posts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Database;

public class BlogDbContext : IdentityDbContext
{
    public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        SeedUsers(builder);  
        SeedRoles(builder);
        SeedUserRoles(builder);
    }

    private void SeedUsers(ModelBuilder builder)
    {
        User user = new User()
        {
            Id = "b74ddd14-6340-4840-95c2-db12554843e5",
            UserName = "Admin",
            Email = "admin@gmail.com",
            LockoutEnabled = false,
            PhoneNumber = "1234567890"
        };

        PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
        passwordHasher.HashPassword(user, "Admin*123");

        builder.Entity<User>().HasData(user);
    }

    private void SeedRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "fab4fac1-c546-41de-aebc-a14da6895711", 
                Name = "Admin", 
                ConcurrencyStamp = "1",
                NormalizedName = "Admin"
            }
        );
    }

    private void SeedUserRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", 
                UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
            }
        );
    }

    public DbSet<Post> Posts { get; set; } = null!;
    
    public DbSet<Settings> Settings { get; set; } = null!;
}