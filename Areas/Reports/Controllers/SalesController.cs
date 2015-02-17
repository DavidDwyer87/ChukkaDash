﻿using ChukkaDashB.Areas.Reports.Models;
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
    public class SalesController : Controller
    {
        //
        // GET: /Reports/Sales/

        public ActionResult srep(string sub)
        {
            ResortMenuControlModel m = new ResortMenuControlModel();
            m.sales = "in";
            m.salesrep = "active";
            m.filterVal ="salesrep";
            m.selectedfilter = "";

            m.datefrom = "";
            m.dateto = "";
            ViewBag.post = "srep";
            ViewBag.postControl = "Sales";
            ViewBag.subTitle = sub;

            return View(m);
        }

        [HttpPost]
        public ActionResult srep(string sub,string vals)
        {
             ResortMenuControlModel m = new ResortMenuControlModel();
            m.sales = "in";
            m.salesrep = "active";
            m.filterVal = "DMC";

            vals = Request["mode"].ToString();

            m.datefrom = Request["datepickerFrom"].ToString();
            m.dateto = Request["datepickerTo"].ToString();
            m.selectedfilter = Request["mode"];
            ViewBag.post = "srep";
            ViewBag.postControl = "sales";

            m.celldata = new System.Data.DataTable("teste");
            m.celldata = Excel("DMC", m.celldata);

            if (vals == "excel")
                vals = "";

            m = new ReportingModel().genericResort(m, "baseResortReport", Request["datepickerFrom"].ToString(),
                Request["datepickerTo"].ToString(), "salesrep", vals);

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
