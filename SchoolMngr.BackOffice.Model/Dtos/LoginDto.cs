using Reinforced.Typings.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SchoolMngr.BackOffice.Model.Dtos
{
    [TsInterface(AutoI = false, Name = "Login")]//TODO: look for using viewmodel-based validation on web client
    public class LoginDto
    {
        [Required]
        [Display(Name = "User Name"), MinLength(6)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password), MinLength(6)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
