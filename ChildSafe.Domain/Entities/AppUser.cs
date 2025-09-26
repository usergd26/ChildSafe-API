using Microsoft.AspNetCore.Identity;

namespace ChildSafe.Domain.Entities
{
    public class AppUser: IdentityUser
    {
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
