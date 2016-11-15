using gloventApp.Data.Infrastructure;
using gloventApp.Data.Models;
using gloventApp.Services.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gloventApp.GUI.Controllers
{
    public class EventController : Controller
    {


        IEventService serviceEv = new EventService();
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork uow = new UnitOfWork(dbFactory);



        // GET: Event
        public ActionResult Index()
        {
            IEnumerable<evente> listEvents = serviceEv.GetAllEvents().ToList();

            return View(listEvents);
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            evente e = serviceEv.GetById(id);

            return View(e);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
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

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            evente e = serviceEv.GetById(id);
            return View(e);
        }

        // POST: Event/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            evente e = serviceEv.GetById(id);
          

           
            serviceEv.Update(e);
            return RedirectToAction("Index");
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
          
            return View();
        }

        // POST: Event/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            evente e = serviceEv.GetById(id);


            serviceEv.Delete(e);
            uow.Commit();

            return RedirectToAction("Index");
        }
        }
    }

