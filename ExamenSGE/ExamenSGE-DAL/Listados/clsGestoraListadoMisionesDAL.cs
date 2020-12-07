using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenSGE_Entidades;
using ExamenSGE_DAL.Connection;

namespace ExamenSGE_DAL.Listados
{
    public class clsGestoraListadoMisionesDAL
    {
        /// <summary>
        /// Este método devuelve un listado con las misiones no completadas
        /// </summary>
        /// <returns>El listado de misiones</returns>
        public static List<clsMisiones> obtenerListadoMisionesNoCompletadas() {
            List<clsMisiones> listadoMisiones = new List<clsMisiones>();
            SqlConnection connection = new SqlConnection();
            clsMyConnection conexion = new clsMyConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            command.CommandText = "SELECT * FROM Misiones WHERE completada = 0";

            try {
                connection = conexion.getConnection();
                command.Connection = connection;
                reader = command.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        clsMisiones mision = new clsMisiones();
                        mision.Id = (int)reader["id"];
                        mision.Nombre = (String)reader["nombre"];
                        mision.Descripcion = (String)reader["descripcion"];
                        mision.Creditos = (int)reader["creditos"];
                        mision.Completada = (bool)reader["completada"];
                        listadoMisiones.Add(mision);
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally {
                conexion.closeConnection(ref connection);
            }
            return listadoMisiones;
        }

        /// <summary>
        /// Este método actualiza las misiones completadas
        /// </summary>
        /// <param name="listadoMisiones">El listado de misiones a actualizar</param>
        /// <returns>El número de misiones actualizadas</returns>
        public static int actualizarListadoMisiones(List<clsMisiones> listadoMisiones) {
            int filasAfectadas = 0;
            SqlConnection connection = new SqlConnection();
            clsMyConnection conexion = new clsMyConnection();
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE Misiones SET completada = @completa WHERE ID = @ID";
            command.Parameters.AddWithValue("@completa", 1);
            try {
                connection = conexion.getConnection();
                command.Connection = connection;
                foreach (clsMisiones mision in listadoMisiones) {
                    command.Parameters.AddWithValue("@ID", mision.Id);
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally {
                conexion.closeConnection(ref connection);
            }
            return filasAfectadas;
        }
    }
}
