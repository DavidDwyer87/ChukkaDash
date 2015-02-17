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
    public class OthersController : Controller
    {
        //
        // GET: /Reports/Other/

        public ActionResult Hotel(string sub)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.other = "in";
            m.hotelr = "active";
            m.filterVal = "hotel";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "Hotel";
            ViewBag.postControl = "Others";
            ViewBag.subTitle = sub;

            return View(m);
        }

        [HttpPost]
        public ActionResult Hotel(string sub,string vals)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.other = "in";
            m.hotelr = "active";
            m.filterVal = "hotel";

            vals = Request["mode"].ToString();

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "hotel";
            ViewBag.postControl = "others";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel("hotel", m.celldata);

            if (vals == "excel")
                vals = "";

            m = new ReportingModel().otherReports(m, "HotelReport", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), vals);

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

        public ActionResult plocation(string sub)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.other = "in";
            m.pax = "active";
            m.filterVal = "pax";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "plocation";
            ViewBag.postControl = "Others";
            ViewBag.subTitle = sub;

            return View(m);
        }

        [HttpPost]
        public ActionResult plocation(string sub, string vals)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.other = "in";
            m.pax = "active";
            m.filterVal = "pax";

            vals = Request["mode"].ToString();

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "plocation";
            ViewBag.postControl = "others";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel("DMC", m.celldata);

            if (vals == "excel")
                vals = "";

            m = new ReportingModel().genericResort(m, "PaxByLocation", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), "DMC", vals);

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

        public ActionResult comp(string sub)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.other = "in";
            m.comp = "active";
            m.filterVal = "Compli";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "comp";
            ViewBag.postControl = "Others";
            ViewBag.subTitle = sub;

            return View(m);
        }

        [HttpPost]
        public ActionResult comp(string sub, string vals)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.other = "in";
            m.comp = "active";
            m.filterVal = "Compli";

            vals = Request["mode"].ToString();

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "comp";
            ViewBag.postControl = "others";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel("Compli", m.celldata);

            if (vals == "excel")
                vals = "";

            m = new ReportingModel().otherReports(m, "ComplimentoryReport", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), "");

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

        public ActionResult pending(string sub)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.other = "in";
            m.pending = "active";
            m.filterVal = "pending";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "pending";
            ViewBag.postControl = "Others";
            ViewBag.subTitle = sub;

            return View(m);
        }

        [HttpPost]
        public ActionResult pending(string sub, string vals)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.other = "in";
            m.pending = "active";
            m.filterVal = "pending";

            vals = Request["mode"].ToString();

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "pending";
            ViewBag.postControl = "others";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel("pending", m.celldata);

            if (vals == "excel")
                vals = "";

            m = new ReportingModel().otherReports(m, "PendingReport", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), "");

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

        public ActionResult Cancel(string sub)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.other = "in";
            m.cancel = "active";
            m.filterVal = "cancel";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "cancel";
            ViewBag.postControl = "Others";
            ViewBag.subTitle = sub;

            return View(m);
        }

        [HttpPost]
        public ActionResult Cancel(string sub, string vals)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.other = "in";
            m.cancel = "active";
            m.filterVal = "cancel";

            vals = Request["mode"].ToString();

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "cancel";
            ViewBag.postControl = "others";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel("cancel", m.celldata);

            if (vals == "excel")
                vals = "";

            m = new ReportingModel().otherReports(m, "cancelReport", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), "");

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

        public ActionResult Nopromo(string sub)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.other = "in";
            m.nopromo = "active";
            m.filterVal = "nopromo";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "nopromo";
            ViewBag.postControl = "Others";
            ViewBag.subTitle = sub;

            return View(m);
        }

        [HttpPost]
        public ActionResult Nopromo(string sub, string vals)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.other = "in";
            m.nopromo = "active";
            m.filterVal = "nopromo";

            vals = Request["mode"].ToString();

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "nopromo";
            ViewBag.postControl = "others";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel("nopromo", m.celldata);

            if (vals == "excel")
                vals = "";

            m = new ReportingModel().otherReports(m, "nopromoReport", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), "");

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
           
            if (mode == "hotel")
            {
                products.Columns.Add("CustomerID", typeof(string));
                products.Columns.Add("Hotelname", typeof(string));
                products.Columns.Add("Adults", typeof(int));
                products.Columns.Add("Children", typeof(int));
                products.Columns.Add("Total Pax", typeof(int));
            }
            else if (mode == "Compli")
            {               
                products.Columns.Add("Date", typeof(string));
                products.Columns.Add("Hotel name", typeof(string));
                products.Columns.Add("Sales rep", typeof(string));
                products.Columns.Add("Total Pax", typeof(int));
            }
            else if (mode == "all")
            {
                products.Columns.Add("CustomerID", typeof(string));
                products.Columns.Add("group name", typeof(string));
                products.Columns.Add("Adults", typeof(int));
                products.Columns.Add("Children", typeof(int));
                products.Columns.Add("Total Pax", typeof(int));
            }
            else if (mode == "pending")
            {
                products.Columns.Add("Date", typeof(string));
                products.Columns.Add("Adults", typeof(int));
                products.Columns.Add("Children", typeof(int));
                products.Columns.Add("Total Pax", typeof(int));
            }           
            else if (mode == "cancel" || mode == "nopromo")
            {
                products.Columns.Add("Date", typeof(string));
                products.Columns.Add("Hotel", typeof(string));
                products.Columns.Add("Sale Rep", typeof(int));
                products.Columns.Add("Adults", typeof(int));
                products.Columns.Add("Children", typeof(int));
                products.Columns.Add("Total Pax", typeof(int));
            }

            return products;
        }

    }
}
