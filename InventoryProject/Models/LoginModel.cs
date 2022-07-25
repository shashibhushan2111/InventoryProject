using System.ComponentModel.DataAnnotations;

namespace InventoryProject.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage="please enter the Email!")]
        [Display(Name ="enter the name")]
        public string Email { get; set; }


        [Required(ErrorMessage = "please enter the correct password!")]
        [Display(Name = "enter the Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
