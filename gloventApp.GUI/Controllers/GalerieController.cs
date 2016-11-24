using gloventApp.Data.Models;
using gloventApp.GUI.Models;
using gloventApp.Services.Galerie;
using gloventApp.Services.Image;
using gloventApp.Services.Video;
using Newtonsoft.Json;
using PagedList;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace gloventApp.GUI.Controllers
{
    public class GalerieController : Controller
    {
        GalerieService gs = null;
        ImageService gi = null;
        VideoService gv = null;
        public GalerieController()
        {
            gs = new GalerieService();
            gi = new ImageService();
            gv = new VideoService();
        }

        // GET: Galerie
        public ActionResult Index(string searching,String serchingevent,String serchingcat)
        {
            var galerie = gs.GetAllGalerie();
            List<galerieModel> ga = new List<galerieModel>();
            foreach (var u in galerie)
            {
                ga.Add(new galerieModel
                {
                    id = u.id,
                    name = u.name,
                    evente = u.evente
                });
                //recherche
                if (!String.IsNullOrEmpty(searching))
                {
                    ga = ga.Where(m => m.name.Contains(searching)).ToList();
                }
                if (!String.IsNullOrEmpty(serchingevent))
                {
                    ga = ga.Where(m => m.evente.nameEvent.Contains(serchingevent)).ToList();
                }
                if (!String.IsNullOrEmpty(serchingcat))
                {
                    ga = ga.Where(m => m.evente.category.Libelle.Contains(serchingcat)).ToList();
                   
                }
                
            }


                return View(ga);
        }

        //pdf rotativ
        //public ActionResult PrintInvoice()
        //{
        //    return new ActionAsPdf(
        //                   "Index")
        //    { FileName = "galerie.pdf" };
        //}





        // GET: Galerie/Details/5
        public ActionResult Details(int id)
        {

            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var galerie = gs.GetByIdGalerie(id);
            galerieModel um = new galerieModel
            {
                id = galerie.id,
                name = galerie.name,
                evente =  galerie.evente
               

            };
            if (galerie == null)
            {
                return HttpNotFound();
            }
            return View(um);
        }

        // GET: Galerie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Galerie/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Galerie/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Galerie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Galerie/Delete/5
        public ActionResult Delete(int id)
        {
            var galerie = gs.GetByIdGalerie(id);
        
            galerieModel um = new galerieModel
            {
                id = galerie.id,
                name = galerie.name
               
            };
            return View(um);
        }

        // POST: Galerie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, galerieModel um)
        {
            try
            {
                
                gs.Delete(gs.GetByIdGalerie(id));
                gs.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Image (int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
           
            var image = gs.GetimageByGalerie(id);

           /* List<imageModel> um = new List<imageModel>();
            foreach (var u in image)
            {
               // var img = new imageModel
               // {
                    id = u.id,
                    name = u.name,
                    aime = u.aime,
                    danger = u.danger,
                    visib = u.visib,
                    dateinvisibl = u.dateinvisibl
                   

              //  };
               um.Add(img);*/
            //}
            if (image == null)
            {
                return HttpNotFound();
            }
            ViewBag.images = image;
            return View();
        }

       public ActionResult Video(int id)
        {

            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var videos = gs.GetvideoByGalerie(id);
            List<videoModel> um = new List<videoModel>();
            
            
            foreach(var v in videos)
            {
                um.Add(new videoModel
                {
                    id = v.id,
                    name = v.name,
                    aime = v.aime,
                    danger = v.danger,
                    visib = v.visib,
                    url = v.url

                });
            }
            
            if (videos == null)
            {
                return HttpNotFound();
            }
            return View(um);
        }
        public ActionResult DetailsImage (int id)
        {
            
           // ImageController ImageController = new ImageController();
            return RedirectToAction("Details", "Image", new { id = id });
           
        }
        
             public ActionResult DetailsVideo(int id)
        {
            return RedirectToAction("Details", "Video", new { id = id });
           
        }
      public ActionResult UpdateVisibilite()
        {
            gs.UpdateVisibilite();
            return RedirectToAction("Index");

        }

        public ActionResult DeleteInvisible()
        {
            gs.DeleteInvisible();
            
            return RedirectToAction("Index");

        }
        public ActionResult DeleteImage(int id)
        {
            return RedirectToAction("Delete", "Image", new { id = id });
        }
        public ActionResult DeleteVideo(int id)
        {
            return RedirectToAction("Delete", "Video", new { id = id });
        }
        public ActionResult ImageInvisible(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var images = gs.GetimageInvisibleByGalerie(id);
            List<imageModel> um = new List<imageModel>();


            foreach (var v in images)
            {
                um.Add(new imageModel
                {
                    id = v.id,
                    name = v.name,
                    aime = v.aime,
                    danger = v.danger,
                    visib = v.visib,
                    dateinvisibl = v.dateinvisibl

                });
            }

            if (images == null)
            {
                return HttpNotFound();
            }
            return View(um);

        }
        public ActionResult VideoInvisible(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var videos = gs.GetvideoInvisibleByGalerie(id);
            List<videoModel> um = new List<videoModel>();


            foreach (var v in videos)
            {
                um.Add(new videoModel
                {
                    id = v.id,
                    name = v.name,
                    aime = v.aime,
                    danger = v.danger,
                    visib = v.visib,
                    url = v.url,
                    dateinvisibl = v.dateinvisibl

                });
            }

            if (videos == null)
            {
                return HttpNotFound();
            }
            return View(um);
        }
        public ActionResult Visible(int id)
        {
            gi.VisibleImage(id);
            gi.Commit();
            //var img = gi.GetByIdImage(id);
          //  var id1 = img.galerie_id;
            return RedirectToAction("Index");
        }
        public ActionResult Invisible(int id)
        {
            gi.InvisibleImage(id);
            gi.Commit();
            // var img = gi.GetByIdImage(id);
            //var id1 = img.galerie_id;
            gi.Commit();
            return RedirectToAction("Index");

        }
        public ActionResult Visiblevid(int id)
        {
            gv.VisibleVideo(id);
            gv.Commit();
            //var img = gv.GetByIdVideo(id);
            // var id1 = img.galerie_id;
            return RedirectToAction("Index");
        }
        public ActionResult Invisiblevid(int id)
        {
            gv.InvisibleVideo(id);
           gv.Commit();
            //var img = gv.GetByIdVideo(id);
            //var id1 = img.galerie_id;
            return RedirectToAction("Index");

        }


        public ActionResult Index1(int? page)

        {
            var galerie = gs.GetAllGalerie();
            List<galerieModel> fVM = new List<galerieModel>();
            foreach (var item in galerie)
            {
                fVM.Add(
                    new galerieModel
                    {
                        id = item.id,
                        name = item.name,
                        evente = item.evente

                    });
            }
            return View(fVM.ToPagedList(pageNumber: page ?? 1,
    pageSize: 3));
        }


        public ActionResult Stat()
        {


           ViewBag.res = gs.CountImage();
            ViewBag.res1 = gs.CountVideo();

            return View();

        }
        public ActionResult Stat1()
        {
            ArrayList Header = new ArrayList { "Type", "Reunion" };
            Dictionary<string, int> zzzz = gs.CountEvent();
            ArrayList data = new ArrayList { Header };
            foreach (var s in zzzz)
            {
                ArrayList d = new ArrayList { s.Key, s.Value };
                data.Add(d);
            }

            //convert it in json
            string datastr = JsonConvert.SerializeObject(data, Formatting.None);
            //sort in viwdata/viewbag

            ViewBag.Data = new HtmlString(datastr);

            return View();
        }
        
    }
}
