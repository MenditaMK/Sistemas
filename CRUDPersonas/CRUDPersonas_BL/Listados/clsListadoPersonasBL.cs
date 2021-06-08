using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDPersonas_Entidades;
using CRUDPersonas_DAL.Listados;

namespace CRUDPersonas_BL.Listados
{
    public class clsListadoPersonasBL
    {
        /// <summary>
        /// Este método llama a la capa DAL para obtener el listado completo de las personas
        /// </summary>
        /// <returns>El listado de las personas</returns>
        public static List<clsPersona> obtenerListadoCompleto()
        {
            List<clsPersona> listado = clsListadoPersonasDAL.obtenerListadoPersonas();
            return listado;
        }
    }
}
