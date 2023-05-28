using NQWebb.Data;
using NQWebb.Models.Entites;

namespace NQWebb.Helpers.Repositories
{
    public class ContactFormRepo : Repo<ContactFormEntity>
    {
        public ContactFormRepo(ApplicationDbContext db) : base(db)
        {
        }
    }
}
