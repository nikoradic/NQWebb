using Microsoft.EntityFrameworkCore;
using NQWebb.Data;
using NQWebb.Models.Entites;
using System.Linq.Expressions;

namespace NQWebb.Helpers.Repositories
{
    public class ProductEntityRepo : Repo<ProductEntity>
    {

        private readonly ApplicationDbContext _db;
        public ProductEntityRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            var items = await _db.Products
                 .Include(x => x.ProductTags)
                 .ThenInclude(x => x.Tag)
                 .ToListAsync();

            return items;




        }

        public override async Task<IEnumerable<ProductEntity>> GetAllAsync(Expression<Func<ProductEntity, bool>> expression)
        {
            var items = await _db.Products
                 .Include(x => x.ProductTags)
                 .ThenInclude(x => x.Tag)
                 .Where(expression)
                 .ToListAsync();

            return items;
        }


        public override async Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> expression)
        {
            var item = await _db.Products
           .Include(x => x.ProductTags)
           .ThenInclude(x => x.Tag)
          .FirstOrDefaultAsync(expression);

            return item!;


        }
    }
}
