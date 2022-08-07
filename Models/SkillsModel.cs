using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Models
{
    public class SkillsModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string SkillName { get; set; }
        [Required]
        public int Percentage { get; set; }
    }
}
