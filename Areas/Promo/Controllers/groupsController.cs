using ChukkaDashB.Areas.Promo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChukkaDashB.Areas.Promo.Controllers
{
    public class groupsController : Controller
    {
        //
        // GET: /Promo/groups/

        public ActionResult Index()
        {
            PageModel m = new PageModel();
            m.nav = new PromoNavModel();
            m.nav.groups = "active";
            m.channel = "groups";

            m.returnurl = "groups";
            new DataModel().groups(m);
            return View(m);
        }

    }
}
