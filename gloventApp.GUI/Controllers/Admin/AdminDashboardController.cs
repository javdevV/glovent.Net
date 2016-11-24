using glovent.App.Services;
using gloventApp.Data.Models;
using gloventApp.GUI.Models.Admin;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gloventApp.GUI.Controllers.Admin
{
  //  [Authorize(Roles = "admin")]
    public class AdminDashboardController : Controller
    {

        UserService usrS = new UserService();
        // GET: AdminDashboard
        public ActionResult Index()
        {
            IEnumerable<user> list1 = usrS.listUsers();





        return View(list1);
        }
  
        [HttpPost]
        public ActionResult Index(string fName)
        {
            List<user>x = usrS.Getusername(fName).ToList();
            


            return View(x);
        }
    
        public ActionResult Delete(int id)
        {

            user u = usrS.GetById(id);



            return View(u);
        }
    
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            user u = usrS.GetById(id);
         usrS.Delete(u);


            usrS.Commit();
            return RedirectToAction("Index");
        }
      
        public ActionResult EditU(int id)
        {
           
            user u = usrS.GetById(id);



            return View(u);

        }
       
        [HttpPost]
        public ActionResult EditU(int id, FormCollection collection)
        {
            user u = usrS.GetById(id);

            if (u.AccountState == true)
            {

                u.AccountState = false;
                usrS.Update(u);
                usrS.Commit();
            }
            else
                u.AccountState = true;
            usrS.Update(u);
            usrS.Commit();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public ActionResult Details(int id)
        {
            user u = usrS.GetById(id);

            return View(u);
        }

    }
}



       


