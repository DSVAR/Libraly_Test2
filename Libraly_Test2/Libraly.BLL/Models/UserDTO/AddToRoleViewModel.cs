using System.ComponentModel.DataAnnotations;



namespace Libraly.BLL.Models.UserDTO
{
    public class AddToRoleViewModel
    {
        [Required(ErrorMessage="Need email")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Need role")]
        public string RoleName { get; set; }
    }
}