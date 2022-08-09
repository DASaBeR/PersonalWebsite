using PersonalWebsite.Contracts;
using PersonalWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Repository
{
    public class ExperienceRepository : RepositoryBase<ExperienceModel>, IExperienceRepository
    {
        public ExperienceRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        
        public IEnumerable<ExperienceModel> GetExperiences(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(c => c.StartYear).ToList();

        public void AddExp(ExperienceModel exp) =>
            Create(exp);

        public void DeleteExp(ExperienceModel exp) =>
            Delete(exp);

        public void UpdateExp(ExperienceModel exp) =>
            Update(exp);
    }
}
