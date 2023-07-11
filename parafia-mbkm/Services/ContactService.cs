using parafia_mbkm.data.Models;
using parafia_mbkm.data;
using parafia_mbkm.ModelViews;

namespace parafia_mbkm.Services
{
    public static class ContactService
    {
        public static async Task<int> AddContactAsync(ContactView contactModel, ParafiaDbDataContext context)
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
            await context.Contacts.AddAsync(contact);
            await context.SaveChangesAsync();

            return contact.Id;
        }

        public static async Task<Contact?> GetContactByIdAsync(int id, ParafiaDbDataContext context)
        {
            return await context.Contacts.FindAsync(id);
        }
    }
}
