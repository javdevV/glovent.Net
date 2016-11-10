using System;
using System.Collections.Generic;

namespace gloventApp.Data.Models
{
    public partial class choice
    {
        public int id { get; set; }
        public string Description { get; set; }
        public Nullable<int> MyPoll_id { get; set; }
        public virtual poll poll { get; set; }
    }
}
