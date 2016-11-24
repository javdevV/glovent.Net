using gloventApp.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace gloventApp.GUI.Models
{
    public partial class EventViewModel
    {
        public EventViewModel()
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
        public Nullable<int> MyOrganization_id { get; set; }
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

        public IEnumerable<SelectListItem> categories { get; set; }










    }
}
