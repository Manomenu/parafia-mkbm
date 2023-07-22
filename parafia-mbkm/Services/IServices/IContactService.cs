using parafia_mbkm.data.Models;
using parafia_mbkm.data;
using parafia_mbkm.Models;

namespace parafia_mbkm.Services.IServices
{
    public interface IContactService
    {
        public Task<int> AddContactAsync(ContactModel contactModel);

        public Task<Contact?> GetContactByIdAsync(int id);

        public Task<IEnumerable<Contact>?> GetAllContactsAsync();
    }
}
