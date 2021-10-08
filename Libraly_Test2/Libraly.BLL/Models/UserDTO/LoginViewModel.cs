using System.ComponentModel.DataAnnotations;

namespace Libraly.BLL.Models.UserDTO
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Пустое поле")]
        [Display(Name ="Ник")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Пустое поле")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Display(Name = "Запомнить меня?")]
        public  bool RememberMe { get; set; }

        public  string ReturnUrl { get; set; }
    }
}