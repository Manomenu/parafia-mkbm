using Microsoft.AspNetCore.Mvc;
using parafia_mbkm.data.Models;
using parafia_mbkm.ModelViews;
using parafia_mbkm.Services.IServices;

namespace parafia_mbkm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService contactService;
        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        // GET: api/[controller]
        [HttpGet]
        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            return await contactService.GetAllContactsAsync();
        }

        //GET api/[controller]/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById([FromRoute] int id)
        {
            Contact? contact = await contactService.GetContactByIdAsync(id);
            if (contact == null)
                return NotFound();
            return Ok(contact);
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody] ContactView contact)
        {
            int contactId = await contactService.AddContactAsync(contact);
            return CreatedAtAction(nameof(GetContactById), "contact", new
            {
                Id = contactId,
            }, contact);
        }
    }
}
