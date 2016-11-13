using System;
using System.Collections.Generic;

namespace gloventApp.Data.Models
{
    public partial class thread
    {
        public int threadId { get; set; }
        public string threadContent { get; set; }
        public string title { get; set; }
        public Nullable<int> CommentingUser_idUser { get; set; }
        public string ParentForum_name { get; set; }
        public virtual forum forum { get; set; }
        public virtual user user { get; set; }
    }
}
