using ChukkaDashB.Areas.GpReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChukkaDashB.Areas.GpReport.Controllers
{
    public class PlainsController : Controller
    {
        //
        // GET: /GpReport/Plains/

        public ActionResult Index(string mode)
        {
            GpModel gp = new GpModel();

            ViewBag.post = "index";
            ViewBag.postControl = "Plains";
            ViewBag.channel = "";
            basicFilter(mode, gp);
            return View(gp);
        }

        [HttpPost]
        public ActionResult Index()
        {
            GpModel gp = new GpModel();

            ViewBag.post = "index";
            ViewBag.postControl = "Plains";
            ViewBag.channel = "";

            gp.datefrom = Request["datepickerFrom"];
            gp.dateto = Request["datepickerTo"];

            new GpReportingModel().reporting(gp.datefrom, gp.dateto, "", gp);
            return View(gp);
        }

        void basicFilter(string mode,GpModel m)
        {
            switch (mode)
            {
                case "Week":
                    {
                        int delta = DayOfWeek.Monday - DateTime.Now.DayOfWeek;
                        DateTime monday = DateTime.Now.AddDays(delta);
                        m.datefrom = monday.ToShortDateString();
                        m.dateto = DateTime.Now.ToShortDateString();
                        m.week = "active";

                        new GpReportingModel().reporting(m.datefrom, m.dateto,"", m);
                        break;
                    }
                case "Month":
                    {
                        m.datefrom = DateTime.Now.Month + "/1/" + DateTime.Now.Year;
                        m.dateto = DateTime.Now.ToShortDateString();
                        m.month = "active";

                        new GpReportingModel().reporting(m.datefrom, m.dateto, "", m);
                        break;
                    }
                case "year":
                    {
                        m.datefrom = "1/1/"+DateTime.Now.Year;
                        m.dateto = "12/31/"+DateTime.Now.Year;
                        m.year = "active";
                        new GpReportingModel().reporting(m.datefrom, m.dateto, "", m);
                        break;
                    }
                default:
                    {
                        int delta = DayOfWeek.Monday - DateTime.Now.DayOfWeek;
                        DateTime monday = DateTime.Now.AddDays(delta);
                        m.datefrom = monday.ToShortDateString();
                        m.dateto = DateTime.Now.ToShortDateString();
                        m.week = "active";
                        new GpReportingModel().reporting(m.datefrom, m.dateto, "", m);
                        break;
                    }
            }
        }
    }
}
