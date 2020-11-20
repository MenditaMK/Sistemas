using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ejercicio2._2.Controllers
{
    public class personasController : Controller
    {
        // GET: personas
        public ActionResult Index()
        {
            return View();
        }
    }
}