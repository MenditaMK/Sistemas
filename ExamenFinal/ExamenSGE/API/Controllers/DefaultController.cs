using ExamenSGEBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: api/Default
        public IEnumerable<string> Get()
        {
            List<clsPersona> listadoPersonas = null;
            try
            {
                listadoPersonas = clsGestoraBL.obtenerListadoCompleto();
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            if (listadoPersonas == null || listadoPersonas.Count == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }
            return listadoPersonas;
        }

        // GET: api/Default/5
        public string Get(int id)
        {
            clsPersona persona;
            try
            {
                persona = clsGestoraBL.obtenerPersonaPorID(id);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            return persona;
        }

        // POST: api/Default
        public void Post([FromBody]string value)
        {
            int filasAfectadas = 0;
            try
            {
                filasAfectadas = clsGestoraBL.insertarPersona(value);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            return filasAfectadas;
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
            int filasAfectadas = 0;
            try
            {
                value.Id = id;
                filasAfectadas = clsGestoraBL.actualizarPersona(value);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            return filasAfectadas;
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
            int filasAfectadas = 0;
            try
            {
                filasAfectadas = clsGestoraBL.eliminarPersona(id);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            return filasAfectadas;
        }
    }
}
