

namespace NQWebb.Models.Entites;



public class TagEntity
{
    public int Id { get; set; }

    public string TagName { get; set; } = null!;

    public ICollection<ProductTagEntity> ProductTags { get; set; } = new HashSet<ProductTagEntity>();
}