using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChukkaDashB.Areas.Reports.Models;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;
using System.Data;

namespace ChukkaDashB.Areas.Reports.Controllers
{
    public class ResortsController : Controller
    {

       
        //
        // GET: /Reports/Resorts/
        public ActionResult Index(string sub)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.Resort = "in";
            m.DMC = "active";
            m.filterVal = "DMC";
            m.selectedfilter = "";
            
            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "index";
            ViewBag.postControl = "resorts";
            ViewBag.subTitle = sub;

            return View(m);
        }

        [HttpPost]
        public ActionResult Index(string vals,string o)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.Resort = "in";
            m.DMC = "active";
            m.filterVal = "DMC";

            vals = Request["mode"].ToString();
                        
            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "index";
            ViewBag.postControl = "resorts";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel("DMC", m.celldata);

            if (vals == "excel")
                vals = "";

            m = new ReportingModel().genericResort(m, "baseResortReport", Request["datepickerFrom"].ToString(), 
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

        public ActionResult Hotel()
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.Resort = "in";
            m.Hotel = "active";
            m.filterVal = "HTL";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post  = "Hotel";
            ViewBag.postControl = "resorts";

            return View(m);
        }

        [HttpPost]
        public ActionResult Hotel(string vals)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.Resort = "in";
            m.Hotel = "active";
            m.filterVal = "HTL";

            vals = Request["mode"].ToString();
            if (vals == "excel")
                vals = "";

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post  = "Hotel";
            ViewBag.postControl = "resorts";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel("hotel", m.celldata);

            m = new ReportingModel().genericResort(m, "baseResortReport", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), "HTL", vals);

            m.filterVals = vals;

            #region excel procedures
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

        public ActionResult Intl()
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.Resort = "in";
            m.Intl = "active";
            m.filterVal = "ITL";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "Intl";
            ViewBag.postControl = "resorts";

            return View(m);
        }

        [HttpPost]
        public ActionResult Intl(string vals)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.Resort = "in";
            m.Intl = "active";
            m.filterVal = "Intl";

            vals = Request["mode"].ToString();
            if (vals == "excel")
                vals = "";

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "Intl";
            ViewBag.postControl = "resorts";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel("Intl", m.celldata);

            m = new ReportingModel().genericResort(m, "baseResortReport", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), "Itl", vals);
            m.filterVals = vals;

            #region excel prpcedures
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

        public ActionResult All()
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.Resort = "in";
            m.All = "active";
            m.filterVal = "All";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "All";
            ViewBag.postControl = "resorts";
            return View(m);
        }

        [HttpPost]
        public ActionResult All(string vals)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.Resort = "in";
            m.All = "active";
            m.filterVal = "All";

            vals = Request["mode"].ToString();
            if (vals == "excel")
                vals = "";

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "All";
            ViewBag.postControl = "resorts";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel("all", m.celldata);

            m = new ReportingModel().genericResort(m, "baseResortReport", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), "All", vals);
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

        public DataTable Excel(string mode,DataTable products)
        {            
            if (mode == "DMC")
            {
                products.Columns.Add("CustomerID", typeof(string));
                products.Columns.Add("DMC Name", typeof(string));
                products.Columns.Add("Adults", typeof(int));
                products.Columns.Add("Children", typeof(int));
                products.Columns.Add("Total Pax", typeof(int));
            }
            else if (mode == "hotel")
            {
                products.Columns.Add("CustomerID", typeof(string));
                products.Columns.Add("Hotelname", typeof(string));
                products.Columns.Add("Adults", typeof(int));
                products.Columns.Add("Children", typeof(int));
                products.Columns.Add("Total Pax", typeof(int));
            }
            else if (mode == "Intl")
            {
                products.Columns.Add("CustomerID", typeof(string));
                products.Columns.Add("Tour name", typeof(string));
                products.Columns.Add("Adults", typeof(int));
                products.Columns.Add("Children", typeof(int));
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
            else if (mode == "comp")
            {
                products.Columns.Add("Date", typeof(string));
                products.Columns.Add("Hotel", typeof(string));
                products.Columns.Add("Sale Rep", typeof(int));
                products.Columns.Add("Complimentory", typeof(int));
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
