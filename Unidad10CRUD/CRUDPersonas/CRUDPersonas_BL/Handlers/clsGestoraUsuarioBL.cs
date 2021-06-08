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

        /// <summary>
        /// Este método llama a la capa DAL para obtener el listado de usuarios de la base de datos
        /// </summary>
        /// <returns>El listado de usuarios</returns>
        public static List<clsUsuario> obtenerListadoUsuarios() {
            return clsGestoraUsuarioDAL.obtenerListadoUsuarios();
        }

        /// <summary>
        /// Este método llama a la capa DAL para comprobar si existe en la base de datos un usuario con un determinado nick
        /// </summary>
        /// <param name="nick">El nick</param>
        /// <returns>Se devolverá 1 en caso de haber ya un usuario y 0 en caso contrario</returns>
        public static int comprobarExistenciaUsuarioPorNick(String nick) {
            return clsGestoraUsuarioDAL.comprobarExistenciaUsuarioPorNick(nick);
        }

        /// <summary>
        /// Este método llama a la capa DAL para comprobar si existe en la base de datos un usuario con un determinado email
        /// </summary>
        /// <param name="email">El email</param>
        /// <returns>Se devolverá 1 en caso de haber ya un usuario y 0 en caso contrario</returns>
        public static int comprobarExistenciaUsuarioPorEmail(String email) {
            return clsGestoraUsuarioDAL.comprobarExistenciaUsuarioPorEmail(email);
        }

        /// <summary>
        /// Este método llama a la capa DAL para verificar si existe un usuario con tales credenciales y en tal caso obtener los datos del usuario
        /// </summary>
        /// <param name="loginInformation">Las credenciales</param>
        /// <returns>El usuario en caso de existir</returns>
        public static clsUsuario obtenerUsuario(clsLoginInformation loginInformation)
        {
            return clsGestoraUsuarioDAL.obtenerUsuario(loginInformation);
        }

        /// <summary>
        /// Este método llama a la capa DAL para actualizar la contraseña de un usuario
        /// </summary>
        /// <param name="email">El email del usuario</param>
        /// <param name="password">La nueva contraseña</param>
        /// <returns>El número de filas afectadas</returns>
        public static int actualizarPassword(String email, String password)
        {
            return clsGestoraUsuarioDAL.actualizarPassword(email, password);
        }

        /// <summary>
        /// Este método actualiza a un usuario
        /// </summary>
        /// <param name="id">El nick del usuario</param>
        /// <param name="usuario">El usuario con los datos cambiados</param>
        /// <returns>El número de filas afectadas</returns>
        public static int actualizarUsuario(string id, clsUsuario usuario)
        {
            return clsGestoraUsuarioDAL.actualizarUsuario(id, usuario);
        }
    }
}
