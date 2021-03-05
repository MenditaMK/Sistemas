using ExamenSGEDAL;
using ExamenSGEEntidades;
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
        /// Este método llama a la capa DAL para actualizar una misión de la base de datos
        /// </summary>
        /// <param name="mision">La misión a actualizar</param>
        /// <returns>El número de filas afectadas</returns>
        public static int actualizarMision(clsMisiones mision)
        {
            return clsGestoraDAL.actualizarMision(mision);
        }

        /// <summary>
        /// Este método llama a la capa DAL para obtener el listado de misiones no completadas
        /// </summary>
        /// <returns>El listado de misiones no completadas</returns>
        public static List<clsMisiones> obtenerListadoMisiones()
        {
            return clsGestoraDAL.obtenerListadoMisiones();
        }
    }
}
