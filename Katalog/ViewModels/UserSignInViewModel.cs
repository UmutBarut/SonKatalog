using System.ComponentModel.DataAnnotations;

namespace Katalog.ViewModels
{
    public class UserSignInViewModel
    {
        // public string UserName { get; set; }
        // public string Password { get; set; }

         [Required(ErrorMessage = "Lütfen Kullanıcı adınızı girin")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Lütfen şifrenizi girin")]
        public string Password { get; set; }
    }

    public class UserSignUpViewModel
    {

           [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Giriniz.")]
        public string Username { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz.")]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "Lütfen Mail Adresinizi Giriniz.")]
        public string Mail { get; set; }
    }
}
