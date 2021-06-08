using CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CRUDPersonas_DAL.Conexion;
using System.Globalization;

namespace CRUDPersonas_DAL.Handlers
{
    public class clsGestoraEventoDAL
    {
        /// <summary>
        /// Este método inserta en la base de datos un nuevo evento
        /// </summary>
        /// <param name="evento">El evento</param>
        /// <returns>El número de filas afectadas</returns>
        public static int insertarEvento(clsEvento evento)
        {
            clsMyConnection clsMyConnection = new clsMyConnection();
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlCommandPost = new SqlCommand();
            SqlCommand sqlCommandID = new SqlCommand();
            DateTime date = DateTime.ParseExact(evento.Fecha.ToString("dd/MM/yyyy HH:mm:ss"), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            SqlDataReader reader;
            int id = 0;

            sqlCommandPost.Parameters.AddWithValue("@Cartel", evento.Cartel);
            sqlCommandPost.Parameters.AddWithValue("@Fecha", date);
            sqlCommandPost.Parameters.AddWithValue("@Informacion", evento.Informacion);
            sqlCommandPost.Parameters.AddWithValue("@Lugar", evento.Lugar);
            sqlCommandPost.Parameters.AddWithValue("@Genero", evento.Genero);
            sqlCommandPost.Parameters.AddWithValue("@Titulo", evento.Titulo);

            sqlCommandPost.CommandText = "INSERT INTO Evento (Cartel, Fecha, Informacion, Lugar, Genero, Titulo) Values (@Cartel, @Fecha, @Informacion, @Lugar, @Genero, @Titulo)";

            //Al tratarse el ID de un Identity, es necesario rescatarlo por eso creamos otro commandText
            sqlCommandID.Parameters.AddWithValue("@Lugar", evento.Lugar);
            sqlCommandID.Parameters.AddWithValue("@Fecha", date);
            sqlCommandID.CommandText = "SELECT ID FROM Evento WHERE Lugar = @Lugar AND Fecha = @Fecha";

            try
            {
                sqlConnection = clsMyConnection.getConnection();

                sqlCommandPost.Connection = sqlConnection;
                int filasAfectadas = sqlCommandPost.ExecuteNonQuery();
                sqlCommandID.Connection = sqlConnection;
                reader = sqlCommandID.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = (int)reader["ID"];
                    }
                }
                reader.Close();

            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                clsMyConnection.closeConnection(ref sqlConnection);
            }
            return id;
        }

        /// <summary>
        /// Este método obtiene de la base de datos todos los datos de un evento
        /// </summary>
        /// <param name="id">El id del evento</param>
        /// <returns>Los datos del evento</returns>
        public static clsEventoDatos obtenerDatosEvento(int id)
        {
            clsMyConnection conexion = new clsMyConnection();
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlCommand command2 = new SqlCommand();  //ESTE ES PARA OBTENER LOS POSTS QUE EXISTEN EN EL EVENTO
            clsEventoDatos eventoDatos = new clsEventoDatos();
            clsEvento evento;
            clsPost post;
            List<clsPost> listadoPosts = new List<clsPost>();
            SqlDataReader reader;
            command.Parameters.AddWithValue("@ID", id);
            command2.Parameters.AddWithValue("@ID", id);
            command.CommandText = "SELECT ID, Cartel, Fecha, Informacion, Lugar, Genero, Titulo, Nombre, S.Localidad, S.Direccion FROM Evento AS E INNER JOIN Usuario AS U ON E.Lugar = U.Nick INNER JOIN Sala AS S ON U.Nick = S.Nick WHERE ID = @ID";
            command2.CommandText = "SELECT NickUsuario, Contenido, FechaPost, Imagen FROM Post AS P INNER JOIN Evento AS E ON P.IDEvento = E.ID INNER JOIN Usuario AS U ON P.NickUsuario = U.Nick WHERE ID = @ID ORDER BY FechaPost DESC";

            try
            {
                sqlConnection = conexion.getConnection();
                command.Connection = sqlConnection;
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        eventoDatos = new clsEventoDatos();
                        evento = new clsEvento();
                        evento.Id = (int)reader["ID"];
                        evento.Cartel = (String)reader["Cartel"];
                        evento.Fecha = (DateTime)reader["Fecha"];
                        evento.Informacion = (String)reader["Informacion"];
                        evento.Lugar = (String)reader["Lugar"];
                        eventoDatos.Evento = evento;
                        eventoDatos.Evento.Genero = (String)reader["Genero"];
                        eventoDatos.Evento.Titulo = (String)reader["Titulo"];
                        eventoDatos.NombreSala = (String)reader["Nombre"];
                        eventoDatos.Localidad = (String)reader["Localidad"];
                        eventoDatos.Direccion = (String)reader["Direccion"];
                    }
                }
                reader.Close();

                command2.Connection = sqlConnection;
                reader = command2.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        post = new clsPost();
                        post.NickUsuario = (String)reader["NickUsuario"];
                        post.Contenido = (String)reader["Contenido"];
                        post.Fecha = (DateTime)reader["FechaPost"];
                        post.Imagen = (String)reader["Imagen"];
                        listadoPosts.Add(post);
                    }
                    eventoDatos.Posts = listadoPosts;
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
            return eventoDatos;
        }

        /// <summary>
        /// Este método obtiene de la base de datos todos los eventos próximos que tendrá un artista
        /// </summary>
        /// <param name="id">El nick del artista</param>
        /// <returns>El listado de eventos</returns>
        public static List<clsEvento> obtenerListadoEventosPorArtista(string id)
        {
            clsMyConnection conexion = new clsMyConnection();
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            List<clsEvento> listadoEventos = new List<clsEvento>();
            SqlDataReader reader;
            clsEvento evento;
            command.Parameters.AddWithValue("@IDArtista", id);
            command.CommandText = "SELECT * FROM EVENTO AS E INNER JOIN ArtistaEvento AS AE ON E.ID = AE.IDEvento WHERE AE.NickArtista = @IDArtista AND E.Fecha >= GETDATE() ORDER BY Fecha Asc";

            try
            {
                sqlConnection = conexion.getConnection();
                command.Connection = sqlConnection;
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        evento = new clsEvento();
                        evento.Id = (int)reader["ID"];
                        evento.Cartel = (String)reader["Cartel"];
                        evento.Fecha = (DateTime)reader["Fecha"];
                        evento.Informacion = (String)reader["Informacion"];
                        evento.Lugar = (String)reader["Lugar"];
                        evento.Genero = (String)reader["Genero"];
                        evento.Titulo = (String)reader["Titulo"];
                        listadoEventos.Add(evento);
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
            return listadoEventos;
        }

        /// <summary>
        /// Este método obtiene de la base de datos todos los eventos
        /// </summary>
        /// <param name="upcoming">Un booleano para saber si traer los próximos eventos venideros o todos</param>
        /// <returns>El listado de eventos</returns>
        public static List<clsEvento> obtenerListadoEventos(bool upcoming)
        {
            clsMyConnection conexion = new clsMyConnection();
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            List<clsEvento> listadoEventos = new List<clsEvento>();
            SqlDataReader reader;
            clsEvento evento;

            try
            {
                sqlConnection = conexion.getConnection();
                command.CommandText = "SELECT * FROM Evento AS E INNER JOIN Sala AS S ON E.Lugar = S.Nick";
                if (upcoming) {
                    command.CommandText += " WHERE Fecha > GETDATE()";
                }
                command.CommandText += " ORDER BY Fecha Asc";
                command.Connection = sqlConnection;
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        evento = new clsEvento();
                        evento.Id = (int)reader["ID"];
                        evento.Cartel = (String)reader["Cartel"];
                        evento.Fecha = (DateTime)reader["Fecha"];
                        evento.Informacion = (String)reader["Informacion"];
                        evento.Lugar = (String)reader["Lugar"];
                        evento.Genero = (String)reader["Genero"];
                        evento.Titulo = (String)reader["Titulo"];
                        evento.Provincia = (String)reader["Provincia"];
                        listadoEventos.Add(evento);
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
            return listadoEventos;
        }

        /// <summary>
        /// Este método inserta en la base de datos un nuevo artista en un evento
        /// </summary>
        /// <param name="artista">El nick del artista</param>
        /// <param name="idEvento">El id del evento</param>
        /// <returns>El número de filas afectadas</returns>
        public static int insertarArtistaAEvento(string artista, int idEvento)
        {
            clsMyConnection clsMyConnection = new clsMyConnection();
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlCommand = new SqlCommand();

            int numeroFilasAfectadas = 0;

            sqlCommand.Parameters.AddWithValue("@NickArtista", artista);
            sqlCommand.Parameters.AddWithValue("@IDEvento", idEvento);

            sqlCommand.CommandText = "INSERT INTO ArtistaEvento (NickArtista, IDEvento) Values (@NickArtista, @IDEvento)";
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
    }
}
