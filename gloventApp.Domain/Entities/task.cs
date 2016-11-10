using System;
using System.Collections.Generic;

namespace gloventApp.Data.Models
{
    public partial class task
    {
        public int id { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public Nullable<int> MyEvent_idEvent { get; set; }
        public Nullable<int> MyOrganizer_idUser { get; set; }
        public virtual evente evente { get; set; }
        public virtual user user { get; set; }
    }
}
