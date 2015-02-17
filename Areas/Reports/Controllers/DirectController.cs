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
    public class DirectController : Controller
    {
        //
        // GET: /Reports/Direct/

        public ActionResult All(string sub)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.direct = "in";
            m.Alldirect = "active";
            m.filterVal = "direct";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "all";
            ViewBag.postControl = "direct";
            ViewBag.subTitle = sub;

            return View(m);
        }

        [HttpPost]
        public ActionResult All(string vals, string o)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.direct = "in";
            m.Alldirect = "active";
            m.filterVal = "direct";

            vals = Request["mode"].ToString();

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "all";
            ViewBag.postControl = "direct";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel(m.celldata);

            if (vals == "excel")
                vals = "";

            m = new ReportingModel().genericResort(m, "baseResortReport", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), "direct", vals);

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

        public ActionResult walk(string sub)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.direct = "in";
            m.walkin = "active";
            m.filterVal = "walkin";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "walk";
            ViewBag.postControl = "direct";
            ViewBag.subTitle = sub;

            return View(m);
        }

        [HttpPost]
        public ActionResult walk(string vals, string o)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.direct = "in";
            m.walkin = "active";
            m.filterVal = "walkin";

            vals = Request["mode"].ToString();

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "walk";
            ViewBag.postControl = "direct";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel(m.celldata);

            if (vals == "excel")
                vals = "";

            m = new ReportingModel().genericResort(m, "baseResortReport", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), "walkin", vals);

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

        public ActionResult website(string sub)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.direct = "in";
            m.website = "active";
            m.filterVal = "website";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "website";
            ViewBag.postControl = "direct";
            ViewBag.subTitle = sub;

            return View(m);
        }

        [HttpPost]
        public ActionResult website(string vals, string o)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.direct = "in";
            m.website = "active";
            m.filterVal = "website";

            vals = Request["mode"].ToString();

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "website";
            ViewBag.postControl = "direct";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel(m.celldata);

            if (vals == "excel")
                vals = "";

            m = new ReportingModel().genericResort(m, "baseResortReport", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), "website", vals);

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
