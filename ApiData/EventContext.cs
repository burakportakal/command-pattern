using ApiModels.Event;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiData
{
    public class EventContext : DbContext, IEventContext
    {
        public EventContext() { }
        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EventDatabase;Trusted_Connection=True;MultipleActiveResultSets=True");
        }

        public DbSet<Event> Event { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}
