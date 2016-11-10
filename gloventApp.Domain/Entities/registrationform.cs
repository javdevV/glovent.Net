using System;
using System.Collections.Generic;

namespace gloventApp.Data.Models
{
    public partial class registrationform
    {
        public registrationform()
        {
            this.events = new List<evente>();
            this.fields = new List<field>();
        }

        public int id { get; set; }
        public string title { get; set; }
        public virtual ICollection<evente> events { get; set; }
        public virtual ICollection<field> fields { get; set; }
    }
}
