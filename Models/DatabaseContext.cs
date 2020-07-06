using System;
using Microsoft.EntityFrameworkCore;

namespace probagetrequest.Models
{

    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Messages> Messagees { get; set; }
        public DbSet<Account> Accounts { get; set; }

    }
}