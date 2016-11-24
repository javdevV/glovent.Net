using glovent.App.Services;
using gloventApp.Data.Models;
using gloventApp.GUI.Models;
using gloventApp.Services.Complaint;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace gloventApp.GUI.Controllers
{
    public class MailController : Controller
    {
        UserService us = new UserService();
        ComplaintService cs = new ComplaintService();

        // GET: Mail
        public ActionResult Index()
        {
            return View();
        }

        // GET: Mail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mail/Create
        public ActionResult Create()
        {
            EmailFormModel ef = new EmailFormModel();
            if(Session["complaint"] != null)
            {
                complaint cv = Session["complaint"] as complaint;
                ef.ToEmail = us.GetById((int)cv.MyUser_idUser).Email;
                return View(ef);
            }
            return View();
            
        }

        // POST: Mail/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress(model.ToEmail));  // replace with valid value _receiver
                message.From = new MailAddress(model.FromEmail);  // replace with valid value _ sender
                message.Subject = "Answer about your Complaint";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "sourour.benzarti@esprit.tn",  // replace with valid value
                        Password = "2015sourour*"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;

                   try
                    {
                        await smtp.SendMailAsync(message);
                        if (Session["complaint"] != null)
                        {
                            complaint cv = Session["complaint"] as complaint;
                            complaint c = cs.GetById(cv.id);
                            c.gere = true;
                            cs.Update(c);
                            cs.Commit();
                            Session["complaint"] = null;
                        }
                    }
                    catch (SmtpFailedRecipientsException e)
                    {
                        Console.WriteLine("erreur mail not send !  s" + e.StatusCode);
                        return View();
                    }
                    
                    return RedirectToAction("Sent");
                }
               

            }
            return View(model);
        }
        public ActionResult Sent()
        {
            return View();
        }


        // GET: Mail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Mail/Edit/5
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

        // GET: Mail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mail/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
