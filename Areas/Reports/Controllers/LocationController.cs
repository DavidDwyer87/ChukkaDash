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
    public class LocationController : Controller
    {
        //
        // GET: /Reports/Location/

        public ActionResult Index()
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.Resort = "in";
            m.LocationPax = "active";
            m.filterVal = "rpax";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "index";
            ViewBag.postControl = "Location";

            return View(m);
            
        }

        [HttpPost]
        public ActionResult Index(string vals)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.Resort = "in";
            m.LocationPax = "active";
            m.filterVal = "rpax";

            vals = Request["mode"].ToString();
            m.filterVals = vals;

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "index";
            ViewBag.postControl = "Location";
            ViewBag.channel = "resort";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel(m.celldata);

            m = new ReportingModel().genericResort(m, "PaxByLocation", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), "rpax", vals);

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

            return View(m);
        }

        public ActionResult cruise()
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.cruise = "in";
            m.CPax = "active";
            m.filterVal = "cruise";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "cruise";
            ViewBag.postControl = "Location";

            return View(m);

        }

        [HttpPost]
        public ActionResult cruise(string vals)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.cruise = "in";
            m.CPax = "active";
            m.filterVal = "cruise";

            vals = Request["mode"].ToString();
            m.filterVals = vals;

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();

            m.selectedfilter = Request["mode"];

            ViewBag.post = "cruise";
            ViewBag.postControl = "Location";
            ViewBag.channel = "cruise";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel(m.celldata);

            m = new ReportingModel().genericResort(m, "PaxByLocation", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), "cpax", vals);

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

            return View(m);
        }

        public ActionResult direct()
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.direct = "in";
            m.DPax = "active";
            m.filterVal = "direct";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "direct";
            ViewBag.postControl = "Location";

            return View(m);

        }

        [HttpPost]
        public ActionResult direct(string vals)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.direct = "in";
            m.DPax = "active";
            m.filterVal = "direct";

            vals = Request["mode"].ToString();
            m.filterVals = vals;

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "direct";
            ViewBag.postControl = "Location";
            ViewBag.channel = "direct";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel(m.celldata);

            m = new ReportingModel().genericResort(m, "PaxByLocation", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), "dpax", vals);

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

            return View(m);
        }

        public ActionResult group()
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.group = "in";
            m.GPax = "active";
            m.filterVal = "groups";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "group";
            ViewBag.postControl = "Location";

            return View(m);

        }

        [HttpPost]
        public ActionResult group(string vals)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.group = "in";
            m.GPax = "active";
            m.filterVal = "groups";

            vals = Request["mode"].ToString();
            m.filterVals = vals;

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "group";
            ViewBag.postControl = "Location";
            ViewBag.channel = "group";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel(m.celldata);

            m = new ReportingModel().genericResort(m, "PaxByLocation", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), "gpax", vals);

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

            return View(m);
        }

        public ActionResult Olocation()
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.other = "in";
            m.pax = "active";
            m.filterVal = "pax";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "oLocation";
            ViewBag.postControl = "Location";

            return View(m);

        }

        [HttpPost]
        public ActionResult Olocation(string vals)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.other = "in";
            m.pax = "active";
            m.filterVal = "pax";

            vals = Request["mode"].ToString();
            m.filterVals = vals;

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "olocation";
            ViewBag.postControl = "Location";
            ViewBag.channel = "other";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel(m.celldata);

            m = new ReportingModel().genericResort(m, "PaxByLocation", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), "pax", vals);

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

            return View(m);
        }

        public ActionResult Sales()
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.sales = "in";
            m.SPax = "active";
            m.filterVal = "spax";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "sales";
            ViewBag.postControl = "Location";

            return View(m);

        }

        [HttpPost]
        public ActionResult Sales(string vals)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.sales = "in";
            m.SPax = "active";
            m.filterVal = "rpax";

            vals = Request["mode"].ToString();
            m.filterVals = vals;

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "index";
            ViewBag.postControl = "Location";
            ViewBag.channel = "resort";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel(m.celldata);

            m = new ReportingModel().genericResort(m, "PaxByLocation", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), "spax", vals);

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

            return View(m);
        }

        public DataTable Excel(DataTable products)
        {
            products.Columns.Add("Location", typeof(string));
            products.Columns.Add("Adults", typeof(int));
            products.Columns.Add("Children", typeof(int));
            products.Columns.Add("Total Pax", typeof(int));

            return products;
        }
    }
}
