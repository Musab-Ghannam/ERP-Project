using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace University_Registration.Controllers
{
    public class mainHomeController : Controller
    {
        // GET: mainHome
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult coarses()
        {
            return View();
        }
    }
}