using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Begginer2.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Costumer()
        {
            return View();
        }
    }
}