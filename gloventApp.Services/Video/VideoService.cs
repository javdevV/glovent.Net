using gloventApp.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gloventApp.Data.Infrastructure;
using gloventApp.Data.Models;

namespace gloventApp.Services.Video
{
    public class VideoService : Service<video>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public VideoService()
           : base(ut)
        {
        }
        public IEnumerable<video> GetAllVideo()
        {
            return ut.getRepository<video>().GetMany().ToList();
        }
        public void DeleteVideo(int id)
        {
            var video = GetByIdVideo(id);
            var like = ut.getRepository<likevideo>().GetMany(x => x.video.id == id).ToList();
            foreach (var lik in like)
            {
                var likevideo = ut.getRepository<likevideo>().GetById(lik.id);
                ut.getRepository<likevideo>().Delete(likevideo);
            }
            ut.getRepository<video>().Delete(video);
            ut.Commit();
        }
        public video GetByIdVideo(int id)
        {
            foreach (video e in GetAllVideo())
            {
                if (e.id == id)
                    return e;
            }
            return null;
        }
        public void InvisibleVideo(int id)
        {
            var video = GetByIdVideo(id);
            video.visib = false;
            video.dateinvisibl = System.DateTime.Today;
            ut.getRepository<video>().Update(video);

            ut.Commit();

        }
        public void VisibleVideo(int id)
        {
            var video = GetByIdVideo(id);
            video.visib = true;
            video.dateinvisibl = null;
            ut.getRepository<video>().Update(video);
            ut.Commit();
        }

    }
}
