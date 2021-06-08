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
        public static int insertarArtista(clsArtista artista) {
            return clsGestoraArtistaDAL.insertarArtista(artista);
        }

        public static List<clsArtista> obtenerListadoArtistas()
        {
            return clsGestoraArtistaDAL.obtenerListadoArtistas();
        }
    }
}
