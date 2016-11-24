using gloventApp.Data.Models;
using gloventApp.GUI.Models;
using gloventApp.Services.Organizationn;
using gloventApp.Services.Userss;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;
using gloventApp.GUI.Helpers;
     


namespace gloventApp.GUI.Controllers
{
    public class OrganizationController : Controller
    {
        //OrganizationService os = new OrganizationService();
        OrganizationService os = new OrganizationService();
        UserService us = new UserService();

        // GET: Organization
        public ActionResult Index()
        {
            organization org = Session["organization"]as organization;
            if (org != null)
            {
            user i = us.GetById((int)org.PresidentID);
            i.MyOrganization_id = org.id;

            us.Update(i);
            us.Commit();
                Session["organization"] = null;
            }

            OrganizationService os = new OrganizationService();
            List<organization> listorganizations = os.getAll().ToList();
            List<OrganizationViewModel> lvm = new List<OrganizationViewModel>();
            //OrganizationViewModel ovm = new OrganizationViewModel();
  
            foreach (organization o in listorganizations)
            {
                OrganizationViewModel om = new OrganizationViewModel();
                om.id = o.id;
                    om.name = o.name;
                    om.type = o.type;
                om.President = us.GetById((int)o.PresidentID);
                //om.PresidentID = o.PresidentID;
                            
                lvm.Add(om);       
            }
            
            

            return View(lvm.ToList());

        }

        // GET: Organization/Details/5
        public ActionResult Details(int id)
        {
            OrganizationViewModel om = new OrganizationViewModel();

            organization o = os.GetById(id);
            
            om.id = o.id;
            om.name = o.name;
            om.type = o.type;
            om.Location = o.Location;
            om.President = us.GetById((int)o.PresidentID);
            

            return View(om);
        }

        // GET: Organization/Create
        public ActionResult Create()
        {
            OrganizationViewModel org = new OrganizationViewModel();
            List<user> listuser = new List<user>();
            listuser = us.GetMany().ToList();

            org.Presidents = listuser.ToSelectListItems1();
            return View(org);
        }


        // POST: Organization/Create
        [HttpPost]
        public ActionResult Create(OrganizationViewModel organization )
        {
            //OrganizationService os = new OrganizationService();
            try
            {
                if(ModelState.IsValid) { 
                    organization o = new organization();
                    //o.id = organization.id;
                    o.name = organization.name;
                    o.type = organization.type;
                    o.PresidentID = organization.PresidentID;
                    o.Location = organization.Location;
                    
                    os.Add(o);
                    os.Commit();

                    Session["organization"] = o;
                    return RedirectToAction("Index");
                }
                return View();

            }
            catch
            {
                return View();
            }
        }

        // GET: Organization/Edit/5
        public ActionResult Edit(int id)
        {
       
            organization o = os.GetById(id);
            OrganizationViewModel om = new OrganizationViewModel() ;
            om.id = o.id;
            om.name = o.name;
            om.type = o.type;
            om.PresidentID = (int)o.PresidentID;
            om.Location = o.Location;
            OrganizationViewModel org = new OrganizationViewModel();
            List<user> listuser = new List<user>();
            listuser = us.GetMany().ToList();
            om.Presidents = listuser.ToSelectListItems1();

            return View(om);
        }

        // POST: Organization/Edit/5
       [HttpPost]
        public ActionResult Edit(int id, OrganizationViewModel organization)
        {
        
            if (ModelState.IsValid)
            {
                organization o = os.GetById(id);
                //o.id = organization.id;
                o.name = organization.name;
                o.type = organization.type;
                o.PresidentID = organization.PresidentID;
                o.Location = organization.Location;
                os.Update(o);
                os.Commit();
                return RedirectToAction("Index");
            }
            return View();
        }
            
        

        // GET: Organization/Delete/5
        public ActionResult Delete(int id)
        {
            OrganizationService os = new OrganizationService();
            organization o = os.GetById(id);
            OrganizationViewModel om = new OrganizationViewModel();
            om.id = o.id;
            om.name = o.name;
            om.type = o.type;
            om.President = us.GetById((int)o.PresidentID);
            return View(om);
        }

        // POST: Organization/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                OrganizationService os = new OrganizationService();
                organization o = os.GetById(id);
                OrganizationViewModel om = new OrganizationViewModel();
                om.id = o.id;
                om.name = o.name;
                om.type = o.type;
                om.President = us.GetById((int)o.PresidentID);

                user i = om.President;
                o.PresidentID = null;
                i.DTYPE = "user";
                us.Update(i);
                us.Commit();
                os.Delete(o);
                os.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //GET
        public ActionResult OrganizationDashbord()
        {
            OrganizationService os = new OrganizationService();
            List<organization> listorganizations = os.getAll().ToList();
            List<OrganizationViewModel> lvm = new List<OrganizationViewModel>();
            //OrganizationViewModel ovm = new OrganizationViewModel();

            foreach (organization o in listorganizations)
            {
                OrganizationViewModel om = new OrganizationViewModel();
                om.id = o.id;
                om.name = o.name;
                om.type = o.type;
                om.President = us.GetById((int)o.PresidentID);
                //om.PresidentID = o.PresidentID;

                lvm.Add(om);
            }
            ViewBag.nomx = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
              
            List<organization> xx = os.getOrganizationByEventsForCurrentMonth().ToList();
            List<OrganizationViewModel> xm = new List<OrganizationViewModel>();
            foreach (organization e in xx)
            {
                OrganizationViewModel f = new OrganizationViewModel();
                f.id = e.id;
                f.name = e.name;
                f.type = e.type;
                f.President = us.GetById((int)e.PresidentID);
                //om.PresidentID = o.PresidentID;
                xm.Add(f);
            }
            ViewBag.p = xm.ToArray();
            ViewBag.map = os.getAll().ToList();





             List<organization> pp = os.getAll().ToList();
            //ViewBag.AllLocations = new SelectList(pp, "Location", "Location");
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in pp)
            {
                items.Add(new SelectListItem { Text = item.Location, Value = item.Location });
            }


            ViewBag.pp = items;


            return View(lvm.ToList());
            
        }

        public ActionResult getInts()
        {
            ViewBag.xx = os.getOrganizationByEventsForCurrentMonth();
            ViewBag.map = os.getAll().ToList();
            return View();
        }

        public ActionResult organizationByEventThisMonth()
        {

            //organization by event in this month  into ViewBag
            List<organization> xx = os.getOrganizationByEventsForCurrentMonth().ToList();
            List<OrganizationViewModel> xm = new List<OrganizationViewModel>();
            foreach (organization e in xx)
            {
                OrganizationViewModel f = new OrganizationViewModel();
                f.id = e.id;
                f.name = e.name;
                f.type = e.type;
                f.President = us.GetById((int)e.PresidentID);
                //om.PresidentID = o.PresidentID;
                xm.Add(f);
            }
            ViewBag.x = xm.ToList();
             return View(xm);
        }


        //GET
        public ActionResult initMap()
        {

            List<organization> pp = os.getAll().ToList();
            //ViewBag.AllLocations = new SelectList(pp, "Location", "Location");
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in pp)
            {
                items.Add(new SelectListItem { Text = item.Location, Value = item.Location });
            }
             
            ViewBag.pp = items;

            ViewBag.map = os.getAll().ToList();
            return View();
        }






        //Post
        [HttpPost]
        public ActionResult initMap(string pxp)
        {
            List<organization> pp = os.getAll().ToList();
            //ViewBag.AllLocations = new SelectList(pp, "Location", "Location");
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in pp)
            {
                items.Add(new SelectListItem { Text = item.Location, Value = item.Location });
            }

            ViewBag.pp = items;


            if (pp != null)
            {
                ViewBag.map = os.organizationByEventLocation(pxp).ToList();
            }
            else { ViewBag.map = os.getAll().ToList(); }
            return View();
        }



        [HttpPost]
        public ActionResult OrganizationDashbord(string pp)
        {
              
            OrganizationService os = new OrganizationService();
            List<organization> listorganizations = os.getAll().ToList();
            List<OrganizationViewModel> lvm = new List<OrganizationViewModel>();
            //OrganizationViewModel ovm = new OrganizationViewModel();

            foreach (organization o in listorganizations)
            {
                OrganizationViewModel om = new OrganizationViewModel();
                om.id = o.id;
                om.name = o.name;
                om.type = o.type;
                om.President = us.GetById((int)o.PresidentID);
                //om.PresidentID = o.PresidentID;

                lvm.Add(om);
            }
            ViewBag.nomx = DateTime.Now.Hour + ":" + DateTime.Now.Minute;

            List<organization> xx = os.getOrganizationByEventsForCurrentMonth().ToList();
            List<OrganizationViewModel> xm = new List<OrganizationViewModel>();
            foreach (organization e in xx)
            {
                OrganizationViewModel f = new OrganizationViewModel();
                f.id = e.id;
                f.name = e.name;
                f.type = e.type;
                f.President = us.GetById((int)e.PresidentID);
                //om.PresidentID = o.PresidentID;
                xm.Add(f);
            }
            ViewBag.p = xm.ToArray();
            // ViewBag.map = os.getAll().ToList();
              
            List<organization> pop = os.getAll().ToList();
            ViewBag.AllLocations = new SelectList(pop, "Location", "Location");
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in pop)
            {
                items.Add(new SelectListItem { Text = item.Location, Value = item.Location });
            }

            ViewBag.pp = items;
             
            ViewBag.map = os.organizationByEventLocation(pp).ToList();






            return View(lvm.ToList());

        }






    }
}
