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
        /// <summary>
        /// Este método llama a la capa DAL para insertar un nuevo post en la base de datos
        /// </summary>
        /// <param name="id">El id del evento en el que se insertará el nuevo post</param>
        /// <param name="post">El post a insertar</param>
        /// <returns>El número de filas afectadas</returns>
        public static int insertarPost(int id, clsPost post)
        {
            return clsGestoraPostDAL.insertarPost(id, post);
        }
    }
}
