using System;
using System.Collections.Generic;

namespace gloventApp.Data.Models
{
    public partial class question
    {
        public question()
        {
            this.answers = new List<answer>();
        }

        public int id { get; set; }
        public string statement { get; set; }
        public Nullable<int> survey_id { get; set; }
        public virtual ICollection<answer> answers { get; set; }
        public virtual survey survey { get; set; }
    }
}
