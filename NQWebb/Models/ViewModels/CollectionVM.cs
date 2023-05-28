using NQWebb.Models.Dtos;

namespace NQWebb.Models.ViewModels
{
    public class CollectionVM
    {
        public string? Title { get; set; }

        public IEnumerable<ProductDto> Items { get; set; } = new List<ProductDto>();
    }
}
