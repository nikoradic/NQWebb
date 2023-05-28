using NQWebb.Helpers.Repositories;
using NQWebb.Models.Dtos;

namespace NQWebb.Helpers.Services;

public class ProductService
{
    private readonly ProductEntityRepo _productEntityRepo;

    public ProductService(ProductEntityRepo productEntityRepo)
    {
        _productEntityRepo = productEntityRepo;
    }

    public async Task<IEnumerable<ProductDto>> GetAllByTagNameAsync(string tagName)
    {

        var productEntities = await _productEntityRepo.GetAllAsync();
        var filteredProducts = productEntities
            .Where(p => p.ProductTags.Any(tag => tag.Tag.TagName == tagName))
            .ToList();

        var list = new List<ProductDto>();
        foreach (var product in filteredProducts)
        {
            list.Add(new ProductDto
            {
                ArticleNumber = product.ArticleNumber,
                Description = product.Description,
                ProductName = product.ProductName,
                Tags = product.ProductTags.Select(tag => tag.Tag.TagName).ToList()
            });
        }

        return list;
    }

    public async Task<ProductDto> GetAsync(string articleNumber)
    {
        var item = await _productEntityRepo.GetAsync(x => x.ArticleNumber == articleNumber);

        var tagList = new List<string>();
        foreach (var tag in item.ProductTags)
            tagList.Add(tag.Tag.TagName);

        var product = new ProductDto
        {
            ArticleNumber = item.ArticleNumber,
            Description = item.Description,
            ProductName = item.ProductName,
            Tags = tagList


        };

        return product;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var items = await _productEntityRepo.GetAllAsync();
        var list = new List<ProductDto>();
        foreach (var item in items)
        {
            list.Add(new ProductDto
            {
                ArticleNumber = item.ArticleNumber,
                Description = item.Description,
                ProductName = item.ProductName,
                ImageUrl = item.ImageUrl


            });
        }
        return list;
    }

    public async Task<IEnumerable<ProductDto>> GetNewCollectionAsync()
    {
        var items = await _productEntityRepo.GetAllAsync();

        var list = items.Take(10).Select(item => new ProductDto
        {
            ArticleNumber = item.ArticleNumber,
            Description = item.Description,
            ProductName = item.ProductName
        }).ToList();

        return list;
    }


}

