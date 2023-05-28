using NQWebb.Models.Dtos;

namespace NQWebb.Models.ViewModels
{
    public class NewCollectionVM
    {
        public string? Title { get; set; }

        public IEnumerable<ProductDto> Items { get; set; } = new List<ProductDto>();

    }
}
