using glovent.App.Services;
using gloventApp.Data.Models;
using gloventApp.GUI.Models.Admin;
using gloventApp.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gloventApp.GUI.Controllers.Admin
{
    public class UsersController : Controller
    {
        IUserService UserService;



        public UsersController(IUserService UserService)
        {
            this.UserService = UserService;
        }
     

        // GET: Users
        public ActionResult Index()
        {
            var user = UserService.GetMany(p => p.DTYPE != "User");
            List<UsersViewModel> CVM = new List<UsersViewModel>();
            foreach (var item in user)
            {
                String state;
                if (item.AccountState.Equals(true))
                    state = "Activated";
                else
                    state = "Desactivated";
                CVM.Add(
                    new UsersViewModel
                    {
                        id = item.Id,
                        fName = item.fName,
                        age=item.age,
                        Email = item.Email,
                        DTYPE = item.DTYPE,
                       AccountState= state,
                     
                    });

            }
            return View(CVM);
        }

        // GET: Employees/Details/
        public JsonResult Details(int id)
        {
            user userr = UserService.Get(p => p.Id == id);
    
            String state;
            if (userr.AccountState.Equals(true))
                state = "Activated";
            else
                state = "Desactivated";
            return Json(new
            {
                mail = userr.Email,
                fn = userr.fName,
                ln = userr.lName,
                type = userr.DTYPE,
                age= userr.age,
                stat = state,
               
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ChangeState(int id)
        {
            try
            {
                user userr = UserService.Get(p => p.Id == id);
                userr.AccountState = !(userr.AccountState);
                UserService.Update(userr);
                UserService.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}