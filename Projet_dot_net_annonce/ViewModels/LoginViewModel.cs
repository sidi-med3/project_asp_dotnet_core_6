using System.ComponentModel.DataAnnotations;

namespace Projet_dot_net_annonce.ViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Remember My")]
        public bool RememberMy { get; set; }

    }
}
