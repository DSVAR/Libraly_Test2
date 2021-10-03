using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Libraly.BLL.Interfaces;
using Libraly.BLL.Models.UserDTO;
using Libraly.BLL.Services;
using Libraly.Data.Entities;
using Libraly.Data.Interfaces;

namespace Libraly_Test2.Init
{
    public class UserRole
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;
        private readonly IUnitOfWork _work;
        private IRepository<User> _repository;

        public UserRole(IUserService userService, IBookService bookService, IMapper mapper,IUnitOfWork work,IRepository<User>repository)
        {
            _userService = userService;
            _bookService = bookService;
            _mapper = mapper;
            _work = work;
            _repository = repository;
        }

        private readonly RegisterViewModel _admin = new RegisterViewModel()
        {
            Email = "Admin@gmail.com",
            FirstName = "Admin",
            Surname = "Admin",
            FullName = "AdminFull",
            Password = "Administrator",
            ConfirmPassword = "Administrator",
            UserName = "OnionAdmin"
        };

        private readonly RegisterViewModel _librarian = new RegisterViewModel()
        {
            Email = "Librarian@gmail.com",
            FirstName = "Librarian",
            Surname = "Librarian",
            FullName = "Librarian",
            Password = "Librarian",
            ConfirmPassword = "Librarian",
            UserName = "OnionLibrarian"
        };

        private readonly RegisterViewModel _deffUser = new RegisterViewModel()
        {
            Email = "_deffUser@gmail.com",
            FirstName = "_deffUser",
            Surname = "_deffUser",
            FullName = "_deffUser",
            Password = "_deffUser",
            ConfirmPassword = "SimplePassword",
            UserName = "OnionUser"
        };




        private string _adminRole = "Admin";
        private string _LibrarianRole = "Librarian";
        private string _UserRole = "User";



        public async Task CheckValue()
        {
            var admin = _mapper.Map<UserViewModel>(_admin);
            var librarian = _mapper.Map<UserViewModel>(_librarian);
            var user = _mapper.Map<UserViewModel>(_deffUser);

            var adm = await _userService.FindRole(_adminRole);
            if (await _userService.FindRole(_adminRole) == null)
            {
                await _userService.CreateRole(_adminRole);
            }
            
            if (await _userService.FindRole(_LibrarianRole) == null)
            {
                await _userService.CreateRole(_LibrarianRole);
            }
            
            if (await _userService.FindRole(_UserRole) == null)
            {
                await _userService.CreateRole(_UserRole);
            }

            if (await _userService.FindUser(_admin.Email) == null)
            {
                var result =await _userService.Create(_admin);
                if (result.Succeeded)
                {
                    admin = _mapper.Map<UserViewModel>(await _userService.FindUser(_admin.Email) ) ;
                    
                    var local =_work.Context.Set<User>().Local.FirstOrDefault(entry => entry.Id.Equals(admin.Id));
                    if(local!=null)
                        _repository.Detach(local);
                    
                    await _userService.AddToRole(admin, _adminRole);
                }
            }
            else 
                admin = _mapper.Map<UserViewModel>(await _userService.FindUser(_admin.Email) ) ;

            if (await _userService.FindUser(_librarian.Email) == null)
            {
                await _userService.Create(_librarian);
            }
            else
                librarian = _mapper.Map<UserViewModel>(await _userService.FindUser(_librarian.Email) ) ;

            if (await _userService.FindUser(_deffUser.Email) == null)
            {
                await _userService.Create(_deffUser);
            }
            else            
                user = _mapper.Map<UserViewModel>(await _userService.FindUser(_deffUser.Email) ) ;

            var role = await _userService.IsInRole(admin, _adminRole);
            if (!await _userService.IsInRole(admin, _adminRole))
            {
                
                var sw= await _userService.AddToRole(admin, _adminRole);;
                var se = 5;
            }

            if (!await _userService.IsInRole(librarian, _LibrarianRole))
            {
              var gs=  await _userService.AddToRole(librarian, _LibrarianRole);
            }

            if (!await _userService.IsInRole(user, _UserRole))
            {
                await _userService.AddToRole(user, _UserRole);
            }
        
        }

 
    }
}