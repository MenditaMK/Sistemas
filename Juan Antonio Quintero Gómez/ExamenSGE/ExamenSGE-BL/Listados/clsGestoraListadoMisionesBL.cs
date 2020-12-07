using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenSGE_Entidades;
using ExamenSGE_DAL.Listados;

namespace ExamenSGE_BL.Listados
{
    public class clsGestoraListadoMisionesBL
    {
        /// <summary>
        /// Este método llama a la capa DAL para obtener el listado de misiones no completadas
        /// </summary>
        /// <returns>El listado de misiones</returns>
        public static List<clsMisiones> obtenerListadoMisionesNoCompletadas() {
            return clsGestoraListadoMisionesDAL.obtenerListadoMisionesNoCompletadas();
        }

        /// <summary>
        /// Este método llama a la capa DAL para actualizar las misiones
        /// </summary>
        /// <param name="listadoMisiones">El listado de misiones</param>
        /// <returns>El número de misiones actualizadas</returns>
        public static int actualizarListadoMisiones(List<clsMisiones> listadoMisiones) {
            return clsGestoraListadoMisionesDAL.actualizarListadoMisiones(listadoMisiones);
        }
    }
}
