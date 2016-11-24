using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gloventApp.Data.Models
{
    public partial class video
    {
        public video()
        {
            this.likevideos = new List<likevideo>();
        }

        public int id { get; set; }
        public int aime { get; set; }
        public int danger { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public bool visib { get; set; }
        [DataType(DataType.Date)]
        public DateTime? dateinvisibl { get; set; }
        public Nullable<int> MyPatricipant_idUser { get; set; }
        public Nullable<int> galerie_id { get; set; }
        public virtual galerie galerie { get; set; }
        public virtual ICollection<likevideo> likevideos { get; set; }
        public virtual user user { get; set; }
    }
}
