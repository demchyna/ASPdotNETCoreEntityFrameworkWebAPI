using ASPdotNETCoreEntityFrameworkWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPdotNETCoreEntityFrameworkWebAPI
{
    public class EJournalContext : DbContext
    {
        public EJournalContext()
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=IF219\SQLEXPRESS;Database=EJournalDB;Trusted_Connection=True;");
        }
    }
}
