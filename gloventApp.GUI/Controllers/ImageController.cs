using gloventApp.GUI.Models;
using gloventApp.Services.Image;
using gloventApp.Services.Image.LikeImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace gloventApp.GUI.Controllers
{
    public class ImageController : Controller
    {
        ImageService gs = null;
        LikeimageService gl = null;
        public ImageController()
        {
            gs = new ImageService();
            gl = new LikeimageService();
        }
        // GET: Image
        public ActionResult Index()
        {
            return View();
        }

        // GET: Image/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var image = gs.GetByIdImage(id);
            imageModel um = new imageModel
            {
                id = image.id,
                image1 = image.image1,
                name = image.name,
                aime = image.aime,
                danger = image.danger,
                user = image.user,
                visib = image.visib,
                dateinvisibl =image.dateinvisibl
                

            };
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(um);
        }

        // GET: Image/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Image/Create
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

        // GET: Image/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Image/Edit/5
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



        
        // GET: Image/Delete/5
        public ActionResult Delete(int id)
        {
            var image = gs.GetByIdImage(id);

            imageModel um = new imageModel
            {
                id = image.id,
                name = image.name,

            };
            return View(um);
        }

        // POST: Image/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                gs.Delete(gs.GetByIdImage(id));
                gs.Commit();

                return RedirectToAction("Index","Galerie");
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Statlike(int id)
        {


            ViewBag.res = gs.Countaime(id);
            ViewBag.res1 = gs.Countsigna(id);
            return View();

        }


    }
}
