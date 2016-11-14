using System;
using System.Collections.Generic;

namespace gloventApp.Data.Models
{
    public partial class likeimage
    {
        public int id { get; set; }
        public Nullable<int> img_id { get; set; }
        public Nullable<int> participant_idUser { get; set; }
        public virtual image image { get; set; }
        public virtual user user { get; set; }
    }
}
