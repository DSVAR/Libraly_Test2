using System.Threading.Tasks;
using Libraly.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Libraly.BLL.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUsers();
        Task<IdentityResult> Create(User user);
        Task<User> FindUser(string name);
        Task<IdentityResult> DeleteUser(User user);
        Task<IdentityResult> ChangePassword(string oldPassword, string newPassword);
        
        Task<SignInResult> SignIn(User user,bool remember);
        Task LogOut();
        
        Task<IdentityResult> CreateRole(string name);
        Task<IdentityRole> AddRoleForUser(User user, string role);
        Task<IdentityResult> DeleteRole(string name);
        Task<IdentityRole> FindRole(string name);
        
    }
}