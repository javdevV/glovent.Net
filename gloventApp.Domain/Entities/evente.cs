using System;
using System.Collections.Generic;

namespace gloventApp.Data.Models
{
    public class evente
    {

        public evente()
        {
            this.tasks = new List<task>();
            this.tickets = new List<ticket>();
            this.surveys = new List<survey>();
            this.users = new List<user>();
        }

        public int idEvent { get; set; }
        public bool avaibility { get; set; }
        public Nullable<System.DateTime> dateEvent { get; set; }
        public string localisation { get; set; }
        public string nameEvent { get; set; }
        public string theme { get; set; }
        public Nullable<int> MyCategory_id { get; set; }
        public Nullable<int> MyOrganization_id { get; set; }
        public Nullable<int> MyRegistrationForm_id { get; set; }
        public virtual category category { get; set; }
        public virtual ICollection<task> tasks { get; set; }
        public virtual registrationform registrationform { get; set; }
        public virtual ICollection<ticket> tickets { get; set; }
        public virtual ICollection<survey> surveys { get; set; }
        public virtual organization organization { get; set; }
        public virtual ICollection<user> users { get; set; }
    }
}
