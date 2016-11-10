using System;
using System.Collections.Generic;

namespace gloventApp.Data.Models
{
    public partial class user
    {
        public user()
        {
            this.answers = new List<answer>();
            this.complaints = new List<complaint>();
            this.polls = new List<poll>();
            this.tasks = new List<task>();
            this.tickets = new List<ticket>();
            this.events = new List<evente>();
            this.organizations = new List<organization>();
        }

        public string DTYPE { get; set; }
        public int idUser { get; set; }
        public bool AccountState { get; set; }
        public string adress { get; set; }
        public int age { get; set; }
        public string email { get; set; }
        public string fName { get; set; }
        public string image { get; set; }
        public string lName { get; set; }
        public string login { get; set; }
        public string pwd { get; set; }
        public Nullable<int> attachement_file { get; set; }
        public Nullable<int> MyOrganization_id { get; set; }
        public virtual ICollection<answer> answers { get; set; }
        public virtual ICollection<complaint> complaints { get; set; }
        public virtual organization organization { get; set; }
        public virtual ICollection<poll> polls { get; set; }
        public virtual ICollection<task> tasks { get; set; }
        public virtual ICollection<ticket> tickets { get; set; }
        public virtual ICollection<evente> events { get; set; }
        public virtual ICollection<organization> organizations { get; set; }
    }
}
