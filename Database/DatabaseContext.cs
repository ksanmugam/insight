using BigPurpleBank.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace big_purple_bank.Server.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    }
}
