using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parafia_mbkm.data.Models
{
    public class Announcement
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Content { get; set; }

        public Announcement()
        {
            Title = "";
            Date = "";
            Content = "";
        }
    }
}
