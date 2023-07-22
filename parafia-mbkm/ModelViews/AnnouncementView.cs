using System.ComponentModel.DataAnnotations;

namespace parafia_mbkm.ModelViews
{
    public class AnnouncementView
    {
        public string Title { get; set; }
        public DateOnly Date { get; set; }
        public string Content { get; set; }
        public string MainImage { get; set; }

        public AnnouncementView()
        {
            Title = "";
            Date = new DateOnly();
            Content = "";
        }
    }
}
