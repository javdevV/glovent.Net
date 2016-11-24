using glovent.App.Services;
using gloventApp.Data.Models;
using gloventApp.Domain.Entities;
using gloventApp.GUI.Helpers;
using gloventApp.GUI.Models;
using gloventApp.Services.Complaint;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace gloventApp.GUI.Controllers
{
    public class ComplaintController : Controller
    {

        ComplaintService cs = new ComplaintService();
        UserService us = new UserService();

        // GET: Complaint
        public ActionResult Index()
        {
           
                List<ComplaintViewModel> lstCVM = new List<ComplaintViewModel>();
                List<complaint> lst = cs.getAll().ToList();
                foreach (complaint comp in lst)
                {
                    ComplaintViewModel cm = new ComplaintViewModel();
                    cm.id = comp.id;
                    cm.Description = comp.Description;
                    cm.creationDate = comp.creationDate;
                    cm.Subject = comp.Subject;
                    cm.importanceLvl = comp.importanceLvl;
                    cm.MyUser_idUser = (int)comp.MyUser_idUser;
                    cm.user = us.GetById((int)comp.MyUser_idUser);
                    lstCVM.Add(cm);


                }
                //List<string> lstS = new List<string>();
                //foreach (var item in Enum.GetValues(typeof(subjectType)))
                //{
                //    lstS.Add(item.ToString());
                //}
                //List<string> lstI = new List<string>();
                //foreach (var item in Enum.GetValues(typeof(importanceType)))
                //{
                //    lstI.Add(item.ToString());
                //}
                //ViewBag.subject = lstS.ToSelectListItems();//new SelectList(lstS, "string","string");
                //ViewBag.importance = lstI.ToSelectListItems();

                return View(lstCVM);
           
          
        }
        //POST
        [HttpPost]
        public ActionResult Index(string lstSubject,string lstImportance, string radio, DateTime? searchDate=null)
        {
            try
            {
            List<complaint> lst = new List<complaint>() ;
            List<ComplaintViewModel> ll = new List<ComplaintViewModel>();
            if (radio.Equals("sujet"))
            {
                lst = cs.complaintsBySubject(lstSubject).ToList();

            }
            else if (radio.Equals("importance"))
            {
                lst = cs.complaintsByImportance(lstImportance).ToList();
            }
            else if (radio.Equals("day")&& searchDate !=null)
            {
                lst = cs.ComplaintsByDay((DateTime)searchDate).ToList();
            }
            else if (radio.Equals("month") && searchDate != null)
            {
                lst = cs.complaintsByMonth((DateTime )searchDate).ToList();
            }
            foreach (complaint comp in lst)
            {
                ComplaintViewModel cm = new ComplaintViewModel();
                cm.id = comp.id;
                cm.Description = comp.Description;
                cm.creationDate = comp.creationDate;
                cm.Subject = comp.Subject;
                cm.importanceLvl = comp.importanceLvl;
                cm.MyUser_idUser = (int)comp.MyUser_idUser;
                cm.user = us.GetById((int)comp.MyUser_idUser);
                ll.Add(cm);
            }
            return View(ll);
             }catch
            {
                return View();
    }
}
        // GET: Complaint/Details/5
        public ActionResult Details(int id)
        {

            complaint comp = cs.GetById(id);
            ComplaintViewModel cm = new ComplaintViewModel();
            cm.id = comp.id;
            cm.Description = comp.Description;
            cm.creationDate = comp.creationDate;
            cm.Subject = comp.Subject;
            cm.importanceLvl = comp.importanceLvl;
            cm.MyUser_idUser = (int)comp.MyUser_idUser;
           cm.user = us.GetById((int)comp.MyUser_idUser);
            Session["complaint"]= comp;
            return View(cm);
        }

        // GET: Complaint/Create
        public ActionResult Create()
        {
            List<string> lst = new List<string>() ;
            foreach (var item in Enum.GetValues(typeof(subjectType)))
            {
                lst.Add(item.ToString());
            }
            ComplaintViewModel cm = new ComplaintViewModel() { importanceLvl = Enum.GetName(typeof(importanceType), importanceType.Low) };
           cm.subjectLst = lst.ToSelectListItems2();
            cm.creationDate = DateTime.Now;
            return View(cm);
        }

        // POST: Complaint/Create
        [HttpPost]
        public ActionResult Create(ComplaintViewModel comp )
        {
            
                complaint c = new complaint();
                 
                c.Description = comp.Description;
                c.creationDate = DateTime.Now;
                c.Subject = comp.Subject;
                c.importanceLvl = comp.importanceLvl;
                c.MyUser_idUser = (int)comp.MyUser_idUser;  
                //c.user = us.GetById((int)comp.MyUser_idUser);
                cs.Add(c);
                cs.Commit();
           
            return RedirectToAction("Index");
           
        }

        // GET: Complaint/Edit/5
        public ActionResult Edit(int id)
        {
            List<string> lst = new List<string>();
            foreach (var item in Enum.GetValues(typeof(subjectType)))
            {
                lst.Add(item.ToString());
            }
            complaint comp = cs.GetById(id);
            ComplaintViewModel cm = new ComplaintViewModel();
            cm.Description = comp.Description;
            cm.creationDate = comp.creationDate;
            cm.Subject = comp.Subject;
            cm.subjectLst = lst.ToSelectListItems2();
            cm.importanceLvl = comp.importanceLvl;
            cm.MyUser_idUser = (int)comp.MyUser_idUser;
            cm.user = us.GetById((int)comp.MyUser_idUser);

            return View(cm);
        }
        
        // POST: Complaint/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ComplaintViewModel comp)
        {
          
                complaint cm = cs.GetById(id);
                
                cm.Description = comp.Description;
                cm.Subject = comp.Subject;
                cm.importanceLvl = comp.importanceLvl;
                cs.Update(cm);
                cs.Commit();
              return RedirectToAction("Index");
            
        }

        // GET: Complaint/Delete/5
        public ActionResult Delete(int id)
        {

            complaint comp = cs.GetById(id);
            ComplaintViewModel cm = new ComplaintViewModel();
            cm.Description = comp.Description;
            cm.creationDate = comp.creationDate;
            cm.Subject = comp.Subject;
            cm.importanceLvl = comp.importanceLvl;
            cm.MyUser_idUser = (int)comp.MyUser_idUser;
            cm.user = us.GetById((int)comp.MyUser_idUser);
            return View(cm);
        }

        // POST: Complaint/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
      
            complaint c = cs.GetById(id);
            cs.Delete(c);
            cs.Commit();
            return RedirectToAction("Index");
          
        }
       
    }
}
