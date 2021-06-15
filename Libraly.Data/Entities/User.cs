using Microsoft.AspNetCore.Identity;

namespace Libraly.Data.Entities
{
    public class User:IdentityUser
    {        
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
}