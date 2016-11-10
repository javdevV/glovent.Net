using System;
using System.Collections.Generic;

namespace gloventApp.Data.Models
{
    public partial class complaint
    {
        public int id { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public Nullable<int> MyUser_idUser { get; set; }
        public virtual user user { get; set; }
    }
}
