using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using parafia_mbkm.data.Models;
using parafia_mbkm.View;
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
        public async Task<IActionResult> GetAllContacts()
        {
            IEnumerable<Contact>? contacts = await contactService.GetAllContactsAsync();
            if (contacts == null)
                return NotFound();
            return Ok(contacts);
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
        [HttpPost, Authorize]
        public async Task<IActionResult> AddContact([FromBody] ContactModel contact)
        {
            int contactId = await contactService.AddContactAsync(contact);
            if (contactId == -1)
                return BadRequest();
            return CreatedAtAction(nameof(GetContactById), "contact", new
            {
                Id = contactId,
            }, contact);
        }
    }
}
