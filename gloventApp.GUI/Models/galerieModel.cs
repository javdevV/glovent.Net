using gloventApp.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gloventApp.GUI.Models
{
    public class galerieModel
    {
       
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<int> event_idEvent { get; set; }
        public virtual evente evente { get; set; }
        public virtual IEnumerable<video> videos { get; set; }
        public virtual IEnumerable<image> images { get; set; }
    }
}