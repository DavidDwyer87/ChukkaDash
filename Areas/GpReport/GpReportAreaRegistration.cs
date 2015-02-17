using System.Web.Mvc;

namespace ChukkaDashB.Areas.GpReport
{
    public class GpReportAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GpReport";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GpReport_default",
                "GpReport/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
