using PersonalWebsite.Contracts;
using PersonalWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Repository
{
    public class ServicesRepository : RepositoryBase<ServicesModel>, IServicesRepository
    {
        public ServicesRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<ServicesModel> GetServices(bool trackChanges) =>
            FindAll(trackChanges).ToList();
    }
}
