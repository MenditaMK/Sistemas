using CRUDPersonas_BL.Handlers;
using CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class SalaController : ApiController
    {
        // GET: api/Sala
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Sala/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Sala
        public int Post([FromBody] clsSala sala)
        {
            int filasAfectadas = 0;
            try
            {
                filasAfectadas = clsGestoraUsuarioBL.insertarUsuario(sala);
                filasAfectadas = clsGestoraSalaBL.insertarSala(sala);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            return filasAfectadas;
        }

        // PUT: api/Sala/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Sala/5
        public void Delete(int id)
        {
        }
    }
}
