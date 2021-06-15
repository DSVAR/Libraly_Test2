using Libraly.Data.Entities;

namespace Libraly.BLL.Initialization
{
    public class DefaultUsers
    {
        private string[,] def =
        {
            {"Администратор", "admin@gmail.com", "Administartor12"},
            {"Библиотекарь", "libr@gmail.com", "Librian11"},
            {"Пользователь", "user@mail.ru", "Userjoke1"}
        };

        private User[] _users =
        {
          //  { email:""}
        };

    }
    
}