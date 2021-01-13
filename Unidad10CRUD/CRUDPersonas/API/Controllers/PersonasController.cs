using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRUDPersonas_Entidades;
using CRUDPersonas_BL.Handlers;
using CRUDPersonas_BL.Listados;

namespace API.Controllers
{
    public class PersonasController : ApiController
    {
        // GET: api/Personas
        public IEnumerable<clsPersona> Get()
        {
            List<clsPersona> listadoPersonas = null;
            try
            {
                listadoPersonas = clsListadoPersonasBL.obtenerListadoCompleto();
            }
            catch (Exception e) {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            if (listadoPersonas == null || listadoPersonas.Count == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }
            return listadoPersonas;
        }

        // GET: api/Personas/5
        public clsPersona Get(int id)
        {
            clsPersona persona;
            try { 
                persona = clsGestoraPersonaBL.obtenerPersonaPorID(id);
            } catch (Exception e) {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            return persona;
        }

        // POST: api/Personas
        public void Post([FromBody]clsPersona value)
        {
            clsGestoraPersonaBL.insertarPersona(value);
        }

        // PUT: api/Personas/5
        public void Put(int id, [FromBody]clsPersona value)
        {
            clsGestoraPersonaBL.actualizarPersona(value);
        }

        // DELETE: api/Personas/5
        public void Delete(int id)
        {
            clsGestoraPersonaBL.eliminarPersona(id);
        }
    }
}
