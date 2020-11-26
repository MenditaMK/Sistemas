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
            //SqlConnection sqlConnection = new SqlConnection();
            //clsMyConnection conexion = new clsMyConnection();

            //try
            //{
            //    sqlConnection = conexion.getConnection();
            //    String query = "INSERT INTO dbo.Personas (Nombre, Apellidos, FechaNacimiento, Foto, Direccion, Telefono, IDDepartamento)" +
            //        "VALUES (@Nombre, @Apellidos, @FechaNacimiento, @Foto, @Direccion, @Telefono, @IDDepartamento)";
            //    SqlCommand command = new SqlCommand(query, sqlConnection);
            //    command.Parameters.AddWithValue("@Nombre", persona.Nombre);
            //    command.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
            //    command.Parameters.AddWithValue("@Foto", persona.Imagen);
            //    command.Parameters.AddWithValue("@Direccion", persona.Direccion);
            //    command.Parameters.AddWithValue("@Telefono", persona.Telefono);
            //    command.Parameters.AddWithValue("@IDDepartamento", persona.IdDepartamento);
            //    command.ExecuteNonQuery();
            //}
            //catch (SqlException e)
            //{
            //    throw e;
            //}
            //finally
            //{
            //    conexion.closeConnection(ref sqlConnection);
            //}
            clsMyConnection clsMyConnection = new clsMyConnection();
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlCommand = new SqlCommand();

            int numeroFilasAfectadas = 0;

            sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar).Value = persona.Nombre;
            sqlCommand.Parameters.Add("@Apellidos", System.Data.SqlDbType.NVarChar).Value = persona.Apellidos == null ? (Object)DBNull.Value : persona.Apellidos;
            sqlCommand.Parameters.Add("@FechaNacimiento", System.Data.SqlDbType.Date).Value = persona.FechaNacimiento == new DateTime() ? (Object)DBNull.Value : persona.FechaNacimiento;
            sqlCommand.Parameters.Add("@Foto", System.Data.SqlDbType.VarBinary).Value = persona.Imagen == null ? (Object)DBNull.Value : persona.Imagen;
            sqlCommand.Parameters.Add("@Direccion", System.Data.SqlDbType.NVarChar).Value = persona.Direccion == null ? (Object)DBNull.Value : persona.Direccion;
            sqlCommand.Parameters.Add("@Telefono", System.Data.SqlDbType.NVarChar).Value = persona.Telefono == null ? (Object)DBNull.Value : persona.Telefono;
            sqlCommand.Parameters.Add("@IDDepartamento", System.Data.SqlDbType.Int).Value = persona.IdDepartamento == 0 ? (Object)DBNull.Value : persona.IdDepartamento;

            sqlCommand.CommandText = "INSERT INTO Personas (Nombre, Apellidos, FechaNacimiento, Foto, Direccion, Telefono, IDDepartamento)" +
                " Values (@Nombre, @Apellidos, @FechaNacimiento, @Foto, @Direccion, @Telefono, @IDDepartamento)";
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

        public static void actualizarPersona(clsPersona persona) {
            SqlConnection sqlConnection = new SqlConnection();
            clsMyConnection conexion = new clsMyConnection();
            SqlCommand command = new SqlCommand();
            command.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = persona.Id;
            command.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar).Value = persona.Nombre;
            command.Parameters.Add("@Apellidos", System.Data.SqlDbType.NVarChar).Value = persona.Apellidos == null ? (Object)DBNull.Value : persona.Apellidos;
            command.Parameters.Add("@FechaNacimiento", System.Data.SqlDbType.Date).Value = persona.FechaNacimiento == new DateTime() ? (Object)DBNull.Value : persona.FechaNacimiento;
            command.Parameters.Add("@Foto", System.Data.SqlDbType.VarBinary).Value = persona.Imagen == null ? (Object)DBNull.Value : persona.Imagen;
            command.Parameters.Add("@Direccion", System.Data.SqlDbType.NVarChar).Value = persona.Direccion == null ? (Object)DBNull.Value : persona.Direccion;
            command.Parameters.Add("@Telefono", System.Data.SqlDbType.NVarChar).Value = persona.Telefono == null ? (Object)DBNull.Value : persona.Telefono;
            command.Parameters.Add("@IDDepartamento", System.Data.SqlDbType.Int).Value = persona.IdDepartamento == 0 ? (Object)DBNull.Value : persona.IdDepartamento;

            command.CommandText = "UPDATE dbo.Personas SET " +
                "Nombre = @Nombre, " +
                "Apellidos = @Apellidos, " +
                "FechaNacimiento = @FechaNacimiento, " +
                "Foto = @Foto, " +
                "Direccion = @Direccion, " +
                "Telefono = @Telefono, " +
                "IDDepartamento = @IDDepartamento " +
                "WHERE ID = @ID";

            try {
                sqlConnection = conexion.getConnection();
                command.Connection = sqlConnection;
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally {
                conexion.closeConnection(ref sqlConnection);
            }
        }
    }
}
