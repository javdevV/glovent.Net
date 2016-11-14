using System;
using System.Collections.Generic;

namespace gloventApp.Data.Models
{
    public partial class likevideo
    {
        public int id { get; set; }
        public Nullable<int> userr_idUser { get; set; }
        public Nullable<int> vid_id { get; set; }
        public virtual video video { get; set; }
        public virtual user user { get; set; }
    }
}
