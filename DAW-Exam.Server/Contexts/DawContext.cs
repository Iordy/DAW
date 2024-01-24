using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using DAW_Exam.Server.Entities;

namespace DAW_Exam.Server.Contexts
{
    public class DawContext : DbContext
    {
        public DawContext(DbContextOptions<DawContext> options) : base(options)
        {

        }

        public DbSet<Excavator> Excavators { get; set; }
        public DbSet<ExcavatorType> ExcavatorTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Excavator>().HasOne(e => e.ExcavatorType).WithMany(e => e.Excavators).HasForeignKey(e => e.ExcavatorTypeId);
        }

    }


}

