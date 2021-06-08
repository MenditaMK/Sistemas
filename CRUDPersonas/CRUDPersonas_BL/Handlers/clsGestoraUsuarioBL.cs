using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDPersonas_Entidades;
using CRUDPersonas_DAL.Handlers;

namespace CRUDPersonas_BL.Handlers
{
    public class clsGestoraUsuarioBL
    {
        /// <summary>
        /// Este método llama a la capa DAL para insertar a un nuevo usuario en la base de datos
        /// </summary>
        /// <param name="usuario">El usuario a insertar</param>
        /// <returns>El número de filas afectadas</returns>
        public static int insertarUsuario(clsUsuario usuario)
        {
            return clsGestoraUsuarioDAL.insertarUsuario(usuario);
        }

        public static List<clsUsuario> obtenerListadoUsuarios() {
            return clsGestoraUsuarioDAL.obtenerListadoUsuarios();
        }

        public static int insertarUsuario(object artista)
        {
            throw new NotImplementedException();
        }

        public static int comprobarExistenciaUsuarioPorNick(String nick) {
            return clsGestoraUsuarioDAL.comprobarExistenciaUsuarioPorNick(nick);
        }

        public static int comprobarExistenciaUsuarioPorEmail(String email) {
            return clsGestoraUsuarioDAL.comprobarExistenciaUsuarioPorEmail(email);
        }

        public static clsUsuario obtenerUsuario(clsLoginInformation loginInformation)
        {
            return clsGestoraUsuarioDAL.obtenerUsuario(loginInformation);
        }

        public static int actualizarPassword(String email, String password)
        {
            return clsGestoraUsuarioDAL.actualizarPassword(email, password);
        }

        public static int actualizarUsuario(string id, clsUsuario usuario)
        {
            return clsGestoraUsuarioDAL.actualizarUsuario(id, usuario);
        }
    }
}
