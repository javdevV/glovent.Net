using System;
using System.Collections.Generic;

namespace gloventApp.Data.Models
{
    public partial class thread
    {
        public int threadId { get; set; }
        public byte[] CommentingUser { get; set; }
        public byte[] ParentForum { get; set; }
        public string threadContent { get; set; }
        public string title { get; set; }
    }
}
