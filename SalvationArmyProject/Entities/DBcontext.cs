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
            //Database.EnsureCreated();
            Database.Migrate();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<EventRequest> EventRequests { get; set; }
        public DbSet<EventResponse> EventResponses { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder) {
        //modelBuilder.Seed();
        //}
    }
}
