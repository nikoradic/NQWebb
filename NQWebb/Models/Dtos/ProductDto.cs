namespace NQWebb.Models.Dtos;

public class ProductDto
{
    public string? ArticleNumber { get; set; }

    public string? ProductName { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public List<string> Tags { get; set; } = new List<string>();
}
