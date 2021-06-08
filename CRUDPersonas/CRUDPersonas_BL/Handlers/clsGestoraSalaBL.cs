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
        public static int insertarSala(clsSala sala) {
            return clsGestoraSalaDAL.insertarSala(sala);
        }

        public static List<clsSala> obtenerListadoSalas()
        {
            return clsGestoraSalaDAL.obtenerListadoSalas();
        }
    }
}
