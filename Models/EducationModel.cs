using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Models
{
    public class EducationModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string FieldOfStudy { get; set; }
        [Required]
        public string Institute { get; set; }
        public string Description { get; set; }
    }
}
