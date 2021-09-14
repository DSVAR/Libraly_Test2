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

            CreateMap<CreateBook, BookViewModel>();
            CreateMap<BookViewModel, CreateBook>();

            CreateMap<UpdateBookViewModel, BookViewModel>();
            CreateMap<BookViewModel, UpdateBookViewModel>();

            CreateMap<UserViewModel, LoginViewModel>();
            CreateMap<LoginViewModel, UserViewModel>();
            
            CreateMap<RegisterViewModel,UserViewModel>();
            CreateMap<UserViewModel,RegisterViewModel>();
            
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel,User>();

        }
    }
}