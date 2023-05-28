using Microsoft.AspNetCore.Identity;

namespace NQWebb.Models.ViewModels
{
    public class UsersVM
    {
        public IList<IdentityUser> Users { get; set; } = new List<IdentityUser>();
        public IList<IdentityUser> Administrators { get; set; } = new List<IdentityUser>();

    }
}
