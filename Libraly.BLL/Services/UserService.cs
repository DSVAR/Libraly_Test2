using System.Linq;
using System.Threading.Tasks;
using Libraly.Data.Entities;
using Libraly.Data.Interfaces;
using Libraly.Data.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Libraly.BLL.Services
{
    public class UserService:IUnitOfWork<User>
    {
        private readonly UserManager<User> _userManager;
        private readonly UnitOfWorkRepo<User> _unitOfWorkRepo;

        UserService(UserManager<User> userManager, UnitOfWorkRepo<User> unitOfWorkRepo)
        {
            _userManager = userManager;
            _unitOfWorkRepo = unitOfWorkRepo;
        }

        public  Task Create(User obj)
        {
            throw new System.NotImplementedException();//await _userManager.CreateAsync(obj,obj.Password);
        }

        public IQueryable<User> GetElements()
        {
            throw new System.NotImplementedException();
        }

        public void Update(User obj)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(User obj)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}