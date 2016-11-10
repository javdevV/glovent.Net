using System;
using System.Collections.Generic;

namespace gloventApp.Data.Models
{
    public partial class organization
    {
        public organization()
        {
            this.events = new List<evente>();
            this.users = new List<user>();
            this.users1 = new List<user>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public virtual ICollection<evente> events { get; set; }
        public virtual ICollection<user> users { get; set; }
        public virtual ICollection<user> users1 { get; set; }
    }
}
