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
        public static void eliminarPersona(int id)
        {
            clsGestoraPersonaDAL.eliminarPersona(id);
        }

        public static void insertarPersona(clsPersona persona)
        {
            clsGestoraPersonaDAL.insertarPersona(persona);
        }

        public static clsPersona obtenerPersonaPorID(int id) {
            return clsGestoraPersonaDAL.obtenerPersonaPorID(id);
        }
    }
}
