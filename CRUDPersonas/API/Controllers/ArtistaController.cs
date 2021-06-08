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
    public class ArtistaController : ApiController
    {
        // GET: api/Artista
        public IEnumerable<clsArtista> Get()
        {
            List<clsArtista> listado = new List<clsArtista>();
            try
            {
                listado = clsGestoraArtistaBL.obtenerListadoArtistas();
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

        // GET: api/Artista/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Artista
        public int Post([FromBody]clsArtista artista)
        {
            int filasAfectadas = 0;
            try
            {
                filasAfectadas = clsGestoraUsuarioBL.insertarUsuario(artista);
                filasAfectadas = clsGestoraArtistaBL.insertarArtista(artista);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            return filasAfectadas;
        }

        // PUT: api/Artista/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Artista/5
        public void Delete(int id)
        {
        }
    }
}
