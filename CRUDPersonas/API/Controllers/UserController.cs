using CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRUDPersonas_BL.Handlers;

namespace API.Controllers
{
    public class UserController : ApiController
    {
        // GET: api/User
        public IEnumerable<clsUsuario> Get()
        {
            List<clsUsuario> listado = new List<clsUsuario>();
            try
            {
                listado = clsGestoraUsuarioBL.obtenerListadoUsuarios();
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            if (listado == null || listado.Count == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }
            
            
            return listado;
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public int Post([FromBody]clsUsuario usuario)
        {
            int filasAfectadas = 0;
            try
            {
                filasAfectadas = clsGestoraUsuarioBL.insertarUsuario(usuario);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            return filasAfectadas;
        }

        // PUT: api/User/5
        public int Put(String id, [FromBody]clsUsuario usuario)
        {
            int filasAfectadas = 5;
            try
            {
                filasAfectadas = clsGestoraUsuarioBL.actualizarUsuario(id, usuario);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            return filasAfectadas;
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
