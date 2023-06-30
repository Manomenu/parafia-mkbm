using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parafia_mbkm.data.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Header { get; set; }
        public string Content { get; set; }

        public Article()
        {
            Header = "";
            Content = "";
        }
    }
}
