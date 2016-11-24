using gloventApp.Data.Infrastructure;
using gloventApp.Data.Models;
using gloventApp.Services.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

using gloventApp.Services.Category;
using gloventApp.GUI.Models;
using gloventApp.GUI.Helpers;
using DotNet.Highcharts.Options;
using DotNet.Highcharts.Enums;
using System.Drawing;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts;

namespace gloventApp.GUI.Controllers
{
    public class EventController : Controller
    {


        EventService serviceEv = new EventService();
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork uow = new UnitOfWork(dbFactory);
        CategoryService catsev = new CategoryService();

        private evente ev;

        // GET: Event
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
            IEnumerable<evente> listEvents = serviceEv.GetAllEvents().ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                listEvents = listEvents.Where(s => s.nameEvent.Contains(searchString));

            }
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(listEvents.ToPagedList(pageNumber, pageSize));

        }





        public ActionResult Index1()
        {
            IEnumerable<evente> events= serviceEv.GetAllEvents();
            IEnumerable<evente> eventss = serviceEv.GetTodayEvents();
            IEnumerable<evente> eventsss = serviceEv.GetThisMonthEvents();
           List<int> num = serviceEv.GetNumberEventsEveryMonth();
            int n = serviceEv.GetNumberEventsLastMounth();
            int n1 = serviceEv.GetNumberEventsThisMounth();
            int n2 = serviceEv.GetTodayNumberEvents();  
            int n3 = serviceEv.GetNumberEvents();
            int m1 = serviceEv.GetNumberEventsI(1);
            int m11 = serviceEv.GetNumberEventsI(11);
            int m2 = serviceEv.GetNumberEventsI(2);
            int m3 = serviceEv.GetNumberEventsI(3);
            int m4 = serviceEv.GetNumberEventsI(4);
            int m5 = serviceEv.GetNumberEventsI(5);
            int m6 = serviceEv.GetNumberEventsI(6);
            int m7 = serviceEv.GetNumberEventsI(7);
            int m8 = serviceEv.GetNumberEventsI(8);
            int m9 = serviceEv.GetNumberEventsI(9);
            int m10 = serviceEv.GetNumberEventsI(10);
            int m12 = serviceEv.GetNumberEventsI(12);
            int last = serviceEv.GetNumberLastYearEvents();
            int last1 = serviceEv.GetNumberLastYearEvents1();
            int thisyear = serviceEv.GetNumberthisYearEvents1();
            int taux = (n1 / n)*100;
            ViewBag.tod = n2;
            ViewBag.na = n3;
            ViewBag.tx = taux;
            ViewBag.l = eventss;
            ViewBag.m = eventsss;
            ViewBag.num = n1;







            Highcharts chart1 = new Highcharts("chart1")
               .InitChart(new Chart { Type = ChartTypes.Column })
               .SetTitle(new Title { Text = "Number of events per Month" })
               .SetXAxis(new XAxis
               {
                   Categories = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }
               })
               .SetSeries(new Series
               {
                   Data = new DotNet.Highcharts.Helpers.Data(new object[] { m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12 })
               });









            Highcharts chart2 = new Highcharts("chart")
                   .InitChart(new Chart())
                   .SetTitle(new Title { Text = "Number of events per month" })
                   .SetPlotOptions(new PlotOptions
                   {
                       Pie = new PlotOptionsPie
                       {
                           AllowPointSelect = true,
                           Cursor = Cursors.Pointer,
                           ShowInLegend = true,
                           Events = new PlotOptionsPieEvents { Click = "function(event) { alert('The slice was clicked!'); }" },
                           Point = new PlotOptionsPiePoint { Events = new PlotOptionsPiePointEvents { LegendItemClick = "function(event) { if (!confirm('Do you want to toggle the visibility of this slice?')) { return false; } }" } }
                       }
                   })
                   .SetSeries(new Series
                   {
                       Type = ChartTypes.Pie,
                       Name = "Browser share",
                       Data = new DotNet.Highcharts.Helpers.Data(new object[]
                                       {
                                        new object[] { "Janvier", m1 },
                                        new object[] { "Fevrier", m2 },
                                        new object[] { "Mars", m3},
                                        new object[] { "Avril", m4 },
                                        new object[] { "Mai", m5},
                                        new object[] { "Juin", m6 },
                                        new object[] { "Juillet", m7 },
                                        new object[] { "Aout", m8 },
                                        new object[] { "Septembre",m9},
                                        new object[] { "Octobre", m10 },
                                        new object[] { "Novembre", m11 },
                                        new object[] { "Decembre", m12 }
                                       })
                   });

















            Highcharts chart3 = new Highcharts("chart3")
                .InitChart(new Chart { Type = ChartTypes.Spline })
                .SetTitle(new Title { Text = "Chart 3" })
                .SetXAxis(new XAxis
                {
                    Categories = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }
                })
                .SetSeries(new Series
                {
                    Data = new DotNet.Highcharts.Helpers.Data(new object[] { 29.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6, 54.4 })
                })
                .InFunction("DrawChart3");

            Highcharts chart4 = new Highcharts("chart4")
                .SetTitle(new Title { Text = "Evolution of number of events" })
                .SetXAxis(new XAxis
                {
                    Categories = new[] { "2014", "2015", "2016"}
                })
                .SetSeries(new Series
                {
                    Data = new DotNet.Highcharts.Helpers.Data(new object[] { last1, last,thisyear})
                });

            return View(new Container(new[] { chart1, chart2, chart3, chart4 }));


            //var chartss = new ChartsModel
            //{
            //    Chart1 = chart


            //};


            //return View(chartss);






            

























           
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
            EventViewModel evm = new EventViewModel();
            List<category> lc = new List<category>();
            lc = catsev.GetMany().ToList();
            evente e = serviceEv.GetById(id);
            evm.idEvent = e.idEvent;
            evm.localisation = e.localisation;
           
            evm.category = e.category;
            evm.avaibility = e.avaibility;
            e.MyCategory_id = e.MyCategory_id;

            evm.categories = lc.ToSelectListItems();
            return View(evm);
        }

        // POST: Event/Edit/5
        
        [HttpPost]
        public ActionResult Edit(int id, evente eventt)
        {

             evente e = serviceEv.GetById(id);

            e.avaibility = eventt.avaibility;
            e.dateEvent = eventt.dateEvent;
            e.localisation = eventt.localisation;
            e.MyCategory_id = eventt.MyCategory_id;
            serviceEv.Update(e);
            serviceEv.Commit();
            return RedirectToAction("Index");







        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            evente e = serviceEv.GetById(id);
            return View(e);
        }

        // POST: Event/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            evente e = serviceEv.GetById(id);

           
            serviceEv.Delete(e);
            serviceEv.Commit();

            return RedirectToAction("Index");
        }



        //public ActionResult Print()
        //{
        //    return new ActionAsPdf("Index",ev);
        //}



       


        public ActionResult Chart1()
        {
            Highcharts chart = new Highcharts("newChart")
                          .SetTitle(new Title { Text = "Chart inside JavaScript function" })
                          .SetTooltip(new Tooltip { Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %'; }" })
                          .SetXAxis(new XAxis { Categories = new[] { "Apples", "Oranges", "Pears", "Bananas", "Plums" } })
                          .SetTooltip(new Tooltip { Formatter = "TooltipFormatter" })
                          .SetLabels(new Labels
                          {
                              Items = new[]
                                                 {
                                           new LabelsItems
                                           {
                                               Html = "Total fruit consumption",
                                               Style = "left: '40px', top: '8px', color: 'black'"
                                           }
                                                 }
                          })
                          .SetPlotOptions(new PlotOptions
                          {
                              Pie = new PlotOptionsPie
                              {
                                  Center = new[] { new PercentageOrPixel(100), new PercentageOrPixel(80) },
                                  Size = new PercentageOrPixel(100),
                                  ShowInLegend = false,
                                  DataLabels = new PlotOptionsPieDataLabels { Enabled = false }
                              }
                          })
                          .SetSeries(new[]
                                     {
                               new Series
                               {
                                   Type = ChartTypes.Column,
                                   Name = "Jane",
                                   Data = new DotNet.Highcharts.Helpers.Data(new object[] { 3, 2, 1, 3, 4 })
                               },
                               new Series
                               {
                                   Type = ChartTypes.Column,
                                   Name = "John",
                                   Data = new DotNet.Highcharts.Helpers.Data(new object[] { 2, 3, 5, 7, 6 })
                               },
                               new Series
                               {
                                   Type = ChartTypes.Column,
                                   Name = "Joe",
                                   Data = new DotNet.Highcharts.Helpers.Data(new object[] { 4, 3, 3, 9, 0 })
                               },
                               new Series
                               {
                                   Type = ChartTypes.Spline,
                                   Name = "Average",
                                   Data = new DotNet.Highcharts.Helpers.Data(new object[] { 3, 2.67, 3, 6.33, 3.33 })
                               },
                               new Series
                               {
                                   Type = ChartTypes.Pie,
                                   Name = "Total consumption",
                                   Data = new DotNet.Highcharts.Helpers.Data(new[]
                                                   {
                                                       new DotNet.Highcharts.Options.Point
                                                       {
                                                           Name = "Jane",
                                                           Y = 13,
                                                           Color = Color.FromName("colors[5]")
                                                       },
                                                       new DotNet.Highcharts.Options.Point
                                                       {
                                                           Name = "John",
                                                           Y = 23,
                                                           Color = Color.FromName("colors[6]")
                                                       },
                                                       new DotNet.Highcharts.Options.Point
                                                       {
                                                           Name = "Joe",
                                                           Y = 19,
                                                           Color = Color.FromName("colors[7]")
                                                       }
                                                   }
                                       )
                               }
                                     })
                          .InFunction("DrawChart")
                          .AddJavascripVariable("colors", "Highcharts.getOptions().colors")
                          .AddJavascripFunction("TooltipFormatter",
                                                @"var s;
                    if (this.point.name) { // the pie chart
                       s = ''+
                          this.point.name +': '+ this.y +' fruits';
                    } else {
                       s = ''+
                          this.x  +': '+ this.y;
                    }
                    return s;");


             


            List<decimal> values = new List<decimal> { (decimal)29.9, (decimal)71.5, (decimal)106.4, (decimal)129.2, 111 };
            Highcharts c1 = new Highcharts("chart")
                .InitChart(new Chart { Type = ChartTypes.Spline })
                .SetTitle(new Title { Text = "Chart with decimal values" })
                .SetXAxis(new XAxis
                {
                    Categories = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" }
                })
                .SetSeries(new Series
                {
                    Data = new DotNet.Highcharts.Helpers.Data(values.Select(x => (object)x).ToArray())
                });

              


            var charts = new ChartsModel
            {
                Chart1 = chart,
                Chart2 = c1

            };


            return View(charts);

         











        }
















    }
    }

