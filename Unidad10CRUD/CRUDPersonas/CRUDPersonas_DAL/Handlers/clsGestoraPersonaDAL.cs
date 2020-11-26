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
    public class clsGestoraPersonaDAL
    {
        /// <summary>
        /// Esta función elimina de la base de datos a una persona
        /// </summary>
        /// <param name="persona">La persona a eliminar</param>
        /// <returns></returns>
        public static void eliminarPersona(int id)
        {
            SqlConnection sqlConnection = new SqlConnection();
            clsMyConnection conexion = new clsMyConnection();

            try
            {
                String query = "DELETE FROM dbo.Personas WHERE ID = @ID";
                sqlConnection = conexion.getConnection();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@ID", id);
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                conexion.closeConnection(ref sqlConnection);
            }
        }

        public static void insertarPersona(clsPersona persona)
        {
            SqlConnection sqlConnection = new SqlConnection();
            clsMyConnection conexion = new clsMyConnection();

            try
            {
                sqlConnection = conexion.getConnection();
                String query = "INSERT INTO dbo.Personas (Nombre, Apellidos, FechaNacimiento, Foto, Direccion, Telefono, IDDepartamento)" +
                    "VALUES (@Nombre, @Apellidos, @FechaNacimiento, @Foto, @Direccion, @Telefono, @IDDepartamento)";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                command.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
                command.Parameters.AddWithValue("@Foto", persona.Imagen);
                command.Parameters.AddWithValue("@Direccion", persona.Direccion);
                command.Parameters.AddWithValue("@Telefono", persona.Telefono);
                command.Parameters.AddWithValue("@IDDepartamento", persona.IdDepartamento);
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                conexion.closeConnection(ref sqlConnection);
            }
        }

        public static clsPersona obtenerPersonaPorID(int id) {
            SqlConnection sqlConnection = new SqlConnection();
            clsMyConnection conexion = new clsMyConnection();
            SqlDataReader reader;
            clsPersona persona = null;
            SqlCommand command = new SqlCommand();

            try {
                sqlConnection = conexion.getConnection();
                command.CommandText = "SELECT * FROM dbo.Personas WHERE ID = " + id;
                command.Connection = sqlConnection;
                reader = command.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        persona = new clsPersona();
                        persona.Id = (int)reader["ID"];
                        persona.Nombre = (String)reader["Nombre"];
                        if (reader["Apellidos"] != System.DBNull.Value)
                        {
                            persona.Apellidos = (String)reader["Apellidos"];
                        }
                        if (reader["FechaNacimiento"] != System.DBNull.Value)
                        {
                            persona.FechaNacimiento = (DateTime)reader["FechaNacimiento"];
                        }
                        if (reader["Foto"] != System.DBNull.Value)
                        {
                            persona.Imagen = (byte[])reader["Foto"];
                        }
                        if (reader["Direccion"] != System.DBNull.Value)
                        {
                            persona.Direccion = (String)reader["Direccion"];
                        }
                        if (reader["Telefono"] != System.DBNull.Value)
                        {
                            persona.Telefono = (String)reader["Telefono"];
                        }
                        if (reader["IDDepartamento"] != System.DBNull.Value)
                        {
                            persona.IdDepartamento = (int)reader["IDDepartamento"];
                        }
                    }
                }
                reader.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally {
                conexion.closeConnection(ref sqlConnection);
            }
            return persona;
        }
    }
}
