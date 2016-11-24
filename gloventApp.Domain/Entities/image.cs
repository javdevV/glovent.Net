using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [DataType(DataType.ImageUrl)]
        public string image1 { get; set; }
        public string name { get; set; }
        public bool visib { get; set; }
        [DataType(DataType.Date)]
        public DateTime? dateinvisibl { get; set; }
        public Nullable<int> MyPatricipant_idUser { get; set; }
        public Nullable<int> galerie_id { get; set; }
        public virtual galerie galerie { get; set; }
        public virtual user user { get; set; }
        public virtual ICollection<likeimage> likeimages { get; set; }
    }
}
