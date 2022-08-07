using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Models
{
    public class ServicesModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string ServiceName { get; set; }
        public string Description { get; set; }
    }
}
