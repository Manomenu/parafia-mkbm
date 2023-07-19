using parafia_mbkm.data.Models;
using parafia_mbkm.data;
using parafia_mbkm.Models;
using parafia_mbkm.Services.IServices;
using Microsoft.EntityFrameworkCore;

// Requires exception refactoring
// https://www.youtube.com/watch?v=YbuSuSpzee4
namespace parafia_mbkm.Services
{
    public class ContactService : IContactService
    {
        private readonly ParafiaDbDataContext _dbContext;

        public ContactService(ParafiaDbDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddContactAsync(ContactModel contactModel)
        {
            try
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
            catch
            {
                return -1;
            }
        }

        public async Task<Contact?> GetContactByIdAsync(int id)
        {
            try
            {
                return await _dbContext.Contacts.FindAsync(id);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Contact>?> GetAllContactsAsync()
        {
            try
            {
                return await _dbContext.Contacts.Include(c => c.ContactLines).ToArrayAsync();
            }
            catch
            {
                return null;
            }
        }
    }
}
