using PersonalWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Contracts
{
    public interface ISkillsRepository
    {
        IEnumerable<SkillsModel> GetSkills(bool trackChanges);
        void AddSkill(SkillsModel skill);
        void UpdateSkill(SkillsModel skill);
        void DeleteSkill(SkillsModel skill);
    }
}
