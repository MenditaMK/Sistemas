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
        public static void eliminarPersona(clsPersona persona)
        {
            SqlConnection sqlConnection = new SqlConnection();
            clsMyConnection conexion = new clsMyConnection();

            try
            {
                String query = "DELETE FROM dbo.Personas WHERE ID = @ID";
                sqlConnection = conexion.getConnection();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@ID", persona.Id);
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
    }
}
