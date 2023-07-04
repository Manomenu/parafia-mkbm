using Microsoft.EntityFrameworkCore;
using parafia_mbkm.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parafia_mbkm.data
{
    public class ParafiaDbDataContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactLine> ContactLines { get; set; }


        public ParafiaDbDataContext(DbContextOptions<ParafiaDbDataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
    }
}
