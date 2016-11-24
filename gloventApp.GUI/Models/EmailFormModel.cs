using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gloventApp.GUI.Models
{
    public class EmailFormModel
    {
        [Required, Display(Name = "Name")]
        public string FromName { get; set; }

        [Required, Display(Name = "Email"), EmailAddress]
        public string FromEmail { get; set; }

        [Required, Display(Name = "Receiver email"), EmailAddress]
        public string ToEmail { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
