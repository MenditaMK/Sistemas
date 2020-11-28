using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDPersonas_DAL.Handlers;
using CRUDPersonas_Entidades;

namespace CRUDPersonas_BL.Handlers
{
    public class clsGestoraPersonaBL
    {
        /// <summary>
        /// Este método llama a la capa DAL para eliminar a una persona de la base de datos
        /// </summary>
        /// <param name="id">El id de la persona a eliminar</param>
        public static void eliminarPersona(int id)
        {
            clsGestoraPersonaDAL.eliminarPersona(id);
        }

        /// <summary>
        /// Este método llama a la capa DAL para insertar a una persona en la base de datos
        /// </summary>
        /// <param name="persona">La persona a insertar</param>
        public static void insertarPersona(clsPersona persona)
        {
            clsGestoraPersonaDAL.insertarPersona(persona);
        }

        /// <summary>
        /// Este método llama a la capa DAL para obtener a una persona de la base de datos a través de su id
        /// </summary>
        /// <param name="id">El id de la persona</param>
        /// <returns>La persona en cuestión</returns>
        public static clsPersona obtenerPersonaPorID(int id) {
            return clsGestoraPersonaDAL.obtenerPersonaPorID(id);
        }

        /// <summary>
        /// Este método llama a la capa DAL para actualizar a una persona de la base de datos
        /// </summary>
        /// <param name="persona">La persona a actualizar</param>
        public static void actualizarPersona(clsPersona persona) {
            clsGestoraPersonaDAL.actualizarPersona(persona);
        }
    }
}
