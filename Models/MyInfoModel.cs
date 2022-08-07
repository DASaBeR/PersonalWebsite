using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Models
{
    public class MyInfoModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
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
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string TelegramId { get; set; }
        public string Linkdin { get; set; }
        public string Github { get; set; }
        public string CVPath { get; set; }
        public string CVName { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
    }
}
