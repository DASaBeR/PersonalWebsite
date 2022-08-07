using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Contracts
{
    public interface IRepositoryManager
    {
        IContactRepository Contact { get; }
        IEducationRepository Education { get; }
        IExperienceRepository Experience { get; }
        IMyInfoRepository MyInfo { get; }
        IServicesRepository Services { get; }
        ISkillsRepository Skills { get; }
        void Save();
    }
}
