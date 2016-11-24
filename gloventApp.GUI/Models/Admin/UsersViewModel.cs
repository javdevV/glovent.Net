using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gloventApp.GUI.Models.Admin
{
    public class UsersViewModel
    {
        public int id { get; set; }
        [Display(Name = "Type")]
        public string DTYPE { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Login")]
        public string fName { get; set; }
        [Display(Name = "Age")]
        public int age { get; set; }
        [Display(Name = "Account State")]
        public string AccountState { get; set; }
    }
}