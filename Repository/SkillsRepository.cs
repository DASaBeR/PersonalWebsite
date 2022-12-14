using PersonalWebsite.Contracts;
using PersonalWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Repository
{
    public class SkillsRepository : RepositoryBase<SkillsModel>, ISkillsRepository
    {
        public SkillsRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<SkillsModel> GetSkills(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(c => c.SkillName).ToList();

        public void AddSkill(SkillsModel skill) =>
            Create(skill);

        public void DeleteSkill(SkillsModel skill) =>
            Delete(skill);

        public void UpdateSkill(SkillsModel skill) =>
            Update(skill);
    }
}
