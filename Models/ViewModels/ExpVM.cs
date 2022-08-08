using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Models.ViewModels
{
    public class ExpVM
    {
        public Guid Id { get; set; }
        [Required]
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        [Required]
        public bool IsCurrent { get; set; }
        [Required]
        public string SubjectOfactivity { get; set; }
        [Required]
        public string Institute { get; set; }
        public string Description { get; set; }
    }
}
