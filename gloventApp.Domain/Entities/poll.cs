using System;
using System.Collections.Generic;

namespace gloventApp.Data.Models
{
    public partial class poll
    {
        public poll()
        {
            this.choices = new List<choice>();
        }

        public int id { get; set; }
        public string Subject { get; set; }
        public Nullable<int> MyPresident_idUser { get; set; }
        public virtual ICollection<choice> choices { get; set; }
        public virtual user user { get; set; }
    }
}
