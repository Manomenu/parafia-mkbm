using Microsoft.AspNetCore.Mvc;
using parafia_mbkm.data;
using Microsoft.EntityFrameworkCore;
using parafia_mbkm.data.Models;
using parafia_mbkm.ModelViews;
using parafia_mbkm.Services;

namespace parafia_mbkm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ParafiaDbDataContext context;
        public ContactController(ParafiaDbDataContext context)
        {
            this.context = context;
        }

        // GET: api/[controller]
        [HttpGet]
        public async Task<IEnumerable<Contact>> GetAll()
        {
            var x = await context.Contacts.Include(c => c.ContactLines).ToArrayAsync();
            return x;
        }

        //GET api/[controller]/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById([FromRoute] int id)
        {
            Contact? contact = await ContactService.GetContactByIdAsync(id, context);
            if (contact == null)
                return NotFound();
            return Ok(contact);
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody] ContactView contact)
        {
            int contactId = await ContactService.AddContactAsync(contact, context);
            return CreatedAtAction(nameof(GetContactById), "contact", new
            {
                Id = contactId,
            }, contact);
        }
    }
}
