using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gloventApp.Data.Models
{
    public partial class category
    {
        public category()
        {
            this.events = new List<evente>();
        }
        
        public int id { get; set; }
        public string Libelle { get; set; }
        [DataType(DataType.ImageUrl)]
        public string image { get; set; }
        public virtual ICollection<evente> events { get; set; }
    }
}
