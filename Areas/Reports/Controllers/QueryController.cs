using ChukkaDashB.Areas.Reports.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChukkaDashB.Areas.Reports.Views
{
    public class QueryController : Controller
    {
        //
        // GET: /Reports/Query/

        public ActionResult Index(string sp, string na, string from, string to, string ch)
        {
            DetailListModel list = new ReportingModel().detail(sp,na, from, to,ch);
            
            return View(list);
        }

        public ActionResult Resortfilter(string val,string selected)
        {           
            return View(new ReportingModel().Filter(val,selected));
        }  
   
        public ActionResult ExcelDetailLineExport(string sp, string na, string from, string to, string ch)
        {
           ReportingModel rm = new ReportingModel();
           ReportingModel.instance.celldata = new System.Data.DataTable("teste");
           Excel(ReportingModel.instance.celldata);

           DetailListModel list = rm.detail(sp, na, from, to, ch);
            var grid = new GridView();

            grid.DataSource = ReportingModel.instance.celldata;
            grid.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Details" + from + " to " + from + ".xls");
            Response.ContentType = "application/ms-excel";

            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return View();
        }

        public void Excel(DataTable products)
        {
            products.Columns.Add("TransNum", typeof(string));
            products.Columns.Add("date", typeof(string));            
            products.Columns.Add("Adults", typeof(int));
            products.Columns.Add("Children", typeof(int));
            products.Columns.Add("Total Pax", typeof(int));
            products.Columns.Add("Tourname", typeof(string));
            products.Columns.Add("salesrep", typeof(string));
            products.Columns.Add("Hotelname", typeof(string));            
        }
    }
}
