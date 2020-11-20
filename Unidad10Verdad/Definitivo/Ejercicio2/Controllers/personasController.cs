using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ejercicio2.Models;

namespace Ejercicio2.Controllers
{
    public class personasController : Controller
    {
        // GET: personas
        public ActionResult Index()
        {
            SqlConnection myConnection = new SqlConnection();
            List<clsPersona> listadoPersonas = new List<clsPersona>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lectorSql;
            clsPersona persona;
            myConnection.ConnectionString = "Server = tcp:jaquintero.database.windows.net, 1433; Initial Catalog = jaquintero; User ID = jaquintero; Password = Mitesoro1.; Encrypt = True; TrustServerCertificate = False;" +
                " Connection Timeout = 30;";
            try
            {
                myConnection.Open();
                comando.CommandText = "SELECT * FROM dbo.Personas";
                comando.Connection = myConnection;
                lectorSql = comando.ExecuteReader();

                if (lectorSql.HasRows) {
                    while (lectorSql.Read()) {
                        persona = new clsPersona();
                        persona.ID = (int)lectorSql["ID"];
                        persona.Nombre = (String)lectorSql["Nombre"];
                        persona.Apellidos = (String)lectorSql["Apellidos"];
                        if (lectorSql["FechaNacimiento"] != System.DBNull.Value) {
                            persona.FechaNacimiento = (DateTime)lectorSql["FechaNacimiento"];
                        }
                        if (lectorSql["Foto"] != System.DBNull.Value) {
                            persona.Foto = (byte[])lectorSql["Foto"];
                        }
                        if (lectorSql["Direccion"] != System.DBNull.Value)
                        {
                            persona.Direccion = (String)lectorSql["Direccion"];
                        }
                        if (lectorSql["Telefono"] != System.DBNull.Value)
                        {
                            persona.Telefono = (String)lectorSql["Telefono"];
                        }
                        if (lectorSql["IDDepartamento"] != System.DBNull.Value)
                        {
                            persona.IDDepartamento = (int)lectorSql["IDDepartamento"];
                        }
                            listadoPersonas.Add(persona);
                    }
                }
                lectorSql.Close();
            }
            catch (SqlException exception) {
                ViewBag.ErrorConexion = exception.ToString();
            }
            finally {
                myConnection.Close();
            }
            return View("Index", listadoPersonas);
        }
    }
}