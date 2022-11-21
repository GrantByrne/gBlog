namespace Blog.Web.Models;

public class Settings
{
    public int Id { get; set; }
    
    public string BlogName { get; set; } = string.Empty;

    public string Tagline { get; set; } = string.Empty;

    public int PageSize { get; set; } = 10;
    
    public string GoogleTrackingId { get; set; } = string.Empty;
}