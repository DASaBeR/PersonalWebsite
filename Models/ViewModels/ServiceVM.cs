using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Models.ViewModels
{
    public class ServiceVM
    {
        public Guid Id { get; set; }
        [Required]
        public string ServiceName { get; set; }
        public string Description { get; set; }
    }
}
