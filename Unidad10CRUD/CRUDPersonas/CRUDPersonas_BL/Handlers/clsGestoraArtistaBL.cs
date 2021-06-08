using CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDPersonas_DAL;

namespace CRUDPersonas_BL.Handlers
{
    public class clsGestoraArtistaBL
    {
        /// <summary>
        /// Este método llama a la capa DAL para insertar un nuevo artista en la base de datos
        /// </summary>
        /// <param name="artista">El artista</param>
        /// <returns>El número de filas afectadas</returns>
        public static int insertarArtista(clsArtista artista) {
            return clsGestoraArtistaDAL.insertarArtista(artista);
        }

        /// <summary>
        /// Este método llama a la capa DAL para obtener el listado de artistas de la base de datos
        /// </summary>
        /// <returns>El listado de artistas</returns>
        public static List<clsArtista> obtenerListadoArtistas()
        {
            return clsGestoraArtistaDAL.obtenerListadoArtistas();
        }
    }
}
