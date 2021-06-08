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
        public static int insertarEvento(clsEvento evento)
        {
            return clsGestoraEventoDAL.insertarEvento(evento);
        }

        public static int insertarArtistaAEvento(string artista, int idEvento)
        {
            return clsGestoraEventoDAL.insertarArtistaAEvento(artista, idEvento);
        }

        public static List<clsEvento> obtenerListadoEventos(bool upcoming)
        {
            return clsGestoraEventoDAL.obtenerListadoEventos(upcoming);
        }

        public static List<clsEvento> obtenerListadoEventosPorArtista(string id)
        {
            return clsGestoraEventoDAL.obtenerListadoEventosPorArtista(id);
        }

        public static clsEventoDatos obtenerDatosEvento(int id)
        {
            return clsGestoraEventoDAL.obtenerDatosEvento(id);
        }
    }
}
