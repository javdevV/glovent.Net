using System;
using System.Collections.Generic;

namespace gloventApp.Data.Models
{
    public partial class forum
    {
        public string name { get; set; }
        public string description { get; set; }
        public byte[] initiator { get; set; }
        public byte[] threads { get; set; }
    }
}
