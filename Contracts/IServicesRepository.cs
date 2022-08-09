using PersonalWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Contracts
{
    public interface IServicesRepository
    {
        IEnumerable<ServicesModel> GetServices(bool trackChanges);
        void AddService(ServicesModel service);
        void UpdateService(ServicesModel service);
        void DeleteService(ServicesModel service);
    }
}
