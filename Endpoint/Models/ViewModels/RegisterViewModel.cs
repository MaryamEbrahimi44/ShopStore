using System.ComponentModel.DataAnnotations;

namespace Endpoint.Models.ViewModels
{
    public class RegisterViewModel
    {

        [MaxLength(100, ErrorMessage = "نام و نام خانوادگی نباید بیش از 100 کاراکتر باشد")]
        [Required(ErrorMessage = "نام و نام خانوادگی را وارد نمایید")]
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; } = string.Empty;
        [EmailAddress]
        [Required(ErrorMessage = "ایمیل را وارد نمایید")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; } = string.Empty;
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "پسورد را وارد نمایید")]
        [Display(Name = "پسورد")]
        public string Password { get; set; } = string.Empty;
        [Compare(nameof(Password), ErrorMessage = "پسورد و تکرار آن باید برابر باشند")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "تکرار پسورد را وارد نمایید")]
        [Display(Name = "تکرار پسورد")]
        public string RePassword { get; set; } = string.Empty;
        [Display(Name = "شماره تلفن")]
        
        public string PhoneNumber { get; set; }
    }
}
