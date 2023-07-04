using Microsoft.AspNetCore.Mvc;
using parafia_mbkm.data;
using parafia_mbkm.data.Models;
using parafia_mbkm.Services;
using parafia_mbkm.ModelViews;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace parafia_mbkm.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly ParafiaDbDataContext context;
        public AnnouncementController(ParafiaDbDataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Announcement>> GetAll()
        {
            return await context.Announcements.ToArrayAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnnouncementById([FromRoute] int id)
        {
            Announcement? announcement = await AnnouncementService.GetAnnouncementByIdAsync(id, context);
            if(announcement == null)
            {
                return NotFound();
            }
            return Ok(announcement);
        }

        [HttpPost]
        public async Task<IActionResult> AddAnnouncement([FromBody] AnnouncementView announcement)
        {
            var announcementId = await AnnouncementService.AddAnnouncementAsync(announcement, context);
            return CreatedAtAction(nameof(GetAnnouncementById), "announcement", new
            { 
                Id = announcementId,
            }, new 
            {
                Title = announcement.Title,
                Date = announcement.Date,
                Content = announcement.Content
            });
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
