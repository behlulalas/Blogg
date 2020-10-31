using TheBlogger.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogger.ViewModel
{
    public class CommentViewModel
    {
        public int PostId { get; set; }
        public int MainCommentId { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }

        List<MainComment> mainComments { get; set; }
        List<SubComment> subComments { get; set; }
    }
}
