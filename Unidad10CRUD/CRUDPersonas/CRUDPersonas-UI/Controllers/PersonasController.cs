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
            List<clsPersona> listadoPersonas = clsListadoPersonasBL.obtenerListadoCompleto();
            List<clsPersonaNombreDepartamento> listadoPersonasNombreDepartamento = new List<clsPersonaNombreDepartamento>();
            clsPersonaNombreDepartamento personaNombreDepartamento;
            foreach (clsPersona persona in listadoPersonas) {
                personaNombreDepartamento = new clsPersonaNombreDepartamento(persona, clsListadoDepartamentosBL.obtenerNombreDepartamento(persona.IdDepartamento));
                listadoPersonasNombreDepartamento.Add(personaNombreDepartamento);
            }
            return View("Index", listadoPersonasNombreDepartamento);
        }

        #region DELETE
        public ActionResult Delete(int id) {
            clsPersona persona = clsGestoraPersonaBL.obtenerPersonaPorID(id);
            clsPersonaNombreDepartamento personaNombreDepartamento = new clsPersonaNombreDepartamento(persona, clsListadoDepartamentosBL.obtenerNombreDepartamento(persona.IdDepartamento));
            return View("Delete", personaNombreDepartamento);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(int id) {
            try {
                clsGestoraPersonaBL.eliminarPersona(id);
            } catch (Exception e) {
                return RedirectToAction("Error");
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Edit
        public ActionResult Edit(int id) {
            clsPersona persona = clsGestoraPersonaBL.obtenerPersonaPorID(id);
            clsPersonaListadoDepartamentos personaListadoDepartamentos = new clsPersonaListadoDepartamentos(persona);
            return View("Edit", personaListadoDepartamentos);
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult EditPost(clsPersonaListadoDepartamentos persona) {
            clsPersona personaNueva = new clsPersona();
            personaNueva.Id = persona.Id;
            personaNueva.Nombre = personaNueva.Nombre;
            personaNueva.Apellidos = persona.Apellidos;
            personaNueva.FechaNacimiento = persona.FechaNacimiento;
            personaNueva.Imagen = persona.Imagen;
            persona.Direccion = persona.Direccion;
            persona.Telefono = persona.Telefono;
            persona.IdDepartamento = persona.IdDepartamento;

            try {
                clsGestoraPersonaBL.actualizarPersona(personaNueva);
            } catch (SqlException e) {
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
        public ActionResult CreatePost(clsPersonaListadoDepartamentos persona) {
            clsPersona personaNueva = new clsPersona();
            personaNueva.Nombre = persona.Nombre;
            personaNueva.Apellidos = persona.Apellidos;
            personaNueva.FechaNacimiento = persona.FechaNacimiento;
            personaNueva.Imagen = persona.Imagen;
            personaNueva.Direccion = persona.Direccion;
            personaNueva.Telefono = persona.Telefono;
            personaNueva.IdDepartamento = persona.IdDepartamento;

            try {
                clsGestoraPersonaBL.insertarPersona(personaNueva);
            } catch (SqlException e) {
                return View("Error");
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Details
        public ActionResult Details(int id) {
            clsPersona persona = clsGestoraPersonaBL.obtenerPersonaPorID(id);
            clsPersonaNombreDepartamento personaConDepartamento = new clsPersonaNombreDepartamento(persona, clsListadoDepartamentosBL.obtenerNombreDepartamento(persona.IdDepartamento));
            return View("Details", personaConDepartamento);
        }
        #endregion

        #region Error
        public ActionResult Error() {
            return View("Error");
        }
        #endregion
    }
}