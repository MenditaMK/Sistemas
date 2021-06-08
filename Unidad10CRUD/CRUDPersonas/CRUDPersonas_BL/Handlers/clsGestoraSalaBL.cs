using CRUDPersonas_DAL.Handlers;
using CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonas_BL.Handlers
{
    public class clsGestoraSalaBL
    {
        /// <summary>
        /// Este método llama a la capa DAL para insertar una nuev sala en la base de datos
        /// </summary>
        /// <param name="sala">La nueva sala</param>
        /// <returns>El número de filas afectadas</returns>
        public static int insertarSala(clsSala sala) {
            return clsGestoraSalaDAL.insertarSala(sala);
        }

        /// <summary>
        /// Este método llama a la capa DAL para obtener el listado de salas de la base de datos
        /// </summary>
        /// <returns></returns>
        public static List<clsSala> obtenerListadoSalas()
        {
            return clsGestoraSalaDAL.obtenerListadoSalas();
        }
    }
}
