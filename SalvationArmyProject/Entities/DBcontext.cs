using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SalvationArmyProject.SeedData;

namespace SalvationArmyProject.Entities
{
    public class DBcontext : IdentityDbContext
    {
        public DBcontext(DbContextOptions<DBcontext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        //public DBcontext(new SQLiteConnection(@"Data Source=|DataDirectory|ComponentDatabase.sqlite"), true) : base(options)
        //{

        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlite("Data Source=blogging.db");
        //}

        public DbSet<User> Users { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder) {
        //modelBuilder.Seed();
        //}
    }
}
