using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDPersonas_DAL.Conexion;
using CRUDPersonas_Entidades;

namespace CRUDPersonas_DAL.Handlers
{
    public class clsGestoraUsuarioDAL
    {
        /// <summary>
        /// Este método inserta a un nuevo usuario en la base de datos
        /// </summary>
        /// <param name="usuario">El usuario a insertar</param>
        /// <returns>El númeror de filas afectadas</returns>
        public static int insertarUsuario(clsUsuario usuario)
        {
            clsMyConnection clsMyConnection = new clsMyConnection();
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlCommand = new SqlCommand();

            int numeroFilasAfectadas = 0;

            sqlCommand.Parameters.AddWithValue("@Nick", usuario.Nick);
            sqlCommand.Parameters.AddWithValue("@Email", usuario.Email);
            sqlCommand.Parameters.AddWithValue("@Nombre", usuario.Nombre);
            sqlCommand.Parameters.AddWithValue("@Password", usuario.Password);
            sqlCommand.Parameters.AddWithValue("@Imagen", usuario.Imagen);
            sqlCommand.Parameters.AddWithValue("@Tipo", usuario.Tipo);

            sqlCommand.CommandText = "INSERT INTO Usuario (Nick, Email, Nombre, Password, Imagen, Tipo) Values (@Nick, @Email, @Nombre, @Password, @Imagen, @Tipo)";
            try
            {
                sqlConnection = clsMyConnection.getConnection();

                sqlCommand.Connection = sqlConnection;

                numeroFilasAfectadas = sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                clsMyConnection.closeConnection(ref sqlConnection);
            }
            return numeroFilasAfectadas;
        }

        /// <summary>
        /// Este método actualiza los datos de un usuario
        /// </summary>
        /// <param name="id">El nick del usuario</param>
        /// <param name="usuario">El usuario con los datos cambiados</param>
        /// <returns>El número de filas afectadas</returns>
        public static int actualizarUsuario(string id, clsUsuario usuario)
        {
            SqlConnection sqlConnection = new SqlConnection();
            clsMyConnection conexion = new clsMyConnection();
            SqlCommand sqlCommand = new SqlCommand();
            int filasAfectadas = 0;
            sqlCommand.Parameters.AddWithValue("@Nick", usuario.Nick);
            sqlCommand.Parameters.AddWithValue("@Nombre", usuario.Nombre);
            sqlCommand.Parameters.AddWithValue("@Password", usuario.Password);
            sqlCommand.Parameters.AddWithValue("@Imagen", usuario.Imagen);
            sqlCommand.Parameters.AddWithValue("@Tipo", usuario.Tipo);
            sqlCommand.Parameters.AddWithValue("@Email", usuario.Email);
            sqlCommand.Parameters.AddWithValue("@ID", id);
            sqlCommand.CommandText = "UPDATE Usuario SET Nick = @Nick, Email = @Email, Nombre = @Nombre, Password = @Password, Imagen = @Imagen, Tipo = @Tipo WHERE Nick = @ID";

            try
            {
                sqlConnection = conexion.getConnection();
                sqlCommand.Connection = sqlConnection;
                filasAfectadas = sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                conexion.closeConnection(ref sqlConnection);
            }
            return filasAfectadas;
        }

        /// <summary>
        /// Este método actualiza la contraseña de un usuario
        /// </summary>
        /// <param name="email">El email</param>
        /// <param name="password">La nueva contraseña</param>
        /// <returns>El número de filas afectadas</returns>
        public static int actualizarPassword(String email, String password)
        {
            SqlConnection sqlConnection = new SqlConnection();
            clsMyConnection conexion = new clsMyConnection();
            SqlCommand sqlCommand = new SqlCommand();
            int filasAfectadas = 0;
            sqlCommand.Parameters.AddWithValue("@Password", password);
            sqlCommand.Parameters.AddWithValue("@Email", email);
            sqlCommand.CommandText = "UPDATE Usuario SET Password = @Password WHERE Email = @Email";

            try
            {
                sqlConnection = conexion.getConnection();
                sqlCommand.Connection = sqlConnection;
                filasAfectadas = sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                conexion.closeConnection(ref sqlConnection);
            }
            return filasAfectadas;
        }

        /// <summary>
        /// Este método verifica si existe un usuario con tales credenciales y en tal caso obtener los datos del usuario
        /// </summary>
        /// <param name="loginInformation">Las credenciales</param>
        /// <returns>El usuario en caso de existir</returns>
        public static clsUsuario obtenerUsuario(clsLoginInformation loginInformation)
        {
            clsMyConnection conexion = new clsMyConnection();
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;
            clsUsuario usuario = null;

            sqlCommand.Parameters.AddWithValue("@NickEmail", loginInformation.NickEmail);
            sqlCommand.Parameters.AddWithValue("@Password", loginInformation.Password);
            sqlCommand.CommandText = "SELECT * FROM Usuario WHERE (Nick = @NickEmail AND Password = @Password) OR (Email = @NickEmail AND Password = @Password)";

            try
            {
                sqlConnection = conexion.getConnection();
                sqlCommand.Connection = sqlConnection;
                reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        usuario = new clsUsuario();
                        usuario.Nick = (String)reader["Nick"];
                        usuario.Email = (String)reader["Email"];
                        usuario.Nombre = (String)reader["Nombre"];
                        usuario.Password = (String)reader["Password"];
                        if (reader["Imagen"] != System.DBNull.Value)
                        {
                            usuario.Imagen = (String)reader["Imagen"];
                        }
                        usuario.Tipo = (String)reader["Tipo"];
                    }
                }
                reader.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                conexion.closeConnection(ref sqlConnection);
            }
            return usuario;
        }

        /// <summary>
        /// Este método obtiene de la base de datos el listado de usuarios
        /// </summary>
        /// <returns>El listado de usuarios</returns>
        public static List<clsUsuario> obtenerListadoUsuarios() {
            clsMyConnection conexion = new clsMyConnection();
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            List<clsUsuario> listadoUsuarios = new List<clsUsuario>();
            SqlDataReader reader;
            clsUsuario usuario;
            try
            {
                sqlConnection = conexion.getConnection();
                command.CommandText = "SELECT * FROM dbo.Usuario";
                command.Connection = sqlConnection;
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        usuario = new clsUsuario();
                        usuario.Nick = (String)reader["Nick"];
                        usuario.Email = (String)reader["Email"];
                        usuario.Nombre = (String)reader["Nombre"];
                        usuario.Password = (String)reader["Password"];
                        if (reader["Imagen"] != System.DBNull.Value)
                        {
                            usuario.Imagen = (String)reader["Imagen"];
                        }
                        usuario.Tipo = (String)reader["Tipo"];
                        listadoUsuarios.Add(usuario);
                    }
                }
                reader.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                conexion.closeConnection(ref sqlConnection);
            }
            return listadoUsuarios;
        }

        /// <summary>
        /// Este método comprueba en la base de datos si ya existe un usuario con un nick determinado
        /// </summary>
        /// <param name="nick">El nick</param>
        /// <returns>Se devuelve 1 en caso de existir ya un usuario con tal nick y 0 en caso contrario</returns>
        public static int comprobarExistenciaUsuarioPorNick(String nick) {
            clsMyConnection conexion = new clsMyConnection();
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            int usuarioEncontrado = 0;
            command.Parameters.AddWithValue("@Nick", nick);
            try
            {
                sqlConnection = conexion.getConnection();
                command.CommandText = "SELECT * FROM dbo.Usuario WHERE Nick = @Nick";
                command.Connection = sqlConnection;
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    usuarioEncontrado = 1;
                }
                reader.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                conexion.closeConnection(ref sqlConnection);
            }
            return usuarioEncontrado;
        }

        /// <summary>
        /// Este método comprueba en la base de datos si ya existe un usuario con un email determinado
        /// </summary>
        /// <param name="email">El email</param>
        /// <returns>Se devuelve 1 en caso de existir ya un usuario con tal email y 0 en caso contrario</returns>
        public static int comprobarExistenciaUsuarioPorEmail(String email) {
            clsMyConnection conexion = new clsMyConnection();
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            int usuarioEncontrado = 0;
            command.Parameters.AddWithValue("@Email", email);
            try
            {
                sqlConnection = conexion.getConnection();
                command.CommandText = "SELECT * FROM dbo.Usuario WHERE Email = @Email";
                command.Connection = sqlConnection;
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    usuarioEncontrado = 1;
                }
                reader.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                conexion.closeConnection(ref sqlConnection);
            }
            return usuarioEncontrado;
        }
    }
}
