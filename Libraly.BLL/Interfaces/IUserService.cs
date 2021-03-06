using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libraly.BLL.Models.UserDTO;
using Libraly.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Libraly.BLL.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>>  GetUsers();
        Task<IdentityResult> Create(RegisterViewModel user);
        Task<User> FindUser(string email);
        Task<IdentityResult> DeleteUser(User user);
        Task<IdentityResult> ChangePassword(User user,ChangePasswordViewModel passwordViewModel);
        
        Task<SignInResult> SignIn(User user,bool remember);
        Task LogOut();
        
        Task<IdentityResult> CreateRole(string name);
        Task<IdentityResult> DeleteRole(string name);
        Task<IdentityRole> FindRole(string name);
        Task<IdentityResult> AddToRole(RoleViewModel userModel, string role=null,UserViewModel userViewModel=null);
        Task<bool> IsInRole(UserViewModel user, string role);
        Task<IdentityResult> RemoveFromRole(RoleViewModel userModel, string role = null,
            UserViewModel userViewModel = null);

    }
}