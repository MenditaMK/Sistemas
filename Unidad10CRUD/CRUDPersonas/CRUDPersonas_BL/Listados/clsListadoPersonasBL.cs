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
        /// Esta función devuelve el listado completo de personas
        /// </summary>
        public static List<clsPersona> obtenerListadoCompleto()
        {
            List<clsPersona> listado = clsListadoPersonasDAL.obtenerListadoPersonas();
            return listado;
        }
    }
}
