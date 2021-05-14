using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDPersonas_BL.Listados;
using CRUDPersonas_Entidades;
using CRUDPersonas_BL.Handlers;
using CRUDPersonas_UI.Models;
using System.Data.SqlClient;

namespace CRUDPersonas_UI.Controllers
{
    public class PersonasController : Controller
    {
        // GET: Personas
        public ActionResult Index()
        {
            try {
                List<clsPersona> listadoPersonas = clsListadoPersonasBL.obtenerListadoCompleto();
                List<clsPersonaNombreDepartamento> listadoPersonasNombreDepartamento = new List<clsPersonaNombreDepartamento>();
                clsPersonaNombreDepartamento personaNombreDepartamento;
                foreach (clsPersona persona in listadoPersonas)
                {
                    personaNombreDepartamento = new clsPersonaNombreDepartamento(persona, clsListadoDepartamentosBL.obtenerNombreDepartamento(persona.IdDepartamento));
                    listadoPersonasNombreDepartamento.Add(personaNombreDepartamento);
                }
                return View("Index", listadoPersonasNombreDepartamento);
            } catch (SqlException e) {
                ViewData["Error"] = "Ha habido un error al obtener los datos de la persona";
                return View("Error");
            }
        }

        #region Delete
        public ActionResult Delete(int id) {
            try {
                clsPersona persona = clsGestoraPersonaBL.obtenerPersonaPorID(id);
                clsPersonaNombreDepartamento personaNombreDepartamento = new clsPersonaNombreDepartamento(persona, clsListadoDepartamentosBL.obtenerNombreDepartamento(persona.IdDepartamento));
                return View("Delete", personaNombreDepartamento);
            } catch (SqlException e) {
                ViewData["Error"] = "Ha habido un error al obtener los datos de la persona";
                return View("Error");
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(int id) {
            try {
                clsGestoraArtistaBL.obtenerListadoArtistas();
                //clsGestoraPersonaBL.eliminarPersona(id);
            } catch (Exception e) {
                ViewData["Error"] = "Ha habido un error al elimianr a la persona";
                return RedirectToAction("Error");
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Edit
        public ActionResult Edit(int id) {
            try {
                clsPersona persona = clsGestoraPersonaBL.obtenerPersonaPorID(id);
                clsPersonaListadoDepartamentos personaListadoDepartamentos = new clsPersonaListadoDepartamentos(persona);
                return View("Edit", personaListadoDepartamentos);
            } catch (SqlException e) {
                ViewData["Error"] = "Ha habido un error al obtener los datos de la persona";
                return View("Error");
            }
            
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult EditPost(clsPersonaListadoDepartamentos persona) {
            clsPersona personaNueva = new clsPersona();
            personaNueva.Id = persona.Id;
            personaNueva.Nombre = persona.Nombre;
            personaNueva.Apellidos = persona.Apellidos;
            personaNueva.FechaNacimiento = persona.FechaNacimiento;
            personaNueva.Imagen = persona.Imagen;
            personaNueva.Direccion = persona.Direccion;
            personaNueva.Telefono = persona.Telefono;
            personaNueva.IdDepartamento = persona.IdDepartamento;

            try {
                clsGestoraPersonaBL.actualizarPersona(personaNueva);
            } catch (SqlException e) {
                ViewData["Error"] = "Ha habido un error al editar la persona";
                return View("Error");
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Create
        public ActionResult Create() {
            clsPersonaListadoDepartamentos persona = new clsPersonaListadoDepartamentos(new clsPersona());
            return View("Create", persona);
        }

        [HttpPost, ActionName("Create")]
        public ActionResult CreatePost(clsPersonaListadoDepartamentos persona, String boton) {
            if (boton == "Crear nueva persona")
            {
                clsPersona personaNueva = new clsPersona();
                personaNueva.Nombre = persona.Nombre;
                personaNueva.Apellidos = persona.Apellidos;
                personaNueva.FechaNacimiento = persona.FechaNacimiento;
                personaNueva.Imagen = persona.Imagen;
                personaNueva.Direccion = persona.Direccion;
                personaNueva.Telefono = persona.Telefono;
                personaNueva.IdDepartamento = persona.IdDepartamento;

                try
                {
                    clsGestoraPersonaBL.insertarPersona(personaNueva);
                }
                catch (SqlException e)
                {
                    ViewData["Error"] = "Ha habido un error al crear a la persona";
                    return View("Error");
                }
                return RedirectToAction("Index");
            }
            else if (boton == "prueba") {
                
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Details
        public ActionResult Details(int id) {
            try {
                clsPersona persona = clsGestoraPersonaBL.obtenerPersonaPorID(id);
                clsPersonaNombreDepartamento personaConDepartamento = new clsPersonaNombreDepartamento(persona, clsListadoDepartamentosBL.obtenerNombreDepartamento(persona.IdDepartamento));
                return View("Details", personaConDepartamento);
            } catch (SqlException e) {
                ViewData["Error"] = "Ha habido un error al obtener los datos de la persona";
                return View("Error");
            }
        }
        #endregion

        #region Error
        public ActionResult Error() {
            return View("Error");
        }
        #endregion
    }
}