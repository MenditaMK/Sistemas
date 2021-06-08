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
        public IEnumerable<clsPersona> Get([FromUri] String hola)
        {
            List<clsPersona> listadoPersonas = null;
            try
            {
                if (String.IsNullOrEmpty(hola)) { listadoPersonas = clsListadoPersonasBL.obtenerListadoCompleto(); }
                else { listadoPersonas.Add(new clsPersona()); }
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
        public int Post([FromBody]clsPersona value)
        {
            int filasAfectadas = 0;
            try {
                filasAfectadas = clsGestoraPersonaBL.insertarPersona(value);
            } catch (Exception e) {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            return filasAfectadas;
        }

        // PUT: api/Personas/5
        public int Put(int id, [FromBody]clsPersona value)
        {
            int filasAfectadas = 0;
            try {
                value.Id = id;
                filasAfectadas = clsGestoraPersonaBL.actualizarPersona(value);
            } catch (Exception e) {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            return filasAfectadas;
            
        }

        // DELETE: api/Personas/5
        public int Delete(int id)
        {
            int filasAfectadas = 0;
            try {
                filasAfectadas = clsGestoraPersonaBL.eliminarPersona(id);
            } catch (Exception e) {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            return filasAfectadas;
        }
    }
}
