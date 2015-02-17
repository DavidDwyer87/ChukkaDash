using ChukkaDashB.Areas.Promo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChukkaDashB.Areas.Promo.Controllers
{
    public class UnknownController : Controller
    {
        //
        // GET: /Promo/Unknow/

        public ActionResult Index()
        {
            PageModel m = new PageModel();
            m.nav = new PromoNavModel();
            m.nav.unknown = "active";

            m.returnurl = "unknown";

            new DataModel().unknown(m);
            return View(m);
        }

    }
}
