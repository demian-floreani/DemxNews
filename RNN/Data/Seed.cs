using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RNN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models
{
    public class Seed
    {
        public void SeedConfig()
        {
            
        }

        public static void SeedDatabase(ModelBuilder modelBuilder)
        {
            List<Title> titles = new List<Title>() 
            {
                new Title() { Id = 1, Name = "Editorial" },
                new Title() { Id = 2, Name = "Opinion" },
                new Title() { Id = 3, Name = "UK News" },
                new Title() { Id = 4, Name = "UK Politics" }
            };

            modelBuilder.Entity<Title>().HasData(titles.ToArray());

            List<Author> authors = new List<Author>();
            authors.Add(new Author() { Id = 1, Name = "Autho1" });

            modelBuilder.Entity<Author>().HasData(authors.ToArray());

            List<Grouping> subjects = new List<Grouping>()
            {
                new Grouping() { Name = "Grouping 1", Rank = 1 },
                new Grouping() { Name = "Grouping 2", Rank = 2 },
                new Grouping() { Name = "Grouping 3", Rank = 3 },
                new Grouping() { Name = "Grouping 4", Rank = 4 },
            };

            int i = 1;
            subjects.ForEach(s => s.Id = i++);
            modelBuilder.Entity<Grouping>().HasData(subjects.ToArray());

            List<Topic> topics = new List<Topic>()
            {
                new Topic() { Name = "Topic 1" },
                new Topic() { Name = "Topic 2" },
                new Topic() { Name = "Topic 3" },
                new Topic() { Name = "Topic 4" },
                new Topic() { Name = "Topic 5" },
                new Topic() { Name = "Topic 6" },
                new Topic() { Name = "Topic 7" },
                new Topic() { Name = "Topic 8" },
                new Topic() { Name = "Topic 9" },
                new Topic() { Name = "Topic 10" },
                new Topic() { Name = "Topic 11" },
                new Topic() { Name = "Topic 12" },
                new Topic() { Name = "Topic 13" },
                new Topic() { Name = "Topic 14" }
            };

            i = 1;
            topics.ForEach(t => t.Id = i++);
            modelBuilder.Entity<Topic>().HasData(topics.ToArray());

            List<Post> posts = new List<Post>()
            {
                new Post() { IsFeatured = true, HeadLine = "Test post: put all the content here for the post title 1", Url = "" },
                new Post() { IsFeatured = true, HeadLine = "Test post: put all the content here for the post title 2", Url = "" },
                new Post() { IsFeatured = true, HeadLine = "Test post: put all the content here for the post title 3", Url = "" },
                new Post() { IsFeatured = true, HeadLine = "Test post: put all the content here for the post title 4", Url = "" },
                new Post() { IsFeatured = true, HeadLine = "Test post: put all the content here for the post title 5", Url = "" },
                new Post() { IsFeatured = true, HeadLine = "Test post: put all the content here for the post title 6", Url = "" },
                new Post() { IsFeatured = true, HeadLine = "Test post: put all the content here for the post title 7", Url = "" },
                new Post() { IsFeatured = true, HeadLine = "Test post: put all the content here for the post title 8", Url = "" },
                new Post() { IsFeatured = true, HeadLine = "Test post: put all the content here for the post title 9", Url = "" },
                new Post() { IsFeatured = true, HeadLine = "Test post: put all the content here for the post title 10", Url = "" },
                new Post() { IsFeatured = true, HeadLine = "Test post: put all the content here for the post title 11", Url = "" }
            };

            i = 1;
            posts.ForEach(x => x.Id = i++);
            modelBuilder.Entity<Post>().HasData(posts.ToArray());

            List<ArticleToTopic> postToTopics = new List<ArticleToTopic>()
            {
                new ArticleToTopic() { Article = new Article() { HeadLine = "Test post: put all the content here for the post title 1" }, Topic = new Topic() { Name = "Topic 1"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Test post: put all the content here for the post title 2" }, Topic = new Topic() { Name = "Topic 2"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Test post: put all the content here for the post title 3" }, Topic = new Topic() { Name = "Topic 3"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Test post: put all the content here for the post title 4" }, Topic = new Topic() { Name = "Topic 4"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Test post: put all the content here for the post title 5" }, Topic = new Topic() { Name = "Topic 5"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Test post: put all the content here for the post title 6" }, Topic = new Topic() { Name = "Topic 6"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Test post: put all the content here for the post title 7" }, Topic = new Topic() { Name = "Topic 7"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Test post: put all the content here for the post title 8" }, Topic = new Topic() { Name = "Topic 1"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Test post: put all the content here for the post title 9" }, Topic = new Topic() { Name = "Topic 2"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Test post: put all the content here for the post title 10" }, Topic = new Topic() { Name = "Topic 3"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Test post: put all the content here for the post title 11" }, Topic = new Topic() { Name = "Topic 4"} }

            };

            foreach (var item in postToTopics)
            {
                item.ArticleId = posts.FirstOrDefault(p => p.HeadLine == item.Article.HeadLine).Id;
                item.TopicId = topics.FirstOrDefault(t => t.Name == item.Topic.Name).Id;
                item.Article = null;
                item.Topic = null;
            }

            modelBuilder.Entity<ArticleToTopic>().HasData(postToTopics.ToArray());

            List<Editorial> editorials = new List<Editorial>()
            {
                new Editorial()
                {
                    AuthorId = 1,
                    TitleId = 1,
                    Url = "",
                    Img = "editorial.jpg",
                    Paragraph = "Leadership campaign falters as he refuses to respond to questions at hustings about late-night argument with Carrie Symonds",
                    Body = "",
                    IsFeatured = true,
                    HeadLine = "Boris Johnson under fire over row with partner as top Tories raise fears"
                },
                new Editorial()
                {
                    AuthorId = 1,
                    TitleId = 2,
                    Url = "",
                    Img = "editorial.jpg",
                    Paragraph = "Leadership campaign falters as he refuses to respond to questions at hustings about late-night argument with Carrie Symonds",
                    Body = "",
                    IsFeatured = true,
                    HeadLine = "MPs debate Boris Johnson's deal as People's Vote march sets off – live news"
                }
            };

            editorials.ForEach(x => x.Id = i++);
            modelBuilder.Entity<Editorial>().HasData(editorials.ToArray());

            List<ArticleToTopic> editorialToTopics = new List<ArticleToTopic>()
            {
                new ArticleToTopic() { Article = new Article() { HeadLine = "Boris Johnson under fire over row with partner as top Tories raise fears" }, Topic = new Topic() { Name = "Topic 1"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "MPs debate Boris Johnson's deal as People's Vote march sets off – live news" }, Topic = new Topic() { Name = "Topic 2"} },
            };

            foreach (var item in editorialToTopics)
            {
                item.ArticleId = editorials.FirstOrDefault(p => p.HeadLine == item.Article.HeadLine).Id;
                item.TopicId = topics.FirstOrDefault(t => t.Name == item.Topic.Name).Id;
                item.Article = null;
                item.Topic = null;
            }

            modelBuilder.Entity<ArticleToTopic>().HasData(editorialToTopics.ToArray());

            List<Opinion> opinions = new List<Opinion>()
            {
                new Opinion()
                {
                    AuthorId = 1,
                    TitleId = 2,
                    Img = "nature.jpg",
                    HeadLine = "Opinion piece 1",
                    Paragraph = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",
                    IsFeatured = true,
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                },
                new Opinion()
                {
                    AuthorId = 1,
                    TitleId = 2,
                    Img = "nature.jpg",
                    HeadLine = "Opinion piece 2",
                    Paragraph = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",
                    IsFeatured = true,
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                },
                new Opinion()
                {
                    AuthorId = 1,
                    TitleId = 2,
                    Img = "nature.jpg",
                    HeadLine = "Opinion piece 3",
                    Paragraph = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",
                    IsFeatured = true,
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                },
                new Opinion()
                {
                    AuthorId = 1,
                    TitleId = 2,
                    Img = "nature.jpg",
                    HeadLine = "Opinion piece 4",
                    Paragraph = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",
                    IsFeatured = false,
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                },
                new Opinion()
                {
                    AuthorId = 1,
                    TitleId = 2,
                    Img = "nature.jpg",
                    HeadLine = "Opinion piece 5",
                    Paragraph = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",
                    IsFeatured = false,
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                },
                new Opinion()
                {
                    AuthorId = 1,
                    TitleId = 2,
                    Img = "nature.jpg",
                    HeadLine = "Opinion piece 6",
                    Paragraph = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",
                    IsFeatured = false,
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                },
                new Opinion()
                {
                    AuthorId = 1,
                    TitleId = 2,
                    Img = "nature.jpg",
                    HeadLine = "Opinion piece 7",
                    Paragraph = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",
                    IsFeatured = false,
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                }
            };

            opinions.ForEach(x => x.Id = i++);
            modelBuilder.Entity<Opinion>().HasData(opinions.ToArray());

            List<ArticleToTopic> opinionToTopics = new List<ArticleToTopic>()
            {
                new ArticleToTopic() { Article = new Article() { HeadLine = "Opinion piece 1" }, Topic = new Topic() { Name = "Topic 1"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Opinion piece 1" }, Topic = new Topic() { Name = "Topic 2"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Opinion piece 2" }, Topic = new Topic() { Name = "Topic 3"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Opinion piece 3" }, Topic = new Topic() { Name = "Topic 4"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Opinion piece 4" }, Topic = new Topic() { Name = "Topic 5"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Opinion piece 5" }, Topic = new Topic() { Name = "Topic 6"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Opinion piece 6" }, Topic = new Topic() { Name = "Topic 7"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Opinion piece 7" }, Topic = new Topic() { Name = "Topic 1"} },
            };

            foreach (var item in opinionToTopics)
            {
                item.ArticleId = opinions.FirstOrDefault(p => p.HeadLine == item.Article.HeadLine).Id;
                item.TopicId = topics.FirstOrDefault(t => t.Name == item.Topic.Name).Id;
                item.Article = null;
                item.Topic = null;
            }

            modelBuilder.Entity<ArticleToTopic>().HasData(opinionToTopics.ToArray());
        }
    }
}
