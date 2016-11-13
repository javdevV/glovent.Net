using System;
using System.Collections.Generic;

namespace gloventApp.Data.Models
{
    public partial class forum
    {
        public forum()
        {
            this.threads1 = new List<thread>();
        }

        public string name { get; set; }
        public string description { get; set; }
        public byte[] threads { get; set; }
        public Nullable<int> initiator_idUser { get; set; }
        public virtual ICollection<thread> threads1 { get; set; }
        public virtual user user { get; set; }
    }
}
