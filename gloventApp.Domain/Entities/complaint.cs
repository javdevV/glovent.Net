using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gloventApp.Data.Models
{
    public partial class complaint
    {
        public int id { get; set; }
        public string Description { get; set; }

        public string Subject { get; set; }
        public Nullable<int> MyUser_idUser { get; set; }
        public virtual user user { get; set; }
        public string importanceLvl { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime creationDate { get; set; }

        private bool mygere = false;
        public bool gere
        {
            get { return mygere; }
            set { mygere = value; }
        }

        public override string ToString()
        {
            return " id : " + id + "desc:  " + Description + " date : " + creationDate + "user : " + MyUser_idUser;
        }
    }
}
