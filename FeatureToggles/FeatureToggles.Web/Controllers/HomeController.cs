using FeatureTogglesExemples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeatureToggles.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            FeactureTogglesConfigInstance.Instance().Config.IsEnabled(EnumFeactureToggles.MyFeacture);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}