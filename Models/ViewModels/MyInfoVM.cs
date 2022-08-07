using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Models.ViewModels
{
    public class MyInfoVM
    {
        public string Name { get; set; }
        [Required]
        public string Specialty { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string LivesIn { get; set; }
        [Required]
        [Range(0,99)]
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string TelegramId { get; set; }
        public string Linkdin { get; set; }
        public string Github { get; set; }
        public string CvName { get; set; }
        public IFormFile MyCV { get; set; }
        public string ImageName { get; set; }
        public IFormFile Image { get; set; }
    }
}
