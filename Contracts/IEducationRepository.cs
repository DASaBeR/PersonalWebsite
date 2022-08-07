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
    }
}
