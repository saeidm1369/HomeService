using System.ComponentModel.DataAnnotations;

namespace HomeService.EndPoint.WebMVC.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "وارد کردن ایمیل الزامی است.")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی‌باشد.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "وارد کردن رمز عبور الزامی است.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "رمز عبور باید حداقل ۶ کاراکتر باشد.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "تایید رمز عبور الزامی است.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "رمز عبور و تایید آن یکسان نیستند.")]
        public string ConfirmPassword { get; set; }

        public bool IsExpert { get; set; }
    }
}
