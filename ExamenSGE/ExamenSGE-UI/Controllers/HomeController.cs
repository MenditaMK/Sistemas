using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamenSGE_UI.Models;
using ExamenSGE_Entidades;
using System.Data.SqlClient;
using ExamenSGE_BL.Listados;

namespace ExamenSGE_UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            clsListadoMisionesNoCompletadas listadoMisiones = new clsListadoMisionesNoCompletadas();
            try {
                listadoMisiones.rellenarListadoMisiones();
            } catch (SqlException e) {
                ViewData["Error"] = "Ha habido un error al obtener el listado de misiones";
                return View("Error");
            }
            return View("Index", listadoMisiones);
        }

        [HttpPost, ActionName("Index")]
        public ActionResult IndexPost(clsListadoMisionesNoCompletadas listadoMisiones)
        {
            List<clsMisiones> misionesCompletadas = new List<clsMisiones>();

            foreach (clsMisiones mision in listadoMisiones.ListadoMisionesNoCompletadas)
            {
                if (mision.Completada)
                {
                    misionesCompletadas.Add(mision);
                }
            }
            try
            {
                clsGestoraListadoMisionesBL.actualizarListadoMisiones(misionesCompletadas);
            }
            catch (SqlException e)
            {
                ViewData["Error"] = "Ha habido un error al actualizar el listado de misiones";
                return View("Error");
            }

            clsListadoMisionesNoCompletadas listadoActualizado = new clsListadoMisionesNoCompletadas();
            listadoActualizado.rellenarListadoMisiones();
            return View("Index", listadoActualizado);

        }

        public ActionResult Error() {
            return View("Error");
        }


        /* Mi idea es recibir en el controlador POST el listado de las misiones
         * luego comprobaría a través de un bucle foreach la propiedad completada que
         * estarían checkeadas y añadiría estas misiones a una nueva lista, que 
         * sería la lista que mandaría a la capa BL para actualizar dichas misiones
         * 
         * Mi problema está en que no sé recibir el listado de la vista, porque me llega
         * vacío
         */
    }
}