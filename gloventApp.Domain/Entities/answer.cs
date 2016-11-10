using System;
using System.Collections.Generic;

namespace gloventApp.Data.Models
{
    public partial class answer
    {
        public int id_question { get; set; }
        public int id_user { get; set; }
        public string reply { get; set; }
        public virtual user user { get; set; }
        public virtual question question { get; set; }
    }
}
