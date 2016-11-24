using gloventApp.Data.Models;
using gloventApp.Domain.Entities;
using gloventApp.GUI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gloventApp.GUI.Models
{
    public class ComplaintViewModel
    {
        public int id { get; set; }
        public string Description { get; set; }

        public string Subject { get; set; }
        public Nullable<int> MyUser_idUser { get; set; }
        public virtual user user { get; set; }
        public string importanceLvl { get; set; }
       
        //Enum.GetValues(typeof(importanceType)).geToString()
        //EnumHelper<importanceType>.GetDisplayValue(importanceType.Low);
        [DataType(DataType.DateTime)]
        public DateTime creationDate { get; set; }


        public IEnumerable<SelectListItem> subjectLst { get; set; }
    }
}