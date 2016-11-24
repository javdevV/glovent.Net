using gloventApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gloventApp.GUI.Models
{
    public class likevideoModel
    {
        public int id { get; set; }
        public Nullable<int> userr_idUser { get; set; }
        public Nullable<int> vid_id { get; set; }
        public virtual video video { get; set; }
        public virtual user user { get; set; }
    }
}