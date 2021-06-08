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
        /// <param name="persona">El id de la persona a eliminar</param>
        /// <returns>El númeror de filas afectadas</returns>
        public static int eliminarPersona(int id)
        {
            int filasAfectadas = 0;
            SqlConnection sqlConnection = new SqlConnection();
            clsMyConnection conexion = new clsMyConnection();

            try
            {
                String query = "DELETE FROM dbo.Personas WHERE ID = @ID";
                sqlConnection = conexion.getConnection();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@ID", id);
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
        /// Este método inserta a una persona en la base de datos
        /// </summary>
        /// <param name="persona">La persona a insertar</param>
        /// <returns>El númeror de filas afectadas</returns>
        public static int insertarPersona(clsPersona persona)
        {
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
            return numeroFilasAfectadas;
        }

        /// <summary>
        /// Este método obtiene a una persona de la base de datos a través de su id
        /// </summary>
        /// <param name="id">El id de la persona</param>
        /// <returns>La persona en cuestión</returns>
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

        /// <summary>
        /// Este método actualiza a una persona de la base de datos
        /// </summary>
        /// <param name="persona">La persona a actualizar</param>
        /// <returns>El númeror de filas afectadas</returns>
        public static int actualizarPersona(clsPersona persona) {
            SqlConnection sqlConnection = new SqlConnection();
            clsMyConnection conexion = new clsMyConnection();
            SqlCommand command = new SqlCommand();
            int filasAfectadas = 0;

            try {
                sqlConnection = conexion.getConnection();
                command.Connection = sqlConnection;
                command.CommandText = "set dateformat dmy";
                command.ExecuteNonQuery();
                command.CommandText = $"UPDATE Personas " +
                                         $"SET Nombre = '{persona.Nombre}' ,Apellidos = '{persona.Apellidos}' ," +
                                         $"FechaNacimiento = '{persona.FechaNacimiento}'," +    //,Foto = {persona.Imagen}  //LA MALDITA FOTO FALLA
                                         $"Direccion = '{persona.Direccion}' ,Telefono = '{persona.Telefono}' ," +
                                         $"IDDepartamento = {persona.IdDepartamento} " +
                                         $"WHERE ID = {persona.Id}";
                filasAfectadas = command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally {
                conexion.closeConnection(ref sqlConnection);
            }
            return filasAfectadas;
        }
    }
}
