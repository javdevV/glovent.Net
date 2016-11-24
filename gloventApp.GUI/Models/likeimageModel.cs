using gloventApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gloventApp.GUI.Models
{
    public class likeimageModel
    {
        public int id { get; set; }
        public Nullable<int> img_id { get; set; }
        public Nullable<int> participant_idUser { get; set; }
        public virtual image image { get; set; }
        public virtual user user { get; set; }
    }
}