using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using parafia_mbkm.data.Models;

namespace parafia_mbkm.data
{
    public class ParafiaDbDataContext : IdentityUserContext<IdentityUser>
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
            base.OnModelCreating(modelBuilder);
        }
    }
}
