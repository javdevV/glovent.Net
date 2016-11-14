using System;
using System.Collections.Generic;

namespace gloventApp.Data.Models
{
    public partial class galerie
    {
        public galerie()
        {
            this.videos = new List<video>();
            this.images = new List<image>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public Nullable<int> event_idEvent { get; set; }
        public virtual evente evente { get; set; }
        public virtual ICollection<video> videos { get; set; }
        public virtual ICollection<image> images { get; set; }
    }
}
