using gloventApp.Data.Infrastructure;
using gloventApp.Data.Models;
using gloventApp.ServicePattern;
using System.Collections.Generic;
using System.Linq;

namespace gloventApp.Services.Image
{
    public class ImageService : Service<image>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public ImageService()
           : base(ut)
        {
        }
        public IEnumerable<image> GetAllImage()
        {
            return ut.getRepository<image>().GetMany().ToList();
        }
        public void DeleteImage(int id)
        {
            var image = GetByIdImage(id);
           var like = ut.getRepository<likeimage>().GetMany(x => x.image.id == id).ToList();
            foreach(var lik in like)
            {
               var likeimage = ut.getRepository<likeimage>().GetById(lik.id);
                ut.getRepository<likeimage>().Delete(likeimage);
            }
            ut.getRepository<image>().Delete(image);
            ut.Commit();
        }
        public image GetByIdImage(int id)
        {
            foreach (image e in GetAllImage())
            {
                if (e.id == id)
                    return e;
            }
            return null;
        }
        public void InvisibleImage(int id)
        {
            var image = GetByIdImage(id);
            image.visib = false;
            image.dateinvisibl = System.DateTime.Today;
            ut.getRepository<image>().Update(image);

            ut.Commit();

        }
        public void VisibleImage(int id)
        {
            var image = GetByIdImage(id);
            image.visib = true;
            image.dateinvisibl = null;
            ut.getRepository<image>().Update(image);
            ut.Commit();
        }
        public void Updateallsign(int id)
        {
            IEnumerable<image> images = new List<image>();
            images = ut.getRepository<image>().GetMany(x => x.galerie_id >= id);
            foreach (var imag in images)
            {
                if (imag.danger >= 10)
                {
                    imag.visib = false;
                }
                ut.getRepository<image>().Update(imag);
            }
            ut.Commit();
        }


        public Dictionary<string, int> Countaime(int id)
        {
            var image = GetByIdImage(id);
            Dictionary<string , int> result = new Dictionary<string, int>();
            
                result.Add(image.name, image.aime);
            
            return result;
        }

        public Dictionary<string, int> Countsigna(int id)
        {
            var image = GetByIdImage(id);
            Dictionary<string, int> result = new Dictionary<string, int>();
            
                result.Add(image.name, image.danger);
           
            return result;
        }

    }
}
