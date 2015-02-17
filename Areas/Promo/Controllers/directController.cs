using ChukkaDashB.Areas.Promo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChukkaDashB.Areas.Promo.Controllers
{
    public class directController : Controller
    {
        //
        // GET: /Promo/direct/

        public ActionResult Index()
        {
            PageModel m = new PageModel();
            m.nav = new PromoNavModel();
            m.nav.direct = "active";
            m.channel = "direct";

            m.returnurl = "direct";
            new DataModel().direct(m);
            return View(m);
        }

    }
}
