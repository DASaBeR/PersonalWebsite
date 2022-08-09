using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Models.ViewModels
{
    public class ContactVM
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please Enter Your Name.")]
        [MaxLength(60, ErrorMessage = "Your name should be less than 60 charracters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email.")]
        [EmailAddress]
        [MaxLength(100, ErrorMessage = "Your Email should be less than 100 charracters.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your Message Subject.")]
        [MaxLength(25, ErrorMessage = "Subject should be less than 25 charracters.")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Please Enter Your Message.")]
        [MaxLength(1024, ErrorMessage = "Your name should be less than 1024 charracters.")]
        public string Message { get; set; }
    }
}
