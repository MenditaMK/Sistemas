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
    public class EventoController : ApiController
    {
        // GET: api/Evento
        public IEnumerable<clsEvento> Get([FromUri] bool upcoming)
        {
            List<clsEvento> listado = new List<clsEvento>();
            try
            {
                listado = clsGestoraEventoBL.obtenerListadoEventos(upcoming);
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

        // GET: api/Evento/5
        public clsEventoDatos Get(int id)
        {
            clsEventoDatos eventoDatos = new clsEventoDatos();
            try
            {
                eventoDatos = clsGestoraEventoBL.obtenerDatosEvento(id);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            return eventoDatos;
        }

        // POST: api/Evento
        public int Post([FromBody]clsEvento evento)
        {
            int idEvento = 0;
            try
            {
               idEvento = clsGestoraEventoBL.insertarEvento(evento);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            return idEvento;
        }

        // PUT: api/Evento/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Evento/5
        public void Delete(int id)
        {
        }
    }
}
