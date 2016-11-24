using gloventApp.Data.Models;
using gloventApp.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gloventApp.Services.User
{
   public interface IUserService: IService<user>
    {

        //void DeleteUser(int id);
        void Edit(int id, bool AccountState);
        user GetUserById(int id);

    }
}
