using System.Web.Mvc;

namespace ChukkaDashB.Areas.Promo
{
    public class PromoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Promo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Promo_default",
                "Promo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
