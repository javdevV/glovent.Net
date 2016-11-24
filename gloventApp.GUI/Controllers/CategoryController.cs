using gloventApp.Data.Infrastructure;
using gloventApp.Data.Models;
using gloventApp.Services.Category;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web.Mvc;
using PagedList;

using gloventApp.GUI.Models;
using System.Web;
using DotNet.Highcharts;
using DotNet.Highcharts.Options;
using DotNet.Highcharts.Enums;
using System.Drawing;
using DotNet.Highcharts.Helpers;
using RazorPDF;

namespace gloventApp.GUI.Controllers
{
    public class CategoryController : Controller
    {
        CategoryService catsev = new CategoryService();
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork uow = new UnitOfWork(dbFactory);



        // GET: Category
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {


            ViewBag.CurrentSort = sortOrder;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;







            IEnumerable<category> listcategories = catsev.getAllCategories().ToList();
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(listcategories.ToPagedList(pageNumber, pageSize));

        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            category c = catsev.GetById(id);
            int numbEvents = catsev.numberOfEventsInCategory(id);
            ViewBag.ne = numbEvents;
        
            return View(c);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            //category cat = new category();
            return View();
        }

        // POST: Category/Create



        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(CategoryViewModel category, HttpPostedFileBase image)
        {

            category rt = new category();

            rt.Libelle = category.libelle;
            rt.id = category.Id;
            rt.image = image.FileName;

            var path = System.IO.Path.Combine(Server.MapPath("~/Content/Upload"), image.FileName);
            image.SaveAs(path);


            catsev.Add(rt);
            catsev.Commit();

            return RedirectToAction("Index");

        }
















        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            category e = catsev.GetById(id);
            return View(e);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, category cate, HttpPostedFileBase image)
        {

            category cat = catsev.GetById(id);

            cat.Libelle = cate.Libelle;

            cat.image = image.FileName;

            var path = System.IO.Path.Combine(Server.MapPath("~/Content/Upload"), image.FileName);
            image.SaveAs(path);

            catsev.Update(cat);
            catsev.Commit();
            return RedirectToAction("Index");


        }









        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            category c = catsev.GetById(id);
            return View(c);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            category e = catsev.GetById(id);


            catsev.Delete(e);


            catsev.Commit();
            return RedirectToAction("Index");
        }



        public ActionResult Index1()
        {
            IEnumerable<category> licat = catsev.getAllCategories();
            ViewBag.l = licat;
            int m = catsev.numberOfEventsInCategory(3);
            int m1 = catsev.numberOfEventsInCategory(4);
            int m2 = catsev.numberOfEventsInCategory(5);
            int m3 = catsev.numberOfEventsInCategory(7);
            int m4 = catsev.numberOfEventsInCategory(8);
            int m5 = catsev.numberOfEventsInCategory(9);



          ViewBag.p2 = catsev.GetById(3); ViewBag.p1 = catsev.GetById(4);
            


            ViewBag.p = catsev.GetById(5);




            Highcharts chart = new Highcharts("chart")
                .InitChart(new Chart())
                .SetTitle(new Title { Text = "Number of events per category" })
                .SetPlotOptions(new PlotOptions
                {
                    Pie = new PlotOptionsPie
                    {
                        AllowPointSelect = true,
                        Cursor = Cursors.Pointer,
                        ShowInLegend = true,
                        Events = new PlotOptionsPieEvents { Click = "function(event) { alert('Category!'); }" },
                        Point = new PlotOptionsPiePoint { Events = new PlotOptionsPiePointEvents { LegendItemClick = "function(event) { if (!confirm('Do you want to toggle the visibility of this category?')) { return false; } }" } }
                    }
                })
                .SetSeries(new Series
                {
                    Type = ChartTypes.Pie,
                    Name = "Number of events",
                    Data = new DotNet.Highcharts.Helpers.Data(new object[]
                                    {
                                        new object[] { "Culture", m },
                                        new object[] { "Sport", m1 },
                                        new object[] { "Concert", m2},
                                        new object[] { "Conference", m3 },
                                        new object[] { "Compétition", m4 },
                                        new object[] { "Festival", m5 }
                                    })
                });

            return View(chart);

        }








       





          
        }
















    }
