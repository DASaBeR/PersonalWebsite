using PersonalWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Contracts
{
    public interface IEducationRepository
    {
        IEnumerable<EducationModel> GetEducations(bool trackChanges);
        void AddEdu(EducationModel edu);
        void UpdateEdu(EducationModel edu);
        void DeleteEdu(EducationModel edu);
    }
}
