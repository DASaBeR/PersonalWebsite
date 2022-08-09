using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Models.ViewModels
{
    public class IndexVM
    {
        public AboutMeVM AboutMe { get; set; }
        public IEnumerable<ServicesModel> Services { get; set; }
        public ContactVM messageVM { get; set; }

    }
}
