using gloventApp.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gloventApp.Data.Infrastructure;
using gloventApp.Data.Models;

namespace gloventApp.Services.Userss
{
    public class UserService : Service<user>, IUserService
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork utwk = new UnitOfWork(factory);
        public UserService() : base(utwk)
        {


        }
        public void updateForOrganizatio(user u , int idorg)
        {
            user i = utwk.getRepository<user>().GetById(u.Id);
            i.MyOrganization_id = idorg;
            utwk.getRepository<user>().Update(i);
            utwk.Commit();
        }
    }
}
