using CRUDPersonas_Entidades;
using CRUDPersonas_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDPersonas_UI.Controllers
{
    public class PruebaController : Controller
    {
        // GET: Prueba
        public ActionResult Index()
        {
            clsPersonaListadoDepartamentos persona = new clsPersonaListadoDepartamentos(new clsPersona());
            return View("Index", persona);
        }
    }
}