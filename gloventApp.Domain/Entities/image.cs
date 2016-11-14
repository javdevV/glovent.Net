using System;
using System.Collections.Generic;

namespace gloventApp.Data.Models
{
    public partial class image
    {
        public image()
        {
            this.likeimages = new List<likeimage>();
        }

        public int id { get; set; }
        public int aime { get; set; }
        public int danger { get; set; }
        public byte[] image1 { get; set; }
        public string name { get; set; }
        public Nullable<int> MyPatricipant_idUser { get; set; }
        public Nullable<int> galerie_id { get; set; }
        public virtual galerie galerie { get; set; }
        public virtual user user { get; set; }
        public virtual ICollection<likeimage> likeimages { get; set; }
    }
}
