using System.ComponentModel.DataAnnotations;

namespace Endpoint.Models.ViewModels
{
    public class LoginViewModel
    {

        [EmailAddress]
        [Required(ErrorMessage = "ایمیل را وارد نمایید")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "پسورد را وارد نمایید")]
        [Display(Name = "پسورد")]
        public string Password { get; set; }
        [Display(Name = "remember me")]

        public bool IsPersitent { get; set; }
        public string ReturnUrl { get; set; }

    }
}
