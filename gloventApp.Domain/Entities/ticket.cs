using System;
using System.Collections.Generic;

namespace gloventApp.Data.Models
{
    public partial class ticket
    {
        public int id { get; set; }
        public float discount { get; set; }
        public float price { get; set; }
        public Nullable<int> MyEvent_idEvent { get; set; }
        public Nullable<int> MyPatricipant_idUser { get; set; }
        public virtual evente evente { get; set; }
        public virtual user user { get; set; }
    }
}
