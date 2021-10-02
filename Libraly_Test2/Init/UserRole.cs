using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Libraly.BLL.Interfaces;
using Libraly.BLL.Models.UserDTO;
using Libraly.BLL.Services;
using Libraly.Data.Entities;

namespace Libraly_Test2.Init
{
    public class UserRole
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;

        public UserRole(IUserService userService, IBookService bookService, IMapper mapper)
        {
            _userService = userService;
            _bookService = bookService;
            _mapper = mapper;
        }

        private readonly RegisterViewModel _admin = new RegisterViewModel()
        {
            Email = "Admin@gmail.com",
            FirstName = "Admin",
            Surname = "Admin",
            FullName = "AdminFull",
            Password = "Administrator",
            ConfirmPassword = "Administrator",
            UserName = "SupeAdmin"
        };

        private readonly RegisterViewModel _librarian = new RegisterViewModel()
        {
            Email = "Librarian@gmail.com",
            FirstName = "Librarian",
            Surname = "Librarian",
            FullName = "Librarian",
            Password = "Librarian",
            ConfirmPassword = "Librarian",
            UserName = "Librarian"
        };

        private readonly RegisterViewModel _deffUser = new RegisterViewModel()
        {
            Email = "_deffUser@gmail.com",
            FirstName = "_deffUser",
            Surname = "_deffUser",
            FullName = "_deffUser",
            Password = "_deffUser",
            ConfirmPassword = "SimplePassword",
            UserName = "SimplePassword"
        };

        private bool _isRegisterAdmin = false;

        private bool _isAdmin = false;

//проверка админа
        private bool _isRegisterLibrarian = false;

        private bool _isLibrarian = false;

//проверка библиотекаря
        private bool _isRegisterUser = false;

        private bool _isUser = false;

//проверка обычного пользователя
        private bool _checkRoleOfAdmin = false;
        private bool _checkRoleOfLibrarian = false;
        private bool _checkRoleOfUser = false;


        private string _adminRole = "Admin";
        private string _LibrarianRole = "Librarian";
        private string _UserRole = "User";


        public void MakeDeffUserRole()
        {
        }


        private async Task CheckValue()
        {
            var admin = _mapper.Map<UserViewModel>(_admin);
            var librarian = _mapper.Map<UserViewModel>(_librarian);
            var user = _mapper.Map<UserViewModel>(_deffUser);


          //  var isRoleAdmin = await _userService.FindRole(_adminRole)==null ? true : false ;
            if (await _userService.FindRole(_adminRole) != null)
            {
                await _userService.CreateRole(_adminRole);
            }
            
            if (await _userService.FindRole(_LibrarianRole) != null)
            {
                await _userService.CreateRole(_LibrarianRole);
            }
            
            if (await _userService.FindRole(_UserRole) != null)
            {
                await _userService.CreateRole(_UserRole);
            }

            if (await _userService.FindUser(_admin.Email) != null)
            {
                await _userService.Create(_admin);
            }

            if (await _userService.FindUser(_librarian.Email) != null)
            {
                await _userService.Create(_librarian);
            }

            if (await _userService.FindUser(_deffUser.Email) != null)
            {
                await _userService.Create(_deffUser);
            }

            var role = await _userService.IsInRole(admin, _adminRole);
            if (!await _userService.IsInRole(admin, _adminRole))
            {
                
            }

            if (!await _userService.IsInRole(librarian, _LibrarianRole))
            {
                
            }

            if (!await _userService.IsInRole(user, _UserRole))
            {
                
            }
        
        }

        private async Task MakeProfilesAndRole()
        {
   
        }
    }
}