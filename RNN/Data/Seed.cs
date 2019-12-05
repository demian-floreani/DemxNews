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
                new Title() { Id = 4, Name = "UK Politics" },
                new Title() { Id = 5, Name = "US News" },
                new Title() { Id = 6, Name = "US Politics" },
                new Title() { Id = 7, Name = "EU News" },
                new Title() { Id = 8, Name = "EU Entry" },
                new Title() { Id = 9, Name = "Italian News" },
                new Title() { Id = 10, Name = "Italian Politics" }
            };

            modelBuilder.Entity<Title>().HasData(titles.ToArray());

            List<Author> authors = new List<Author>();
            authors.Add(new Author() { Id = 1, Name = "Author1" });

            modelBuilder.Entity<Author>().HasData(authors.ToArray());

            List<Grouping> subjects = new List<Grouping>()
            {
                new Grouping() { Name = "", Type = "Headlines", Rank = 1 },
                //new Grouping() { Name = "EU Migrant Crisis", Type = "In Focus", Rank = 2 }
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

            //List<Post> posts = new List<Post>()
            //{
            //    new Post() { GroupingId = 1, HeadLine = "Test post: put all the content here for the post title 1", Url = "" },
            //    new Post() { GroupingId = 1, HeadLine = "Test post: put all the content here for the post title 2", Url = "" },
            //    new Post() { GroupingId = 1, HeadLine = "Test post: put all the content here for the post title 3", Url = "" },
            //    new Post() { GroupingId = 1, HeadLine = "Test post: put all the content here for the post title 4", Url = "" },
            //    new Post() { GroupingId = 1, HeadLine = "Test post: put all the content here for the post title 5", Url = "" },
            //    new Post() { GroupingId = 1, HeadLine = "Test post: put all the content here for the post title 6", Url = "" },
            //    new Post() { GroupingId = 1, HeadLine = "Test post: put all the content here for the post title 7", Url = "" },
            //    new Post() { GroupingId = 1, HeadLine = "Test post: put all the content here for the post title 8", Url = "" },
            //    new Post() { GroupingId = 1, HeadLine = "Test post: put all the content here for the post title 9", Url = "" },
            //    new Post() { GroupingId = 1, HeadLine = "Test post: put all the content here for the post title 10", Url = "" },
            //    new Post() { GroupingId = 1, HeadLine = "Test post: put all the content here for the post title 11", Url = "" }
            //};

            //i = 1;
            //posts.ForEach(x => x.Id = i++);
            //modelBuilder.Entity<Post>().HasData(posts.ToArray());

            //List<EntryToTopic> postToTopics = new List<EntryToTopic>()
            //{
            //    new EntryToTopic() { Entry = new Entry() { HeadLine = "Test post: put all the content here for the post title 1" }, Topic = new Topic() { Name = "Topic 1"} },
            //    new EntryToTopic() { Entry = new Entry() { HeadLine = "Test post: put all the content here for the post title 2" }, Topic = new Topic() { Name = "Topic 2"} },
            //    new EntryToTopic() { Entry = new Entry() { HeadLine = "Test post: put all the content here for the post title 3" }, Topic = new Topic() { Name = "Topic 3"} },
            //    new EntryToTopic() { Entry = new Entry() { HeadLine = "Test post: put all the content here for the post title 4" }, Topic = new Topic() { Name = "Topic 4"} },
            //    new EntryToTopic() { Entry = new Entry() { HeadLine = "Test post: put all the content here for the post title 5" }, Topic = new Topic() { Name = "Topic 5"} },
            //    new EntryToTopic() { Entry = new Entry() { HeadLine = "Test post: put all the content here for the post title 6" }, Topic = new Topic() { Name = "Topic 6"} },
            //    new EntryToTopic() { Entry = new Entry() { HeadLine = "Test post: put all the content here for the post title 7" }, Topic = new Topic() { Name = "Topic 7"} },
            //    new EntryToTopic() { Entry = new Entry() { HeadLine = "Test post: put all the content here for the post title 8" }, Topic = new Topic() { Name = "Topic 1"} },
            //    new EntryToTopic() { Entry = new Entry() { HeadLine = "Test post: put all the content here for the post title 9" }, Topic = new Topic() { Name = "Topic 2"} },
            //    new EntryToTopic() { Entry = new Entry() { HeadLine = "Test post: put all the content here for the post title 10" }, Topic = new Topic() { Name = "Topic 3"} },
            //    new EntryToTopic() { Entry = new Entry() { HeadLine = "Test post: put all the content here for the post title 11" }, Topic = new Topic() { Name = "Topic 4"} }

            //};

            //foreach (var item in postToTopics)
            //{
            //    item.EntryId = posts.FirstOrDefault(p => p.HeadLine == item.Entry.HeadLine).Id;
            //    item.TopicId = topics.FirstOrDefault(t => t.Name == item.Topic.Name).Id;
            //    item.Entry = null;
            //    item.Topic = null;
            //}

            //modelBuilder.Entity<EntryToTopic>().HasData(postToTopics.ToArray());

            //List<Entry> Entrys = new List<Entry>()
            //{
            //    new Entry()
            //    {
            //        AuthorId = 1,
            //        TitleId = 1,
            //        Url = "",
            //        Img = "Entry.jpg",
            //        Paragraph = "Leadership campaign falters as he refuses to respond to questions at hustings about late-night argument with Carrie Symonds",
            //        Body = "",
            //        HeadLine = "Boris Johnson under fire over row with partner as top Tories raise fears",
            //        GroupingId = 1,
            //        Rank = 1
            //    },
            //    new Entry()
            //    {
            //        AuthorId = 1,
            //        TitleId = 2,
            //        Img = "nature.jpg",
            //        HeadLine = "Entry piece 1",
            //        Paragraph = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",
            //        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            //        GroupingId = 1,
            //        Rank = 2
            //    },
            //    new Entry()
            //    {
            //        AuthorId = 1,
            //        TitleId = 2,
            //        Img = "nature.jpg",
            //        HeadLine = "Entry piece 2",
            //        Paragraph = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",
            //        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            //        GroupingId = 1,
            //        Rank = 3
            //    },
            //    new Entry()
            //    {
            //        AuthorId = 1,
            //        TitleId = 2,
            //        Img = "nature.jpg",
            //        HeadLine = "Entry piece 3",
            //        Paragraph = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",
            //        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            //        GroupingId = 1,
            //        Rank = 4
            //    },
            //    new Entry()
            //    {
            //        AuthorId = 1,
            //        TitleId = 5,
            //        Img = "nature.jpg",
            //        HeadLine = "Entry piece 4",
            //        Paragraph = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",
            //        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            //        GroupingId = 1,
            //        Rank = 5
            //    },
            //    new Entry()
            //    {
            //        AuthorId = 1,
            //        TitleId = 6,
            //        Img = "nature.jpg",
            //        HeadLine = "Entry piece 5",
            //        Paragraph = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",
            //        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            //        GroupingId = 1,
            //        Rank = 6
            //    },
            //    new Entry()
            //    {
            //        AuthorId = 1,
            //        TitleId = 4,
            //        Img = "nature.jpg",
            //        HeadLine = "Entry piece 6",
            //        Paragraph = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",
            //        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            //        GroupingId = 1,
            //        Rank = 7
            //    },
            //    new Entry()
            //    {
            //        AuthorId = 1,
            //        TitleId = 2,
            //        Img = "nature.jpg",
            //        HeadLine = "Entry piece 7",
            //        Paragraph = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",
            //        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            //        GroupingId = 2,
            //        Rank = 1
            //    },
            //    new Entry()
            //    {
            //        AuthorId = 1,
            //        TitleId = 9,
            //        Img = "viking.jpg",
            //        HeadLine = "Over 350 migrants on NGO ship Ocean Viking after new rescue in Mediterranean",
            //        Paragraph = "",
            //        Body = "",
            //        GroupingId = 2,
            //        Rank = 2
            //    },
            //    new Entry()
            //    {
            //        AuthorId = 1,
            //        TitleId = 1,
            //        Url = "",
            //        Img = "Entry.jpg",
            //        Paragraph = "Leadership campaign falters as he refuses to respond to questions at hustings about late-night argument with Carrie Symonds",
            //        Body = "",
            //        HeadLine = "MPs debate Boris Johnson's deal as People's Vote march sets off – live Entry",
            //        GroupingId = 2,
            //        Rank = 2
            //    },
            //};

            //Entrys.ForEach(x => x.Id = i++);
            //modelBuilder.Entity<Entry>().HasData(Entrys.ToArray());

            //List<EntryToTopic> EntryToTopics = new List<EntryToTopic>()
            //{
            //    new EntryToTopic() { Entry = new Entry() { HeadLine = "Boris Johnson under fire over row with partner as top Tories raise fears" }, Topic = new Topic() { Name = "Topic 1"} },
            //    new EntryToTopic() { Entry = new Entry() { HeadLine = "MPs debate Boris Johnson's deal as People's Vote march sets off – live Entry" }, Topic = new Topic() { Name = "Topic 2"} },
            //    new EntryToTopic() { Entry = new Entry() { HeadLine = "Entry piece 1" }, Topic = new Topic() { Name = "Topic 1"} },
            //    new EntryToTopic() { Entry = new Entry() { HeadLine = "Entry piece 1" }, Topic = new Topic() { Name = "Topic 2"} },
            //    new EntryToTopic() { Entry = new Entry() { HeadLine = "Entry piece 2" }, Topic = new Topic() { Name = "Topic 3"} },
            //    new EntryToTopic() { Entry = new Entry() { HeadLine = "Entry piece 3" }, Topic = new Topic() { Name = "Topic 4"} },
            //    new EntryToTopic() { Entry = new Entry() { HeadLine = "Entry piece 4" }, Topic = new Topic() { Name = "Topic 5"} },
            //    new EntryToTopic() { Entry = new Entry() { HeadLine = "Entry piece 5" }, Topic = new Topic() { Name = "Topic 6"} },
            //    new EntryToTopic() { Entry = new Entry() { HeadLine = "Entry piece 6" }, Topic = new Topic() { Name = "Topic 7"} },
            //    new EntryToTopic() { Entry = new Entry() { HeadLine = "Entry piece 7" }, Topic = new Topic() { Name = "Topic 1"} },
            //    new EntryToTopic() { Entry = new Entry() { HeadLine = "Over 350 migrants on NGO ship Ocean Viking after new rescue in Mediterranean" }, Topic = new Topic() { Name = "Topic 1"} }
            //};

            //foreach (var item in EntryToTopics)
            //{
            //    item.EntryId = Entrys.FirstOrDefault(p => p.HeadLine == item.Entry.HeadLine).Id;
            //    item.TopicId = topics.FirstOrDefault(t => t.Name == item.Topic.Name).Id;
            //    item.Entry = null;
            //    item.Topic = null;
            //}

            //modelBuilder.Entity<EntryToTopic>().HasData(EntryToTopics.ToArray());
        }
    }
}
