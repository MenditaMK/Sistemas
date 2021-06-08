using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDPersonas_Entidades;
using CRUDPersonas_DAL.Listados;

namespace CRUDPersonas_BL.Listados
{
    public class clsListadoDepartamentosBL
    {
        /// <summary>
        /// Este método llama a la capa DAL para obtener el listado completo de los departamentos
        /// </summary>
        /// <returns>El listado completo de los departamentos</returns>
        public static List<clsDepartamento> obtenerListadoDepartamentos()
        {
            return clsListadoDepartamentoDAL.obtenerListadoDepartamentos();
        }

        /// <summary>
        /// Este método llama a la capa DAL para obtener el nombre de un departamento a través de su id
        /// </summary>
        /// <param name="id">El id del departamento</param>
        /// <returns>El nombre del departamento</returns>
        public static string obtenerNombreDepartamento(int id)
        {
            return clsListadoDepartamentoDAL.obtenerNombreDepartamento(id);
        }
    }
}
