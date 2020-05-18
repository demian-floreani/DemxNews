using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RNN.Data.Impl;
using RNN.Models.Identity;

namespace RNN.Models
{
    public class RNNContext : IdentityDbContext<ApplicationUser>
    {
        public RNNContext(DbContextOptions<RNNContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; } 
        public DbSet<Entry> Entries { get; set; }
        public DbSet<EntryToTopic> EntryToTopics { get; set; }
        public DbSet<Topic> Topics { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Newsletter> Newsletters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Entry>().HasIndex(p => p.Slug).IsUnique();

            modelBuilder.Entity<Topic>().HasIndex(t => t.Name).IsUnique();

            modelBuilder.Entity<EntryToTopic>()
                .HasKey(pt => new { pt.TopicId, pt.EntryId });
            modelBuilder.Entity<EntryToTopic>()
                .HasOne(pt => pt.Entry)
                .WithMany(p => p.EntryToTopics)
                .HasForeignKey(bc => bc.EntryId);
            modelBuilder.Entity<EntryToTopic>()
                .HasOne(pt => pt.Topic)
                .WithMany(t => t.EntryToTopics)
                .HasForeignKey(bc => bc.TopicId);

            Seed.SeedDatabase(modelBuilder);
        }

    }
}
