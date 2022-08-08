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
        void AddEdu(EducationModel exp);
        void UpdateEdu(EducationModel exp);
        void DeleteEdu(EducationModel exp);
    }
}
