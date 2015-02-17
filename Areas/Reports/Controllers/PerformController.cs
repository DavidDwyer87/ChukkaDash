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
    public class PerformController : Controller
    {
        //
        // GET: /Reports/Perform/

        public ActionResult Index()
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.Resort = "in";
            m.Perform = "active";
            m.filterVal = "rperform";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "index";
            ViewBag.postControl = "perform";

            return View(m);
            
        }

        [HttpPost]
        public ActionResult Index(string vals)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.Resort = "in";
            m.Perform = "active";
            m.filterVal = "rperform";            

            vals = Request["mode"].ToString();
            m.filterVals = vals;

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "index";
            ViewBag.postControl = "perform";
            ViewBag.channel = "resort";


            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel(m.celldata);
            if (vals == "excel")
                vals = "";

            m = new ReportingModel().genericResort(m, "TourPerformance", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(),"resort" , vals);

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
            m.CPerform = "active";
            m.filterVal = "cruise";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "cruise";
            ViewBag.postControl = "perform";

            return View(m);            
        }

        [HttpPost]
        public ActionResult cruise(string vals)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.cruise = "in";
            m.CPerform = "active";
            m.filterVal = "cruise";
            
            vals = Request["mode"].ToString();
            m.filterVals = vals;

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "cruise";

            ViewBag.postControl = "perform";
            ViewBag.channel = "cruise";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel(m.celldata);
            if (vals == "excel")
                vals = "";

            m = new ReportingModel().genericResort(m, "TourPerformance", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), "cruise", vals);

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
            m.DPerform = "active";
            m.filterVal = "direct";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "direct";
            ViewBag.postControl = "perform";

            return View(m);            
        }

        [HttpPost]
        public ActionResult direct(string vals)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.direct = "in";
            m.DPerform = "active";
            m.filterVal = "direct";            

            vals = Request["mode"].ToString();
            m.filterVals = vals;

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "direct";
            ViewBag.postControl = "perform";
            ViewBag.channel = "direct";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel(m.celldata);
            if (vals == "excel")
                vals = "";

            m = new ReportingModel().genericResort(m, "TourPerformance", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), "direct", vals);

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
            m.GPerform = "active";
            m.filterVal = "groups";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "group";
            ViewBag.postControl = "perform";

            return View(m);
        }

        [HttpPost]
        public ActionResult group(string vals)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.group = "in";
            m.Perform = "active";
            m.filterVal = "groups";
            m.filterVals = vals;

            vals = Request["mode"].ToString();
            m.filterVals = vals;

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "index";
            ViewBag.postControl = "perform";
            ViewBag.channel = "group";

            if (vals == "excel")
                vals = "";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel(m.celldata);

            m = new ReportingModel().genericResort(m, "TourPerformance", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), "groups", vals);

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

        public ActionResult sales()
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.sales = "in";
            m.SPerform = "active";
            m.filterVal = "sperform";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "sales";
            ViewBag.postControl = "perform";

            return View(m);            
        }

        [HttpPost]
        public ActionResult sales(string vals)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.sales = "in";
            m.SPerform = "active";
            m.filterVal = "sales";            

            vals = Request["mode"].ToString();
            m.filterVals = vals;

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "sales";
            ViewBag.postControl = "perform";
            ViewBag.channel = "Sales";

            if (vals == "excel")
                vals = "";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel(m.celldata);

            m = new ReportingModel().genericResort(m, "TourPerformance", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), "salesrep", vals);

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
            products.Columns.Add("TourName", typeof(string));
            products.Columns.Add("Adults", typeof(int));
            products.Columns.Add("Children", typeof(int));
            products.Columns.Add("Total Pax", typeof(int));

            return products;
        }

    }
}
