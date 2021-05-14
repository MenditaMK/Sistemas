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
            sqlCommand.Parameters.AddWithValue("@Localidad", sala.Email);
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
    }
}
