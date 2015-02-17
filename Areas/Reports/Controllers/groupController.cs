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
    public class groupController : Controller
    {
        //
        // GET: /Reports/group/

        public ActionResult All(string sub)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.group = "in";
            m.Allgroup = "active";
            m.filterVal = "groups";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "All";
            ViewBag.postControl = "group";
            ViewBag.subTitle = sub;

            return View(m);
        }

        [HttpPost]
        public ActionResult All(string vals, string o)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.group = "in";
            m.Allgroup = "active";
            m.filterVal = "groups";

            vals = Request["mode"].ToString();

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "All";
            ViewBag.postControl = "group";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel(m.celldata);

            if (vals == "excel")
                vals = "";

            m = new ReportingModel().genericResort(m, "baseResortReport", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), "groups", vals);

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

        public ActionResult local(string sub)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.group = "in";
            m.local = "active";
            m.filterVal = "local";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "local";
            ViewBag.postControl = "group";
            ViewBag.subTitle = sub;

            return View(m);
        }

        [HttpPost]
        public ActionResult local(string vals, string o)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.group = "in";
            m.local = "active";
            m.filterVal = "local";

            vals = Request["mode"].ToString();

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "local";
            ViewBag.postControl = "group";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel(m.celldata);

            if (vals == "excel")
                vals = "";

            m = new ReportingModel().genericResort(m, "baseResortReport", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), "local", vals);

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

        public ActionResult national(string sub)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.group = "in";
            m.intlgroup = "active";
            m.filterVal = "itlgrp";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "national";
            ViewBag.postControl = "group";
            ViewBag.subTitle = sub;

            return View(m);
        }

        [HttpPost]
        public ActionResult national(string vals, string o)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.group = "in";
            m.intlgroup = "active";
            m.filterVal = "itlgrp";

            vals = Request["mode"].ToString();

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "national";
            ViewBag.postControl = "group";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel(m.celldata);

            if (vals == "excel")
                vals = "";

            m = new ReportingModel().genericResort(m, "baseResortReport", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), "itlgrp", vals);

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

        public DataTable Excel(DataTable products)
        {
            products.Columns.Add("Promo code", typeof(string));
            products.Columns.Add("Adults", typeof(int));
            products.Columns.Add("Children", typeof(int));
            products.Columns.Add("Total Pax", typeof(int));

            return products;
        }

    }
}
