using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RNN.Models
{
    public class RNNContext : DbContext
    {
        public RNNContext(DbContextOptions<RNNContext> options) : base(options) {}

        public DbSet<Author> Authors { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Grouping> Groupings { get; set; }

        public DbSet<Entry> Entries { get; set; }
        public DbSet<EntryToTopic> EntryToTopics { get; set; }

        public DbSet<Grouping> Subjects { get; set; }
        public DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
