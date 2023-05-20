using System.ComponentModel.DataAnnotations;

namespace MVC_MyProject.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Kullanıcı Adı Boş Bırakalamaz!")]
        [Display(Name ="Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Şifre Boş Bırakalamaz!")]
        [Display(Name ="Şifre")]
        public string Password { get; set; }
    }
}
