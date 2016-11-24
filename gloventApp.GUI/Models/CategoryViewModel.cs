using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gloventApp.GUI.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string libelle { get; set; }
        [DataType(DataType.ImageUrl)]
        public string image { get; set; }

    }
}