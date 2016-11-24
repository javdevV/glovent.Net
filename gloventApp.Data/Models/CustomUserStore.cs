using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using gloventApp.Data.Models;

namespace gloventApp.Data
{
    public class CustomUserStore : UserStore<user, CustomRole, int,
    CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(gloventdbContext context)
            : base(context)
        {

           
        }
    }
}