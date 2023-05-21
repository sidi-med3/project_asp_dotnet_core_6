using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Projet_dot_net_annonce.ViewModels
{
    public class RegisterViewModel
    {
        
        public String? Nom { get; set; } 
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
        [Required]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = "";
    }
    public class RgisterListViewMode
    {
       public List<IdentityUser> Users{ get; set;}
    }
}
