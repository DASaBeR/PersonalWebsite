using PersonalWebsite.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IContactRepository _contactRepository;
        private IEducationRepository _educationRepository;
        private IExperienceRepository _experienceRepository;
        private IMyInfoRepository _myInfoRepository;
        private IServicesRepository _servicesRepository;
        private ISkillsRepository _skillsRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IContactRepository Contact
        {
            get
            {
                if (_contactRepository == null)
                    _contactRepository = new ContactRepository(_repositoryContext);
                return _contactRepository;
            }
        }

        public IEducationRepository Education
        {
            get
            {
                if (_educationRepository == null)
                    _educationRepository = new EducationRepository(_repositoryContext);
                return _educationRepository;
            }
        }
        public IExperienceRepository Experience
        {
            get
            {
                if (_experienceRepository == null)
                    _experienceRepository = new ExperienceRepository(_repositoryContext);
                return _experienceRepository;
            }
        }
        public IMyInfoRepository MyInfo
        {
            get
            {
                if (_myInfoRepository == null)
                    _myInfoRepository = new MyInfoRepository(_repositoryContext);
                return _myInfoRepository;
            }
        }
        public IServicesRepository Services
        {
            get
            {
                if (_servicesRepository == null)
                    _servicesRepository = new ServicesRepository(_repositoryContext);
                return _servicesRepository;
            }
        }
        public ISkillsRepository Skills
        {
            get
            {
                if (_skillsRepository == null)
                    _skillsRepository = new SkillsRepository(_repositoryContext);
                return _skillsRepository;
            }
        }
        public void Save() => _repositoryContext.SaveChanges();
    }
}
