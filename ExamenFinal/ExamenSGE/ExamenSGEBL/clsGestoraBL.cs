using ExamenSGEDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSGEBL
{
    public class clsGestoraBL
    {
        /// <summary>
        /// Este método llama a la capa DAL para eliminar a una persona de la base de datos
        /// </summary>
        /// <param name="id">El id de la persona a eliminar</param>
        /// <returns>El número de filas afectadas</returns>
        public static int eliminarPersona(int id)
        {
            return clsGestoraDAL.eliminarPersona(id);
        }

        /// <summary>
        /// Este método llama a la capa DAL para insertar a una persona en la base de datos
        /// </summary>
        /// <param name="persona">La persona a insertar</param>
        /// <returns>El número de filas afectadas</returns>
        public static int insertarPersona(clsPersona persona)
        {
            return clsGestoraDAL.insertarPersona(persona);
        }

        /// <summary>
        /// Este método llama a la capa DAL para obtener a una persona de la base de datos a través de su id
        /// </summary>
        /// <param name="id">El id de la persona</param>
        /// <returns>La persona en cuestión</returns>
        public static clsPersona obtenerPersonaPorID(int id)
        {
            return clsGestoraDAL.obtenerPersonaPorID(id);
        }

        /// <summary>
        /// Este método llama a la capa DAL para actualizar a una persona de la base de datos
        /// </summary>
        /// <param name="persona">La persona a actualizar</param>
        /// <returns>El número de filas afectadas</returns>
        public static int actualizarPersona(clsPersona persona)
        {
            return clsGestoraDAL.actualizarPersona(persona);
        }

        public static List<clsPersona> obtenerListadoCompleto()
        {
            return clsGestoraDAL.obtenerListadoPersonas();
        }
    }
}
