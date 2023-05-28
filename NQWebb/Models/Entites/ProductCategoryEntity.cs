﻿using Microsoft.EntityFrameworkCore;

namespace NQWebb.Models.Entites;

[PrimaryKey("ArticleNumber", "CategoryId")]
public class ProductCategoryEntity
{
    public string ArticleNumber = null!;

    public ProductEntity Product { get; set; } = null!;

    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;
}
