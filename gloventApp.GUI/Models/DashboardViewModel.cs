using gloventApp.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gloventApp.GUI.Models
{
    public class DashboardViewModel
    {
        public int idEvent { get; set; }
        public bool avaibility { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> dateEvent { get; set; }
        public string localisation { get; set; }
        public string nameEvent { get; set; }

        public IEnumerable<evente> events { get; set; }
        public IEnumerable<evente> events1 { get; set; }
        public IEnumerable<evente> events2 { get; set; }
        public IEnumerable<evente> events3 { get; set; }
        public IEnumerable<evente> events4 { get; set; }
        public evente event1 { get; set; }
        public evente event2 { get; set; }
        public category cat { get; set; }

        public IEnumerable<category> categories { get; set; }
        public IEnumerable<category> categories1 { get; set; }
        public IEnumerable<category> categories2 { get; set; }


    }
}