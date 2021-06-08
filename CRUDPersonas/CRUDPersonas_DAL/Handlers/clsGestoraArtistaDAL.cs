using CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDPersonas_DAL.Conexion;
using System.Data.SqlClient;

namespace CRUDPersonas_DAL
{
    public class clsGestoraArtistaDAL
    {
        public static int insertarArtista(clsArtista artista) 
        {
            clsMyConnection clsMyConnection = new clsMyConnection();
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlCommand = new SqlCommand();

            int numeroFilasAfectadas = 0;

            sqlCommand.Parameters.AddWithValue("@Nick", artista.Nick);
            sqlCommand.Parameters.AddWithValue("@Biografia", artista.Biografia);
            sqlCommand.Parameters.AddWithValue("@Link", artista.Link);
            sqlCommand.Parameters.AddWithValue("@Genero", artista.Genero);

            sqlCommand.CommandText = "INSERT INTO Artista (Nick, Biografia, Link, Genero) Values (@Nick, @Biografia, @Link, @Genero)";
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

        public static List<clsArtista> obtenerListadoArtistas()
        {
            clsMyConnection conexion = new clsMyConnection();
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            List<clsArtista> listadoArtistas = new List<clsArtista>();
            SqlDataReader reader;
            clsArtista artista;
            try
            {
                sqlConnection = conexion.getConnection();
                command.CommandText = "SELECT * FROM Usuario AS U INNER JOIN Artista AS A ON U.Nick = A.Nick";
                command.Connection = sqlConnection;
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        artista = new clsArtista();
                        artista.Nick = (String)reader["Nick"];
                        artista.Email = (String)reader["Email"];
                        artista.Nombre = (String)reader["Nombre"];
                        if (reader["Imagen"] != System.DBNull.Value)
                        {
                            artista.Imagen = (String)reader["Imagen"];
                        }
                        artista.Biografia = (String)reader["Biografia"];
                        artista.Link = (String)reader["Link"];
                        artista.Genero = (String)reader["Genero"];
                        listadoArtistas.Add(artista);
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
            return listadoArtistas;
        }
    }
}
