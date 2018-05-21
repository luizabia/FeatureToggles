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
    }
}