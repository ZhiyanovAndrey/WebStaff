using Microsoft.EntityFrameworkCore;
using System;

namespace WebStaff.Models
{
    public class Context : DbContext
    {
        public DbSet<Emploee> Emploees { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
