using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Data.Conventions
{
    public class DateTime2Convention:Convention
    {//quelque soit prop de type dateTime 
        public DateTime2Convention()
        {
            this.Properties<DateTime>().
                Configure(d => d.HasColumnType("datetime2"));
        }
    }
}
