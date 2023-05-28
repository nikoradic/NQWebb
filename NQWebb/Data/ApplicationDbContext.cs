using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NQWebb.Models.Entites;

namespace NQWebb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<ProductTagEntity> ProductTags { get; set; }
        public DbSet<ContactFormEntity> ContactForms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProductEntity>().HasData(
               new ProductEntity { ArticleNumber = "1", ProductName = "Soffa", ImageUrl = "new.jpg", Description = "A comfortable sofa with plush cushions." },
               new ProductEntity { ArticleNumber = "2", ProductName = "Black Sooffa", ImageUrl = "poular.jpg", Description = "A comfortable sofa with plush cushions." },
               new ProductEntity { ArticleNumber = "3", ProductName = " WhiteSoffa", ImageUrl = "featu.jpg", Description = "A comfortable sofa with plush cushions." }
             );
            builder.Entity<TagEntity>().HasData(
                new TagEntity { Id = 1, TagName = "New" },
                new TagEntity { Id = 2, TagName = "Popular" },
                new TagEntity { Id = 3, TagName = "Featured" }
                );
            builder.Entity<ProductTagEntity>().HasData(
                new ProductTagEntity { ArticleNumber = "1", TagId = 1 }, // TagId = Id i TagEntity
                new ProductTagEntity { ArticleNumber = "1", TagId = 2 },
                new ProductTagEntity { ArticleNumber = "2", TagId = 2 },
                new ProductTagEntity { ArticleNumber = "3", TagId = 3 },
                new ProductTagEntity { ArticleNumber = "3", TagId = 1 }
                );

            // Skapa fler producter, samtidigt katogisera de i ProductTagEntity. 

        }
    }
}
