using ChukkaDashB.Areas.Reports.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChukkaDashB.Areas.Reports.Controllers
{
    public class CruiseController : Controller
    {
        //
        // GET: /Reports/Cruise/
        public ActionResult Index(string sub)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.cruise = "in";
            m.Allcruise = "active";
            m.filterVal = "cruise";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "index";
            ViewBag.postControl = "Cruise";
            ViewBag.subTitle = sub;

            return View(m);
        }

        [HttpPost]
        public ActionResult Index(string vals,string na)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.cruise = "in";
            m.Allcruise = "active";
            m.filterVal = "cruise";

            vals = Request["mode"].ToString();

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "index";
            ViewBag.postControl = "cruise";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel("all", m.celldata);

            m = new ReportingModel().genericResort(m, "baseResortReport", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), "cruise", vals);

            m.filterVals = vals;

            #region excel procedure
            if (Request["mode"].ToString() == "excel")
            {
                var grid = new GridView();

                grid.DataSource = m.celldata;
                grid.DataBind();

                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=" + m.datefrom + " to " + m.dateto + ".xls");
                Response.ContentType = "application/ms-excel";

                Response.Charset = "";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);

                grid.RenderControl(htw);

                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            #endregion

            return View(m);
        }

        public ActionResult port(string sub)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.cruise = "in";
            m.byport= "active";
            m.filterVal = "port";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "port";
            ViewBag.postControl = "Cruise";
            ViewBag.subTitle = sub;

            return View(m);
        }

        [HttpPost]
        public ActionResult port(string vals, string na)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.cruise = "in";
            m.byport = "active";
            m.filterVal = "port";

            vals = Request["mode"].ToString();

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "port";
            ViewBag.postControl = "cruise";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel("port", m.celldata);


            m = new ReportingModel().genericResort(m, "cruisePort", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), "cruise", vals);

            m.filterVals = vals;

            #region excel procedure
            if (Request["mode"].ToString() == "excel")
            {
                var grid = new GridView();

                grid.DataSource = m.celldata;
                grid.DataBind();

                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=" + m.datefrom + " to " + m.dateto + ".xls");
                Response.ContentType = "application/ms-excel";

                Response.Charset = "";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);

                grid.RenderControl(htw);

                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            #endregion

            return View(m);
        }


        public ActionResult Vessel(string sub)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.cruise = "in";
            m.vessel = "active";
            m.filterVal = "vessel";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "vessel";
            ViewBag.postControl = "Cruise";
            ViewBag.subTitle = sub;

            return View(m);
        }

        [HttpPost]
        public ActionResult Vessel(string vals, string na)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.cruise = "in";
            m.vessel = "active";
            m.filterVal = "vessel";

            vals = Request["mode"].ToString();

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "vessel";
            ViewBag.postControl = "cruise";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel("vessel", m.celldata);

            m = new ReportingModel().genericResort(m, "baseResortReport", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), "vessel", vals);

            m.filterVals = vals;

            #region excel procedure
            if (Request["mode"].ToString() == "excel")
            {
                var grid = new GridView();

                grid.DataSource = m.celldata;
                grid.DataBind();

                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=" + m.datefrom + " to " + m.dateto + ".xls");
                Response.ContentType = "application/ms-excel";

                Response.Charset = "";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);

                grid.RenderControl(htw);

                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            #endregion

            return View(m);
        }

        public DataTable Excel(string mode, DataTable products)
        {
            if (mode == "all")
            {
                products.Columns.Add("CustomerID", typeof(string));
                products.Columns.Add("Cruise line", typeof(string));
                products.Columns.Add("Adults", typeof(int));
                products.Columns.Add("Children", typeof(int));
                products.Columns.Add("Total Pax", typeof(int));
            }
            else if (mode == "port")
            {                
                products.Columns.Add("Port", typeof(string));
                products.Columns.Add("Adults", typeof(int));
                products.Columns.Add("Children", typeof(int));
                products.Columns.Add("Total Pax", typeof(int));
            }
            else if (mode == "vessel")
            {               
                products.Columns.Add("Vessel name", typeof(string));
                products.Columns.Add("Adults", typeof(int));
                products.Columns.Add("Children", typeof(int));
                products.Columns.Add("Total Pax", typeof(int));
            }
            

            return products;
        }
    }
}
