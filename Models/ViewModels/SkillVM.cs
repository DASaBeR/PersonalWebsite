using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Models.ViewModels
{
    public class SkillVM
    {
        public Guid Id { get; set; }
        [Required]
        public string SkillName { get; set; }
        [Required]
        [Range(0 , 100)]
        public int Percentage { get; set; }
    }
}
