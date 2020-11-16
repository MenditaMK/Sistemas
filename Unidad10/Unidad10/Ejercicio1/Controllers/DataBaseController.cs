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

            connection.ConnectionString = "server = jaquintero.database.windows.net; database = jaquintero; uid = prueba; pwd = Mitesoro1.";
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