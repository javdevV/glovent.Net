using System;
using System.Collections.Generic;

namespace gloventApp.Data.Models
{
    public partial class field
    {
        public int id { get; set; }
        public string label { get; set; }
        public string type { get; set; }
        public Nullable<int> MyRF_id { get; set; }
        public string category { get; set; }
        public virtual registrationform registrationform { get; set; }
    }
}
