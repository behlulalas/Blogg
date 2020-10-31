using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using TheBlogger.Models.Comments;

namespace TheBlogger.Models
{
    public class Post
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public List<MainComment> MainComments { get; set; }
        public IdentityUser user { get; set; }
        public int PostState { get; set; } = 0;
    }
}
