using System.Collections.Generic;
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


        private void CheckValue()
        {
            var admin = _mapper.Map<UserViewModel>(_admin);
            var librarian = _mapper.Map<UserViewModel>(_librarian);
            var user = _mapper.Map<UserViewModel>(_deffUser);


            var isroleAdmin = _userService.FindRole(_adminRole);
            var isroleLibrarian = _userService.FindRole(_LibrarianRole);
            var isroleUser = _userService.FindRole(_UserRole);

            var isRegisteredAdmin = _userService.FindUser(_admin.Email);
            var isRegisteredLibrarian = _userService.FindUser(_librarian.Email);
            var isRegisteredUser = _userService.FindUser(_deffUser.Email);

            var isRoleOfAdmin = _userService.IsInRole(admin, _adminRole);
            var isRoleOfLibrarian = _userService.IsInRole(librarian, _LibrarianRole);
            var isRoleOfUser = _userService.IsInRole(user, _UserRole);
        }

        private void MakeProfilesAndRole()
        {
            if (!_isRegisterAdmin) _userService.Create(_admin);

            if (!_isAdmin) _userService.CreateRole(_adminRole);

            if (!_isRegisterLibrarian) _userService.Create(_librarian);
            if (!_isLibrarian) _userService.CreateRole(_LibrarianRole);

            if (!_isRegisterUser) _userService.Create(_deffUser);
            if (!_isUser) _userService.CreateRole(_UserRole);
        }
    }
}