using gloventApp.Data.Infrastructure;
using gloventApp.Data.Models;
using gloventApp.ServicePattern;
using gloventApp.Services.Image;
using gloventApp.Services.Video;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace gloventApp.Services.Galerie
{
    public class GalerieService : Service<galerie>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        

        public GalerieService()
           : base(ut)
            
        {
        }
        public IEnumerable<galerie> GetAllGalerie()
        {
            return ut.getRepository<galerie>().GetMany().ToList();
        }

        public void DeleteGalerie(int id)
        {
            var galerie = GetByIdGalerie(id);

            var imgs= ut.getRepository<image>().GetMany(x => x.galerie_id == id);

            foreach (var gal in imgs) {
              var image= ut.getRepository<image>().GetById(gal.id);
                var like = ut.getRepository<likeimage>().GetMany(x => x.image.id == gal.id);
                foreach(var lik in like)
                {
                    ut.getRepository<likeimage>().Delete(lik);
                    ut.Commit();
                }
                ut.getRepository<image>().Delete(image);
                ut.Commit();
            }
                var vds= ut.getRepository<video>().GetMany(x => x.galerie_id == id);
            foreach (var vd in vds)
            {
                var video = ut.getRepository<video>().GetById(vd.id);
                var likev = ut.getRepository<likevideo>().GetMany(x => x.video.id == vd.id);
                foreach(var likk in likev)
                {
                    ut.getRepository<likevideo>().Delete(likk);
                    ut.Commit();

                }
                ut.getRepository<video>().Delete(video);
                ut.Commit();
            }
            ut.getRepository<galerie>().Delete(galerie);
            ut.Commit();
        }
        public galerie GetByIdGalerie(int id)
        {
            foreach (galerie e in GetAllGalerie())
            {
                if (e.id == id)
                    return e;
            }
            return null;
        }
        public bool BloqueGalerie(int id)
        {
            return false;
        }
        public IEnumerable<image> GetimageByGalerie(int id)
        {

           return ut.getRepository<image>().GetMany(x => x.galerie_id == id);

        }
        public IEnumerable<video> GetvideoByGalerie(int id)
        {
            return ut.getRepository<video>().GetMany(x => x.galerie_id == id);

        }
        public IEnumerable<image> GetimageInvisibleByGalerie(int id)
        {
            // bool vis = true;
        return ut.getRepository<image>().GetMany(x => x.galerie_id == id && x.visib==false);
        }
        public IEnumerable<video> GetvideoInvisibleByGalerie(int id)
        {
            return ut.getRepository<video>().GetMany(x => x.galerie_id == id && x.visib == false);
        }

        public void UpdateVisibilite()
        {
            IEnumerable<galerie> galeries = new List<galerie>();
            galeries = GetAllGalerie();
            foreach (var gal in galeries)
            {
               var  id = gal.id;
                IEnumerable<image> images = new List<image>();
                images = GetimageByGalerie(id);
                foreach (var img in images)
                    if (img.danger >= 10 && img.visib==true)
                {
                        img.visib = false;
                   img.dateinvisibl = System.DateTime.Today;

                        ut.getRepository<image>().Update(img);
                    }
                IEnumerable<video> videos = new List<video>();
                videos = GetvideoByGalerie(id);
                foreach (var vid in videos)
                    if (vid.danger >= 10)
                    {
                        vid.visib = false;
                        ut.getRepository<video>().Update(vid);
                        vid.dateinvisibl = System.DateTime.Today;

                        ut.getRepository<video>().Update(vid);
                    }
            }
            ut.Commit();
        }

        public void DeleteInvisible()
        {
            
            IEnumerable<galerie> galeries = new List<galerie>();
            galeries = GetAllGalerie();
            foreach (var gal in galeries)
            {
                List<image> images = new List<image>();
                images = ut.getRepository<image>().GetMany().ToList();
                foreach (var img in images)
                  

                if ((img.visib == false)&&(img.dateinvisibl.Value.Day <= DateTime.Today.Day - 10))
                    {
                        img.visib = false;
                        ut.getRepository<image>().Delete(img);
                    }
                List<video> videos = new List<video>();
                videos = ut.getRepository<video>().GetMany().ToList();
                foreach (var vid in videos)
                    if ((vid.visib == false) && (vid.dateinvisibl.Value.Day <= DateTime.Today.Day - 10))
                    {
                        vid.visib = false;
                        ut.getRepository<video>().Delete(vid);
                    }
            }
            ut.Commit();
        }
       public IEnumerable<galerie> SearchBynamecategory(string searchincat)
        {

            return ut.getRepository<galerie>().GetMany(x => x.evente.category.Libelle == searchincat).ToList(); 
        }

        public Dictionary<string,int> CountImage()
        {
            var galeries = GetAllGalerie();
            Dictionary<string,int> result = new Dictionary<string, int>();
            foreach (var gal in galeries)
            {
                result.Add(gal.name, gal.images.Count());
            }
            return result;
        }
        public Dictionary<string, int> CountVideo()
        {
            var galeries = GetAllGalerie();
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach (var gal in galeries)
            {
                result.Add(gal.name, gal.videos.Count());
            }
            return result;
        }

        public Dictionary<string, int> CountEvent()
        {
            var galeries = GetAllGalerie();
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach (var gal in galeries)
            {
               var nb = gal.videos.Count() + gal.images.Count();
                var ss = gal.evente.nameEvent;
                result.Add(gal.evente.nameEvent , nb);
                Console.WriteLine(ss + "" + nb);
            }
            return result;
        }

      

        }
    }
