using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parafia_mbkm.data.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ContactTitle { get; set; }
        public List<ContactLine> ContactLines { get; set; }

        public Contact() 
        {
            ContactLines = new List<ContactLine>();
            ContactTitle = "";
        }
    }

    
}
