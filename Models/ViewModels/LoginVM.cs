using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Models.ViewModels
{
    public class LoginVM
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
