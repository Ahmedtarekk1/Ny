using System;
using Microsoft.EntityFrameworkCore;

namespace Laboration2.Models
{
    public class HusContext : DbContext
    {
        public DbSet<Hustyp> Hustyp { get; set; }
        public DbSet<Ägare> Ägare { get; set; }

        public HusContext()
        {
            Database.EnsureCreated();
        }
        //SQLite 
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=Husen.db");
        }


    }
}

