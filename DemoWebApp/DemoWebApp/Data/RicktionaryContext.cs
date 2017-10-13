using DemoWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApp.Data
{
    public class RicktionaryContext : DbContext
    {
        public RicktionaryContext(DbContextOptions<RicktionaryContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rickism>().Property(r => r.Created).HasDefaultValueSql("getdate()");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Rickism> Rickisms { get; set; }

    }
}
