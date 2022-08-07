using PersonalWebsite.Contracts;
using PersonalWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Repository
{
    public class EducationRepository : RepositoryBase<EducationModel> , IEducationRepository
    {
        public EducationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<EducationModel> GetEducations(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(c => c.Year).ToList();
    }
}
