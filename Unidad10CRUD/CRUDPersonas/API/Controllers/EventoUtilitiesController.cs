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
    public class EventoUtilitiesController : ApiController
    {
        // GET: api/EventoUtilities
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/EventoUtilities/5
        public IEnumerable<clsEvento> Get(String id)
        {
            List<clsEvento> listado = new List<clsEvento>();
            try
            {
                listado = clsGestoraEventoBL.obtenerListadoEventosPorArtista(id);
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

        // POST: api/EventoUtilities
        public int Post([FromBody] clsListadoArtistasEvento listadoArtistasEvento)
        {
            int filasAfectadas = 0;
            int filasTotalesAfectadas = 0;
            try
            {
                foreach (String artista in listadoArtistasEvento.ListadoArtistas)
                {
                    filasAfectadas = clsGestoraEventoBL.insertarArtistaAEvento(artista, listadoArtistasEvento.IDEvento);
                    filasTotalesAfectadas = filasTotalesAfectadas + filasAfectadas;
                }
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            return filasTotalesAfectadas;
        }

        // PUT: api/EventoUtilities/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EventoUtilities/5
        public void Delete(int id)
        {
        }
    }
}
