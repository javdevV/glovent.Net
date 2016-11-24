using gloventApp.Data.Infrastructure;
using gloventApp.Data.Models;
using gloventApp.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gloventApp.Services.Image.LikeImage
{
   public  class LikeimageService : Service<likeimage>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public LikeimageService()
           : base(ut)
        {
        }


       public  IEnumerable<likeimage> Getlikebyidimage(int id)
        {
            return ut.getRepository<likeimage>().GetMany(x => x.image.id == id);
        }


    }
}
