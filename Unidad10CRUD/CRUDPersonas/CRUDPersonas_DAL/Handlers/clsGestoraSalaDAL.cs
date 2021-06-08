using CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDPersonas_DAL.Conexion;

namespace CRUDPersonas_DAL.Handlers
{
    public class clsGestoraSalaDAL
    {
        /// <summary>
        /// Este método inserta una nueva sala en la base de datos
        /// </summary>
        /// <param name="sala">La sala a insertar</param>
        /// <returns>El númeror de filas afectadas</returns>
        public static int insertarSala(clsSala sala) 
        {
            clsMyConnection clsMyConnection = new clsMyConnection();
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlCommand = new SqlCommand();

            int numeroFilasAfectadas = 0;

            sqlCommand.Parameters.AddWithValue("@Nick", sala.Nick);
            sqlCommand.Parameters.AddWithValue("@Localidad", sala.Localidad);
            sqlCommand.Parameters.AddWithValue("@Direccion", sala.Direccion);
            sqlCommand.Parameters.AddWithValue("@Provincia", sala.Provincia);

            sqlCommand.CommandText = "INSERT INTO Sala (Nick, Localidad, Direccion, Provincia) Values (@Nick, @Localidad, @Direccion, @Provincia)";
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
        /// Este método obtiene de la base de datos el listado de salas
        /// </summary>
        /// <returns>El listado de salas</returns>
        public static List<clsSala> obtenerListadoSalas()
        {
            clsMyConnection conexion = new clsMyConnection();
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            List<clsSala> listadoSalas = new List<clsSala>();
            SqlDataReader reader;
            clsSala sala;
            try
            {
                sqlConnection = conexion.getConnection();
                command.CommandText = "SELECT * FROM Usuario AS U INNER JOIN Sala AS S ON U.Nick = S.Nick";
                command.Connection = sqlConnection;
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        sala = new clsSala();
                        sala.Nick = (String)reader["Nick"];
                        sala.Email = (String)reader["Email"];
                        sala.Nombre = (String)reader["Nombre"];
                        if (reader["Imagen"] != System.DBNull.Value)
                        {
                            sala.Imagen = (String)reader["Imagen"];
                        }
                        sala.Localidad = (String)reader["Localidad"];
                        sala.Direccion = (String)reader["Direccion"];
                        sala.Provincia = (String)reader["Provincia"];
                        listadoSalas.Add(sala);
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
            return listadoSalas;
        }
    }
}
