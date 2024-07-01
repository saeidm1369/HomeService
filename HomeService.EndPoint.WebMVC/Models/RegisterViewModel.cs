using System.ComponentModel.DataAnnotations;

namespace HomeService.EndPoint.WebMVC.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "ایمیل الزامی است.")]
        [EmailAddress(ErrorMessage = "فرمت ایمیل صحیح نیست.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "رمز عبور الزامی است.")]
        [StringLength(100, ErrorMessage = "رمز عبور باید حداقل ۶ کاراکتر باشد.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "رمز عبور و تایید آن یکسان نیست.")]
        public string ConfirmPassword { get; set; }
    }
}
