using System.ComponentModel.DataAnnotations;


namespace NQWebb.Models.Entites;

public class ProductEntity
{
    [Key]

    public string ArticleNumber { get; set; } = null!;

    public string? ProductName { get; set; }

    public string? ImageUrl { get; set; }

    public string? Description { get; set; }



    public ICollection<ProductTagEntity> ProductTags { get; set; } = new HashSet<ProductTagEntity>();







}
