using System.ComponentModel.DataAnnotations;
using Libraly.Data.Entities;

namespace Libraly.BLL.Models.UserDTO
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Пустая строка")]
        public string OldPassword { get; set; }


        [Required(ErrorMessage = "Пустая строка")]
        [Compare("OldPassword", ErrorMessage ="Пароли не совпадают")]
        public string RepeatOldPassword { get; set; }


        [Required(ErrorMessage = "Пустая строка")]
        public string NewPassword { get; set; }
    }
}