using System.Collections.Generic;
using System.Runtime.InteropServices;
using Libraly.Data.Entities;

namespace Libraly.BLL.Initialization
{
    public class DefaultUsers
    {
        public string[,] def =
        {
            {"Администратор", "admin@gmail.com", "Administartor12"},
            {"Библиотекарь", "libr@gmail.com", "Librian11"},
            {"Пользователь", "user@mail.ru", "Userjoke1"}
        };

       
        
        private User _admin()
        {
         User _user = new User();
            _user.Password = "Administartor12";
            _user.Email = "admin@gmail.com";
            _user.UserName = "Администратор";

            return _user;
        }
        private User _librian()
        {
         User _user = new User();
            _user.Password = "Librian11";
            _user.Email = "libr@gmail.com";
            _user.UserName = "Библиотекарь";

            return _user;
        }

        private User _simpleUser()
        {
         User _user = new User();
            _user.Password = "Userjoke1";
            _user.Email = "user@mail.ru";
            _user.UserName = "Пользователь";

            return _user;
        }

        public List<User> Users()
        {
            List<User> newUsers = new List<User>();
            newUsers.Add(_admin());
            newUsers.Add(_librian());
            newUsers.Add(_simpleUser());

            return newUsers;
        }
        
    }
    
}