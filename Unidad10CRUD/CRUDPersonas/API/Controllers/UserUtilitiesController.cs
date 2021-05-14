using API.Models;
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
    public class UserUtilitiesController : ApiController
    {
        // GET: api/UserUtilities
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UserUtilities/5
        public int Get([FromUri] String nick, [FromUri] String email)
        {
            int usuarioEncontrado = 0;
            try
            {
                if (!String.IsNullOrEmpty(nick))
                {
                    usuarioEncontrado = clsGestoraUsuarioBL.comprobarExistenciaUsuarioPorNick(nick);
                }
                else
                {
                    usuarioEncontrado = clsGestoraUsuarioBL.comprobarExistenciaUsuarioPorEmail(email);
                }
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            return usuarioEncontrado;
        }

        // POST: api/UserUtilities
        public clsUsuario Post([FromBody]clsLoginInformation loginInformation)
        {
            clsUsuario usuario = null;
            try
            {
                usuario = clsGestoraUsuarioBL.obtenerUsuario(loginInformation);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            return usuario;
        }

        // PUT: api/UserUtilities/5
        public int Put([FromBody]clsEmailPassword emailPassword)
        {
            int filasAfectadas = 0;
            try
            {
                filasAfectadas = clsGestoraUsuarioBL.actualizarPassword(emailPassword.Email, emailPassword.Password);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            return filasAfectadas;
        }

        // DELETE: api/UserUtilities/5
        public void Delete(int id)
        {
        }
    }
}
