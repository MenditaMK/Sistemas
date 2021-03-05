using ExamenSGEBL;
using ExamenSGEEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class MisionController : ApiController
    {
        // GET: api/Mision
        public IEnumerable<clsMisiones> Get()
        {
            List<clsMisiones> listadoMisiones = null;
            try
            {
                listadoMisiones = clsGestoraBL.obtenerListadoMisiones();
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            return listadoMisiones;
        }

        // PUT: api/Mision/5
        public int Put(int id, [FromBody] clsMisiones value)
        {
            int filasAfectadas = 0;
            try
            {
                value.Id = id;
                filasAfectadas = clsGestoraBL.actualizarMision(value);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            return filasAfectadas;
        }

        // GET: api/Mision/5
        public string Get(int id)
        {
            String retorno = "";
            return retorno ;
        }

        // POST: api/Mision
        public void Post([FromBody]string value)
        {
        }



        // DELETE: api/Mision/5
        public void Delete(int id)
        {
        }
    }
}
