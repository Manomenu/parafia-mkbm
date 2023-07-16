using parafia_mbkm.data.Models;
using parafia_mbkm.data;
using parafia_mbkm.ModelViews;
using parafia_mbkm.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace parafia_mbkm.Services
{
    public class ContactService : IContactService
    {
        private readonly ParafiaDbDataContext _dbContext;

        public ContactService(ParafiaDbDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddContactAsync(ContactView contactModel)
        {
            Contact contact = new Contact
            {
                ContactTitle = contactModel.ContactTitle,
                ContactLines = contactModel.ContactLines.Select(cl => new ContactLine
                {
                    Category = cl.Category, 
                    Value = cl.Value,
                    Icon = cl.Icon,
                }).ToList()
            };
            await _dbContext.Contacts.AddAsync(contact);
            await _dbContext.SaveChangesAsync();

            return contact.Id;
        }

        public async Task<Contact?> GetContactByIdAsync(int id)
        {
            return await _dbContext.Contacts.FindAsync(id);
        }

        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            return await _dbContext.Contacts.Include(c => c.ContactLines).ToArrayAsync();
        }
    }
}
