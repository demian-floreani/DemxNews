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
            authors.Add(new Author() { Id = 1, Name = "RenegadeNews" });

            modelBuilder.Entity<Author>().HasData(authors.ToArray());

            List<Subject> subjects = new List<Subject>()
            {
                new Subject() { Name = "Migration", Rank = 1 },
                new Subject() { Name = "Boom & Bust", Rank = 2 },
                new Subject() { Name = "Climate Activism", Rank = 3 },
                new Subject() { Name = "Free Speech", Rank = 4 },
                new Subject() { Name = "Deep State", Rank = 5 }
            };

            int i = 1;
            subjects.ForEach(s => s.Id = i++);
            modelBuilder.Entity<Subject>().HasData(subjects.ToArray());

            List<Topic> topics = new List<Topic>()
            {
                new Topic() { Name = "Brexit" },
                new Topic() { Name = "Deep State" },
                new Topic() { Name = "Corruption" },
                new Topic() { Name = "Money in Politics" },
                new Topic() { Name = "Donald Trump" },
                new Topic() { Name = "EU" },
                new Topic() { Name = "Neo-Liberalism" },
                new Topic() { Name = "Bilderberg" },
                new Topic() { Name = "Federal Reserve" },
                new Topic() { Name = "NWO" },
                new Topic() { Name = "Migrants" },
                new Topic() { Name = "Mass Immigration" },
                new Topic() { Name = "Islamism" },
                new Topic() { Name = "Assange" },
                new Topic() { Name = "Merkel" },
                new Topic() { Name = "Neo-Cons" },
                new Topic() { Name = "RINOs" },
                new Topic() { Name = "Crony Capitalism" },
                new Topic() { Name = "Economy" },
                new Topic() { Name = "Animal Rights" },
                new Topic() { Name = "GMO" },
                new Topic() { Name = "5G" },
                new Topic() { Name = "Wifi" },
                new Topic() { Name = "Censorship" },
                new Topic() { Name = "Tech Fascism" },
                new Topic() { Name = "First Amendment" },
                new Topic() { Name = "Big Brother" },
                new Topic() { Name = "Wikipedia" },
                new Topic() { Name = "Viktor Orban" },
                new Topic() { Name = "Salvini" },
                new Topic() { Name = "Junker" },
                new Topic() { Name = "Refugees" },
                new Topic() { Name = "Integration" }
            };

            i = 1;
            topics.ForEach(t => t.Id = i++);
            modelBuilder.Entity<Topic>().HasData(topics.ToArray());

            List<SubjectToTopic> subjectToTopics = new List<SubjectToTopic>()
            {
                //new SubjectToTopic() { Subject = new Subject() { Name = "Fight for EU" }, Topic = new Topic() { Name = "Viktor Orban"} },
                //new SubjectToTopic() { Subject = new Subject() { Name = "Fight for EU" }, Topic = new Topic() { Name = "Salvini"} },
                //new SubjectToTopic() { Subject = new Subject() { Name = "Fight for EU" }, Topic = new Topic() { Name = "Junker"} },
                //new SubjectToTopic() { Subject = new Subject() { Name = "Fight for EU" }, Topic = new Topic() { Name = "Refugees"} },
                //new SubjectToTopic() { Subject = new Subject() { Name = "Fight for EU" }, Topic = new Topic() { Name = "Integration"} },

                //new SubjectToTopic() { Subject = new Subject() { Name = "Environment" }, Topic = new Topic() { Name = "Animal rights"} },
                //new SubjectToTopic() { Subject = new Subject() { Name = "Environment" }, Topic = new Topic() { Name = "GMO"} },
                //new SubjectToTopic() { Subject = new Subject() { Name = "Environment" }, Topic = new Topic() { Name = "5G"} },
                //new SubjectToTopic() { Subject = new Subject() { Name = "Environment" }, Topic = new Topic() { Name = "Wifi"} },

                //new SubjectToTopic() { Subject = new Subject() { Name = "Free Speech" }, Topic = new Topic() { Name = "First Amendment"} },
                //new SubjectToTopic() { Subject = new Subject() { Name = "Free Speech" }, Topic = new Topic() { Name = "Censorship"} },
                //new SubjectToTopic() { Subject = new Subject() { Name = "Free Speech" }, Topic = new Topic() { Name = "Tech fascism"} },
                //new SubjectToTopic() { Subject = new Subject() { Name = "Free Speech" }, Topic = new Topic() { Name = "Big Brother"} },

                ////new SubjectToTopic() { Subject = new Subject() { Name = "Divided States" }, Topic = new Topic() { Name = "Migrants"} },
                ////new SubjectToTopic() { Subject = new Subject() { Name = "Divided States" }, Topic = new Topic() { Name = "Mass immigration"} },
                ////new SubjectToTopic() { Subject = new Subject() { Name = "Divided States" }, Topic = new Topic() { Name = "Islamism"} },
                ////new SubjectToTopic() { Subject = new Subject() { Name = "Divided States" }, Topic = new Topic() { Name = "Brexit" } },
                //new SubjectToTopic() { Subject = new Subject() { Name = "Divided States" }, Topic = new Topic() { Name = "Deep state" } },
                //new SubjectToTopic() { Subject = new Subject() { Name = "Divided States" }, Topic = new Topic() { Name = "Corruption" } },
                //new SubjectToTopic() { Subject = new Subject() { Name = "Divided States" }, Topic = new Topic() { Name = "Money in politics" } },
                //new SubjectToTopic() { Subject = new Subject() { Name = "Divided States" }, Topic = new Topic() { Name = "Donald Trump" } },
                ////new SubjectToTopic() { Subject = new Subject() { Name = "Divided States" }, Topic = new Topic() { Name = "EU" } },
                //new SubjectToTopic() { Subject = new Subject() { Name = "Divided States" }, Topic = new Topic() { Name = "Neo-liberalism" } }
            };

            foreach (var item in subjectToTopics)
            {
                item.SubjectId = subjects.FirstOrDefault(s => s.Name == item.Subject.Name).Id;
                item.TopicId = topics.FirstOrDefault(t => t.Name == item.Topic.Name).Id;
                item.Subject = null;
                item.Topic = null;
            }

            modelBuilder.Entity<SubjectToTopic>().HasData(subjectToTopics.ToArray());

            List<Post> posts = new List<Post>()
            {
                new Post() { IsFeatured = true, HeadLine = "Journalists Detained During First Day of Bilderberg", Url = "" },
                new Post() { IsFeatured = true, HeadLine = "RON PAUL: US/UK Trying To Kill Assange?", Url = "" },
                new Post() { IsFeatured = true, HeadLine = "Merkel Attacks Trump in Harvard Speech", Url = "" },
                new Post() { IsFeatured = true, HeadLine = "Bye-bye Bolton?", Url = "" },
                new Post() { IsFeatured = true, HeadLine = "White House launches tool to report censorship on Facebook", Url = "" },
                new Post() { IsFeatured = true, HeadLine = "Barr: Mueller could have reached a decision on obstruction", Url = "" },
                new Post() { IsFeatured = true, HeadLine = "U.S. Economy Grew 3.1% in First Quarter", Url = "" },
                new Post() { IsFeatured = true, HeadLine = "Donald Trump: 'I Got Me Elected'", Url = "" },
                new Post() { IsFeatured = true, HeadLine = "Test post: put all the content here for the post title 1", Url = "" },
                new Post() { IsFeatured = true, HeadLine = "Test post: put all the content here for the post title 2", Url = "" },
                new Post() { IsFeatured = true, HeadLine = "Test post: put all the content here for the post title 3", Url = "" },
                new Post() { IsFeatured = true, HeadLine = "Test post: put all the content here for the post title 4", Url = "" },
                new Post() { IsFeatured = true, HeadLine = "Test post: put all the content here for the post title 5", Url = "" },
                new Post() { IsFeatured = true, HeadLine = "Test post: put all the content here for the post title 6", Url = "" },
                new Post() { IsFeatured = true, HeadLine = "Test post: put all the content here for the post title 7", Url = "" },
                new Post() { IsFeatured = true, HeadLine = "Test post: put all the content here for the post title 8", Url = "" }
            };

            i = 1;
            posts.ForEach(x => x.Id = i++);
            modelBuilder.Entity<Post>().HasData(posts.ToArray());

            List<ArticleToTopic> postToTopics = new List<ArticleToTopic>()
            {
                new ArticleToTopic() { Article = new Article() { HeadLine = "Journalists Detained During First Day of Bilderberg" }, Topic = new Topic() { Name = "Bilderberg"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "RON PAUL: US/UK Trying To Kill Assange?" }, Topic = new Topic() { Name = "Deep State"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Merkel Attacks Trump in Harvard Speech" }, Topic = new Topic() { Name = "Merkel"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Bye-bye Bolton?" }, Topic = new Topic() { Name = "Neo-Cons"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "White House launches tool to report censorship on Facebook" }, Topic = new Topic() { Name = "Tech Fascism"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "U.S. Economy Grew 3.1% in First Quarter" }, Topic = new Topic() { Name = "Economy"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Donald Trump: 'I Got Me Elected'" }, Topic = new Topic() { Name = "Donald Trump"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Test post: put all the content here for the post title 1" }, Topic = new Topic() { Name = "Viktor Orban"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Test post: put all the content here for the post title 2" }, Topic = new Topic() { Name = "Salvini"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Test post: put all the content here for the post title 3" }, Topic = new Topic() { Name = "Junker"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Test post: put all the content here for the post title 4" }, Topic = new Topic() { Name = "Integration"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Test post: put all the content here for the post title 5" }, Topic = new Topic() { Name = "Deep State"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Test post: put all the content here for the post title 6" }, Topic = new Topic() { Name = "Salvini"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Test post: put all the content here for the post title 7" }, Topic = new Topic() { Name = "Salvini"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Test post: put all the content here for the post title 8" }, Topic = new Topic() { Name = "Salvini"} }
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
                new ArticleToTopic() { Article = new Article() { HeadLine = "Boris Johnson under fire over row with partner as top Tories raise fears" }, Topic = new Topic() { Name = "Bilderberg"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "MPs debate Boris Johnson's deal as People's Vote march sets off – live news" }, Topic = new Topic() { Name = "Deep State"} },
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
                new ArticleToTopic() { Article = new Article() { HeadLine = "Opinion piece 1" }, Topic = new Topic() { Name = "Salvini"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Opinion piece 1" }, Topic = new Topic() { Name = "Deep State"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Opinion piece 2" }, Topic = new Topic() { Name = "Salvini"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Opinion piece 3" }, Topic = new Topic() { Name = "Salvini"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Opinion piece 4" }, Topic = new Topic() { Name = "Salvini"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Opinion piece 5" }, Topic = new Topic() { Name = "Deep State"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Opinion piece 6" }, Topic = new Topic() { Name = "Viktor Orban"} },
                new ArticleToTopic() { Article = new Article() { HeadLine = "Opinion piece 7" }, Topic = new Topic() { Name = "Donald Trump"} },
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
