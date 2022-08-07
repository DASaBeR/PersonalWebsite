using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Models.ViewModels
{
    public class AboutMeVM
    {
        public MyInfoModel MyInfo { get; set; }
        public IEnumerable<SkillsModel> Skills { get; set; }
        public IEnumerable<EducationModel> Educations { get; set; }
        public IEnumerable<ExperienceModel> Experiences { get; set; }
    }
}
