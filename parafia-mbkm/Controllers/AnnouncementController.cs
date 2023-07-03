using Microsoft.AspNetCore.Mvc;
using parafia_mbkm.data;
using parafia_mbkm.data.Models;
using parafia_mbkm.Services;
using parafia_mbkm.ModelViews;
using Microsoft.EntityFrameworkCore;

namespace parafia_mbkm.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnnouncementController
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
        // to do
    }
}
