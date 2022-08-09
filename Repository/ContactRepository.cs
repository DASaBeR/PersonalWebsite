using PersonalWebsite.Contracts;
using PersonalWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Repository
{
    public class ContactRepository : RepositoryBase<ContactModel> , IContactRepository
    {
        public ContactRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<ContactModel> GetMessages(bool trackChanges) =>
            FindAll(trackChanges).ToList();
        public void DeleteMessage(ContactModel message) =>
            Delete(message);
        public void SaveContactMessage(ContactModel contactMessage) =>
            Create(contactMessage);

    }
}
