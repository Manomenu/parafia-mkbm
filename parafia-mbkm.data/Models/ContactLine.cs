using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parafia_mbkm.data.Models
{
    public class ContactLine
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Value { get; set; }

        public ContactLine()
        {
            Category = "";
            Value = "";
        }
    }
}
