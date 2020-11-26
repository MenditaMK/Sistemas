using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDPersonas_BL.Listados;
using CRUDPersonas_Entidades;
using CRUDPersonas_BL.Handlers;

namespace CRUDPersonas_UI.Controllers
{
    public class PersonasController : Controller
    {
        // GET: Personas
        public ActionResult Index()
        {
            List<clsPersona> listadoPersonas = clsListadoPersonasBL.obtenerListadoCompleto();
            return View("Index", listadoPersonas);
        }

        #region DELETE
        public ActionResult Delete(int id) {
            clsPersona persona = clsGestoraPersonaBL.obtenerPersonaPorID(id);
            return View("Delete", persona);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(int id) {
            try {
                clsGestoraPersonaBL.eliminarPersona(id);
            } catch (Exception e) {
                throw e; //REDIRIGIR A VISTAAAAAAAAA ERRORRRRRRR
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Edit
        public ActionResult Edit(int id) {
            clsPersona persona = clsGestoraPersonaBL.obtenerPersonaPorID(id);
            return View("Edit", persona);
        }
        #endregion
    }
}