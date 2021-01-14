using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace camer_chan.Controllers
{
    public class HomeController : Controller
    {
        private readonly DateTime eventDate;

        public HomeController()
        {
            eventDate = new DateTime(2021, 1, 16, 16, 0, 0);
        }
        public ActionResult Index(string lang = null, string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(lang))
                ChangeCultureHelper(lang);

            if (!string.IsNullOrEmpty(returnUrl))
                return Redirect(returnUrl);
            //retrieve culture language
            ViewData["culture"] = Thread.CurrentThread.CurrentCulture;
            ViewData["eventDate"] = eventDate.ToString("MM/dd/yyyy HH:mm:ss");
            return View();
        }

        public ActionResult ChangeCulture(string lang)
        {
            return RedirectToAction("Index", new { lang });
        }
        public void ChangeCultureHelper(string lang)
        {
            if (!string.IsNullOrEmpty(lang))
            {
                var cultureInfo = CultureInfo.GetCultureInfo(lang);
                Thread.CurrentThread.CurrentCulture = cultureInfo;
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
            }
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Championnat d'Afrique des Nations (CHAN) 2021";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "@Flywings";

        //    return View();
        //}
    }
}