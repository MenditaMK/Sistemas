using CRUDPersonas_DAL.Handlers;
using CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonas_BL.Handlers
{
    public class clsGestoraPostBL
    {
        public static int insertarPost(int id, clsPost post)
        {
            return clsGestoraPostDAL.insertarPost(id, post);
        }
    }
}
