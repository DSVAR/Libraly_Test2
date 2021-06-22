using AutoMapper;
using Libraly.BLL.Models.BookDTO;
using Libraly.BLL.Models.UserDTO;
using Libraly.Data.Entities;

namespace Libraly.BLL.Configures
{
    public class ConfigureOfMapping:Profile
    {
        public ConfigureOfMapping()
        {
            //соединяем модели 
            CreateMap<Book,BookViewModel>();
            CreateMap<BookViewModel,Book>();

            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel,User>();

            CreateMap<UserViewModel, LoginViewModel>();
            CreateMap<LoginViewModel, UserViewModel>();
            
            CreateMap<RegisterViewModel,UserViewModel>();
            CreateMap<UserViewModel,RegisterViewModel>();

        }
    }
}