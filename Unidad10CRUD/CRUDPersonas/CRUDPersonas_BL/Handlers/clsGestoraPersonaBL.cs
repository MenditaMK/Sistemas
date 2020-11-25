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
        public static void eliminarPersona(clsPersona persona)
        {
            clsGestoraPersonaDAL.eliminarPersona(persona);
        }

        public static void insertarPersona(clsPersona persona)
        {
            clsGestoraPersonaDAL.insertarPersona(persona);
        }
    }
}
