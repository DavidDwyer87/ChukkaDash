using ChukkaDashB.Areas.Promo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChukkaDashB.Areas.Promo.Controllers
{
    public class resortsController : Controller
    {
        //
        // GET: /Promo/Resorts/

        public ActionResult Index()
        {
            PageModel m = new PageModel();
            m.nav = new PromoNavModel();
            m.nav.resort = "active";
            m.channel = "resort";
            m.returnurl = "resorts";

            new DataModel().resort(m);
            return View(m);
        }

    }
}
