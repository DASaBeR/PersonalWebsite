using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Models.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [Display(Name ="Username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string Password { get; set; }
        [Compare("Password" , ErrorMessage ="Password and Repeat Password must be match.")]
        [Display(Name ="Repeat Password")]
        public string RePassword { get; set; }
        [EmailAddress]
        [Required]
        [Display(Name ="Email Address")]
        public string Email { get; set; }
        
    }
}
