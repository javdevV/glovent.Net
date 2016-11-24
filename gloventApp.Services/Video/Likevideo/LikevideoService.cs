using gloventApp.Data.Infrastructure;
using gloventApp.Data.Models;
using gloventApp.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gloventApp.Services.Video.Likevideo
{
    public class LikevideoService : Service<likevideo>
    {

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public LikevideoService()
           : base(ut)
        {
        }
      

             public IEnumerable<likevideo> Getlikebyidvideo(int id)
        {
            return ut.getRepository<likevideo>().GetMany(x => x.video.id == id);
        }
        public void DeleteLike(int id)
        {
            var likeimage = ut.getRepository<likeimage>().GetById(id);
            //id = likeimage.image.id;
            var image = ut.getRepository<image>().GetById(likeimage.image.id);
            image.aime = image.aime - 1;
            ut.getRepository<image>().Update(image);

            ut.getRepository<likeimage>().Delete(likeimage);
            ut.Commit();
        }
    }
}
