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

        public DbSet<Editorial> Editorials { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<ArticleToTopic> ArticleToTopics { get; set; }

        public DbSet<Grouping> Subjects { get; set; }
        public DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<SubjectToTopic>()
            //    .HasKey(pt => new { pt.SubjectId, pt.TopicId });
            //modelBuilder.Entity<SubjectToTopic>()
            //    .HasOne(st => st.Subject)
            //    .WithMany(s => s.SubjectToTopic)
            //    .HasForeignKey(st => st.SubjectId);
            //modelBuilder.Entity<SubjectToTopic>()
            //    .HasOne(st => st.Topic)
            //    .WithMany(t => t.SubjectToTopic)
            //    .HasForeignKey(bc => bc.TopicId);

            //modelBuilder.Entity<PostToTopic>()
            //    .HasKey(pt => new { pt.TopicId, pt.PostId });
            //modelBuilder.Entity<PostToTopic>()
            //    .HasOne(pt => pt.Post)
            //    .WithMany(p => p.PostToTopic)
            //    .HasForeignKey(bc => bc.PostId);
            //modelBuilder.Entity<PostToTopic>()
            //    .HasOne(pt => pt.Topic)
            //    .WithMany(t => t.PostToTopic)
            //    .HasForeignKey(bc => bc.TopicId);

            modelBuilder.Entity<ArticleToTopic>()
                .HasKey(pt => new { pt.TopicId, pt.ArticleId });
            modelBuilder.Entity<ArticleToTopic>()
                .HasOne(pt => pt.Article)
                .WithMany(p => p.ArticleToTopics)
                .HasForeignKey(bc => bc.ArticleId);
            modelBuilder.Entity<ArticleToTopic>()
                .HasOne(pt => pt.Topic)
                .WithMany(t => t.ArticleToTopic)
                .HasForeignKey(bc => bc.TopicId);


            //modelBuilder.Entity<OpinionToTopic>()
            //    .HasKey(pt => new { pt.TopicId, pt.OpinionId });
            //modelBuilder.Entity<OpinionToTopic>()
            //    .HasOne(pt => pt.Opinion)
            //    .WithMany(p => p.OpinionToTopic)
            //    .HasForeignKey(bc => bc.OpinionId);
            //modelBuilder.Entity<OpinionToTopic>()
            //    .HasOne(pt => pt.Topic)
            //    .WithMany(t => t.OpinionToTopic)
            //    .HasForeignKey(bc => bc.TopicId);

            Seed.SeedDatabase(modelBuilder);
        }

    }
}
