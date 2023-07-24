using parafia_mbkm.data;
using parafia_mbkm.data.Models;
using parafia_mbkm.ModelViews;

namespace parafia_mbkm.Services
{
    public class AnnouncementService
    {
        public static async Task<int> AddAnnouncementAsync(AnnouncementView announcementModel, ParafiaDbDataContext context)
        {
            Announcement announcement = new Announcement
            {
                Title = announcementModel.Title,
                Date = announcementModel.Date,
                Content = announcementModel.Content
            };
            await context.Announcements.AddAsync(announcement);
            await context.SaveChangesAsync();

            return announcement.Id;
        }

        public static async Task<Announcement?> GetAnnouncementByIdAsync(int id, ParafiaDbDataContext context)
        {
            return await context.Announcements.FindAsync(id);
        }
    }
}
