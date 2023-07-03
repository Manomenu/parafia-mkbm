using System.ComponentModel.DataAnnotations;

namespace parafia_mbkm.ModelViews
{
    public class AnnouncementView
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public string Content { get; set; }

        public AnnouncementView()
        {
            Title = "";
            Date = "";
            Content = "";
        }
    }
}
