using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gloventApp.Data.Models
{
    public partial class evente
    {
        public evente()
        {
            this.tasks = new List<task>();
            this.tickets = new List<ticket>();
            this.tickets1 = new List<ticket>();
            this.surveys = new List<survey>();
            this.galeries = new List<galerie>();
            this.users = new List<user>();
        }

        public int idEvent { get; set; }
        public bool avaibility { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> dateEvent { get; set; }
        public string localisation { get; set; }
        public string nameEvent { get; set; }
       
        public string theme { get; set; }
        public Nullable<int> MyCategory_id { get; set; }

        public Nullable<int> Myo { get; set; }
        public Nullable<int> MyRegistrationForm_id { get; set; }
        public int nombreParticipant { get; set; }
        public bool type { get; set; }
        public virtual category category { get; set; }
        public virtual ICollection<task> tasks { get; set; }
        public virtual ICollection<ticket> tickets { get; set; }
        public virtual registrationform registrationform { get; set; }
        public virtual ICollection<ticket> tickets1 { get; set; }
        public virtual ICollection<survey> surveys { get; set; }
        public virtual ICollection<galerie> galeries { get; set; }
        public virtual organization organization { get; set; }
        public virtual ICollection<user> users { get; set; }
        public double longi { get; set; }
        public double lapti { get; set; }
       









        public int calculateNumberParticiapant()
        {
            int number = 0;
            foreach (user u in users)
            {
                number += 1;
            }
            this.nombreParticipant = number;
            return number;
        }




    }
}
