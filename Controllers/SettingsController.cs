using ChukkaDash.Models;
using ChukkaDashB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace ChukkaDashB.Controllers
{
    public class SettingsController : Controller
    {
        //
        // GET: /Settings/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult notify(string option)
        {
            var ctx = new UsersContext();
            var e = ctx.email.FirstOrDefault(i => i.Id == 1);

            if (e != null)
            {
                ViewBag.hname = e.hostname;
                ViewBag.login = e.login;
                ViewBag.password = e.password;
                ViewBag.port = e.port;
                ViewBag.email = e.email;
            }

            //DashConfigModel m = new basicConfig().SettingsConfig();
            //m.sysSetting = new setting();
            //switch (option)
            //{
            //    case "Sys":
            //        {
            //            m.sysSetting.systemAdmin = "active";
            //            break;
            //        }
            //    case "target":
            //        {
            //            m.sysSetting.traget = "active";
            //            break;
            //        }
            //    case "notify":
            //        {
            //            m.sysSetting.notification = "active";
            //            break;
            //        }
            //    default:
            //        {
            //            m.sysSetting.systemAdmin = "active";
            //            break;
            //        }
            //}

            return View();
        }

        [HttpPost]
        public ActionResult notify(string option, string op)
        {
            var ctx = new UsersContext();
            var e = ctx.email.FirstOrDefault(i => i.Id == 1);

            int _port = 25;
            if (e == null)
            {
                if (!string.IsNullOrEmpty(Request["port"]))
                    _port = Convert.ToInt32(Request["port"]);

                ctx.email.Add(new smtpConfig
                {
                    email = Request["email"],
                    hostname = Request["hostname"],
                    login = Request["login"],
                    password = Request["pass"],
                    port = _port
                });
            }
            else
            {
                if (!string.IsNullOrEmpty(Request["port"]))
                    _port = Convert.ToInt32(Request["port"]);

                e.email = Request["email"];
                e.login = Request["login"];
                e.hostname = Request["hostname"];
                e.password = Request["pass"];
                e.port = _port;

            }

            ctx.SaveChanges();

            ViewBag.hname = e.hostname;
            ViewBag.login = e.login;
            ViewBag.password = e.password;
            ViewBag.port = e.port;
            ViewBag.email = e.email;

            ///ashConfigModel m = new basicConfig().SettingsConfig();
            //m.sysSetting = new setting();

            //m.sysSetting.notification = "active";

            return View();
        }

        [HttpPost]
        public ActionResult addUser(string user)
        {
            string _email = Request["email"];
            string _user = Request["user"];
            string _managePromo = Request["mpc"];
            string _report = Request["rp"];
            string _gp = Request["gpr"];
            string _set = Request["sett"];


            var contx = new UsersContext();
            var r = contx.UserProfiles.FirstOrDefault(p => p.UserName == _user);
            if (r != null)
            {
                r.email = _email;
                contx.SaveChanges();
            }
            else if (!string.IsNullOrEmpty(_email) && !string.IsNullOrEmpty(_user))
            {
                string pass = new Random().Next(10000000).ToString() + "pw";
                WebSecurity.CreateUserAndAccount(_user.Trim(), pass);

                var ctx1 = new UsersContext();
                var email = ctx1.email.FirstOrDefault(e => e.Id == 1);
                           

               try
               {
                   MailMessage mail = new MailMessage(email.login, _email);
                   SmtpClient client = new SmtpClient(email.hostname, email.port);
                   client.DeliveryMethod = SmtpDeliveryMethod.Network;
                   client.Credentials = new NetworkCredential(email.login, email.password);


                   mail.Subject = "Chukka dashboard account";
                   mail.Body = "Welcome to chukka dashboard. " +
                       "your username: " + _user.Trim() +
                       "your password " + pass +
                       "Please remember to change your password upon login to your account.";

                   client.Send(mail);
               }
               catch(SmtpException ex)
               {

               }
            }

            var ctx = new UsersContext();
            UserProfile up = ctx.UserProfiles.FirstOrDefault(u => u.UserName == _user);

            if (!string.IsNullOrEmpty(_managePromo))
            {
                up.managePromo = true;
            }
            else
                up.managePromo = false;

            if (!string.IsNullOrEmpty(_report))
            {
                up.report = true;
            }
            else
                up.report = false;

            if (!string.IsNullOrEmpty(_gp))
            {
                up.gpreport = true;
            }
            else
                up.gpreport = false;

            if (!string.IsNullOrEmpty(_set))
            {
                up.settings = true;
            }
            else
                up.settings = false;

            ctx.SaveChanges();

            return Redirect("Index");
        }

        public ActionResult remove(string user)
        {
            using (var ctx = new UsersContext())
            {
                var n = ctx.UserProfiles.FirstOrDefault(u => u.UserName == user);
                ctx.UserProfiles.Remove(n);
                ctx.SaveChanges();
            }
            return Redirect("Index");
        }

        public ActionResult changePass()
        {
            //DashConfigModel m = new basicConfig().SettingsConfig();
            //return View(m);
            return View();
        }

        [HttpPost]
        public ActionResult  newPassword(string user)
        {
            var ctx = new UsersContext();
            string na = Request["userna"];
            var u = ctx.UserProfiles.FirstOrDefault(s => s.UserName ==na );

            string username = u.UserName;
            string _email = u.email;
            bool gp = u.gpreport;
            bool promo = u.managePromo;
            bool report = u.report;
            bool settings = u.settings;

            ctx.UserProfiles.Remove(u);
            ctx.SaveChanges();
           
            try
            {
                WebSecurity.CreateUserAndAccount(username, Request["newpass"]);

                var n = ctx.UserProfiles.FirstOrDefault(s => s.UserName == na);
                n.email = _email;
                n.gpreport = gp;
                n.managePromo = promo;
                n.report = report;
                n.settings = settings;

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                
            }

            return Redirect("/settings");
        }

        [HttpPost]
        public ActionResult changing()
        {
            bool changePasswordSucceeded;
            try
            {
                changePasswordSucceeded = WebSecurity.ChangePassword(User.Identity.Name, Request["old"], Request["newpass"]);
            }
            catch (Exception)
            {
                changePasswordSucceeded = false;
            }

            if (!changePasswordSucceeded)
            {
                return RedirectToAction("changepass");
            }
            //else
            //{
            //    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
            //}

            
            return Redirect("/dashboard");          
        }
        

    }
}
