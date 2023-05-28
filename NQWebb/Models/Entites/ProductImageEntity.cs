using Microsoft.EntityFrameworkCore;

namespace NQWebb.Models.Entites;



[PrimaryKey("ArticelNumber", "ImageId")]
public class ProductImageEntity
{
    public string ArticuleNumber { get; set; } = null!;

    public ProductEntity Product { get; set; } = null!;
    public int ImageId { get; set; }
    public ImageEntity Image { get; set; } = null!;

    public bool IsDefaultImage { get; set; }
}
