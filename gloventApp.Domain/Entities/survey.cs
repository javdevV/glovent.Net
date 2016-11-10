using System;
using System.Collections.Generic;

namespace gloventApp.Data.Models
{
    public partial class survey
    {
        public survey()
        {
            this.questions = new List<question>();
        }

        public int id { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public Nullable<int> MyEvent_idEvent { get; set; }
        public virtual evente evente { get; set; }
        public virtual ICollection<question> questions { get; set; }
    }
}
