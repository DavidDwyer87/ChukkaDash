using ChukkaDash.Models;
using ChukkaDashB.Areas.Promo.Models;
using ChukkaDashB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChukkaDashB.Areas.Promo.Controllers
{
    public class QueryController : Controller
    {
        //
        // GET: /Promo/Query/

        public ActionResult Remove(string _name,string returnurl)
        {
            var ctx = new UsersContext();
            var i = ctx.chan.FirstOrDefault(d => d.name == _name);
            if (i != null)
            {
                ctx.chan.Remove(i);
                ctx.SaveChanges();
            }

            return Redirect("/promo/" + returnurl + "/");
        }
        public ActionResult Edit(string customID,string _name,string tag,string returnurl,string _nam)
        {
            var ctx = new UsersContext();
            var result = ctx.chan.FirstOrDefault(m => m.name == _nam);

            if(result !=null)
            {
                result.name = _name.Trim();
                result.tag = tag;
                result.Customer = customID.Trim();

                ctx.SaveChanges();
            }

            return Redirect("/promo/"+returnurl+"/");
        }

        public ActionResult ForEdit(string name)
        {
            var ctx = new UsersContext();
            var edit = ctx.chan.FirstOrDefault(e => e.name == name);

            if(edit != null)
            {
                ViewBag.customer = edit.Customer;
                ViewBag.name = edit.name;
                ViewBag.tag = edit.tag;
            }

            return View();
        }
        public ActionResult add(string customID,string _name,string _tag,string _channel,string _catigory,string returnurl)
        {
            var ctx = new UsersContext();
            var check = ctx.chan.FirstOrDefault(m => m.name == _name);
            
            if(check == null)
            {
                ctx.chan.Add(new Channel { 
                    Customer = customID,
                    name = _name,
                    tag = _tag,
                    channel = _channel,
                    catigory = _catigory
                });

                ctx.SaveChanges();
            }

            return Redirect("/promo/" + returnurl + "/");
        }

        public ActionResult Salesdetails(string name)
        {
            PromoListModel m = new PromoListModel();
            new DataModel().promos(m, name);
            return View(m);
        }

        public ActionResult getpromos(string code)
        {
            PromoListModel m = new PromoListModel();
            new DataModel().getPromos(m, code);
            return View(m);
        }
    }
}
