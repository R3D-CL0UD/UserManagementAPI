using System.ComponentModel.DataAnnotations;

namespace UserManagementAPI.Dtos
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "نام کاربری الزامی است")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "رمز عبور الزامی است")]
        [MinLength(6, ErrorMessage = "رمز عبور باید حداقل ۶ کاراکتر باشد")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "تکرار رمز عبور الزامی است")]
        [Compare("Password", ErrorMessage = "رمز عبور و تکرار آن مطابقت ندارند")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "نام الزامی است")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "سن الزامی است")]
        [Range(1, 120, ErrorMessage = "سن باید بین ۱ تا ۱۲۰ باشد")]
        public int Age { get; set; }
    }
}