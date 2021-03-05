using ExamenSGEDAL.Conexion;
using ExamenSGEEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSGEDAL
{
    public class clsGestoraDAL
    {
        /// <summary>
        /// Este método actualiza los creditos de una mision de la base de datos
        /// </summary>
        /// <param name="mision">La misión a actualizar</param>
        /// <returns>El númeror de filas afectadas</returns>
        public static int actualizarMision(clsMisiones mision)
        {
            SqlConnection sqlConnection = new SqlConnection();
            clsMyConnection conexion = new clsMyConnection();
            SqlCommand command = new SqlCommand();
            int filasAfectadas = 0;

            try
            {
                sqlConnection = conexion.getConnection();
                command.Connection = sqlConnection;
                command.Parameters.AddWithValue("@Creditos", mision.Creditos);
                command.Parameters.AddWithValue("@ID", mision.Id);
                command.CommandText = "UPDATE Misiones SET creditos = @Creditos WHERE id = @ID";
                filasAfectadas = command.ExecuteNonQuery();
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
        /// Esta funcion obtiene de la base de datos el listado completo de misiones no completadas
        /// </summary>
        /// <returns>El listado completo de las misiones no completadas de la base de datos</returns>
        public static List<clsMisiones>obtenerListadoMisiones()
        {
            clsMyConnection conexion = new clsMyConnection();
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            List<clsMisiones> listadoMisiones = new List<clsMisiones>();
            SqlDataReader reader;
            clsMisiones mision;

            try
            {
                sqlConnection = conexion.getConnection();
                command.CommandText = "SELECT * FROM Misiones WHERE completada = 0";
                command.Connection = sqlConnection;
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        mision = new clsMisiones();
                        mision.Id = (int)reader["id"];
                        mision.Nombre = (String)reader["nombre"];
                        mision.Descripcion = (String)reader["descripcion"];
                        mision.Creditos = (int)reader["creditos"];
                        if (reader["completada"] != System.DBNull.Value)
                        {
                            mision.Completada = (bool)reader["completada"];
                        }
                        listadoMisiones.Add(mision);
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
            return listadoMisiones;
        }
    }
}
