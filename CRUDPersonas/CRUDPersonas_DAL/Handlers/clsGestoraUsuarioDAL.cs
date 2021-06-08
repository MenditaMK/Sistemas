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
                    //while (reader.Read())
                    //{
                    //    usuario = new clsUsuario();
                    //    usuario.Nick = (String)reader["Nick"];
                    //    usuario.Email = (String)reader["Email"];
                    //    usuario.Nombre = (String)reader["Nombre"];
                    //    usuario.Password = (String)reader["Password"];
                    //    if (reader["Imagen"] != System.DBNull.Value)
                    //    {
                    //        usuario.Imagen = (String)reader["Imagen"];
                    //    }
                    //}
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
