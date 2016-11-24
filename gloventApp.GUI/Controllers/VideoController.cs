using gloventApp.GUI.Models;
using gloventApp.Services.Video;
using gloventApp.Services.Video.Likevideo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace gloventApp.GUI.Controllers
{
    public class VideoController : Controller
    {
        VideoService gs = null;
        LikevideoService gl = null;
        public VideoController()
        {
            gs = new VideoService();
            gl = new LikevideoService();
        }
        // GET: Video
        public ActionResult Index()
        {
            return View();
        }

        // GET: Video/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var video = gs.GetByIdVideo(id);
            videoModel um = new videoModel
            {
                id = video.id,
                name = video.name,
                url = video.url,
                
                danger = video.danger,
                aime =video.aime,
                visib = video.visib,
                dateinvisibl =video.dateinvisibl,
                user = video.user
              

            };
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(um);
        }

        // GET: Video/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Video/Create
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

        // GET: Video/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Video/Edit/5
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

        // GET: Video/Delete/5
        public ActionResult Delete(int id)
        {
            var video = gs.GetByIdVideo(id);

            videoModel um = new videoModel
            {
                id = video.id,
                name = video.name

            };
            return View(um);
        }

        // POST: Video/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            try
            {

                gs.Delete(gs.GetByIdVideo(id));
                var idg = gs.GetByIdVideo(id).galerie_id;
                gs.Commit();

                return RedirectToAction("Index", "Galerie");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult userlike(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var likevideo = gl.Getlikebyidvideo(id);
            List<likevideoModel> um = new List<likevideoModel>();


            foreach (var v in likevideo)
            {
                um.Add(new likevideoModel
                {
                    id = v.id,
                    user = v.user


                });
            }

            if (likevideo == null)
            {
                return HttpNotFound();
            }
            return View(um);

        }
    }
}
