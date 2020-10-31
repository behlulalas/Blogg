using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogger.Models.Comments
{
    public class MainComment : Comment
    {
        public List<SubComment> subComments { get; set; }
    }
}
