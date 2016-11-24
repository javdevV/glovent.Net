using gloventApp.Data.Infrastructure;
using gloventApp.Data.Models;
using gloventApp.ServicePattern;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glovent.App.Services
{
    public class UserService : Service<user>
    {
        static IDatabaseFactory dbFactory = new DatabaseFactory();
        static IUnitOfWork utwk = new UnitOfWork(dbFactory);

        public UserService()
            : base(utwk)
        {
        }
        


        //A Enlever si marche pas
        public IEnumerable<user>Getusername(string user)
        {

            return utwk.getRepository<user>().GetMany(e => e.fName.Contains(user)).ToList();

        }


        public IEnumerable<user> listUsers()
        {


            return utwk.getRepository<user>().GetMany().Where(u=>u.DTYPE.Equals("user"));


        }

       

        





    }


}