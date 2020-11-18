using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace Ejercicio1.Controllers
{
    public class DataBaseController : Controller
    {
        // GET: DataBase
        public ActionResult Index()
        {
     
            return View();
        }

        [HttpPost, ActionName("Index")]
        public ActionResult IndexPost() {
            SqlConnection connection = new SqlConnection();

            connection.ConnectionString = "Server = tcp:jaquintero.database.windows.net, 1433; Initial Catalog = jaquintero; User ID = jaquintero; Password = Mitesoro1.; Encrypt = True; TrustServerCertificate = False;" +
                " Connection Timeout = 30;";
            try
            {
                connection.Open();
                ViewData["ConnectionStatus"] = connection.State.ToString();
            }
            catch (SqlException exception)
            {
                // throw exception;
                //No se lanza excepciones aqui
                ViewData["ConnectionStatus"] = "Error de conexión";
            }
            finally {
                connection.Close();
            }
            return View();
        }
    }
}