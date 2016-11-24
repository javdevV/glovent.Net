using gloventApp.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace gloventApp.GUI.Models
{
    public partial class OrganizationViewModel
    {
        public OrganizationViewModel()
        {
            this.events = new List<evente>();
            this.users = new List<user>();
            this.users1 = new List<user>();
        }
        [Key]
        public int id { get; set; }

        public string name { get; set; }
        public string type { get; set; }
        public virtual ICollection<evente> events { get; set; }
        public ICollection<user> users { get; set; }//users => PRESIDENT
        public virtual ICollection<user> users1 { get; set; }// liste des organizateurs !!

        public string Location { get; set; }

        public int PresidentID { get; set; }
        public user President { get; set; }

        public IEnumerable<SelectListItem> Presidents { get; set; }


    }
}
