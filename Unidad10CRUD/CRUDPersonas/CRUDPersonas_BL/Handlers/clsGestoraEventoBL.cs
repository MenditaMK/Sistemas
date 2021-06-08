using CRUDPersonas_DAL.Handlers;
using CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonas_BL.Handlers
{
    public class clsGestoraEventoBL
    {
        /// <summary>
        /// Este método llama a la capa DAL para insertar un nuevo evento en la base de datos
        /// </summary>
        /// <param name="evento">El nuevo evento</param>
        /// <returns>El número de filas afectadas</returns>
        public static int insertarEvento(clsEvento evento)
        {
            return clsGestoraEventoDAL.insertarEvento(evento);
        }

        /// <summary>
        /// Este método llama a la capa DAL para insertar un nuevo artista en un evento en la base de datos
        /// </summary>
        /// <param name="artista">El nick del artista</param>
        /// <param name="idEvento">El id del evento al que se va a insertar el artista</param>
        /// <returns>El número de filas afectadas</returns>
        public static int insertarArtistaAEvento(string artista, int idEvento)
        {
            return clsGestoraEventoDAL.insertarArtistaAEvento(artista, idEvento);
        }

        /// <summary>
        /// Este método llama a la capa DAL para obtener el listado de eventos de la base de datos
        /// </summary>
        /// <param name="upcoming">Un booleano para saber si traer los próximos eventos venideros o todos</param>
        /// <returns>El listado de eventos</returns>
        public static List<clsEvento> obtenerListadoEventos(bool upcoming)
        {
            return clsGestoraEventoDAL.obtenerListadoEventos(upcoming);
        }

        /// <summary>
        /// Este método llama a la capa DAL para obtener el listado de próximos eventos que tendrá un artista
        /// </summary>
        /// <param name="id">El nick del artista</param>
        /// <returns>El listado de eventos</returns>
        public static List<clsEvento> obtenerListadoEventosPorArtista(string id)
        {
            return clsGestoraEventoDAL.obtenerListadoEventosPorArtista(id);
        }

        /// <summary>
        /// Este método llama a la capa DAL para obtener todos los datos de un evento de la base de datos
        /// </summary>
        /// <param name="id">El id del evento</param>
        /// <returns>Todos los datos del evento</returns>
        public static clsEventoDatos obtenerDatosEvento(int id)
        {
            return clsGestoraEventoDAL.obtenerDatosEvento(id);
        }
    }
}
