using CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDPersonas_DAL.Conexion;
using System.Globalization;

namespace CRUDPersonas_DAL.Handlers
{
    public class clsGestoraPostDAL
    {
        public static int insertarPost(int id, clsPost post)
        {
            clsMyConnection clsMyConnection = new clsMyConnection();
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlCommand = new SqlCommand();
            DateTime localDate = DateTime.Now;

            sqlCommand.Parameters.AddWithValue("@IDEvento", id);
            sqlCommand.Parameters.AddWithValue("@NickUsuario", post.NickUsuario);
            sqlCommand.Parameters.AddWithValue("@Contenido", post.Contenido);
            sqlCommand.Parameters.AddWithValue("@FechaPost", localDate);  //REALMENTE OBTENGO EL VALOR DE LA FECHA CUANDO LLEGA A ESTE PUNTO DEL CÓDIGO, PORQUE SI LO COJO DESDE LA APP HAY MUCHOS 
                                                                          //PROBLEMAS DEBIDO AL CAMBIO DE REGIONES ENTRE DISTINTOS DISPOSITIVOS, EL PARSEO Y DEMÁS

            sqlCommand.CommandText = "INSERT INTO Post (IDEvento, NickUsuario, Contenido, FechaPost) Values (@IDEvento, @NickUsuario, @Contenido, @FechaPost)";
            try
            {
                sqlConnection = clsMyConnection.getConnection();
                sqlCommand.Connection = sqlConnection;
                int filasAfectadas = sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                clsMyConnection.closeConnection(ref sqlConnection);
            }
            return id;
        }
    }
}
