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
            return clsGestoraPersonaBL.obtenerPersonaPorID(id);
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
        public void Delete(clsPersona value)
        {
            clsGestoraPersonaBL.eliminarPersona(value.Id);
        }
    }
}
