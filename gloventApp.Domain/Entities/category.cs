using System;
using System.Collections.Generic;

namespace gloventApp.Data.Models
{
    public partial class category
    {
        public category()
        {
            this.events = new List<evente>();
        }

        public int id { get; set; }
        public string Libelle { get; set; }
        public virtual ICollection<evente> events { get; set; }
    }
}
