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

        public DbSet<Event> Events { get; set; }

        public DbSet<Participant> Participants { get; set; }

        public DbSet<EventAtendee> EventAtendees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EventAtendee>()
                .HasKey(ea => new { ea.ParticipantId, ea.EventId });

            modelBuilder.Entity<EventAtendee>()
                .HasOne(ea => ea.Participant)
                .WithMany(e => e.EventAtendees)
                .HasForeignKey(ea => ea.ParticipantId);

            modelBuilder.Entity<EventAtendee>()
                .HasOne(ea => ea.Event)
                .WithMany(e => e.EventAtendees)
                .HasForeignKey(ea => ea.EventId);

        }

    }


}

