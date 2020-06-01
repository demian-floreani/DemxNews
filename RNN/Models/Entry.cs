using Microsoft.AspNetCore.Identity;
using RNN.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Paragraph { get; set; }
        public string Img { get; set; }
        public string Body { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int Rank { get; set; }
        public string HeadLine { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
        public int PageViews { get; set; }
        public bool IsPublished { get; set; }
        public int IsPinned { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsFeatured { get; set; }
        public ICollection<EntryToTopic> EntryToTopics { get; set; }
    }
}
