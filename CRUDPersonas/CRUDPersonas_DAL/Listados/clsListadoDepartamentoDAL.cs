using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDPersonas_DAL.Conexion;
using CRUDPersonas_Entidades;

namespace CRUDPersonas_DAL.Listados
{
    public class clsListadoDepartamentoDAL
    {
        /// <summary>
        /// Este método obtiene el listado completo de los departamentos de la base de datos
        /// </summary>
        /// <returns>El listado de los departamentos</returns>
        public static List<clsDepartamento> obtenerListadoDepartamentos()
        {
            List<clsDepartamento> listado = new List<clsDepartamento>();
            clsDepartamento departamento;
            clsMyConnection conexion = new clsMyConnection();
            SqlConnection sqlConnection = new SqlConnection();
            SqlDataReader reader;
            SqlCommand command = new SqlCommand();

            try
            {
                sqlConnection = conexion.getConnection();
                command.Connection = sqlConnection;
                command.CommandText = "SELECT * FROM dbo.Departamentos";
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        departamento = new clsDepartamento();
                        departamento.Id = (int)reader["ID"];
                        departamento.Nombre = (String)reader["Nombre"];
                        listado.Add(departamento);
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
            return listado;
        }

        /// <summary>
        /// Este método obtiene el nombre de un departamento a través de su id
        /// </summary>
        /// <param name="id">El id del departamento</param>
        /// <returns>El nombre del departamento</returns>
        public static string obtenerNombreDepartamento(int id)
        {
            String nombreDepartamento = null;
            SqlConnection sqlConnection = new SqlConnection();
            clsMyConnection conexion = new clsMyConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;

            try
            {
                sqlConnection = conexion.getConnection();
                command.Connection = sqlConnection;
                command.CommandText = "SELECT * FROM dbo.Departamentos WHERE ID = " + id;
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        nombreDepartamento = (String)reader["Nombre"];
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
            return nombreDepartamento;
        }
    }
}
