using CRUDPersonas_BL.Listados;
using CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class DepartamentosController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<clsDepartamento> Get()
        {
            List<clsDepartamento> listadoDepartamentos = null;
            try
            {
                listadoDepartamentos = clsListadoDepartamentosBL.obtenerListadoDepartamentos();
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            if (listadoDepartamentos == null || listadoDepartamentos.Count == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }
            return listadoDepartamentos;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}