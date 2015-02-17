using ChukkaDashB.Areas.DashBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChukkaDashB.Areas.DashBoard.Controllers
{
    public class directController : Controller
    {
        //
        // GET: /DashBoard/direct/

        public ActionResult Index(string mode)
        {
            directModel m = new directModel();
            m.direct = "active";

            switch (mode)
            {
                case "week":
                    {
                        int delta = DayOfWeek.Monday - DateTime.Now.DayOfWeek;
                        DateTime monday = DateTime.Now.AddDays(delta);


                        DataModel dm = new DataModel();
                        dm.summarydirect(monday.ToShortDateString(), DateTime.Now.ToShortDateString(), m);

                        break;
                    }
                case "month":
                    {
                        DataModel dm = new DataModel();
                        dm.summarydirect(DateTime.Now.Month + "/1/" + DateTime.Now.Year,
                            new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1).ToString(), m);
                        break;
                    }
                case "year":
                    {
                        DataModel dm = new DataModel();
                        dm.summarydirect("1/1/" + DateTime.Now.Year, "12/31/" + DateTime.Now.Year, m);

                        break;
                    }
                default:
                    {
                        int delta = DayOfWeek.Monday - DateTime.Now.DayOfWeek;
                        DateTime monday = DateTime.Now.AddDays(delta);

                        DataModel dm = new DataModel();
                        dm.summarydirect(monday.ToShortDateString(), DateTime.Now.ToShortDateString(), m);
                        break;
                    }
            }
            return View(m);
        }

    }
}
