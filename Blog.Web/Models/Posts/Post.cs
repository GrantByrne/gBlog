namespace Blog.Web.Models.Posts;

public class Post
{
    public long Id { get; set; }
    
    public string Title { get; set; } = string.Empty;
    
    public string Content { get; set; } = string.Empty;
    
    public DateTime Created { get; set; }
    
    public DateTime Published { get; set; }
    
    public PostStatus Status { get; set; }
}