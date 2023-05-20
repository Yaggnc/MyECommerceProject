using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_MyProject.Models.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez")]
        [Display(Name ="Kullanıcı Adı")]
        public string Username { get; set; }


        [Required(ErrorMessage ="Şifre Boş Geçilemez")]
        [Display(Name ="Şifre")]
        public string Password { get; set; }


        [Required(ErrorMessage ="Şifre Onayı boş geçilemez")]
        [Display(Name ="Şifre Onayı")]
        [Compare("Password",ErrorMessage ="Şifreler uyuşmuyor!")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage ="Email boş geçilemez")]
        [Display(Name ="Email")]
        public string Email { get; set; }
        

    }
}
